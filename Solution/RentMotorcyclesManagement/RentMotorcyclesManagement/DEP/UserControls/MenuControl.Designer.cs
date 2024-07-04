using System.Windows.Forms;

namespace RentMotorcyclesManagement
{
    partial class MenuControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMainMenu = new System.Windows.Forms.Panel();
            this.tblLayoutMenu = new System.Windows.Forms.TableLayoutPanel();
            this.mainHeader1 = new RentMotorcyclesManagement.MainHeader();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelMainMenu.SuspendLayout();
            this.tblLayoutMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMainMenu
            // 
            this.panelMainMenu.Controls.Add(this.tblLayoutMenu);
            this.panelMainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMainMenu.Name = "panelMainMenu";
            this.panelMainMenu.Size = new System.Drawing.Size(1172, 834);
            this.panelMainMenu.TabIndex = 0;
            // 
            // tblLayoutMenu
            // 
            this.tblLayoutMenu.ColumnCount = 3;
            this.tblLayoutMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tblLayoutMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tblLayoutMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tblLayoutMenu.Controls.Add(this.mainHeader1, 1, 0);
            this.tblLayoutMenu.Controls.Add(this.panelHeader, 0, 0);
            this.tblLayoutMenu.Controls.Add(this.panelMenu, 1, 1);
            this.tblLayoutMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutMenu.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutMenu.Name = "tblLayoutMenu";
            this.tblLayoutMenu.RowCount = 2;
            this.tblLayoutMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblLayoutMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tblLayoutMenu.Size = new System.Drawing.Size(1172, 834);
            this.tblLayoutMenu.TabIndex = 0;
            // 
            // mainHeader1
            // 
            this.mainHeader1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainHeader1.Location = new System.Drawing.Point(61, 3);
            this.mainHeader1.Name = "mainHeader1";
            this.mainHeader1.Size = new System.Drawing.Size(1048, 160);
            this.mainHeader1.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHeader.Location = new System.Drawing.Point(3, 3);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(52, 160);
            this.panelHeader.TabIndex = 0;
            // 
            // panelMenu
            // 
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(61, 169);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1048, 662);
            this.panelMenu.TabIndex = 1;
            // 
            // MenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMainMenu);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MenuControl";
            this.Size = new System.Drawing.Size(1172, 834);
            this.panelMainMenu.ResumeLayout(false);
            this.tblLayoutMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panelMainMenu;
        public System.Windows.Forms.TableLayoutPanel tblLayoutMenu;
        public System.Windows.Forms.Panel panelHeader;
        public MainHeader mainHeader1;
        public System.Windows.Forms.Panel panelMenu;
    }
}
