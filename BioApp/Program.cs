using System.Xml;

internal class Program
{
    private static void Main(string[] args)
    {
        bool programOn = true;
        string input;
        int[] menuOptionArray = new int[] {0, 1, 2};
        do
        {
            Console.WriteLine("Välkommen till programments huvudmeny. Skriv siffran för handlingen du vill utföra, tryck sedan enter:\n 1. Köp enkelbiljett\n 2. Köp gruppbiljett \n 0. Avsluta");
            input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    Console.WriteLine("Avslutar program");
                    programOn = false;
                    break;
                case "1":
                    Console.WriteLine("´Skriv din ålder för att se ditt biljettpris:");
                    int age = IntputChecker();

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
                    GroupPriceCalculator(); break;
                default:
                    Console.WriteLine("Felaktig inmatning. Vänligen skriv endast siffran för det alternativ du vill välja, tryck sedan enter.");
                    break;
            }
        }
        while (programOn);


    }
    private static int OptionValidator(int[] optionArray)
    {
        bool correctInput = false;
        int result;
        do
        {
            result = IntputChecker();
            
            if (!optionArray.Contains(result))
                Console.WriteLine("Felaktig input. Skriv siffran för det alternativ du vill välja.");
            
            else
                correctInput = true;
            
        } while (!correctInput);

        return result;
    }

    private static int IntputChecker()
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
    private static bool AgeListValidator(string[] list, int listSize, out List<int> priceList) 
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

    private static int AgeChecker(int age)
    {
        int price = 0;
        if (age <20)
        {
            price = 80;
        }
        else if (age > 64)
        {
            price = 90;
        }
        else
        {
            price = 120;
        }
        return price;
    }

    private static void GroupPriceCalculator()
    {
        int guestCount;
        bool correctInput = false;
        
            Console.WriteLine("Hur många personer är i sällskapet?");
        guestCount = IntputChecker();
            

        List<int> priceList;
        

        do
        {            
            Console.WriteLine($"Skriv åldern på alla {guestCount} deltagare. Separera med mellanslag.");
            correctInput = AgeListValidator(Console.ReadLine().Split(' '),guestCount, out priceList);

        }
        while (!correctInput);
        priceList.Sort();
        int youthTickets = 0;
        int seniorTickets = 0;
        int standardTickets = 0;
        foreach (int price in priceList) 
        {
            switch (price)
            {
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
        Console.WriteLine($"Biljetter: \t {guestCount}\n");
        if (youthTickets > 0)
        Console.WriteLine($"Ungdom\t|\t80kr \t{youthTickets}st\t|{80 * youthTickets}kr ");
        if (seniorTickets > 0)
            Console.WriteLine($"Senior\t|\t90kr \t{seniorTickets}st\t|{90*seniorTickets}kr ");
        if (standardTickets > 0)
            Console.WriteLine($"Standard|\t120kr \t{standardTickets}st\t|{120 * standardTickets}kr ");
        Console.WriteLine("---------------------------------------");
        Console.WriteLine($"\t\tTotal kostnad:\t|{priceList.Sum()}kr");
        Console.WriteLine("\nTryck på enter för att återvända till startmenyn.");
        Console.ReadLine();
        Console.Clear();

            //foreach (string age in ageList)
            //{
            //    Console.WriteLine($"{age} ");
            //    correctInput = int.TryParse(age, out _);

            //    if (!correctInput)
            //    {
            //        Console.WriteLine("Felaktig inmatning");
            //        break;
            //    }
            //    else
            //    {
            //        priceCalc.Add(AgeChecker(int.Parse(age)));
            //    }
            //}
            //    if (ageList.Count == priceCalc.Count)
            //    {
            //        Console.WriteLine("Korrekt inmatning.");
            //        Console.WriteLine($"Total kostnad för biljetterna: {priceCalc.Sum()}");
            //    }
        
    }
        
}