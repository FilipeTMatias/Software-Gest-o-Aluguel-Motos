using System.Windows.Forms;

namespace RentMotorcyclesManagement
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.panelMainControl = new System.Windows.Forms.Panel();
            this.timerStateMachine = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // panelMainControl
            // 
            this.panelMainControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainControl.Location = new System.Drawing.Point(0, 0);
            this.panelMainControl.Name = "panelMainControl";
            this.panelMainControl.Size = new System.Drawing.Size(180, 134);
            this.panelMainControl.TabIndex = 0;
            // 
            // timerStateMachine
            // 
            this.timerStateMachine.Tick += new System.EventHandler(this.Process);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 134);
            this.Controls.Add(this.panelMainControl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMainControl;
        private System.Windows.Forms.Timer timerStateMachine;
    }
}

