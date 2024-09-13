using System.Xml;
using BioApp    ;

internal class Program
{
    private static void Main(string[] args)
    {
        bool programOn = true;
        string input;
        //int[] menuOptionArray = new int[] {0, 1, 2};
        do
        {
            Console.WriteLine("Välkommen till programments huvudmeny. Skriv siffran för handlingen du vill utföra, tryck sedan enter:\n 1. Se pris för enkelbiljett\n 2. Se pris för gruppbiljett\n 3. Text-repeterare\n 4. Hitta tredje ordet \n 0. Avsluta");
            input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    Console.WriteLine("Avslutar program");
                    programOn = false;
                    break;
                case "1":
                    Console.WriteLine("´Skriv din ålder för att se ditt biljettpris:");
                    int age = InputMethods.IntputChecker();

                    if (age < 20)
                    {
                        Console.WriteLine($"Ungdomspris: 80kr");
                    }
                    else if (age > 64)
                    {
                        Console.WriteLine($"Pensionärpris: 90kr");
                    }
                    else
                    {
                        Console.WriteLine($"Standardpris: 120kr");
                    }
                    
                    Console.WriteLine("\nTryck på enter för att återvända till startmenyn.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "2":
                    CinemaMethods.GroupPriceCalculator(); break;
                case "3":
                    InputMethods.InputRepeater();
                    break;
                case "4":
                    InputMethods.ThirdWordFinder();
                    break;
                default:
                    Console.WriteLine("Felaktig inmatning. Vänligen skriv endast siffran för det alternativ du vill välja, tryck sedan enter.");
                    break;
            }
        }
        while (programOn);
        


    }
  
    
    
   

    

    
        
}