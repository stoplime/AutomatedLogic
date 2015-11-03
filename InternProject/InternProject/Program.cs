using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace InternProject
{
    class Program
    {
        static void Main(string[] args)
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

        public static string ToPigLatin(string inputEnglish)
        {
            string pigLatin = "";

            string patternWord = @"(\w+)";
            string patternNonWord = @"(\W)";
            Regex regexWord = new Regex(patternWord);
            Regex regexNonWord = new Regex(patternNonWord);
            
            //find all words and separate them from punctuations
            string[] words = regexWord.Split(inputEnglish);
            string[] punctuations = new string[words.Length];

            for (int i = 0; i < words.Length; i++)
            {
                string punctuation = "";
                int n;
                if (regexNonWord.IsMatch(words[i]) || int.TryParse(words[i], out n))
                {
                    punctuations[i] = words[i];
                    words[i] = "";
                    Console.WriteLine("punctuation: " + punctuation);
                }
            }
            //convert words to pigLatin
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != "")
                {
                    char[] word = words[i].ToCharArray();
                    char firstLetter = word[0];
                    char[] otherLetters = (words[i].Substring(1,word.Length-1)).ToCharArray();
                    string vowels = "AEIOUaeiou";
                    if (vowels.IndexOf(firstLetter) == -1)
                    {
                        pigLatin += new string(otherLetters) + firstLetter.ToString() + "ay";
                    }
                    else
                    {
                        pigLatin += new string(otherLetters) + firstLetter.ToString() + "y";
                    }
                }else
                {
                    pigLatin += punctuations[i];
                }
            }

            return pigLatin;
        }

        public static bool PowerOf(float input, float power)
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
