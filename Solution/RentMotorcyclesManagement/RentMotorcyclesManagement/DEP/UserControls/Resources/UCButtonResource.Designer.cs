namespace RentMotorcyclesManagement
{
    partial class UCButtonResource
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        protected System.ComponentModel.IContainer components = null;

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
            this.tblLayoutButtons = new System.Windows.Forms.TableLayoutPanel();
            this.pctBoxButton = new System.Windows.Forms.PictureBox();
            this.lblButtonMessage = new System.Windows.Forms.Label();
            this.tblLayoutButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxButton)).BeginInit();
            this.SuspendLayout();
            // 
            // tblLayoutButtons
            // 
            this.tblLayoutButtons.ColumnCount = 1;
            this.tblLayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutButtons.Controls.Add(this.pctBoxButton, 0, 0);
            this.tblLayoutButtons.Controls.Add(this.lblButtonMessage, 0, 1);
            this.tblLayoutButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutButtons.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutButtons.Name = "tblLayoutButtons";
            this.tblLayoutButtons.RowCount = 2;
            this.tblLayoutButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tblLayoutButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblLayoutButtons.Size = new System.Drawing.Size(150, 150);
            this.tblLayoutButtons.TabIndex = 0;
            this.tblLayoutButtons.Click += new System.EventHandler(this.tblLayoutButtons_Click);
            // 
            // pctBoxButton
            // 
            this.pctBoxButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctBoxButton.Location = new System.Drawing.Point(3, 3);
            this.pctBoxButton.Name = "pctBoxButton";
            this.pctBoxButton.Size = new System.Drawing.Size(144, 106);
            this.pctBoxButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctBoxButton.TabIndex = 0;
            this.pctBoxButton.TabStop = false;
            this.pctBoxButton.Click += new System.EventHandler(this.pctBoxButton_Click);
            // 
            // lblButtonMessage
            // 
            this.lblButtonMessage.AutoSize = true;
            this.lblButtonMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblButtonMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblButtonMessage.Location = new System.Drawing.Point(3, 112);
            this.lblButtonMessage.Name = "lblButtonMessage";
            this.lblButtonMessage.Size = new System.Drawing.Size(144, 38);
            this.lblButtonMessage.TabIndex = 1;
            this.lblButtonMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCButtonResource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblLayoutButtons);
            this.Name = "UCButtonResource";
            this.Click += new System.EventHandler(this.UCButtonResource_Click);
            this.tblLayoutButtons.ResumeLayout(false);
            this.tblLayoutButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tblLayoutButtons;
        public System.Windows.Forms.PictureBox pctBoxButton;
        public System.Windows.Forms.Label lblButtonMessage;
    }
}
