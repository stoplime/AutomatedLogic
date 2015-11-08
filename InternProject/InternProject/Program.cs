/***** Steffen Lim ******/
using System;
using System.Text.RegularExpressions;

namespace InternProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Steffen's solution to Automated Logic's internship porblem");

            string flag = "";
            while (flag.ToLower() != "x")
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("\t 1\t check the power factor of a number");
                Console.WriteLine("\t 2\t translate english to pig Latin");
                Console.WriteLine("\t x\t exit program");
                flag = Console.ReadLine();
                switch (flag.ToLower())
                {
                    case "1":
                        Console.WriteLine("Please input two integers to see if one is a power of the other:");
                        Console.WriteLine("Ex input: 8, power: 2 -> 8 is a power multiple of 2, so it's true");
                        Console.Write("input: ");
                        int input;
                        if (!int.TryParse(Console.ReadLine(),out input))
                        {
                            Console.WriteLine("Sorry, unrecogized input. Please provide an integer.");
                            break;
                        }
                        Console.Write("power: ");
                        int power;
                        if (!int.TryParse(Console.ReadLine(),out power))
                        {
                            Console.WriteLine("Sorry, unrecogized input. Please provide a positive integer.");
                            break;
                        }
                        if (power < 0)
                        {
                            power = Math.Abs(power);
                            Console.WriteLine("Sorry, power cannot accept negative values. Did you mean " + power + "?");
                        }
                        bool test = PowerOf(input, power);
                        Console.WriteLine(test+", "+input + ((test)?" is":" is not") + " a power multiple of "+ power);
                        Console.WriteLine(Math.Log(input,power));
                        break;
                    case "2":
                        Console.WriteLine("Translate english into Piglatin!");
                        Console.WriteLine("Please enter an english phrase you would like to translate: ");
                        Console.WriteLine(ToPigLatin(Console.ReadLine()));
                        break;
                    case "x":
                        Console.WriteLine("Thank you for using this system, have a good day!");
                        Console.WriteLine("press enter to continue...");
                        Console.ReadLine();
                        return;
                    default:
                        Console.WriteLine("Sorry, unrecognized command. Please try again.");
                        break;
                }
                Console.WriteLine("\nenter 'x' to exit or any key to continue...");
                flag = Console.ReadLine();
            }

        }

        public static bool PowerOf(double input, double power)
        {
            if (power == 0)
            {
                return false;
            }
            if (power == 1 && input == 1)
            {
                return true;
            }
            double result = Math.Log(input, power);
            if (result % 1 == 0)
            {
                return true;
            }
            else 
            {
                return false;
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
                int n;
                if (regexNonWord.IsMatch(words[i]) || int.TryParse(words[i], out n))
                {
                    punctuations[i] = words[i];
                    words[i] = "";
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
                        pigLatin += firstLetter.ToString() + new string(otherLetters) + "yay";
                    }
                }else
                {
                    pigLatin += punctuations[i];
                }
            }

            return pigLatin;
        }
    }
}
