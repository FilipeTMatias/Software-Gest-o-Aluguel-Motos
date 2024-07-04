using System;
using System.IO;
using System.Windows.Forms;

namespace RentMotorcyclesManagement
{
    public static class GeneralSystemRoutines
    {
        public enum MACHINE_STEPS
        {
            INITIALIZING = 1,
            WAITING_LOGIN_ACTION = 2,
            REGISTERING_NEW_USER = 3,
            AFTER_LOGGED = 4,
            WAITING_ACTION = 5,
            PROCESSING_ACTION = 6
        }

        public enum ICON_MESSAGE
        {
            WARNING = 1,
            ERROR = 2,
            SUCCESS = 3
        }

        public enum PROFILE_TYPES
        {
            ADMIN = 1,
            ENTREGADOR = 2
        }

        public static void ShowSystemMessage(ValidationReturnPersistence validationResult)
        {
            if (validationResult.IconLevel == ICON_MESSAGE.ERROR)
            {
                MessageBox.Show(validationResult.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (validationResult.IconLevel == ICON_MESSAGE.WARNING)
            {
                MessageBox.Show(validationResult.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (validationResult.IconLevel == ICON_MESSAGE.SUCCESS)
            {
                MessageBox.Show(validationResult.Message, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static bool ValidateCNPJField(string cnpj)
        {
            string validation = cnpj.Replace(".", "").Replace(",", "").Replace("-", "").Replace("/", "");

            try
            {
                if (validation.Length == 14 && long.TryParse(validation, out long cnpjNumber))
                    return true;
            }
            catch { }

            return false;
        }

        public static bool ValidateDriverLicenseNumberField(string driverLicenseNumber)
        {
            string validation = driverLicenseNumber.Replace(".", "").Replace("-", "");

            try
            {
                if (validation.Length >= 9 && validation.Length <= 11 && long.TryParse(validation, out long driverLicense))
                    return true;
            }
            catch { }

            return false;
        }

        public static bool ValidateVehicleID(string vehicleID)
        {
            try
            {
                if (vehicleID.Length >= 1 && vehicleID.Length < 8 && int.TryParse(vehicleID, out int idNumber))
                    return true;
            }
            catch { }

            return false;
        }

        public static bool ValidateVehiclePlate(string vehiclePlate)
        {
            string validation = vehiclePlate.Replace("-", "");

            try
            {
                if (validation.Length == 7)
                    return true;
            }
            catch { }

            return false;
        }

        public static bool ValidateVehicleYear(string vehicleYear)
        {
            try
            {
                if (vehicleYear.Length == 4 && int.TryParse(vehicleYear, out int idNumber))
                    return true;
            }
            catch { }

            return false;
        }

        public static string ReplaceUnnecessaryCaracters(string validation)
        {
            return validation.Replace(".", "").Replace(",", "").Replace("-", "").Replace("/", "");
        }

        public static string ConvertStringInVarchar(string variable)
        {
            return "\'" + variable + "\'";
        }

        public static string ReplaceDashInDot(string variable)
        {
            return ConvertStringInVarchar(variable).Replace(",", ".");
        }

        public static string ConvertDateTimeInVarchar(DateTime variable)
        {
            return ConvertStringInVarchar(variable.ToString("yyyy-MM-dd"));
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        public static ValidationReturnPersistence StorageDriverLicenseImage(string driverLicenseImage)
        {
            ValidationReturnPersistence result = new ValidationReturnPersistence();

            string picturesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string fileName = Path.GetFileName(driverLicenseImage);
            string destinationFilePath = Path.Combine(picturesFolder, fileName);

            try
            {
                File.Copy(driverLicenseImage, destinationFilePath, true);

                result.Result = true;
                result.Message = $"Imagem da CNH salva com sucesso no diretório: {destinationFilePath}";
                result.IconLevel = ICON_MESSAGE.SUCCESS;
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = $"Falha ao salvar a imagem: {ex.Message}";
                result.IconLevel = ICON_MESSAGE.ERROR;
            }

            return result;
        }

        public static ButtonControl GetDataGridViewRowValues(DataGridViewRow dataGridView, string columnName, bool enabled = false)
        {
            ButtonControl buttonControl = new ButtonControl()
            {
                TextValue = dataGridView.Cells[columnName].Value.ToString(),
                Enabled = enabled
            };

            return buttonControl;
        }

        public static string CalculateTaxValues(int totalPlanDays, double planPrice, DateTime endPlanDate, DateTime expectedReturnDate)
        {
            int daysDifference;
            double taxValue = 0;

            if (endPlanDate > expectedReturnDate)
            {
                daysDifference = Convert.ToInt32((endPlanDate.Date - expectedReturnDate.Date).TotalDays);

                switch (totalPlanDays)
                {
                    case 7:
                        {
                            taxValue = (daysDifference * CalculatePercentage(planPrice, 20));

                            break;
                        }
                    case 15:
                        {
                            taxValue = (daysDifference * CalculatePercentage(planPrice, 40));

                            break;
                        }
                    default:
                        break;
                }
            }
            else if (expectedReturnDate > endPlanDate)
            {
                daysDifference = Convert.ToInt32((expectedReturnDate.Date - endPlanDate.Date).TotalDays);

                taxValue = daysDifference * 50;
            }

            return taxValue.ToString("0.00");
        }

        public static double CalculatePercentage(double number, double percent)
        {
            return number * (percent / 100);
        }
    }
}
