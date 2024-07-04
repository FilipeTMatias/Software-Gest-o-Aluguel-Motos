using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;

namespace RentMotorcyclesManagement
{
    public class GeneralDatabaseRoutines
    {
        public static void OpenConnection(NpgsqlConnection dbConnection)
        {
            dbConnection.Open();
        }

        public static void CloseConnection(NpgsqlConnection dbConnection)
        {
            dbConnection.Close();
        }

        public static void TransactionCommands(NpgsqlConnection dbConnection, string query)
        {
            NpgsqlCommand cmd = dbConnection.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            cmd.Dispose();
        }

        public static void BeginTran(NpgsqlConnection dbConnection)
        {
            TransactionCommands(dbConnection, "BEGIN");
        }

        public static void Commit(NpgsqlConnection dbConnection)
        {
            TransactionCommands(dbConnection, "COMMIT");
        }

        public static void Rollback(NpgsqlConnection dbConnection)
        {
            TransactionCommands(dbConnection, "ROLLBACK");
        }

        public static List<RegUsersProfilesPersistence> GetProfiles(NpgsqlConnection dbConnection)
        {
            string query = "SELECT \"ID\", \"PROFILE\", \"ADMIN\" " +
                            "FROM \"REGUSERSPROFILES\" ORDER BY \"ID\"";

            IEnumerable<RegUsersProfilesPersistence> result = dbConnection.Query<RegUsersProfilesPersistence>(query);

            return (List<RegUsersProfilesPersistence>)result;
        }

        public static List<RegDriverLicenseTypePersistence> GetDriverLicenseTypes(NpgsqlConnection dbConnection)
        {
            string query = "SELECT \"ID\", \"DRIVER_LICENSE_TYPE\" AS DriverLicenseType, \"AVAILABLE\" " +
                            "FROM \"REGDRIVERLICENSETYPE\" ORDER BY \"ID\"";

            IEnumerable<RegDriverLicenseTypePersistence> result = dbConnection.Query<RegDriverLicenseTypePersistence>(query);

            return (List<RegDriverLicenseTypePersistence>)result;
        }

        public static RegUsersPersistence ValidateLogin(NpgsqlConnection dbConnection, string user, int idProfile)
        {
            string query = "SELECT \"ID\", \"USER\", \"NAME\", \"PASSWORD\", \"ID_PROFILE\" AS IdProfile " +
                            "FROM \"REGUSERS\" " +
                            "WHERE \"USER\" = " + GeneralSystemRoutines.ConvertStringInVarchar(user) + " " +
                            "AND \"ID_PROFILE\" = " + idProfile + " " +
                            "LIMIT 1";

            RegUsersPersistence result = dbConnection.QuerySingleOrDefault<RegUsersPersistence>(query);

            return result;
        }

        public static bool CreateNewUser(NpgsqlConnection dbConnection, string cnpj, string userName, DateTime birthday, string driverLicenseNumber,
                                            int idDriverLicenseType, string driverLicenseImage, string password)
        {
            cnpj = GeneralSystemRoutines.ReplaceUnnecessaryCaracters(cnpj);
            driverLicenseNumber = GeneralSystemRoutines.ReplaceUnnecessaryCaracters(driverLicenseNumber);

            bool success = false;

            string query = "INSERT INTO \"REGUSERS\" ( " +
                        "\"USER\", \"NAME\", \"PASSWORD\", \"ID_PROFILE\" ) " +
                        "VALUES ( " +
                        GeneralSystemRoutines.ConvertStringInVarchar(cnpj) + " " +
                        ", " + GeneralSystemRoutines.ConvertStringInVarchar(userName) + " " +
                        ", " + GeneralSystemRoutines.ConvertStringInVarchar(GeneralSystemRoutines.HashPassword(password)) + " " +
                        ", " + (int)GeneralSystemRoutines.PROFILE_TYPES.ENTREGADOR + ") " +
                        "RETURNING \"ID\"";

            NpgsqlCommand cmd = dbConnection.CreateCommand();
            cmd.CommandText = query;

            object result = cmd.ExecuteScalar();

            cmd.Dispose();

            long idReturn;

            if (result != null)
            {
                idReturn = Convert.ToInt32(result);

                query = "INSERT INTO \"REGUSERSDRIVERS\" ( " +
                        "\"ID_USER\", \"CNPJ\", \"BIRTHDAY\", \"DRIVER_LICENSE_NUMBER\", \"DRIVER_LICENSE_TYPE\", \"DRIVER_LICENSE_IMAGE\", \"REGISTER_DATE\" ) " +
                        "VALUES ( " +
                        idReturn + " " +
                        "," + GeneralSystemRoutines.ConvertStringInVarchar(cnpj) + " " +
                        "," + GeneralSystemRoutines.ConvertDateTimeInVarchar(birthday) + " " +
                        "," + GeneralSystemRoutines.ConvertStringInVarchar(driverLicenseNumber) + " " +
                        "," + idDriverLicenseType + " " +
                        "," + GeneralSystemRoutines.ConvertStringInVarchar(driverLicenseImage) + " " +
                        "," + GeneralSystemRoutines.ConvertDateTimeInVarchar(DateTime.Now) + ") ";

                cmd = dbConnection.CreateCommand();
                cmd.CommandText = query;

                cmd.ExecuteNonQuery();

                success = true;
            }

            cmd.Dispose();

            return success;
        }

