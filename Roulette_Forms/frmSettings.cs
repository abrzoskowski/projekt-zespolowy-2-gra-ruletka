using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roulette_Forms
{
    public partial class frmSettings : Form
    {
        public frmMain mainForm;

        public frmSettings()
        {
            InitializeComponent();
        }

        private void ShowAccountStatus()
        {
            txbAccountStatus.Text = Program.accountStatus.ToString("n2");
        }

        private void ShowPlayerName()
        {
            txbPlayerName.Text = Program.playerName;
        }

        private void ShowSaveBetHistory()
        {
            chbSaveBetHistory.Checked = Program.saveBetHistory;
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            ShowAccountStatus();
            ShowPlayerName();
            ShowSaveBetHistory();
        }

        private void frmSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.isSettingsFormOpened = !Program.isSettingsFormOpened;
        }

        private void btnSetAccountStatus_Click(object sender, EventArgs e)
        {
            Program.accountStatus = float.Parse(txbAccountStatus.Text);
            mainForm.ClearBets();
            mainForm.ShowAccountStatus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Program.accountStatus = float.Parse(txbAccountStatus.Text);
            Program.playerName = txbPlayerName.Text;
            Program.saveBetHistory = chbSaveBetHistory.Checked;
            mainForm.ClearBets();
            mainForm.ShowAccountStatus();
            this.Close();
        }
    }
}
