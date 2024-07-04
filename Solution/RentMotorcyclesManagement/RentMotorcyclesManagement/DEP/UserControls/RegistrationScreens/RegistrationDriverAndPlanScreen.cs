using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RentMotorcyclesManagement
{
    public partial class RegistrationDriverAndPlanScreen : UCRegistrationScreen
    {
        public bool NewPlanActived
        {
            get { return newPlanActived; }
        }

        private bool newPlanActived = false;

        public RegistrationDriverAndPlanScreen()
        {
            InitializeComponent();
        }

        public RegistrationDriverAndPlanScreen(NpgsqlConnection dbConnection) : base(dbConnection) { }

        protected override void LoadParameters()
        {
            cBoxPlans.DataSource = GeneralDatabaseRoutines.GetPlanPrices(dbConnection);
            cBoxPlans.DisplayMember = "Description";
            cBoxPlans.ValueMember = "TotalDays";
            cBoxPlans.SelectedIndex = 0;
            cBoxPlans.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxPlans.Focus();
        }

        public void LoadingScreenToInsert(RegDriversAndPlansPersistence dataSource)
        {
            txtBoxUserId.Text = dataSource.Id.ToString();
            txtBoxName.Text = dataSource.Name;
            mTxtBoxRegisterDate.Text = dataSource.RegisterDate.ToString();
            mTxtBoxStartPlanDate.Text = dataSource.RegisterDate.AddDays(1).ToString();
            cBoxPlans_SelectedValueChanged(null, null);
        }

        public void ResetParameters()
        {
            newPlanActived = false;
        }

        private void button_Click(object sender, EventArgs e)
        {
            string button = (sender as Button).Name;

            switch (button)
            {
                case "btnEnter":
                    {
                        ValidationReturnPersistence validationResult = ValidateFields();

                        if (validationResult.Result)
                        {
                            int totalDays = Convert.ToInt32(cBoxPlans.SelectedValue);
                            double planPrice = ((List<RegPlanPricesPersistence>)cBoxPlans.DataSource).Where(x => totalDays == x.TotalDays).FirstOrDefault().Price;

                            double totalPlanValue = Math.Round(totalDays * planPrice, 2);

                            GeneralDatabaseRoutines.BeginTran(dbConnection);

                            if (GeneralDatabaseRoutines.InsertPlanSelected(dbConnection, Convert.ToInt32(txtBoxUserId.Text),
                                ((List<RegPlanPricesPersistence>)cBoxPlans.DataSource).Where(x => x.TotalDays == Convert.ToInt32(cBoxPlans.SelectedValue)).FirstOrDefault().Id,
                                Convert.ToDateTime(mTxtBoxStartPlanDate.Text), Convert.ToDateTime(mTxtBoxEndPlanDate.Text), Convert.ToDateTime(dtPExpectedReturnDate.Text),
                                Convert.ToInt32(cBoxPlans.SelectedValue) * ((List<RegPlanPricesPersistence>)cBoxPlans.DataSource).Where(x => x.TotalDays == Convert.ToInt32(cBoxPlans.SelectedValue)).FirstOrDefault().Price,
                                Convert.ToDouble(txtTotalTax.Text), Convert.ToDouble(txtTotalAmount.Text)))
                            {
                                GeneralDatabaseRoutines.Commit(dbConnection);

                                validationResult.Result = true;
                                validationResult.Message = "Plano selecionado com sucesso.";
                                validationResult.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.SUCCESS;

                                newPlanActived = true;
                            }
                            else
                            {
                                GeneralDatabaseRoutines.Rollback(dbConnection);

                                validationResult.Result = false;
                                validationResult.Message = "Erro ao registrar plano selecionado.";
                                validationResult.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.ERROR;

                                newPlanActived = false;
                            }
                        }
                        else
                        {
                            newPlanActived = false;
                        }

                        GeneralSystemRoutines.ShowSystemMessage(validationResult);

                        break;
                    }
            }
        }

        protected override ValidationReturnPersistence ValidateFields()
        {
            ValidationReturnPersistence validationResult = new ValidationReturnPersistence();

            if (string.IsNullOrWhiteSpace(dtPExpectedReturnDate.Text))
            {
                validationResult.Result = false;
                validationResult.Message = "Preencha a Data Previsão Retorno.";
                validationResult.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.WARNING;

                return validationResult;
            }
            else if (Convert.ToDateTime(dtPExpectedReturnDate.Text).Date < DateTime.Now.Date)
            {
                validationResult.Result = false;
                validationResult.Message = "O campo Data Previsão Retorno está incorreto.";
                validationResult.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.WARNING;

                return validationResult;
            }
            else
                validationResult.Result = true;

            return validationResult;
        }

        private void cBoxPlans_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(mTxtBoxStartPlanDate.Text.Replace("/",""))) 
                mTxtBoxEndPlanDate.Text = Convert.ToDateTime(mTxtBoxStartPlanDate.Text).AddDays(Convert.ToInt64(cBoxPlans.SelectedValue)).ToString();

            if (!string.IsNullOrWhiteSpace(dtPExpectedReturnDate.Text))
                dtPExpectedReturnDate_ValueChanged(null, null);
        }

        private void dtPExpectedReturnDate_ValueChanged(object sender, EventArgs e)
        {
            int totalPlanDays = Convert.ToInt32(cBoxPlans.SelectedValue);
            double price = ((List<RegPlanPricesPersistence>)cBoxPlans.DataSource).Where(x => x.TotalDays == Convert.ToInt32(cBoxPlans.SelectedValue)).FirstOrDefault().Price;

            txtTotalTax.Text = GeneralSystemRoutines.CalculateTaxValues(totalPlanDays, price, Convert.ToDateTime(mTxtBoxEndPlanDate.Text), Convert.ToDateTime(dtPExpectedReturnDate.Text));

            txtTotalAmount.Text = Math.Round(Convert.ToDouble(txtTotalTax.Text) + (price * totalPlanDays), 2).ToString("0.00");
        }
    }
}
