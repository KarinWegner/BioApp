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
