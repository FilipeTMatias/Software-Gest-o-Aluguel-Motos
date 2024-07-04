using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RentMotorcyclesManagement
{
    public partial class RegisterDriversAndPlansScreen : UCScreenResource
    {
        public MainRegistrationScreen mainRegScreen;
        public RegistrationDriverAndPlanScreen registrationDriverAndPlans;
        private RegUsersPersistence userLoggedData;

        public RegisterDriversAndPlansScreen()
        {
            InitializeComponent();
        }

        public RegisterDriversAndPlansScreen(NpgsqlConnection dbConnection, string screenTitleName, object dataSourceGrid, int buttonOptions) : base(dbConnection, screenTitleName, dataSourceGrid, buttonOptions) { }

        protected override void LoadParameters()
        {
            if (profileType == (int)GeneralSystemRoutines.PROFILE_TYPES.ENTREGADOR)
                this.mainFooter.SelectActiveButtons(string.IsNullOrEmpty(((List<RegDriversAndPlansPersistence>)dtGridScreen.DataSource).FirstOrDefault().PlanDescription),
                    false, false, false, false);
            
            RefreshDataGridColumns();
        }

        public void LoadUserLoggedData(RegUsersPersistence userLoggedData)
        {
            this.userLoggedData = userLoggedData;
        }

        public override void Process()
        {
            switch (mainFooter.ButtonPressed)
            {
                case "btnInsert":
                    {
                        mainRegScreen = new MainRegistrationScreen(dbConnection);
                        registrationDriverAndPlans = new RegistrationDriverAndPlanScreen(dbConnection);
                        registrationDriverAndPlans.LoadingScreenToInsert(((List<RegDriversAndPlansPersistence>)dtGridScreen.DataSource).FirstOrDefault());
                        registrationDriverAndPlans.cBoxPlans.Focus();
                        mainRegScreen.panelMainRegisterScreen.Dock = DockStyle.Fill;
                        mainRegScreen.panelMainRegisterScreen.Controls.Add(registrationDriverAndPlans);
                        mainRegScreen.StartPosition = FormStartPosition.CenterScreen;
                        mainRegScreen.Show();

                        break;
                    }
                default:
                    break;
            }

            mainFooter.ResetParameters();

            if (registrationDriverAndPlans != null && registrationDriverAndPlans.NewPlanActived)
            {
                registrationDriverAndPlans.ResetParameters();
                mainRegScreen.Close();
                RefreshDataGridView(userLoggedData);
                
                if (userLoggedData.IdProfile == (int)GeneralSystemRoutines.PROFILE_TYPES.ENTREGADOR)
                    mainFooter.btnInsert.Visible = false;
            }
        }

        private void RefreshDataGridView(RegUsersPersistence userLoggedData)
        {
            this.dtGridScreen.DataSource = GeneralDatabaseRoutines.GetRegDriversAndPlans(dbConnection, userLoggedData);
            RefreshDataGridColumns();
        }

        private void RefreshDataGridColumns()
        {
            dtGridScreen.Columns["Name"].HeaderText = "Nome";
            dtGridScreen.Columns["RegisterDate"].HeaderText = "Data de Cadastro";
            dtGridScreen.Columns["PlanDescription"].HeaderText = "Plano Selecionado";
            dtGridScreen.Columns["PlanStartDate"].HeaderText = "Data Início Plano";
            dtGridScreen.Columns["PlanEndDate"].HeaderText = "Data Encerramento Plano";
            dtGridScreen.Columns["ExpectedReturnDate"].HeaderText = "Data Previsão Devolução";
            dtGridScreen.Columns["PlanPrice"].HeaderText = "Preço Diária";
            dtGridScreen.Columns["PlanTax"].HeaderText = "Taxas Adicionais";
            dtGridScreen.Columns["TotalAmount"].HeaderText = "Valor Total";
        }
    }
}
