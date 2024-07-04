using Npgsql;
using System;
using System.Windows.Forms;

namespace RentMotorcyclesManagement
{
    public partial class LoginControl : UserControl
    {
        public bool LoginSuccess
        {
            get { return loginSuccess; }
        }

        public bool NewUserPressed
        {
            get { return newUserPressed; }
        }

        public RegUsersPersistence UserData
        {
            get { return userData; }
        }

        private bool loginSuccess = false;
        private bool newUserPressed = false;
        private RegUsersPersistence userData;

        private NpgsqlConnection dbConnection;

        public LoginControl(NpgsqlConnection dbConnection)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
            LoadParameters();
        }

        private void LoadParameters()
        {
            cBoxProfile.DataSource = GeneralDatabaseRoutines.GetProfiles(dbConnection);
            cBoxProfile.DisplayMember = "Profile";
            cBoxProfile.ValueMember = "Id";
            cBoxProfile.SelectedIndex = 1;
            cBoxProfile.DropDownStyle = ComboBoxStyle.DropDownList;
            txtBoxUser.Focus();
        }

        public void ResetNewUserPressed()
        {
            newUserPressed = false;
        }

        public void ResetLoginSuccess()
        {
            loginSuccess = false;
        }

        private void button_Click(object sender, System.EventArgs e)
        {
            string button = (sender as Button).Name;

            switch (button)
            {
                case "btnEnter":
                    {
                        ValidateFields();
                        userData = ValidateLogin();

                        if (userData != null && GeneralSystemRoutines.VerifyPassword(txtPassword.Text, userData.Password))
                        {
                            loginSuccess = true;
                        }
                        else
                        {
                            loginSuccess = false;

                            ValidationReturnPersistence validationReturn = new ValidationReturnPersistence()
                            {
                                Result = false,
                                Message = "Usuário não encontrado. Verifique o perfil e a senha.",
                                IconLevel = GeneralSystemRoutines.ICON_MESSAGE.ERROR
                            };

                            GeneralSystemRoutines.ShowSystemMessage(validationReturn);
                        }

                        break;
                    }
                case "btnNewUser":
                    {
                        newUserPressed = true;

                        break;
                    }
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtBoxUser.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                return false;
            else
                return true;
        }

        private RegUsersPersistence ValidateLogin()
        {
            RegUsersPersistence regUsersPersistence = GeneralDatabaseRoutines.ValidateLogin(dbConnection, txtBoxUser.Text, Convert.ToInt32(cBoxProfile.SelectedValue));

            return regUsersPersistence;
        }
    }
}
