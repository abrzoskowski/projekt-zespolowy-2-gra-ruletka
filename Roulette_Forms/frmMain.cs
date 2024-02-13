using Npgsql;
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
    public partial class frmMain : Form
    {
        private void ShowFields()
        {
            sbyte i = -3;
            foreach (var l in new List<Label> {
                lblNumPrev3,
                lblNumPrev2,
                lblNumPrev1,
                lblNumCur,
                lblNumNext1,
                lblNumNext2,
                lblNumNext3
            })
            {
                WheelField wf = Program.GetField(i);
                l.Text = wf.n.ToString();
                Dictionary<Color, Color> displayColors = new Dictionary<Color, Color> {
                    { Color.Green, Color.DarkGreen },
                    { Color.Red, Color.DarkRed },
                    { Color.Black, Color.Black },
                };
                l.ForeColor = displayColors[wf.c];
                i += 1;
            }
        }

        public void ShowAccountStatus()
        {
            lblAccountStatus.Text = "Stan konta: " + Program.accountStatus.ToString("n2") + " zł";
        }

        private void ShowCurrentBets()
        {
            lblCurrentBets.Text = "Postawione zakłady: " + Program.currentBets.Values.Sum().ToString("n2") + " zł";
        }

        private void AddBet(string id)
        {
            DisableBetButtons();
            if (Program.currentBets.ContainsKey(id))
                Program.currentBets[id] += Program.currentBetPrice;
            else
                Program.currentBets[id] = Program.currentBetPrice;
            UpdateBetPriceButtons();
            ShowCurrentBets();
            if (!btnClear.Enabled)
                btnClear.Enabled = true;
            if (!btnSpin.Enabled)
                btnSpin.Enabled = true;
        }

        public void ClearBets()
        {
            btnSpin.Enabled = false;
            btnClear.Enabled = false;
            Program.currentBets.Clear();
            ShowCurrentBets();
            UpdateBetPriceButtons();
        }

        private void DisableBetButtons()
        {
            foreach (var b in new List<Button> {
                btn1To18, btnOdd, btnRed, btn19To36, btnEven, btnBlack,
                btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9,
                btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19,
                btn20, btn21, btn22, btn23, btn24, btn25, btn26, btn27, btn28, btn29,
                btn30, btn31, btn32, btn33, btn34, btn35, btn36, btnCol1, btnCol2, btnCol3,
                btnRow1, btnRow2, btnRow3, btnRow4, btnRow5, btnRow6,
                btnRow7, btnRow8, btnRow9, btnRow10, btnRow11, btnRow12
            })
                b.Enabled = false;
        }

        private void EnableBetButtons()
        {
            foreach (var b in new List<Button> {
                btn1To18, btnOdd, btnRed, btn19To36, btnEven, btnBlack,
                btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9,
                btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19,
                btn20, btn21, btn22, btn23, btn24, btn25, btn26, btn27, btn28, btn29,
                btn30, btn31, btn32, btn33, btn34, btn35, btn36, btnCol1, btnCol2, btnCol3,
                btnRow1, btnRow2, btnRow3, btnRow4, btnRow5, btnRow6,
                btnRow7, btnRow8, btnRow9, btnRow10, btnRow11, btnRow12
            })
                b.Enabled = true;
        }

        public void UpdateBetPriceButtons()
        {
            foreach (var b in new Dictionary<Button, float> {
                { btn1Gr, 0.01f }, { btn2Gr, 0.02f }, { btn5Gr, 0.05f },
                { btn10Gr, 0.1f }, { btn20Gr, 0.2f }, { btn50Gr, 0.5f },
                { btn1Zł, 1 }, { btn2Zł, 2 }, { btn5Zł, 5 },
                { btn10Zł, 10 }, { btn20Zł, 20 }, { btn50Zł, 50 },
                { btn100Zł, 100 }, { btn200Zł, 200 }, { btn500Zł, 500 }
            })
                if (Program.accountStatus - Program.currentBets.Values.Sum() >= b.Value)
                    b.Key.Enabled = true;
                else
                    b.Key.Enabled = false;
        }

        private void DisableBetPriceButtons()
        {
            foreach (var b in new List<Button> {
                btn1Gr, btn2Gr, btn5Gr, btn10Gr, btn20Gr, btn50Gr,
                btn1Zł, btn2Zł, btn5Zł, btn10Zł, btn20Zł, btn50Zł,
                btn100Zł, btn200Zł, btn500Zł
            })
            {
                b.Enabled = false;
            }
        }

        private void SetCurrentBetPrice(float p)
        {
            Program.currentBetPrice = p;
            if (!btn1To18.Enabled)
                EnableBetButtons();
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ShowFields();
            ShowAccountStatus();
            ShowCurrentBets();
            UpdateBetPriceButtons();
        }

        private void btnSpin_Click(object sender, EventArgs e)
        {
            btnSpin.Enabled = false;
            DisableBetPriceButtons();
            btnClear.Enabled = false;
            Program.accountStatus -= Program.currentBets.Values.Sum();
            ShowAccountStatus();

            tmrSpin.Interval = 50;
            tmrSpin.Enabled = true;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (!Program.isSettingsFormOpened)
            {
                frmSettings frm = new frmSettings();
                frm.mainForm = this;
                frm.Show();
                Program.isSettingsFormOpened = !Program.isSettingsFormOpened;
            }
        }

        private void btn1To18_Click(object sender, EventArgs e)
        {
            AddBet("1To18");
        }

        private void btnOdd_Click(object sender, EventArgs e)
        {
            AddBet("odd");
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            AddBet("red");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            AddBet("0");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            AddBet("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            AddBet("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            AddBet("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            AddBet("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            AddBet("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            AddBet("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            AddBet("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            AddBet("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            AddBet("9");
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            AddBet("10");
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            AddBet("11");
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            AddBet("12");
        }

        private void btn13_Click(object sender, EventArgs e)
        {
            AddBet("13");
        }

        private void btn14_Click(object sender, EventArgs e)
        {
            AddBet("14");
        }

        private void btn15_Click(object sender, EventArgs e)
        {
            AddBet("15");
        }

        private void btn16_Click(object sender, EventArgs e)
        {
            AddBet("16");
        }

        private void btn17_Click(object sender, EventArgs e)
        {
            AddBet("17");
        }

        private void btn18_Click(object sender, EventArgs e)
        {
            AddBet("18");
        }

        private void btn19_Click(object sender, EventArgs e)
        {
            AddBet("19");
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            AddBet("20");
        }

        private void btn21_Click(object sender, EventArgs e)
        {
            AddBet("21");
        }

        private void btn22_Click(object sender, EventArgs e)
        {
            AddBet("22");
        }

        private void btn23_Click(object sender, EventArgs e)
        {
            AddBet("23");
        }

        private void btn24_Click(object sender, EventArgs e)
        {
            AddBet("24");
        }

        private void btn25_Click(object sender, EventArgs e)
        {
            AddBet("25");
        }

        private void btn26_Click(object sender, EventArgs e)
        {
            AddBet("26");
        }

        private void btn27_Click(object sender, EventArgs e)
        {
            AddBet("27");
        }

        private void btn28_Click(object sender, EventArgs e)
        {
            AddBet("28");
        }

        private void btn29_Click(object sender, EventArgs e)
        {
            AddBet("29");
        }

        private void btn30_Click(object sender, EventArgs e)
        {
            AddBet("30");
        }

        private void btn31_Click(object sender, EventArgs e)
        {
            AddBet("31");
        }

        private void btn32_Click(object sender, EventArgs e)
        {
            AddBet("32");
        }

        private void btn33_Click(object sender, EventArgs e)
        {
            AddBet("33");
        }

        private void btn34_Click(object sender, EventArgs e)
        {
            AddBet("34");
        }

        private void btn35_Click(object sender, EventArgs e)
        {
            AddBet("35");
        }

        private void btn36_Click(object sender, EventArgs e)
        {
            AddBet("36");
        }

        private void btnCol1_Click(object sender, EventArgs e)
        {
            AddBet("col1");
        }

        private void btnCol2_Click(object sender, EventArgs e)
        {
            AddBet("col2");
        }

        private void btnCol3_Click(object sender, EventArgs e)
        {
            AddBet("col3");
        }

        private void btnRow1_Click(object sender, EventArgs e)
        {
            AddBet("row1");
        }

        private void btnRow2_Click(object sender, EventArgs e)
        {
            AddBet("row2");
        }

        private void btnRow3_Click(object sender, EventArgs e)
        {
            AddBet("row3");
        }

        private void btnRow4_Click(object sender, EventArgs e)
        {
            AddBet("row4");
        }

        private void btnRow5_Click(object sender, EventArgs e)
        {
            AddBet("row5");
        }

        private void btnRow6_Click(object sender, EventArgs e)
        {
            AddBet("row6");
        }

        private void btnRow7_Click(object sender, EventArgs e)
        {
            AddBet("row7");
        }

        private void btnRow8_Click(object sender, EventArgs e)
        {
            AddBet("row8");
        }

        private void btnRow9_Click(object sender, EventArgs e)
        {
            AddBet("row9");
        }

        private void btnRow10_Click(object sender, EventArgs e)
        {
            AddBet("row10");
        }

        private void btnRow11_Click(object sender, EventArgs e)
        {
            AddBet("row11");
        }

        private void btnRow12_Click(object sender, EventArgs e)
        {
            AddBet("row12");
        }

        private void btn19To36_Click(object sender, EventArgs e)
        {
            AddBet("19To36");
        }

        private void btnEven_Click(object sender, EventArgs e)
        {
            AddBet("even");
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            AddBet("black");
        }

        private void btn1Gr_Click(object sender, EventArgs e)
        {
            SetCurrentBetPrice(0.01f);
        }

        private void btn2Gr_Click(object sender, EventArgs e)
        {
            SetCurrentBetPrice(0.02f);
        }

        private void btn5Gr_Click(object sender, EventArgs e)
        {
            SetCurrentBetPrice(0.05f);
        }

        private void btn10Gr_Click(object sender, EventArgs e)
        {
            SetCurrentBetPrice(0.1f);
        }

        private void btn20Gr_Click(object sender, EventArgs e)
        {
            SetCurrentBetPrice(0.2f);
        }

        private void btn50Gr_Click(object sender, EventArgs e)
        {
            SetCurrentBetPrice(0.5f);
        }

        private void btn1Zł_Click(object sender, EventArgs e)
        {
            SetCurrentBetPrice(1f);
        }

        private void btn2Zł_Click(object sender, EventArgs e)
        {
            SetCurrentBetPrice(2f);
        }

        private void btn5Zł_Click(object sender, EventArgs e)
        {
            SetCurrentBetPrice(5f);
        }

        private void btn10Zł_Click(object sender, EventArgs e)
        {
            SetCurrentBetPrice(10f);
        }

        private void btn20Zł_Click(object sender, EventArgs e)
        {
            SetCurrentBetPrice(20f);
        }

        private void btn50Zł_Click(object sender, EventArgs e)
        {
            SetCurrentBetPrice(50f);
        }

        private void btn100Zł_Click(object sender, EventArgs e)
        {
            SetCurrentBetPrice(100f);
        }

        private void btn200Zł_Click(object sender, EventArgs e)
        {
            SetCurrentBetPrice(200f);
        }

        private void btn500Zł_Click(object sender, EventArgs e)
        {
            SetCurrentBetPrice(500f);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearBets();
        }

        private void tmrSpin_Tick(object sender, EventArgs e)
        {
            if (tmrSpin.Interval > 1000)
            {
                tmrSpin.Enabled = false;
                
                // tu będzie kod rozstrzygający postawione zakłady
                // i przywracający stan poprzedni
                float moneyToAdd = Program
                    .currentBets
                    .Select(p => {
                        byte actualFieldNum = Program.GetField(0).n;
                        if (Program.betTypes[p.Key](actualFieldNum))
                            return 2 * p.Value;
                        else
                            return 0;
                    })
                    .Sum();
                Program.accountStatus += moneyToAdd;
                ShowAccountStatus();
                UpdateBetPriceButtons();

                var dbCmdStr = "select max(id) from roulette.spin;";
                var dbCmd = new NpgsqlCommand(dbCmdStr, Program.dbCon);
                var dbCmdRdr = dbCmd.ExecuteReader();
                dbCmdRdr.Read();
                int newId;
                if (dbCmdRdr.GetValue(0).GetType().ToString() == "System.DBNull")
                {
                    newId = 1;
                }
                else
                {
                    newId = dbCmdRdr.GetInt32(0) + 1;
                }
                dbCmdRdr.Close();
                dbCmdStr = "insert into roulette.spin values (" +
                    newId.ToString() + ", '" + Program.playerName + "', '" +
                    DateTime.Now.ToString() + "', " +
                    Program.GetField(0).n.ToString() + ", " +
                    Program.accountStatus.ToString() + ");";
                dbCmd = new NpgsqlCommand(dbCmdStr, Program.dbCon);
                dbCmd.ExecuteNonQuery();
                if (Program.saveBetHistory)
                {
                    foreach (var p in Program.currentBets)
                    {
                        dbCmdStr = "insert into roulette.bet values (" +
                            newId.ToString() + ", '" + p.Key.ToString() + "', " +
                            p.Value.ToString() + ");";
                        dbCmd = new NpgsqlCommand(dbCmdStr, Program.dbCon);
                        dbCmd.ExecuteNonQuery();
                    }
                }
                btnClear.Enabled = true;
                btnSpin.Enabled = true;
            }
            else
            {
                // zmiana wskazywanego pola koła
                if (Program.wheelPos == 0)
                {
                    Program.wheelPos = 36;
                }
                else
                {
                    Program.wheelPos--;
                }

                // wizualizacja nowego stanu
                ShowFields();

                // spowolnienie koła
                int rndDelta = 25 + new Random().Next(26);
                tmrSpin.Interval += rndDelta;
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.dbCon.Close();
        }

        private void frmMain_Click(object sender, EventArgs e)
        {
            cmsBets.Show();
        }

        private void tmiBetHistory_Click(object sender, EventArgs e)
        {
            if (!Program.isBetHistoryFormOpened)
            {
                frmBetHistory frm = new frmBetHistory();
                frm.Show();
                Program.isBetHistoryFormOpened = true;
            }
        }

        private void tmiBetProbability_Click(object sender, EventArgs e)
        {
            if (!Program.isBetProbabilityFormOpened)
            {
                frmBetProbability frm = new frmBetProbability();
                frm.Show();
                Program.isBetProbabilityFormOpened = true;
            }
        }
    }
}
