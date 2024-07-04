using Npgsql;
using System;
using System.Windows.Forms;

namespace RentMotorcyclesManagement
{
    public partial class UCRegistrationScreen : UserControl
    {
        protected NpgsqlConnection dbConnection;
        protected string btnEvent;

        public UCRegistrationScreen()
        {
            InitializeComponent();
        }

        public UCRegistrationScreen(NpgsqlConnection dbConnection)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
            LoadParameters();
        }

        public UCRegistrationScreen(NpgsqlConnection dbConnection, string btnEvent)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
            this.btnEvent = btnEvent;
            LoadParameters();
        }

        protected virtual void LoadParameters() { }

        protected virtual ValidationReturnPersistence ValidateFields() 
        {
            throw new NotImplementedException();
        }
    }
}
