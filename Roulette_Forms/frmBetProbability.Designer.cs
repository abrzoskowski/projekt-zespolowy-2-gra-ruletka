namespace Roulette_Forms
{
    partial class frmBetProbability
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
            this.lsvBetProbability = new System.Windows.Forms.ListView();
            this.clhBetType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhProbability = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lsvBetProbability
            // 
            this.lsvBetProbability.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhBetType,
            this.clhProbability});
            this.lsvBetProbability.Location = new System.Drawing.Point(0, 0);
            this.lsvBetProbability.Name = "lsvBetProbability";
            this.lsvBetProbability.Size = new System.Drawing.Size(257, 131);
            this.lsvBetProbability.TabIndex = 0;
            this.lsvBetProbability.UseCompatibleStateImageBehavior = false;
            this.lsvBetProbability.View = System.Windows.Forms.View.Details;
            // 
            // clhBetType
            // 
            this.clhBetType.Text = "Typ zakładu";
            this.clhBetType.Width = 74;
            // 
            // clhProbability
            // 
            this.clhProbability.Text = "Prawdopodobieństwo";
            this.clhProbability.Width = 116;
            // 
            // frmBetProbability
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 131);
            this.Controls.Add(this.lsvBetProbability);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBetProbability";
            this.Text = "Prawdopodobieństwo trafienia zakładów";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBetProbability_FormClosed);
            this.Load += new System.EventHandler(this.frmBetProbability_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvBetProbability;
        private System.Windows.Forms.ColumnHeader clhBetType;
        private System.Windows.Forms.ColumnHeader clhProbability;
    }
}