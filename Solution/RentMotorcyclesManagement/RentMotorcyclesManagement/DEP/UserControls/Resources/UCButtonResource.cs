using System.Drawing;
using System.Windows.Forms;

namespace RentMotorcyclesManagement
{
    public partial class UCButtonResource : UserControl
    {
        public UCButtonResource()
        {
            InitializeComponent();
            this.Focus();
        }

        public Image ButtonImage
        {
            get { return this.pctBoxButton.Image; }
            set
            { 
                this.pctBoxButton.Image = value;
            }
        }

        public string ButtonTitle
        {
            get { return this.lblButtonMessage.Text; }
            set
            {
                this.lblButtonMessage.Text = value;
            }
        }

        public void UCButtonResource_Click(object sender, System.EventArgs e) { }

        public void tblLayoutButtons_Click(object sender, System.EventArgs e)
        {
            this.Click += UCButtonResource_Click;
        }

        public void pctBoxButton_Click(object sender, System.EventArgs e) { }
    }
}
