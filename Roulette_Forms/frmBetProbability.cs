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
    public partial class frmBetProbability : Form
    {
        public frmBetProbability()
        {
            InitializeComponent();
        }

        private void frmBetProbability_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.isBetProbabilityFormOpened = false;
        }

        private void frmBetProbability_Load(object sender, EventArgs e)
        {
            var dbCmdStr = "select number from roulette.spin;";
            var dbCmd = new NpgsqlCommand(dbCmdStr, Program.dbCon);
            var dbCmdRdr = dbCmd.ExecuteReader();
            List<byte> numbers = new List<byte>();
            while (dbCmdRdr.Read())
                numbers.Add((byte)dbCmdRdr.GetInt16(0));
            dbCmdRdr.Close();
            int numbersLen = numbers.Count;
            Dictionary<string, string> betNameDict = new Dictionary<string, string>
            {
                { "0", "0" },
                { "1", "1" },
                { "2", "2" },
                { "3", "3" },
                { "4", "4" },
                { "5", "5" },
                { "6", "6" },
                { "7", "7" },
                { "8", "8" },
                { "9", "9" },
                { "10", "10" },
                { "11", "11" },
                { "12", "12" },
                { "13", "13" },
                { "14", "14" },
                { "15", "15" },
                { "16", "16" },
                { "17", "17" },
                { "18", "18" },
                { "19", "19" },
                { "20", "20" },
                { "21", "21" },
                { "22", "22" },
                { "23", "23" },
                { "24", "24" },
                { "25", "25" },
                { "26", "26" },
                { "27", "27" },
                { "28", "28" },
                { "29", "29" },
                { "30", "30" },
                { "31", "31" },
                { "32", "32" },
                { "33", "33" },
                { "34", "34" },
                { "35", "35" },
                { "36", "36" },
                { "row1", "1. wiersz" },
                { "row2", "2. wiersz" },
                { "row3", "3. wiersz" },
                { "row4", "4. wiersz" },
                { "row5", "5. wiersz" },
                { "row6", "6. wiersz" },
                { "row7", "7. wiersz" },
                { "row8", "8. wiersz" },
                { "row9", "9. wiersz" },
                { "row10", "10. wiersz" },
                { "row11", "11. wiersz" },
                { "row12", "12. wiersz" },
                { "col1", "1. kolumna" },
                { "col2", "2. kolumna" },
                { "col3", "3. kolumna" },
                { "1To18", "1-18" },
                { "19To36", "19-36" },
                { "odd", "nieparzyste" },
                { "even", "parzyste" },
                { "red", "czerwone" },
                { "black", "czarne" }
            };
            foreach (var el in betNameDict)
            {
                string probStr;
                if (numbersLen > 0)
                {
                    int satisfiable = numbers
                        .Where(Program.betTypes[el.Key])
                        .Count();
                    double satisfiability = ((double)satisfiable * 100) / numbersLen;
                    probStr = satisfiability.ToString("n2") + "%";
                }
                else
                {
                    probStr = "?";
                }

                lsvBetProbability.Items.Add(new ListViewItem(new string[] {
                    betNameDict[el.Key],
                    probStr
                }));
            }
        }
    }
}
