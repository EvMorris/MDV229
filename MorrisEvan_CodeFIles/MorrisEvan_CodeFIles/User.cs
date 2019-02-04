using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MorrisEvan_CodeFIles
{
    class User
    {
        public string userName;
        public string userId;

        public User()
        {

        }

        public void Login(MySqlConnection conn, string username, string password)
        {
            // Form SQL Statement
            //conn.Open();
            string stm = "SELECT id, username " +
                "FROM users " +
                "WHERE username = @username AND pass = @password;";

            // Prepare SQL Statement
            MySqlCommand cmd = new MySqlCommand(stm, conn);

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            // Execute SQL statement and place the returned data into rdr
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                this.userId = Convert.ToString(rdr["id"]);
                this.userName = Convert.ToString(rdr["username"]);
                
            }
            else
            {
                Console.WriteLine("Login Failed");
            }
            rdr.Close();
        }

        public void GetuserName()
        {

        }

        public void GetCollection(MySqlConnection conn)
        {
            // Form SQL Statement
            //conn.Open();
            string stm = "SELECT * " +
                "FROM collection " +
                "WHERE userId = @userId;";

            MySqlCommand cmd = new MySqlCommand(stm, conn);

            cmd.Parameters.AddWithValue("@userId", this.userId);

            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read()){
                    Console.WriteLine("Category: " + Convert.ToString(rdr["category"]));
                    Console.WriteLine("Brand: " + Convert.ToString(rdr["brandName"]));
                    Console.WriteLine("Year: " + Convert.ToString(rdr["yearMade"]));
                    Console.WriteLine("\n");
                }

            }
            else
            {
                Console.WriteLine("Collection empty");
            }
            rdr.Close();


        }

        public void addWine(MySqlConnection conn)
        {

            string wineName = Utility.ValidateString("Enter wine name:");
            string wineBrand = Utility.ValidateString("Enter wine brand");
            string wineYear = Utility.ValidateString("Enter wine year:");
            string wineCategory = Utility.ValidateString("Category");

            Wine newWine = new Wine(wineName, wineCategory, wineBrand, wineYear);
            newWine.AddWine(conn);

            string stm = "INSERT INTO collection (category, brandName, yearMade, userId, wineId) " +
                "VALUES (@wineCategory, @wineBrand, @year, @userId, @wineId);";

            MySqlCommand cmd = new MySqlCommand(stm, conn);

            cmd.Parameters.AddWithValue("@userId", this.userId);
            cmd.Parameters.AddWithValue("@wineId", newWine.WineId);
            cmd.Parameters.AddWithValue("@wineCategory", newWine.Category);
            cmd.Parameters.AddWithValue("@wineBrand", newWine.BrandName);
            cmd.Parameters.AddWithValue("@year", newWine.YearMade);

            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Close();


        }

        public void AddReview(MySqlConnection conn)
        {
            string wineName = Utility.ValidateString("Enter wine name:");
            string wineId = Utility.ValidateString("Enter wine id");
            string wineRev = Utility.ValidateString("Enter a short review:");
            

            

            string stm = "INSERT INTO reviews (wineName, review, userId, wineId) " +
                "VALUES (@wineName, @review, @userId, @wineId);";

            MySqlCommand cmd = new MySqlCommand(stm, conn);

            cmd.Parameters.AddWithValue("@userId", this.userId);
            cmd.Parameters.AddWithValue("@wineId", wineId);
            cmd.Parameters.AddWithValue("@wineName", wineName);
            cmd.Parameters.AddWithValue("@review", wineRev);


            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Close();
        }

        public void GetReviews(MySqlConnection conn)
        {
            string stm = "SELECT * " +
                "FROM reviews " +
                "WHERE userId = @userId;";

            MySqlCommand cmd = new MySqlCommand(stm, conn);

            cmd.Parameters.AddWithValue("@userId", this.userId);

            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    Console.WriteLine("Wine : " + Convert.ToString(rdr["wineName"]));
                    Console.WriteLine("Review: " + Convert.ToString(rdr["review"]));
                   
                    Console.WriteLine("\n");
                }

            }
            else
            {
                Console.WriteLine("No reviews");
            }
            rdr.Close();



        }
    }
}