        public static bool CreateNewVehicle(NpgsqlConnection dbConnection, int vehicleID, string vehicleModel, string vehiclePlate, int vehicleYear, int vehicleStatus)
        {
            vehiclePlate = GeneralSystemRoutines.ReplaceUnnecessaryCaracters(vehiclePlate);

            string query = "INSERT INTO \"REGVEHICLES\" ( " +
                    "\"ID\", \"YEAR_VEHICLE\", \"MODEL_VEHICLE\", \"PLATE_VEHICLE\", \"STATUS\") " +
                    "VALUES ( " +
                    + vehicleID + " " +
                    ", " + vehicleYear + " " +
                    ", " + GeneralSystemRoutines.ConvertStringInVarchar(vehicleModel) + " " +
                    ", " + GeneralSystemRoutines.ConvertStringInVarchar(vehiclePlate) + " " +
                    ", " + vehicleStatus + ") " +
                    "RETURNING \"ID\"";

            NpgsqlCommand cmd = dbConnection.CreateCommand();
            cmd.CommandText = query;
            object result = cmd.ExecuteScalar();

            cmd.Dispose();

            if (result != null)
                return true;
            else
                return false;
        }

        public static List<RegVehiclesPersistence> GetRegVehicles(NpgsqlConnection dbConnection)
        {
            string query = "SELECT MOTO.\"ID\", MOTO.\"YEAR_VEHICLE\" AS YearVehicle, MOTO.\"MODEL_VEHICLE\" AS ModelVehicle, MOTO.\"PLATE_VEHICLE\" AS PlateVehicle, MOTO.\"STATUS\",  ST.\"VEHICLE_STATUS\" AS VehicleStatus " +
                            "FROM \"REGVEHICLES\" AS MOTO " +
                            "LEFT JOIN \"REGVEHICLESSTATUS\" AS ST " +
                            "ON MOTO.\"STATUS\" = ST.\"ID\" " +
                            "ORDER BY \"ID\" " +
                            "LIMIT 100 ";

            IEnumerable<RegVehiclesPersistence> result = dbConnection.Query<RegVehiclesPersistence>(query);

            return (List<RegVehiclesPersistence>)result;
        }

        public static List<RegVehiclesPersistence> GetRegVehicles(NpgsqlConnection dbConnection, string vehiclePlate)
        {
            string query = "SELECT MOTO.\"ID\", MOTO.\"YEAR_VEHICLE\" AS YearVehicle, MOTO.\"MODEL_VEHICLE\" AS ModelVehicle, MOTO.\"PLATE_VEHICLE\" AS PlateVehicle, MOTO.\"STATUS\",  ST.\"VEHICLE_STATUS\" AS VehicleStatus " +
                            "FROM \"REGVEHICLES\" AS MOTO " +
                            "LEFT JOIN \"REGVEHICLESSTATUS\" AS ST " +
                            "ON MOTO.\"STATUS\" = ST.\"ID\" " +
                            "WHERE MOTO.\"PLATE_VEHICLE\" LIKE '%" + vehiclePlate + "%' " +
                            "ORDER BY \"ID\" " +
                            "LIMIT 100 ";

            IEnumerable<RegVehiclesPersistence> result = dbConnection.Query<RegVehiclesPersistence>(query);

            return (List<RegVehiclesPersistence>)result;
        }

        public static List<RegDriversAndPlansPersistence> GetRegDriversAndPlans(NpgsqlConnection dbConnection, RegUsersPersistence userLoggedData)
        {
            string query = "SELECT USERS.\"ID\", USERS.\"NAME\", DRI.\"REGISTER_DATE\" AS RegisterDate, PLAN.\"DESCRIPTION\" AS PlanDescription, TCK.\"PLAN_START_DATE\" AS PlanStartDate, " +
                        "TCK.\"PLAN_END_DATE\" AS PlanEndDate, TCK.\"EXPECTED_RETURN_DATE\" AS ExpectedReturnDate, TCK.\"PLAN_PRICE\" AS PlanPrice, PLAN.\"TOTAL_DAYS\" AS TotalDays, " +
                        "PLAN.\"PRICE\" , TCK.\"PLAN_TAX\" AS PlanTax, TCK.\"TOTAL_AMOUNT\" AS TotalAmount " +
                        "FROM \"REGUSERS\" AS USERS " +
                        "LEFT JOIN \"REGUSERSDRIVERS\" AS DRI " +
                        "ON USERS.\"ID\" = DRI.\"ID_USER\"" +
                        "LEFT JOIN \"REGUSERSDRIVERSTICKET\" AS TCK " +
                        "ON DRI.\"ID_USER\" = TCK.\"ID_USER\" " +
                        "LEFT JOIN \"REGPLANPRICES\" AS PLAN " +
                        "ON TCK.\"ID_PLAN\" = PLAN.\"ID\" ";

            if (userLoggedData.IdProfile != (int)GeneralSystemRoutines.PROFILE_TYPES.ADMIN)
                query += " WHERE USERS.\"ID\" = " + userLoggedData.Id;
            else
                query += " WHERE USERS.\"ID_PROFILE\" = " + (int)GeneralSystemRoutines.PROFILE_TYPES.ENTREGADOR + " ORDER BY USERS.\"ID\"";

            IEnumerable<RegDriversAndPlansPersistence> result = dbConnection.Query<RegDriversAndPlansPersistence>(query);

            return (List<RegDriversAndPlansPersistence>)result;
        }

