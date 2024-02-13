using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roulette_Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        // wartości są na początku ustawione na sztywno
        // docelowo użyjemy PostgreSQL-a

        // połączenie z bazą danych
        static string dbConStr = "Host=127.0.0.1;Username=postgres;" +
            "Password=root;Database=postgres";
        public static NpgsqlConnection dbCon = new NpgsqlConnection(dbConStr);

        // poniżej będziemy trzymać zawartość koła gry (liczby pól i ich kolory)
        public static WheelField[] wheel = new WheelField[] {
            new WheelField(0, Color.Green),
            new WheelField(32, Color.Red),
            new WheelField(15, Color.Black),
            new WheelField(19, Color.Red),
            new WheelField(4, Color.Black),
            new WheelField(21, Color.Red),
            new WheelField(2, Color.Black),
            new WheelField(25, Color.Red),
            new WheelField(17, Color.Black),
            new WheelField(34, Color.Red),
            new WheelField(6, Color.Black),
            new WheelField(27, Color.Red),
            new WheelField(13, Color.Black),
            new WheelField(36, Color.Red),
            new WheelField(11, Color.Black),
            new WheelField(30, Color.Red),
            new WheelField(8, Color.Black),
            new WheelField(23, Color.Red),
            new WheelField(10, Color.Black),
            new WheelField(5, Color.Red),
            new WheelField(24, Color.Black),
            new WheelField(16, Color.Red),
            new WheelField(33, Color.Black),
            new WheelField(1, Color.Red),
            new WheelField(20, Color.Black),
            new WheelField(14, Color.Red),
            new WheelField(31, Color.Black),
            new WheelField(9, Color.Red),
            new WheelField(22, Color.Black),
            new WheelField(18, Color.Red),
            new WheelField(29, Color.Black),
            new WheelField(7, Color.Red),
            new WheelField(28, Color.Black),
            new WheelField(12, Color.Red),
            new WheelField(35, Color.Black),
            new WheelField(3, Color.Red),
            new WheelField(26, Color.Black)
        };
        // zmienna oznaczająca aktualnie wskazywane pole koła
        // czyli indeks tablicy wheel z przedziału 0-36
        // tutaj aktualnym polem jest 0
        public static byte wheelPos = 0;
        // słownik zawierający możliwe rodzaje zakładów
        // wygranie zakładu sprawdzamy predykatem
        public static Dictionary<string, Func<byte, bool>> betTypes = new Dictionary<string, Func<byte, bool>>
        {
            { "0", x => x == 0 },
            { "1", x => x == 1 },
            { "2", x => x == 2 },
            { "3", x => x == 3 },
            { "4", x => x == 4 },
            { "5", x => x == 5 },
            { "6", x => x == 6 },
            { "7", x => x == 7 },
            { "8", x => x == 8 },
            { "9", x => x == 9 },
            { "10", x => x == 10 },
            { "11", x => x == 11 },
            { "12", x => x == 12 },
            { "13", x => x == 13 },
            { "14", x => x == 14 },
            { "15", x => x == 15 },
            { "16", x => x == 16 },
            { "17", x => x == 17 },
            { "18", x => x == 18 },
            { "19", x => x == 19 },
            { "20", x => x == 20 },
            { "21", x => x == 21 },
            { "22", x => x == 22 },
            { "23", x => x == 23 },
            { "24", x => x == 24 },
            { "25", x => x == 25 },
            { "26", x => x == 26 },
            { "27", x => x == 27 },
            { "28", x => x == 28 },
            { "29", x => x == 29 },
            { "30", x => x == 30 },
            { "31", x => x == 31 },
            { "32", x => x == 32 },
            { "33", x => x == 33 },
            { "34", x => x == 34 },
            { "35", x => x == 35 },
            { "36", x => x == 36 },
            { "row1", x => x >= 1 && x <= 3 },
            { "row2", x => x >= 4 && x <= 6 },
            { "row3", x => x >= 7 && x <= 9 },
            { "row4", x => x >= 10 && x <= 12 },
            { "row5", x => x >= 13 && x <= 15 },
            { "row6", x => x >= 16 && x <= 18 },
            { "row7", x => x >= 19 && x <= 21 },
            { "row8", x => x >= 22 && x <= 24 },
            { "row9", x => x >= 25 && x <= 27 },
            { "row10", x => x >= 28 && x <= 30 },
            { "row11", x => x >= 31 && x <= 33 },
            { "row12", x => x >= 34 && x <= 36 },
            { "col1", x => x % 3 == 1 },
            { "col2", x => x % 3 == 2 },
            { "col3", x => x % 3 == 0 },
            { "1To18", x => x >= 1 && x <= 18 },
            { "19To36", x => x >= 19 && x <= 36 },
            { "odd", x => x % 2 != 0 },
            { "even", x => x % 2 == 0 },
            { "red", x => new List<byte> {
                1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36
            }.Contains(x) },
            { "black", x => new List<byte> {
                2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35
            }.Contains(x) }
        };
        // nazwa gracza
        public static string playerName;
        // stan konta
        public static float accountStatus;
        // postawione zakłady
        public static Dictionary<string, float> currentBets = new Dictionary<string, float>();
        // kwota zakładu do postawienia
        public static float currentBetPrice;
        // zapisywanie historii zakładów
        public static bool saveBetHistory = false;
        // otwarcie okna historii zakładów
        public static bool isBetHistoryFormOpened = false;
        // otwarcie okna prawdopodobieństwa trafienia zakładów
        public static bool isBetProbabilityFormOpened = false;
        // otwarcie okna ustawień
        public static bool isSettingsFormOpened = false;

        public static WheelField GetField(sbyte offset)
        {
            sbyte dir = (sbyte)Math.Sign(offset);
            sbyte res = (sbyte)wheelPos;
            for (sbyte i = 0; i != offset; i += dir)
            {
                if (dir == -1 && res == 0)
                    res = 36;
                else if (dir == 1 && res == 36)
                    res = 0;
                else
                    res += dir;
            }
            return wheel[res];
        }

        static void GetPlayerName()
        {
            var dbCmdStr = "select player_name from roulette.spin " +
                "order by date desc limit 1;";
            var dbCmd = new NpgsqlCommand(dbCmdStr, dbCon);
            var dbCmdRdr = dbCmd.ExecuteReader();
            if (dbCmdRdr.HasRows)
            {
                dbCmdRdr.Read();
                playerName = dbCmdRdr.GetString(0);
            }
            else
                playerName = "Jan";
            dbCmdRdr.Close();
        }

        static void GetAccountStatus()
        {
            var dbCmdStr = "select post_account_status from roulette.spin " +
                "order by date desc limit 1;";
            var dbCmd = new NpgsqlCommand(dbCmdStr, dbCon);
            var dbCmdRdr = dbCmd.ExecuteReader();
            if (dbCmdRdr.HasRows)
            {
                dbCmdRdr.Read();
                accountStatus = dbCmdRdr.GetFloat(0);
            }
            else
                accountStatus = 1000;
            dbCmdRdr.Close();
        }

        [STAThread]
        static void Main()
        {
            dbCon.Open();
            GetPlayerName();
            GetAccountStatus();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
