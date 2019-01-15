using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MorrisEvan_Integrative2
{
    class Code
    {
        public Code()
        {
            GetData();
            //Init();
        }


        private void Init()
        {
            Menu menu = new Menu("Convert The Restaurant Reviews Database From SQL To JSON", "Showcase Our 5 Star Rating System", "Showcase Our Animated Bar Graph Review System", "Play A Card Game", "Exit");
            menu.Title = "Integrative";
            menu.Display();
            Select();

        }

        private void Select()
        {
            switch (Utility.ValidateInt("Make selection 1-5"))
            {
                case 1:
                    ConToJson();
                    break;
                case 2:
                    StarRating();
                    break;
                case 3:
                    BarGraph();
                    break;
                case 4:
                    CardGame();
                    break;
                case 5:
                    Exit();
                    break;
                default:
                    Console.WriteLine("Select a valid option.");
                    break;
            }
        }

        private void ConToJson()
        {

        }

        private void StarRating()
        {

        }

        private void BarGraph()
        {

        }

        private void CardGame()
        {

        }

        private void Exit()
        {

        }

        private void GetData()
        {
            Console.WriteLine("Start\n");

            // MySQL Database Connection String
            string cs = @"server=192.168.0.10;userid=root;password=root;database=example_1809;port=8889";

            // Declare a MySQL Connection
            MySqlConnection conn = null;

            try
            {
                // Open a connection to MySQL
                conn = new MySqlConnection(cs);
                conn.Open();

                // Form SQL Statement
                string stm = "SELECT VERSION()";

                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);

                // Execute SQL Statement and Convert Results to a String
                string version = Convert.ToString(cmd.ExecuteScalar());

                // Output Results
                Console.WriteLine("MySQL version : {0}", version);

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            Console.WriteLine("Done");
        }
    }
}

