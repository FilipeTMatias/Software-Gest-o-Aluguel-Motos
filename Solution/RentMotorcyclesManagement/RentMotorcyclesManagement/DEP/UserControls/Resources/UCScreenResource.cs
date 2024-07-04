using Npgsql;
using System.Windows.Forms;

namespace RentMotorcyclesManagement
{
    public partial class UCScreenResource : UserControl
    {
        protected NpgsqlConnection dbConnection;
        protected int profileType = 0;

        public UCScreenResource()
        {
            InitializeComponent();
        }

        public UCScreenResource(NpgsqlConnection dbConnection, string screenTitleName, object dataSourceGrid)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
            this.lblScreenTitle.Text = screenTitleName;
            this.dtGridScreen.DataSource = dataSourceGrid;
            LoadParameters();
        }

        public UCScreenResource(NpgsqlConnection dbConnection, string screenTitleName, object dataSourceGrid, int buttonOptions)
        {
            profileType = buttonOptions;
            InitializeComponent();
            this.dbConnection = dbConnection;
            this.lblScreenTitle.Text = screenTitleName;
            this.dtGridScreen.DataSource = dataSourceGrid;
            LoadParameters();
        }

        protected virtual void LoadParameters() { }
        public virtual void Process() { }
        protected virtual void RefreshDataGridView() { }
    }
}
