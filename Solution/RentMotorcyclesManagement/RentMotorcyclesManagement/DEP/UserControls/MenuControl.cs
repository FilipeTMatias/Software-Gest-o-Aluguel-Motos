using Npgsql;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RentMotorcyclesManagement
{
    public partial class MenuControl : UserControl
    {
        public RegisterVehiclesScreen regVehiclesScreen = null;
        public RegisterDriversAndPlansScreen regDriversAndPlansScreen = null;

        private NpgsqlConnection dbConnection;
        private int profileType;        

        public MenuControl(NpgsqlConnection dbConnection, int profileType)
        {
            InitializeComponent();
            LoadParameters(dbConnection, profileType);
        }

        private void LoadParameters(NpgsqlConnection dbConnection, int profileType)
        {
            this.dbConnection = dbConnection;
            this.profileType = profileType;

            this.mainHeader1.LoadingHeaderByProfile(profileType);
            this.Size = Screen.FromControl(this).WorkingArea.Size;
        }

        public void LoadSelectedScreen(string menuSelectedName, RegUsersPersistence userLoggedData)
        {
            switch (menuSelectedName)
            {
                case "btnRegVehicles":
                    {
                        if (this.panelMenu.Controls.ContainsKey(menuSelectedName))
                        {
                            regVehiclesScreen.Show();
                            break;
                        }
                        else
                        {
                            List<RegVehiclesPersistence> listRegVehicles = GeneralDatabaseRoutines.GetRegVehicles(dbConnection);

                            regVehiclesScreen = new RegisterVehiclesScreen(dbConnection, "Cadastro de Motos", listRegVehicles);
                            panelMenu.Dock = DockStyle.Fill;
                            panelMenu.Controls.Add(regVehiclesScreen);
                            HideCurrentControl();
                            regVehiclesScreen.Show();
                        }

                        break;
                    }
                case "btnRegDriversAndPlans":
                    {
                        if (this.panelMenu.Controls.ContainsKey(menuSelectedName))
                        {
                            regDriversAndPlansScreen.Show();
                            break;
                        }
                        else
                        {
                            List<RegDriversAndPlansPersistence> listRegDriverAndPlans = GeneralDatabaseRoutines.GetRegDriversAndPlans(dbConnection, userLoggedData);

                            regDriversAndPlansScreen = new RegisterDriversAndPlansScreen(dbConnection, "Seleção de Planos" , listRegDriverAndPlans, profileType);
                            regDriversAndPlansScreen.LoadUserLoggedData(userLoggedData);
                            panelMenu.Dock = DockStyle.Fill;
                            panelMenu.Controls.Add(regDriversAndPlansScreen);
                            HideCurrentControl();
                            regDriversAndPlansScreen.Show();
                        }

                        break;
                    }
            }

            mainHeader1.ResetMenuSelected();
        }

        public void Process(string menuSelectedName)
        {
            switch (menuSelectedName)
            {
                case "btnRegVehicles":
                    {
                        regVehiclesScreen.Process();
                        break;
                    }
                case "btnRegDriversAndPlans":
                    {
                        regDriversAndPlansScreen.Process();
                        break;
                    }
            }
        }

        private void HideCurrentControl()
        {
            foreach (Control control in panelMenu.Controls)
            {
                if (control.Visible)
                    control.Hide();
            }
        }
    }
}
