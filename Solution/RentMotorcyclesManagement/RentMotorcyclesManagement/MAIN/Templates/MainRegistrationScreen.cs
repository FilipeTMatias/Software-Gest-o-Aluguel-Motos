using Npgsql;
using System.Windows.Forms;

namespace RentMotorcyclesManagement
{
    public partial class MainRegistrationScreen : Form
    {
        public RegistrationDriverUsersScreen registerNewUserScreen;

        private NpgsqlConnection dbConnection;

        public MainRegistrationScreen(NpgsqlConnection dbConnection)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
        }
    }
}
