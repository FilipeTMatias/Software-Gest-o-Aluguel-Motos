using Npgsql;
using System.Windows.Forms;
using static RentMotorcyclesManagement.GeneralSystemRoutines;

namespace RentMotorcyclesManagement
{
    public partial class MainForm : Form
    {
        public MACHINE_STEPS machineCycle = MACHINE_STEPS.INITIALIZING;
        private LoginControl loginControl = null;
        private MenuControl menuControl = null;
        private MainRegistrationScreen mainRegisterScreen = null;
        private RegUsersPersistence userLoggedData = null;

        NpgsqlConnection dbConnection;

        public MainForm()
        {
            InitializeComponent();
            LoadParameters();
        }

        private void LoadParameters()
        {
            dbConnection = new NpgsqlConnection("Host=localhost;Port=5432;Database=dbRentVehiclesManagement;User Id=postgres;Password=postgresAdmin;");
            GeneralDatabaseRoutines.OpenConnection(dbConnection);

            loginControl = new LoginControl(dbConnection);
            panelMainControl.Dock = DockStyle.Fill;
            panelMainControl.Controls.Add(loginControl);
            this.Size = new System.Drawing.Size(360, 400);

            timerStateMachine.Interval = 100;
            timerStateMachine.Enabled = true;
        }

        public void Process(object sender, System.EventArgs e)
        {
            switch (machineCycle)
            {
                case MACHINE_STEPS.INITIALIZING:
                    {
                        loginControl.Show();

                        machineCycle = MACHINE_STEPS.WAITING_LOGIN_ACTION;

                        break;
                    }
                case MACHINE_STEPS.WAITING_LOGIN_ACTION:
                    {
                        if (loginControl.LoginSuccess)
                        {
                            machineCycle = MACHINE_STEPS.AFTER_LOGGED;
                        }
                        else if (loginControl.NewUserPressed)
                        {
                            mainRegisterScreen = new MainRegistrationScreen(dbConnection);
                            mainRegisterScreen.StartPosition = FormStartPosition.CenterScreen;

                            mainRegisterScreen.registerNewUserScreen = new RegistrationDriverUsersScreen(dbConnection);
                            mainRegisterScreen.panelMainRegisterScreen.Dock = DockStyle.Fill;
                            mainRegisterScreen.panelMainRegisterScreen.Controls.Add(mainRegisterScreen.registerNewUserScreen);
                            
                            mainRegisterScreen.Show();
                            this.Hide();

                            loginControl.ResetNewUserPressed();

                            machineCycle = MACHINE_STEPS.REGISTERING_NEW_USER;
                        }

                        break;
                    }
                case MACHINE_STEPS.REGISTERING_NEW_USER:
                    {
                        if (mainRegisterScreen.registerNewUserScreen.NewUserCreated)
                        {
                            this.Show();
                            mainRegisterScreen.Close();

                            mainRegisterScreen.registerNewUserScreen.ResetNewUserCreated();

                            machineCycle = MACHINE_STEPS.WAITING_LOGIN_ACTION;
                        }

                        break;
                    }
                case MACHINE_STEPS.AFTER_LOGGED:
                    {
                        userLoggedData = loginControl.UserData;

                        menuControl = new MenuControl(dbConnection, userLoggedData.IdProfile);
                        panelMainControl.Dock = DockStyle.Fill;
                        panelMainControl.Controls.Add(menuControl);
                        this.WindowState = FormWindowState.Maximized;
                        loginControl.Hide();
                        menuControl.Show();

                        loginControl.ResetLoginSuccess();

                        machineCycle = MACHINE_STEPS.WAITING_ACTION;

                        break;
                    }
                case MACHINE_STEPS.WAITING_ACTION:
                    {
                        if (menuControl.mainHeader1.ButtonSelected)
                        {
                            menuControl.LoadSelectedScreen(menuControl.mainHeader1.MenuSelected, userLoggedData);
                        }
                        else
                        {
                            menuControl.Process(menuControl.mainHeader1.MenuSelected);
                        }

                        break;
                    }
                case MACHINE_STEPS.PROCESSING_ACTION:
                    {
                        break;
                    }
                default:
                    break;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralDatabaseRoutines.CloseConnection(dbConnection);
        }
    }
}
