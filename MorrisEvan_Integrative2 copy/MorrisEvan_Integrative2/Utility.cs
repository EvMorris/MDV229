using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorrisEvan_Integrative2
{
    class Utility
    {
        public static float GetAverage(int[] numbers)
        {
            int total = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                total += numbers[i];
            }
            // float avg = total / numbers.Length;
            return total / numbers.Length;
        }
        public static int ValidateInt(string prompt)
        {
            int result;
            Console.WriteLine($"{ prompt}");
            string response = Console.ReadLine();

            while (!int.TryParse(response, out result))
            {
                Console.WriteLine("Enter an integer only");
                response = Console.ReadLine();
            }
            return result;
        }
        public static string ValidateString(string prompt)
        {
            Console.WriteLine($"{ prompt}");
            string response = Console.ReadLine();

            while (String.IsNullOrWhiteSpace(response))
            {
                Console.WriteLine("Please do not leave this blank.");
                response = Console.ReadLine();
            }
            return response;
        }
        public static float ValidateFloat(string prompt)
        {
            float result;
            Console.WriteLine($"{ prompt}");
            string response = Console.ReadLine();

            while (!float.TryParse(response, out result))
            {
                Console.WriteLine("Enter a number only");
                response = Console.ReadLine();
            }
            return result;
        }
    }
}
