using System.Windows.Forms;

namespace RentMotorcyclesManagement
{
    partial class MainRegistrationScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMainRegisterScreen = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelMainRegisterScreen
            // 
            this.panelMainRegisterScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainRegisterScreen.Location = new System.Drawing.Point(0, 0);
            this.panelMainRegisterScreen.Name = "panelMainRegisterScreen";
            this.panelMainRegisterScreen.Size = new System.Drawing.Size(662, 411);
            this.panelMainRegisterScreen.TabIndex = 0;
            // 
            // MainRegistrationScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 411);
            this.Controls.Add(this.panelMainRegisterScreen);
            this.Location = new System.Drawing.Rectangle(0, 0, 1366, 728).Location;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainRegistrationScreen";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panelMainRegisterScreen;
    }
}