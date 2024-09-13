internal class Program
{
    private static void Main(string[] args)
    {
        bool programOn = true;
        string input;
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
                    AgeChecker(IntputChecker());
                    break;
                    case "2":GroupPriceCalculator(); break;
                default:
                    Console.WriteLine("Felaktig inmatning. Vänligen skriv endast siffran för det alternativ du vill välja, tryck sedan enter.");
                    break;
            }
        }
        while (programOn);


    }
    private static int IntputChecker()
    {

        bool correctInput = false;
        string input;
        int numberInput;
        do
        {
            input = Console.ReadLine();
            correctInput = int.TryParse(input, out _);
            if (!correctInput)
                Console.WriteLine("Felaktig inmatning. Vänligen skriv endast siffror, bekräfta sedan med enter.");
            
        }
         while (!correctInput || string.IsNullOrWhiteSpace(input));
        return int.Parse(input);
        }
    private static int AgeChecker(int age)
    {
        int price;
        if (age <20)
        {
            price = 80;
            Console.WriteLine($"Ungdomspris: {price}kr");
        }
        else if (age > 64)
        {
            price = 90;
            Console.WriteLine($"Pensionärpris: {price}kr");
        }
        else
        {
            price = 120;
            Console.WriteLine($"Standardpris: {price}kr");
        }
        return price;
    }
    private static void GroupPriceCalculator()
    {
        int guestCount;
        bool correctInput = false;
        
            Console.WriteLine("Hur många personer är i sällskapet?");
            guestCount = IntputChecker();
            
            Console.WriteLine($"Du har angett {guestCount}.");
        

        while (!correctInput) { 
        Console.WriteLine($"Skriv åldern på alla {guestCount} deltagare. Separera med mellanslag.");
        List<string> ageList = new List<string>(Console.ReadLine().Split(' '));

            List<int> priceCalc = new List<int>();

        foreach (string age in ageList)
        {
            Console.WriteLine($"{age} ");
            correctInput = int.TryParse(age, out _);

            if (!correctInput)
            {
                Console.WriteLine("Felaktig inmatning");
                break;
            }
            else
            {
                priceCalc.Add(AgeChecker(int.Parse(age)));
            }
        }
            if (ageList.Count == priceCalc.Count)
            {
                Console.WriteLine("Korrekt inmatning.");
                Console.WriteLine($"Total kostnad för biljetterna: {priceCalc.Sum()}");
            }
        }
    }
        
}