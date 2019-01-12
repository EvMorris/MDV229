using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorrisEvan_Integrative2
{
    class Code
    {
        public Code()
        {
            Init();
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
    }
}
