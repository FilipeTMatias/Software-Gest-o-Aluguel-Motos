namespace RentMotorcyclesManagement
{
    partial class MainHeader
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
        public void InitializeComponent()
        {
            this.tblLayoutHeader = new System.Windows.Forms.TableLayoutPanel();
            this.btnRegVehicles = new RentMotorcyclesManagement.UCButtonResource();
            this.btnRegDriversAndPlans = new RentMotorcyclesManagement.UCButtonResource();
            this.tblLayoutHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblLayoutHeader
            // 
            this.tblLayoutHeader.ColumnCount = 4;
            this.tblLayoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tblLayoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblLayoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tblLayoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tblLayoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutHeader.Controls.Add(this.btnRegVehicles, 0, 0);
            this.tblLayoutHeader.Controls.Add(this.btnRegDriversAndPlans, 2, 0);
            this.tblLayoutHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutHeader.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutHeader.Name = "tblLayoutHeader";
            this.tblLayoutHeader.RowCount = 1;
            this.tblLayoutHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutHeader.Size = new System.Drawing.Size(1236, 118);
            this.tblLayoutHeader.TabIndex = 0;
            // 
            // btnRegVehicles
            // 
            this.btnRegVehicles.ButtonImage = global::RentMotorcyclesManagement.Properties.Resources.RegVehiclesButton;
            this.btnRegVehicles.ButtonTitle = "Cadastro de Motos";
            this.btnRegVehicles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRegVehicles.Location = new System.Drawing.Point(3, 3);
            this.btnRegVehicles.Name = "btnRegVehicles";
            this.btnRegVehicles.Size = new System.Drawing.Size(179, 112);
            this.btnRegVehicles.TabIndex = 1;
            // 
            // btnRegDriversAndPlans
            // 
            this.btnRegDriversAndPlans.ButtonImage = global::RentMotorcyclesManagement.Properties.Resources.RegDriversButton;
            this.btnRegDriversAndPlans.ButtonTitle = "Seleção de Planos";
            this.btnRegDriversAndPlans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRegDriversAndPlans.Location = new System.Drawing.Point(311, 3);
            this.btnRegDriversAndPlans.Name = "btnRegDriversAndPlans";
            this.btnRegDriversAndPlans.Size = new System.Drawing.Size(179, 112);
            this.btnRegDriversAndPlans.TabIndex = 2;
            // 
            // MainHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblLayoutHeader);
            this.Name = "MainHeader";
            this.Size = new System.Drawing.Size(1236, 118);
            this.tblLayoutHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tblLayoutHeader;
        public UCButtonResource btnRegVehicles;
        public UCButtonResource btnRegDriversAndPlans;
    }
}
