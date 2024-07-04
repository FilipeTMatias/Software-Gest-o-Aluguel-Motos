using Npgsql;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using System.Linq;

namespace RentMotorcyclesManagement
{
    public partial class RegistrationDriverUsersScreen : UCRegistrationScreen
    {
        public bool NewUserCreated
        {
            get { return newUserCreated; }
        }

        private bool newUserCreated = false;

        public RegistrationDriverUsersScreen()
        {
            InitializeComponent();
        }

        public RegistrationDriverUsersScreen(NpgsqlConnection dbConnection) : base(dbConnection) { }

        protected override void LoadParameters()
        {
            cBoxDriverLicenseType.DataSource = GeneralDatabaseRoutines.GetDriverLicenseTypes(dbConnection);
            cBoxDriverLicenseType.DisplayMember = "DriverLicenseType";
            cBoxDriverLicenseType.ValueMember = "Id";
            cBoxDriverLicenseType.SelectedIndex = 0;
            cBoxDriverLicenseType.DropDownStyle = ComboBoxStyle.DropDownList;
            mTxtBoxCNPJ.Focus();
        }

        public void ResetNewUserCreated()
        {
            newUserCreated = false;
        }

        private void button_Click(object sender, EventArgs e)
        {
            string button = (sender as Button).Name;

            switch (button)
            {
                case "btnDriverLicenseImage":
                    {
                        DriverLicenseImageProcessing();

                        break;
                    }
                case "btnEnter":
                    {
                        ValidationReturnPersistence validationResult = ValidateFields();

                        if (validationResult.Result)
                        {
                            ValidationReturnPersistence validationStorageImage = GeneralSystemRoutines.StorageDriverLicenseImage(txtBoxDriverLicenseImage.Text);

                            GeneralSystemRoutines.ShowSystemMessage(validationStorageImage);

                            if (validationStorageImage.Result)
                            {
                                GeneralDatabaseRoutines.BeginTran(dbConnection);

                                if (GeneralDatabaseRoutines.CreateNewUser(dbConnection, mTxtBoxCNPJ.Text, txtBoxName.Text.ToUpper(), dtPBirthday.Value, txtBoxDriverLicenseNumber.Text,
                                                cBoxDriverLicenseType.SelectedIndex, txtBoxDriverLicenseImage.Text, txtBoxPassword.Text))
                                {
                                    GeneralDatabaseRoutines.Commit(dbConnection);

                                    validationResult.Result = true;
                                    validationResult.Message = "Usuário cadastrado com sucesso. PERFIL ENTREGADOR!";
                                    validationResult.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.SUCCESS;

                                    GeneralSystemRoutines.ShowSystemMessage(validationResult);

                                    newUserCreated = true;
                                }
                                else
                                {
                                    GeneralDatabaseRoutines.Rollback(dbConnection);

                                    validationResult.Result = false;
                                    validationResult.Message = "Erro ao cadastrar usuário.";
                                    validationResult.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.ERROR;

                                    GeneralSystemRoutines.ShowSystemMessage(validationResult);

                                    newUserCreated = false;
                                }
                            }
                            else
                            {
                                newUserCreated = false;
                            }
                        }
                        else
                        {
                            GeneralSystemRoutines.ShowSystemMessage(validationResult);
                            newUserCreated = false;
                        }

                        break;
                    }
            }
        }

        private void DriverLicenseImageProcessing()
        {
            openFileDialog1.Filter = "Arquivos do tipo imagem *.bmp|*.png";
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Title = "Selecione um arquivo";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                txtBoxDriverLicenseImage.Text = openFileDialog1.FileName;
        }

        protected override ValidationReturnPersistence ValidateFields()
        {
            ValidationReturnPersistence validationResult = new ValidationReturnPersistence();

            if (string.IsNullOrWhiteSpace(mTxtBoxCNPJ.Text) || string.IsNullOrWhiteSpace(txtBoxName.Text) ||
                string.IsNullOrWhiteSpace(txtBoxDriverLicenseImage.Text) || string.IsNullOrWhiteSpace(txtBoxDriverLicenseNumber.Text))
            {
                validationResult.Result = false;
                validationResult.Message = "Preencha todos os campos.";
                validationResult.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.WARNING;

                return validationResult;
            }
            else if (!GeneralSystemRoutines.ValidateCNPJField(mTxtBoxCNPJ.Text))
            {
                validationResult.Result = false;
                validationResult.Message = "O campo CNPJ está incorreto.";
                validationResult.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.WARNING;

                return validationResult;
            }
            else if (DateTime.Now.Year - dtPBirthday.Value.Year < 18)
            {
                validationResult.Result = false;
                validationResult.Message = "Você deve possuir mais de 18 anos para poder se cadastrar.";
                validationResult.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.WARNING;
            }
            else if (!GeneralSystemRoutines.ValidateDriverLicenseNumberField(txtBoxDriverLicenseNumber.Text))
            {
                validationResult.Result = false;
                validationResult.Message = "O campo Número CNH está incorreto.";
                validationResult.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.WARNING;
            }
            else if (Convert.ToInt32(cBoxDriverLicenseType.SelectedValue) != ((List<RegDriverLicenseTypePersistence>)cBoxDriverLicenseType.DataSource).Where(x => x.Available).FirstOrDefault().Id)
            {
                validationResult.Result = false;
                validationResult.Message = "Se a sua CNH não for do tipo A, você não poderá se cadastrar.";
                validationResult.IconLevel = GeneralSystemRoutines.ICON_MESSAGE.WARNING;
            }
            else
                validationResult.Result = true;

            return validationResult;
        }
    }
}
