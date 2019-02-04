using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;


namespace MorrisEvan_Integrative2
{
    class Data
    {
        private string _folder = @"..\..\output\";
        public string cmd { get; set; }
        

        public Data()
        {

            //Pull();
        }

        public void PullAll()
        {
            Console.WriteLine("Start\n");

            // MySQL Database Connection String
            string cs = @"server=10.63.24.217;userid=realUser;password=password;database=ILA1;port=8889";

            // Declare a MySQL Connection
            MySqlConnection conn = null;

            try
            {
                // Open a connection to MySQL
                conn = new MySqlConnection(cs);
                conn.Open();

                // Form SQL Statement
                string stm = "SELECT * FROM RestaurantProfiles;";

                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);

                // Execute SQL statement and place the returned data into rdr
                MySqlDataReader rdr = cmd.ExecuteReader();
                string jsonData = "[";

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Console.WriteLine(Convert.ToString(rdr["id"]));
                        jsonData += "{";
                        jsonData += "'id':" + Convert.ToString(rdr["id"]) + ",";
                        jsonData += "},";
                    }
                }
                else
                {
                    Console.WriteLine("Login Failed");
                }

                rdr.Close();
                jsonData += "]";

                //cmd.ToString();
                // Console.WriteLine(rdr);
                ToJson(jsonData);


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

        public void ToJson( string jsonData)
        {
            Console.WriteLine("Test");

            Console.WriteLine(Directory.GetCurrentDirectory());

            Console.WriteLine("Converting to Json...");
            using (StreamWriter outStream = new StreamWriter(_folder + "convert.json"))
            {
                //int counter = cmd.Count();

                outStream.WriteLine(jsonData);

                //foreach (List<> item in cmd)
                //{
                   // string[] info;
                   // string line = item.ToJson();
                //}
            }
        }



        
    }
}
