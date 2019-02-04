using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MorrisEvan_CodeFIles
{
    class Wine
    {
        //columns-id
        public string WineId { get; set; }
        public string WineName { get; set; }
        public string Category { get; set; }
        public string BrandName { get; set; }
        public string YearMade {get;set;}

        public Wine(string wineName, string category, string brandName, string yearMade)
        {
            WineName = wineName;
            Category = category;
            BrandName = brandName;
            YearMade = yearMade;

        }

        public void AddWine(MySqlConnection conn)
        {
            string stm = "INSERT INTO wine (wineName, category, brandName, yearMade) " +
                "VALUES (@wineName, @wineCategory, @wineBrand, @year);";

            MySqlCommand cmd = new MySqlCommand(stm, conn);

            cmd.Parameters.AddWithValue("@wineName", this.WineName);
            cmd.Parameters.AddWithValue("@wineCategory", this.Category);
            cmd.Parameters.AddWithValue("@wineBrand", this.BrandName);
            cmd.Parameters.AddWithValue("@year", this.YearMade);

            MySqlDataReader rdr = cmd.ExecuteReader();

            this.WineId = Convert.ToString(cmd.LastInsertedId);
            rdr.Close();

        }



        
    }
}
