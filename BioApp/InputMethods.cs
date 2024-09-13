using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioApp
{
    internal class InputMethods
    {
        public static int IntputChecker()
        {
            bool correctInput = false;
            string input;
            do
            {
                input = Console.ReadLine();
                correctInput = int.TryParse(input, out _);
                if (!correctInput || string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Felaktig inmatning. Vänligen skriv endast siffror.");
                }
                else if (int.Parse(input) < 0)
                {
                    Console.WriteLine("Felaktig inmatning. Negativa nummer ej giltiga.");
                    correctInput = false;
                }
                else
                {
                    correctInput = true;
                }
            }
            while (!correctInput);
            return int.Parse(input);

        }
        public static void ThirdWordFinder()
        {
            bool correctInput = false;
            List<string> wordList;
            do
            {
                Console.WriteLine("Skriv in minst tre ord. Programmet kommer att hitta och återupprepa det tredje ordet i meningen.");
                string input = Console.ReadLine();
                wordList = new List<string>(input.Split(' '));

                wordList.RemoveAll(s => s == "");               //Tar bort alla tomma blanksteg
                if (wordList.Count >= 3)
                {
                    correctInput = true;
                }
                else
                {
                    Console.WriteLine("Felaktig input. Skriv minst tre ord i meningen, blanksteg räknas inte.");
                }
            }
            while (!correctInput);
            string thirdWord = wordList[2];
            Console.WriteLine($"Det tredje ordet är {thirdWord}!");

        }

        public static void InputRepeater()
        {
            Console.WriteLine("Skriv den fras du vill se återupprepad 10 gånger:");
            string input = Console.ReadLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i + 1}. {input}, ");
            }
            Console.WriteLine("\nKlar! Tryck på enter för att återvända till startmenyn.");
            Console.ReadLine();
        }
        //public static int OptionValidator(int[] optionArray)
        //{
        //    bool correctInput = false;
        //    int result;
        //    do
        //    {
        //        result = IntputChecker();

        //        if (!optionArray.Contains(result))
        //            Console.WriteLine("Felaktig input. Skriv siffran för det alternativ du vill välja.");

        //        else
        //            correctInput = true;

        //    } while (!correctInput);

        //    return result;
        //}
    }
}
