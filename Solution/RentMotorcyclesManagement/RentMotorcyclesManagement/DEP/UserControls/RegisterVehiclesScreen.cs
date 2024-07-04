using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RentMotorcyclesManagement
{
    public partial class RegisterVehiclesScreen : UCScreenResource
    {
        public MainRegistrationScreen mainRegScreen;
        public RegistrationVehiclesScreen registrationVehicleScreen;

        public RegisterVehiclesScreen()
        {
            InitializeComponent();
        }

        public RegisterVehiclesScreen(NpgsqlConnection dbConnection, string screenTitleName, object dataSourceGrid) : base(dbConnection, screenTitleName, dataSourceGrid) { }

        protected override void LoadParameters()
        {
            dtGridScreen.Columns["Status"].Visible = false;
        }

        public override void Process()
        {
            switch (mainFooter.ButtonPressed)
            {
                case "btnInsert":
                    {
                        mainRegScreen = new MainRegistrationScreen(dbConnection);
                        registrationVehicleScreen = new RegistrationVehiclesScreen(dbConnection, "btnInsert");
                        registrationVehicleScreen.txtBoxID.Focus();
                        registrationVehicleScreen.Refresh();

                        mainRegScreen.panelMainRegisterScreen.Dock = DockStyle.Fill;
                        mainRegScreen.panelMainRegisterScreen.Controls.Add(registrationVehicleScreen);
                        mainRegScreen.StartPosition = FormStartPosition.CenterScreen;
                        mainRegScreen.Show();

                        break;
                    }
                case "btnUpdate":
                    {
                        var vehicleData = dtGridScreen.SelectedRows[0];
                        mainRegScreen = new MainRegistrationScreen(dbConnection);
                        registrationVehicleScreen = new RegistrationVehiclesScreen(dbConnection, "btnUpdate");

                        registrationVehicleScreen.LoadingScreenToUpdate(vehicleData);
                        registrationVehicleScreen.txtBoxID.Enabled = false;
                        registrationVehicleScreen.txtBoxPlate.Focus();
                        registrationVehicleScreen.Refresh();

                        mainRegScreen.panelMainRegisterScreen.Dock = DockStyle.Fill;
                        mainRegScreen.panelMainRegisterScreen.Controls.Add(registrationVehicleScreen);
                        mainRegScreen.StartPosition = FormStartPosition.CenterScreen;
                        mainRegScreen.Show();

                        break;
                    }
                case "btnRemove":
                    {
                        var vehicleData = dtGridScreen.SelectedRows[0];
                        RemoveVehicleRegister(vehicleData);

                        break;
                    }
                case "btnSearch":
                    {
                        SearchingByVehiclePlate();

                        break;
                    }
                default:
                    break;
            }

            mainFooter.ResetParameters();

            if (registrationVehicleScreen != null && registrationVehicleScreen.ProcessConcluded)
            {
                registrationVehicleScreen.ResetParameters();
                mainRegScreen.Close();
                RefreshDataGridView();
            }
        }

        private void RemoveVehicleRegister(DataGridViewRow vehicleData)
        {
            mainFooter.ResetParameters();

            ValidationReturnPersistence validationReturn = new ValidationReturnPersistence();

            if (!GetVehicleStatusAbleToDelete(Convert.ToInt32(vehicleData.Cells["Status"].Value)))
            {
                validationReturn.Result = false;
                validationReturn.Message = "O cadastro não pode ser excluído pois a moto não está com o status disponível.";
                validationReturn.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.ERROR;
            }
            else
            {
                int idVehicle = Convert.ToInt32(vehicleData.Cells["Id"].Value);

                GeneralDatabaseRoutines.BeginTran(dbConnection);

                if (GeneralDatabaseRoutines.DeleteVehicleRegister(dbConnection, idVehicle))
                {
                    GeneralDatabaseRoutines.Commit(dbConnection);

                    validationReturn.Result = true;
                    validationReturn.Message = "Cadastro removido com sucesso!";
                    validationReturn.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.SUCCESS;
                }
                else
                {
                    GeneralDatabaseRoutines.Rollback(dbConnection);

                    validationReturn.Result = true;
                    validationReturn.Message = "Erro ao remover o cadastro.";
                    validationReturn.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.SUCCESS;
                }

                RefreshDataGridView();
            }

            GeneralSystemRoutines.ShowSystemMessage(validationReturn);
        }

        private void SearchingByVehiclePlate()
        {
            mainFooter.ResetParameters();

            RefreshDataGridView(mainFooter.txtBoxSearch.Text.ToUpper());
        }

        protected void RefreshDataGridView(string vehiclePlate = "")
        {
            if (string.IsNullOrEmpty(vehiclePlate))
                this.dtGridScreen.DataSource = GeneralDatabaseRoutines.GetRegVehicles(dbConnection);
            else
                this.dtGridScreen.DataSource = GeneralDatabaseRoutines.GetRegVehicles(dbConnection, vehiclePlate);

            dtGridScreen.Columns["YearVehicle"].HeaderText = "Ano Moto";
            dtGridScreen.Columns["ModelVehicle"].HeaderText = "Modelo Moto";
            dtGridScreen.Columns["PlateVehicle"].HeaderText = "Placa Moto";
            dtGridScreen.Columns["VehicleStatus"].HeaderText = "Status";
        }

        private bool GetVehicleStatusAbleToDelete(int statusVehicle)
        {
            List<RegVehicleStatusPersistence> regVehicleStatus = GeneralDatabaseRoutines.GetVehicleStatus(dbConnection);

            if (regVehicleStatus.Where(x => x.Id == statusVehicle).FirstOrDefault().Available)
                return true;
            else
                return false;
        }
    }
}
