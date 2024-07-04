using System.Windows.Forms;

namespace RentMotorcyclesManagement
{
    partial class UCScreenResource
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
            this.panelScreen = new System.Windows.Forms.Panel();
            this.tblLayoutScreen = new System.Windows.Forms.TableLayoutPanel();
            this.lblScreenTitle = new System.Windows.Forms.Label();
            this.dtGridScreen = new System.Windows.Forms.DataGridView();
            this.mainFooter = new RentMotorcyclesManagement.MainFooter();
            this.panelScreen.SuspendLayout();
            this.tblLayoutScreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // panelScreen
            // 
            this.panelScreen.Controls.Add(this.tblLayoutScreen);
            this.panelScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScreen.Location = new System.Drawing.Point(0, 0);
            this.panelScreen.Name = "panelScreen";
            this.panelScreen.Size = new System.Drawing.Size(1166, 559);
            this.panelScreen.TabIndex = 0;
            // 
            // tblLayoutScreen
            // 
            this.tblLayoutScreen.ColumnCount = 1;
            this.tblLayoutScreen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutScreen.Controls.Add(this.lblScreenTitle, 0, 0);
            this.tblLayoutScreen.Controls.Add(this.dtGridScreen, 0, 1);
            this.tblLayoutScreen.Controls.Add(this.mainFooter, 0, 2);
            this.tblLayoutScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutScreen.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutScreen.Name = "tblLayoutScreen";
            this.tblLayoutScreen.RowCount = 3;
            this.tblLayoutScreen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tblLayoutScreen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tblLayoutScreen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tblLayoutScreen.Size = new System.Drawing.Size(1166, 559);
            this.tblLayoutScreen.TabIndex = 0;
            // 
            // lblScreenTitle
            // 
            this.lblScreenTitle.AutoSize = true;
            this.lblScreenTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScreenTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScreenTitle.Location = new System.Drawing.Point(3, 0);
            this.lblScreenTitle.Name = "lblScreenTitle";
            this.lblScreenTitle.Size = new System.Drawing.Size(1160, 27);
            this.lblScreenTitle.TabIndex = 1;
            this.lblScreenTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtGridScreen
            // 
            this.dtGridScreen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGridScreen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGridScreen.Location = new System.Drawing.Point(3, 30);
            this.dtGridScreen.MultiSelect = false;
            this.dtGridScreen.Name = "dtGridScreen";
            this.dtGridScreen.ReadOnly = true;
            this.dtGridScreen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridScreen.Size = new System.Drawing.Size(1160, 441);
            this.dtGridScreen.TabIndex = 0;
            // 
            // mainFooter
            // 
            this.mainFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainFooter.Location = new System.Drawing.Point(3, 477);
            this.mainFooter.Name = "mainFooter";
            this.mainFooter.Size = new System.Drawing.Size(1160, 79);
            this.mainFooter.TabIndex = 2;
            // 
            // UCScreenResource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelScreen);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UCScreenResource";
            this.Size = new System.Drawing.Size(1166, 559);
            this.panelScreen.ResumeLayout(false);
            this.tblLayoutScreen.ResumeLayout(false);
            this.tblLayoutScreen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panelScreen;
        protected System.Windows.Forms.TableLayoutPanel tblLayoutScreen;
        protected System.Windows.Forms.DataGridView dtGridScreen;
        protected System.Windows.Forms.Label lblScreenTitle;
        public MainFooter mainFooter;
    }
}
