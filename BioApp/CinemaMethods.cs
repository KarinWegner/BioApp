using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioApp;

namespace BioApp
{
    internal class CinemaMethods
    {
        public static int AgeChecker(int age)
        {
            int price = 0;
            if (age < 20)
            {   if (age < 5)
                    price = 0;
                else
                    price = 80;
            }
            else if (age > 64)
            { 
                if (age > 100)
                    price = 0;
                else
                    price = 90;
            }
            else
            {
                price = 120;
            }
            return price;
        }
        public static bool AgeListValidator(string[] list, int listSize, out List<int> priceList)
        {
            priceList = new List<int>();
            bool correctinput = true;
            if (list.Count() != listSize)
            {
                Console.WriteLine("Felaktig input.");
                return false;
            }
            foreach (string s in list)
            {
                if (!int.TryParse(s, out _))
                {
                    correctinput = false;
                    Console.WriteLine($"incorrect input: {s}");
                    return correctinput;
                }
                else if (int.Parse(s) < 0)
                {
                    correctinput = false;
                    Console.WriteLine($"incorrect input: {s}");
                    return correctinput;
                }
                else
                {
                    priceList.Add(AgeChecker(int.Parse(s)));
                    //Console.WriteLine($"Added {s} to list");
                }
            }
            return correctinput;
        }
        public static void GroupPriceCalculator()
        {
            int guestCount;
            bool correctInput = false;

            Console.WriteLine("Hur många personer är i sällskapet?");
            guestCount = InputMethods.IntputChecker();


            List<int> priceList;


            do
            {
                Console.WriteLine($"Skriv åldern på alla {guestCount} deltagare. Separera med mellanslag.");
                correctInput = AgeListValidator(Console.ReadLine().Split(' '), guestCount, out priceList);

            }
            while (!correctInput);
            priceList.Sort();
            int youthTickets = 0;
            int seniorTickets = 0;
            int standardTickets = 0;
            int freeEntrys = 0;
            foreach (int price in priceList)
            {
                switch (price)
                {
                    case 0:
                        freeEntrys++;
                        break;
                    case 80:
                        youthTickets++;
                        break;
                    case 90:
                        seniorTickets++;
                        break;
                    case 120:
                        standardTickets++;
                        break;
                }
            }
            Console.WriteLine("Sammanfattning:");
            Console.WriteLine($"Biljetter: \t\t{guestCount}st\n");
            if (youthTickets > 0)
                Console.WriteLine($"Ungdom\t|\t80kr \t{youthTickets}st\t|{80 * youthTickets}kr ");
            if (seniorTickets > 0)
                Console.WriteLine($"Senior\t|\t90kr \t{seniorTickets}st\t|{90 * seniorTickets}kr ");
            if (standardTickets > 0)
                Console.WriteLine($"Standard|\t120kr \t{standardTickets}st\t|{120 * standardTickets}kr ");
            if (freeEntrys > 0)
            {
                Console.WriteLine($"Gratis*\t|\t0kr \t{freeEntrys}st\t|0kr");
                Console.WriteLine("\n*småbarn under 5 och seniorer\n över 100 får gratis inträde!");
            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"\t\tTotal kostnad:\t|{priceList.Sum()}kr");
            Console.WriteLine("\nTryck på enter för att återvända till startmenyn.");
            Console.ReadLine();
            Console.Clear();
        }
        }
    }