        public static List<RegVehicleStatusPersistence> GetVehicleStatus(NpgsqlConnection dbConnection)
        {
            string query = "SELECT \"ID\", \"VEHICLE_STATUS\" AS VehicleStatus, \"AVAILABLE\" " +
                            "FROM \"REGVEHICLESSTATUS\" ";

            IEnumerable<RegVehicleStatusPersistence> result = dbConnection.Query<RegVehicleStatusPersistence>(query);

            return (List<RegVehicleStatusPersistence>)result;
        }

        public static List<RegPlanPricesPersistence> GetPlanPrices(NpgsqlConnection dbConnection)
        {
            string query = "SELECT \"ID\", \"DESCRIPTION\", \"TOTAL_DAYS\" AS TotalDays, \"PRICE\" " +
                            "FROM \"REGPLANPRICES\" ";

            IEnumerable<RegPlanPricesPersistence> result = dbConnection.Query<RegPlanPricesPersistence>(query);

            return (List<RegPlanPricesPersistence>)result;
        }

        public static bool DeleteVehicleRegister(NpgsqlConnection dbConnection, int idVehicle)
        {
            try
            {
                string query = "DELETE FROM \"REGVEHICLES\" " +
                                "WHERE \"ID\" = " + idVehicle + " ";

                NpgsqlCommand cmd = dbConnection.CreateCommand();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
            catch 
            {
                return false;
            }

            return true;
        }

        public static bool UpdateVehicle(NpgsqlConnection dbConnection, int idVehicle, string vehiclePlate, int vehicleStatus)
        {
            string query = "UPDATE \"REGVEHICLES\" SET \"PLATE_VEHICLE\" = " + GeneralSystemRoutines.ConvertStringInVarchar(vehiclePlate) + ", \"STATUS\" = " + vehicleStatus + " " +
                    "WHERE \"ID\" = " + idVehicle + " " +
                    "RETURNING \"ID\"";

            NpgsqlCommand cmd = dbConnection.CreateCommand();
            cmd.CommandText = query;
            object result = cmd.ExecuteScalar();

            cmd.Dispose();

            if (result != null)
                return true;
            else
                return false;
        }

        public static bool InsertPlanSelected(NpgsqlConnection dbConnection, int userId,  int idPlan, DateTime planStartDate, DateTime endPlanDate, DateTime expectedReturnDate, double planPrice, double totalTax, double totalAmount)
        {
            string query = "INSERT INTO \"REGUSERSDRIVERSTICKET\" ( " +
                            "\"ID_USER\", \"ID_PLAN\", \"PLAN_START_DATE\", \"PLAN_END_DATE\", \"EXPECTED_RETURN_DATE\", \"PLAN_PRICE\", \"PLAN_TAX\", \"TOTAL_AMOUNT\" ) " +
                            "VALUES ( " +
                            + userId + " " +
                            ", " + idPlan + " " +
                            ", " + GeneralSystemRoutines.ConvertDateTimeInVarchar(planStartDate) + " " +
                            ", " + GeneralSystemRoutines.ConvertDateTimeInVarchar(endPlanDate) + " " +
                            ", " + GeneralSystemRoutines.ConvertDateTimeInVarchar(expectedReturnDate) + " " +
                            ", " + GeneralSystemRoutines.ConvertStringInVarchar(planPrice.ToString()) + " " +
                            ", " + GeneralSystemRoutines.ConvertStringInVarchar(totalTax.ToString()) + " " +
                            ", " + GeneralSystemRoutines.ConvertStringInVarchar(totalAmount.ToString()) + ") " +
                            "RETURNING \"ID\"";

            NpgsqlCommand cmd = dbConnection.CreateCommand();
            cmd.CommandText = query;
            object result = cmd.ExecuteScalar();

            cmd.Dispose();

            if (result != null)
                return true;
            else
                return false;
        }
    }
}
