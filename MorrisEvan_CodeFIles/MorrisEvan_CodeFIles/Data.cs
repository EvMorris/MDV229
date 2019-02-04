using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MorrisEvan_CodeFIles
{
    class Data
    {
        
        public string cmd { get; set; }


        public Data()
        {

            //Pull();
        }

        public void PullAll()
        {
            Console.WriteLine("Start\n");

            // MySQL Database Connection String
            string cs = @"server=192.168.0.10;userid=realUser;password=password;database=wineData;port=8889";

            // Declare a MySQL Connection
            MySqlConnection conn = null;

            try
            {
                // Open a connection to MySQL
                conn = new MySqlConnection(cs);
                conn.Open();

                // Form SQL Statement
                string stm = "SELECT * FROM wine;";

                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);

                // Execute SQL statement and place the returned data into rdr
                MySqlDataReader rdr = cmd.ExecuteReader();
                

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        //Console.WriteLine(Convert.ToString(rdr["id"]));
                        Console.WriteLine(Convert.ToString(rdr["wineName"]));
                        Console.WriteLine(Convert.ToString(rdr["category"]));
                        Console.WriteLine(Convert.ToString(rdr["brandName"]));
                        Console.WriteLine(Convert.ToString(rdr["yearMade"]));
                    }
                }
                else
                {
                    Console.WriteLine("Login Failed");
                }

                rdr.Close();
               

                //cmd.ToString();
                Console.WriteLine(rdr);
               


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
            //ToJson();

        }


    }
}
