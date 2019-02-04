using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MorrisEvan_CodeFIles
{
    class Code
    {
        private static MySqlConnection conn;


        private static Menu menu;
        private static Menu profileMenu;
        private static User loggedIn;

        public Code()
        {
            string cs = @"server=192.168.0.10;userid=realUser;password=password;database=wineData;port=8889";

            conn = new MySqlConnection(cs);
            conn.Open();
            

            loggedIn = new User();
            Console.WriteLine("LOGIN");
            Console.WriteLine("Enter Username:");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            string passWord = Console.ReadLine();
            loggedIn.Login(conn, userName, passWord);
            Init();
        }

        private void Init()
        {
            menu = new Menu("My Profile", "Add To My Collection", "Write a Review", "Search", "Exit");
            menu.Title = "My Wine Collector";
            menu.Display();
            Select();


        }

        private void Select()
        {
            switch (Utility.ValidateInt("Make selection 1-4"))
            {
                case 1:
                    MyProfile();
                    break;
                case 2:
                    loggedIn.addWine(conn);
                    break;
                case 3:
                    loggedIn.AddReview(conn);
                    break;
                case 4:
                    Search();
                    break;
                case 5:
                    ExitProgram();
                    break;
                default:
                    Console.WriteLine("Select a valid option.");
                    break;
            }

            Console.ReadKey();
            Init();
        }

        private void MyProfile()
        {
             profileMenu = new Menu("My Collection", "My Reviews");
            profileMenu.Title = loggedIn.userName + "'s profile";
            profileMenu.Display();
            SubSelect();
        }
        
        private void SubSelect()
        {
            switch (Utility.ValidateInt("Make selection"))
            {
                case 1:
                    loggedIn.GetCollection(conn);
                    break;
                case 2:
                    loggedIn.GetReviews(conn);
                    break;
                
                default:
                    Console.WriteLine("Select a valid option.");
                    break;
            }

            Console.ReadKey();
            Init();
        }
        private void AddToColl()
        {

        }

        private void WriteRev()
        {

        }

        private void Search()
        {
            Data data = new Data();
            data.PullAll();
        }

        private void ExitProgram()
        {
            Environment.Exit(0);
        }

         
    }
}
