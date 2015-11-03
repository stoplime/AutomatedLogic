using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;

namespace internshipProject
{
    public class Program
    {
        public void Main(string[] args)
        {
            /*
            Console.WriteLine("Enter a number A to see if it is a power of B");
            Console.Write("A: ");
            int A = int.Parse(Console.ReadLine());
            Console.Write("B: ");
            int B = int.Parse(Console.ReadLine());
            Console.WriteLine("Result: "+PowerOf(A,B));
            Console.ReadLine
            */

            while (true)
            {
                Console.WriteLine("enter phrase to convert to piglatin: ");
                Console.WriteLine(ToPigLatin(Console.ReadLine()));
            }

        }

        public string ToPigLatin(string inputEnglish)
        {
            string pattern = @"(\w+\W)";
            Regex regex = new Regex(pattern);
            string[] words = regex.Split(inputEnglish);
            string pigLatin = "";
            foreach (string word in words)
            {
                pigLatin = pigLatin + word + "\n";
            }
            return pigLatin;
        }

        public bool PowerOf (float input, float power)
        {
            float result = input / power;
            if (result > 2)
            {
                return PowerOf(result, power);
            }
            else if (result == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
