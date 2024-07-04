using System.Windows.Forms;

namespace RentMotorcyclesManagement
{
    public partial class MainFooter : UserControl
    {
        public string ButtonPressed
        {
            get { return buttonPressed; }
        }

        private string buttonPressed = string.Empty;

        public MainFooter()
        {
            InitializeComponent();
        }

        public void SelectActiveButtons(bool activeBtnInsert, bool activeBtnUpdate, bool activeBtnRemove, bool activebtnSearch, bool activeTxtBoxSearch)
        {
            btnInsert.Visible = activeBtnInsert;
            btnUpdate.Visible = activeBtnUpdate;
            btnRemove.Visible = activeBtnRemove;
            btnSearch.Visible = activebtnSearch;
            txtBoxSearch.Visible = activeTxtBoxSearch;
        }

        private void button_Click(object sender, System.EventArgs e)
        {
            buttonPressed = (sender as Button).Name;
        }

        public void ResetParameters()
        {
            buttonPressed = string.Empty;
        }
    }
}
