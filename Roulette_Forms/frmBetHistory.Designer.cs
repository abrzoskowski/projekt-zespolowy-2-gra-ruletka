namespace Roulette_Forms
{
    partial class frmBetHistory
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
            this.lsvBetHistory = new System.Windows.Forms.ListView();
            this.clhBetType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhBetPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsvBetHistory
            // 
            this.lsvBetHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhBetType,
            this.clhBetPrice});
            this.lsvBetHistory.Location = new System.Drawing.Point(0, 0);
            this.lsvBetHistory.Name = "lsvBetHistory";
            this.lsvBetHistory.Size = new System.Drawing.Size(168, 167);
            this.lsvBetHistory.TabIndex = 0;
            this.lsvBetHistory.UseCompatibleStateImageBehavior = false;
            this.lsvBetHistory.View = System.Windows.Forms.View.Details;
            // 
            // clhBetType
            // 
            this.clhBetType.Text = "Typ zakładu";
            this.clhBetType.Width = 75;
            // 
            // clhBetPrice
            // 
            this.clhBetPrice.Text = "Koszt zakładu";
            this.clhBetPrice.Width = 82;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(49, 173);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Wyczyść";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmBetHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(168, 196);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lsvBetHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBetHistory";
            this.Text = "Historia zakładów";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBetHistory_FormClosed);
            this.Load += new System.EventHandler(this.frmBetHistory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvBetHistory;
        private System.Windows.Forms.ColumnHeader clhBetType;
        private System.Windows.Forms.ColumnHeader clhBetPrice;
        private System.Windows.Forms.Button btnClear;

    }
}