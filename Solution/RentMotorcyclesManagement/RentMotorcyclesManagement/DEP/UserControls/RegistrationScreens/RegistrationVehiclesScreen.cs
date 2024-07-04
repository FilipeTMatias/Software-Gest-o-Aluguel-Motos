using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RentMotorcyclesManagement
{
    public partial class RegistrationVehiclesScreen : UCRegistrationScreen
    {
        public bool ProcessConcluded
        {
            get { return processConcluded; }
        }

        private bool processConcluded = false;

        public RegistrationVehiclesScreen()
        {
            InitializeComponent();
        }

        public RegistrationVehiclesScreen(NpgsqlConnection dbConnection, string btnEvent) : base(dbConnection, btnEvent) { }

        protected override void LoadParameters()
        {
            cBoxStatus.DataSource = GeneralDatabaseRoutines.GetVehicleStatus(dbConnection);
            cBoxStatus.DisplayMember = "VehicleStatus";
            cBoxStatus.ValueMember = "Id";
            cBoxStatus.SelectedIndex = 0;
            cBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void LoadingScreenToUpdate(DataGridViewRow dataGridView)
        {
            ButtonControl buttonControl = GeneralSystemRoutines.GetDataGridViewRowValues(dataGridView, "Id");
            txtBoxID.Text = buttonControl.TextValue;
            txtBoxID.Enabled = buttonControl.Enabled;

            buttonControl = GeneralSystemRoutines.GetDataGridViewRowValues(dataGridView, "ModelVehicle");
            txtBoxModel.Text = buttonControl.TextValue;
            txtBoxModel.Enabled = buttonControl.Enabled;

            buttonControl = GeneralSystemRoutines.GetDataGridViewRowValues(dataGridView, "YearVehicle");
            txtBoxYear.Text = buttonControl.TextValue;
            txtBoxYear.Enabled = buttonControl.Enabled;

            buttonControl = GeneralSystemRoutines.GetDataGridViewRowValues(dataGridView, "PlateVehicle", true);
            txtBoxPlate.Text = buttonControl.TextValue;
            txtBoxID.Enabled = buttonControl.Enabled;

            LoadParameters();
            cBoxStatus.SelectedValue = ((List<RegVehicleStatusPersistence>)cBoxStatus.DataSource).Where(x => x.Id == Convert.ToInt32(dataGridView.Cells["Status"].Value)).FirstOrDefault().Id;

            txtBoxID.Refresh();
        }

        private void button_Click(object sender, EventArgs e)
        {
            ValidationReturnPersistence validationResult = ValidateFields();

            switch (btnEvent)
            {
                case "btnInsert":
                    {
                        if (validationResult.Result)
                        {
                            GeneralDatabaseRoutines.BeginTran(dbConnection);

                            if (GeneralDatabaseRoutines.CreateNewVehicle(dbConnection, Convert.ToInt32(txtBoxID.Text), txtBoxModel.Text.ToUpper(), txtBoxPlate.Text.ToUpper(), Convert.ToInt32(txtBoxYear.Text), Convert.ToInt32(cBoxStatus.SelectedValue)))
                            {
                                GeneralDatabaseRoutines.Commit(dbConnection);

                                validationResult.Result = true;
                                validationResult.Message = "Moto cadastrada com sucesso!";
                                validationResult.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.SUCCESS;

                                GeneralSystemRoutines.ShowSystemMessage(validationResult);
                                processConcluded = true;
                            }
                            else
                            {
                                GeneralDatabaseRoutines.Rollback(dbConnection);

                                validationResult.Result = true;
                                validationResult.Message = "Erro ao cadastrar a moto.";
                                validationResult.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.SUCCESS;

                                GeneralSystemRoutines.ShowSystemMessage(validationResult);
                                processConcluded = false;
                            }
                        }
                        else
                        {
                            GeneralSystemRoutines.ShowSystemMessage(validationResult);
                            processConcluded = false;
                        }

                        break;
                    }
                case "btnUpdate":
                    {
                        if (validationResult.Result)
                        {
                            GeneralDatabaseRoutines.BeginTran(dbConnection);

                            if (GeneralDatabaseRoutines.UpdateVehicle(dbConnection, Convert.ToInt32(txtBoxID.Text), txtBoxPlate.Text.ToUpper(), Convert.ToInt32(cBoxStatus.SelectedValue)))
                            {
                                GeneralDatabaseRoutines.Commit(dbConnection);

                                validationResult.Result = true;
                                validationResult.Message = "Cadastro atualizado com sucesso!";
                                validationResult.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.SUCCESS;

                                GeneralSystemRoutines.ShowSystemMessage(validationResult);
                                processConcluded = true;
                            }
                            else
                            {
                                GeneralDatabaseRoutines.Rollback(dbConnection);

                                validationResult.Result = true;
                                validationResult.Message = "Erro ao atualizar o cadastro.";
                                validationResult.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.SUCCESS;

                                GeneralSystemRoutines.ShowSystemMessage(validationResult);
                                processConcluded = false;
                            }
                        }
                        else
                        {
                            GeneralSystemRoutines.ShowSystemMessage(validationResult);
                            processConcluded = false;
                        }

                        break;
                    }
            }
        }

        protected override ValidationReturnPersistence ValidateFields()
        {
            ValidationReturnPersistence validationResult = new ValidationReturnPersistence();

            if (string.IsNullOrWhiteSpace(txtBoxID.Text) || string.IsNullOrWhiteSpace(txtBoxModel.Text) ||
                string.IsNullOrWhiteSpace(txtBoxPlate.Text) || string.IsNullOrWhiteSpace(txtBoxYear.Text))
            {
                validationResult.Result = false;
                validationResult.Message = "Preencha todos os campos.";
                validationResult.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.WARNING;

                return validationResult;
            }
            else if (!GeneralSystemRoutines.ValidateVehicleID(txtBoxID.Text))
            {
                validationResult.Result = false;
                validationResult.Message = "O campo ID está incorreto (apenas números e com até 7 caracteres).";
                validationResult.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.WARNING;

                return validationResult;
            }
            else if (!GeneralSystemRoutines.ValidateVehiclePlate(txtBoxPlate.Text))
            {
                validationResult.Result = false;
                validationResult.Message = "O campo Placa está incorreto.";
                validationResult.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.WARNING;
            }
            else if (!GeneralSystemRoutines.ValidateVehicleYear(txtBoxYear.Text))
            {
                validationResult.Result = false;
                validationResult.Message = "O campo Ano está incorreto.";
                validationResult.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.WARNING;
            }
            else
                validationResult.Result = true;

            return validationResult;
        }

        public void ResetParameters()
        {
            processConcluded = false;
        }
    }
}
