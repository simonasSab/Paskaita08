namespace Uzduotis01
{
    // Sukurkite automobilių nuomos sistemą.
    // Jums reikės sukurti pagrindinę klasę Automobilis, kuri turės šiuos atributus: marke, modelis, metai ir kaina už dieną.
    // Sukurkite reikiamus getterius ir setterius, taip pat konstruktorių, leidžiantį sukurti automobilio objektą su nurodytais atributais.
    // Toliau sukurti dvi subklases, NaftosKuroAutomobilis ir ElektrinisAutomobilis.
    // Kiekviena subklasė turi papildomą atributą, pavyzdžiui, degalų suvartojimas 100 km atstumu arba baterijos krovimo laikas.
    // Taip pat, kiekviena subklasė turi turėti savo konstruktorių, kuris prideda šiuos papildomus atributus, ir tinkamus getterius ir setterius.
    // Galų gale, parašykite klasę Nuoma, kurioje yra sąrašas su turimais automobiliais.
    // Sukurti metodus, kurie leistų pridėti naujus automobilius į sąrašą, pasiimti automobilį iš sąrašo ir apskaičiuoti nuomos kainą už nurodytą dienų skaičių.
    // Pridėti viso autoparko atspausdinimą. Susikūrus klasę autoparkas prisidėti sąrašą automobilių.
    internal class Program
    {
        private static Fleet fleet = new();
        private static Rent rent = new();
        private static int fleetID = 0;

        public static void Main(string[] args)
        {
            MainMenu();
        }

        private static void MainMenu()
        {
            int selection;
            bool isInt;
            do
            {
                Console.WriteLine("1.Create electric car and add to fleet" +
                                "\n2.Create generic product and add to fleet" +
                                "\n3.Display all fleet" +
                                "\n4.Display electric fleet" +
                                "\n5.Display fossil fuel fleet" +
                                "\n6.Calculate rent price for amount of days" +
                                "\n7.Rent a car" +
                                "\n           0. Quit.\n");
                isInt = int.TryParse(Console.ReadLine(), out selection);
                Console.WriteLine();
            }
            while (!isInt || selection < 0 || selection > 7);

            switch (selection)
            {
                case 0:
                    Console.WriteLine($"Quitting.");
                    return;
                case 1: // Create electric car and add to fleet
                    fleet.AddVehicle(NewElectricVehicle());
                    break;
                case 2: // Create generic product and add to fleet
                    fleet.AddVehicle(NewFossilFuelVehicle());
                    break;
                case 3: // Display all fleet
                    fleet.PrintList();
                    break;
                case 4: // Display electric fleet
                    fleet.PrintList(true);
                    break;
                case 5: // Display fossil fuel fleet
                    fleet.PrintList(false);
                    break;
                case 6: // Calculate rent price for amount of days
                    fleet.PrintList();
                    fleet.CalculateAndDisplayRentPrice(SelectDaysToRent(), SelectFleetID());
                    break;
                case 7: // Rent a car
                    fleet.PrintList();
                    rent.AddVehicle(fleet.Vehicles[fleet.GetIndexFromID(SelectFleetID())]);
                    break;
                default:
                    Console.WriteLine($"Unexpected error - program is quitting.");
                    return;
            }
            MainMenu();
        }

        public static ElectricVehicle? NewElectricVehicle()
        {
            Random random = new();
            // Get make
            string make = $"Tesla{random.Next(1, 10)}";
            // Get model
            string model = $"Leaf{random.Next(1, 100):00}";
            // Get year
            int year = random.Next(2009, 2025);
            // Get rent rate
            double rate = 29 + (year - 2008);
            // Get charge time
            int chargeTime = 125 - (year - 2008) * 5;

            // Create product and return it
            ElectricVehicle? vehicle = new(fleetID, make, model, year, rate, chargeTime);
            fleetID++;

            return vehicle;
        }

        public static FossilFuelVehicle? NewFossilFuelVehicle()
        {
            Random random = new();
            // Get make
            string make = $"Mustang{random.Next(1,10)}";
            // Get model
            string model = $"Beast{random.Next(1,100):00}";
            // Get year
            int year = random.Next(2009, 2025);
            // Get rent rate
            double rate = 19 + (year - 2008);
            // Get charge time
            double fuelConsumption = 8.1 - (year - 2008) * 0.1;

            // Create product and return it
            FossilFuelVehicle? vehicle = new(fleetID, make, model, year, rate, fuelConsumption);
            fleetID++;

            return vehicle;
        }

        public static int SelectFleetID()
        {
            int id;
            bool isInt;
            do
            {
                Console.WriteLine("Enter vehicle ID number... (Cancel: -1)\n");
                isInt = int.TryParse(Console.ReadLine(), out id);
                if (id == -1)
                {
                    Console.WriteLine("\nCancelled\n");
                    return id;
                }
            }
            while (!isInt || !fleet.IDExists(id));

            Console.WriteLine();

            return id;
        }

        public static int SelectDaysToRent()
        {
            int days;
            bool isInt;
            do
            {
                Console.WriteLine("How many days to rent? (Cancel: -1)\n");
                isInt = int.TryParse(Console.ReadLine(), out days);
                if (days == -1)
                {
                    Console.WriteLine("\nCancelled\n");
                    return days;
                }
            }
            while (!isInt || days < 1);

            Console.WriteLine();

            return days;
        }
    }
}