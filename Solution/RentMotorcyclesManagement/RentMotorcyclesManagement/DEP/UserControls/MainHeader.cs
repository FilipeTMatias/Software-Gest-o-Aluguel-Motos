using System;
using System.Windows.Forms;

namespace RentMotorcyclesManagement
{
    public partial class MainHeader : UserControl
    {
        public bool ButtonSelected 
        {
            get { return buttonSelected; }
        }

        public string MenuSelected
        {
            get { return menuSelected; }
        }

        private bool buttonSelected = false;
        private string menuSelected;

        public MainHeader()
        {
            InitializeComponent();
            LoadComponents();
        }

        private void LoadComponents()
        {
            this.btnRegDriversAndPlans.pctBoxButton.Click += ButtonHeader_Click;
            this.btnRegVehicles.pctBoxButton.Click += ButtonHeader_Click;
        }

        public void LoadingHeaderByProfile(int idProfile)
        {
            btnRegVehicles.Enabled = idProfile == (int)GeneralSystemRoutines.PROFILE_TYPES.ADMIN;
        }

        public void ButtonHeader_Click(object sender, EventArgs e)
        {
            var buttonClicked = sender as PictureBox;

            var componentClicked = buttonClicked.Parent as TableLayoutPanel;

            var controlClicked = componentClicked.Parent;

            if (buttonClicked.Enabled)
            {
                buttonSelected = true;

                menuSelected = controlClicked.Name;  
            }
        }

        public void ResetMenuSelected()
        {
            buttonSelected = false;
        }
    }
}
