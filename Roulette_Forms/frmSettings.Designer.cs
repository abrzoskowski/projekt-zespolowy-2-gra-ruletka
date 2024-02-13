namespace Roulette_Forms
{
    partial class frmSettings
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
            this.lblAccountStatus = new System.Windows.Forms.Label();
            this.txbAccountStatus = new System.Windows.Forms.TextBox();
            this.lblZł = new System.Windows.Forms.Label();
            this.btnSetAccountStatus = new System.Windows.Forms.Button();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.txbPlayerName = new System.Windows.Forms.TextBox();
            this.chbSaveBetHistory = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAccountStatus
            // 
            this.lblAccountStatus.AutoSize = true;
            this.lblAccountStatus.Location = new System.Drawing.Point(5, 15);
            this.lblAccountStatus.Name = "lblAccountStatus";
            this.lblAccountStatus.Size = new System.Drawing.Size(62, 13);
            this.lblAccountStatus.TabIndex = 0;
            this.lblAccountStatus.Text = "Stan konta:";
            // 
            // txbAccountStatus
            // 
            this.txbAccountStatus.Location = new System.Drawing.Point(89, 12);
            this.txbAccountStatus.Name = "txbAccountStatus";
            this.txbAccountStatus.Size = new System.Drawing.Size(100, 20);
            this.txbAccountStatus.TabIndex = 1;
            // 
            // lblZł
            // 
            this.lblZł.AutoSize = true;
            this.lblZł.Location = new System.Drawing.Point(195, 15);
            this.lblZł.Name = "lblZł";
            this.lblZł.Size = new System.Drawing.Size(16, 13);
            this.lblZł.TabIndex = 2;
            this.lblZł.Text = "zł";
            // 
            // btnSetAccountStatus
            // 
            this.btnSetAccountStatus.Location = new System.Drawing.Point(217, 10);
            this.btnSetAccountStatus.Name = "btnSetAccountStatus";
            this.btnSetAccountStatus.Size = new System.Drawing.Size(75, 23);
            this.btnSetAccountStatus.TabIndex = 3;
            this.btnSetAccountStatus.Text = "Ustaw";
            this.btnSetAccountStatus.UseVisualStyleBackColor = true;
            this.btnSetAccountStatus.Click += new System.EventHandler(this.btnSetAccountStatus_Click);
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Location = new System.Drawing.Point(5, 41);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(78, 13);
            this.lblPlayerName.TabIndex = 4;
            this.lblPlayerName.Text = "Nazwa gracza:";
            // 
            // txbPlayerName
            // 
            this.txbPlayerName.Location = new System.Drawing.Point(89, 38);
            this.txbPlayerName.Name = "txbPlayerName";
            this.txbPlayerName.Size = new System.Drawing.Size(100, 20);
            this.txbPlayerName.TabIndex = 5;
            // 
            // chbSaveBetHistory
            // 
            this.chbSaveBetHistory.AutoSize = true;
            this.chbSaveBetHistory.Location = new System.Drawing.Point(8, 64);
            this.chbSaveBetHistory.Name = "chbSaveBetHistory";
            this.chbSaveBetHistory.Size = new System.Drawing.Size(146, 17);
            this.chbSaveBetHistory.TabIndex = 6;
            this.chbSaveBetHistory.Text = "Zapisuj historię zakładów";
            this.chbSaveBetHistory.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(114, 87);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Zapisz";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 119);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chbSaveBetHistory);
            this.Controls.Add(this.txbPlayerName);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.btnSetAccountStatus);
            this.Controls.Add(this.lblZł);
            this.Controls.Add(this.txbAccountStatus);
            this.Controls.Add(this.lblAccountStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.Text = "Ustawienia";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSettings_FormClosed);
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAccountStatus;
        private System.Windows.Forms.TextBox txbAccountStatus;
        private System.Windows.Forms.Label lblZł;
        private System.Windows.Forms.Button btnSetAccountStatus;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.TextBox txbPlayerName;
        private System.Windows.Forms.CheckBox chbSaveBetHistory;
        private System.Windows.Forms.Button btnSave;
    }
}