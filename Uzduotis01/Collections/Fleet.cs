namespace Uzduotis01
{
    // Susikūrus klasę autoparkas prisidėti sąrašą automobilių.
    // Pridėti viso autoparko atspausdinimą.
    internal class Fleet
    {
        public List<Vehicle> Vehicles { get; set; }

        public Fleet()
        {
            Vehicles = new();
        }

        public void AddVehicle(Vehicle? vehicle)
        {
            if (vehicle != null)
            {
                Vehicles.Add(vehicle);
                Console.WriteLine("Added to fleet: " + vehicle.ToString() + "\n");
            }
        }

        public void RemoveVehicle(Vehicle? vehicle)
        {
            if (vehicle != null)
            {
                Vehicles.Remove(vehicle);
                Console.WriteLine("Removed from fleet: " + vehicle.ToString() + "\n");
            }
        }

        public void PrintList()
        {
            if (Vehicles.Count > 0)
            {
                for (int i = 0; i < Vehicles.Count; i++)
                {
                    Console.WriteLine(Vehicles[i].ToString());
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Fleet is empty.\n");
            }
        }

        public void PrintList(bool electric)
        {
            if (Vehicles.Count > 0)
            {
                for (int i = 0; i < Vehicles.Count; i++)
                {
                    if (electric && Vehicles[i].GetType() == typeof(ElectricVehicle))
                    {
                        Console.WriteLine(Vehicles[i].ToString());
                    }
                    else if (!electric && Vehicles[i].GetType() == typeof(FossilFuelVehicle))
                    {
                        Console.WriteLine(Vehicles[i].ToString());
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Fleet is empty.\n");
            }
        }

        public bool IDExists(int id)
        {
            if (Vehicles.Count > 0)
            {
                for (int i = 0; i < Vehicles.Count; i++)
                {
                    if (Vehicles[i].GetID() == id)
                        return true;
                }
                Console.WriteLine("ID not found\n");
                return false;
            }
            else
            {
                Console.WriteLine("Fleet is empty.\n");
                return false;
            }
        }

        public int GetIndexFromID(int id)
        {
            if (Vehicles.Count > 0)
            {
                for (int i = 0; i < Vehicles.Count; i++)
                {
                    if (Vehicles[i] != null && Vehicles[i].GetID() == id)
                        return i;
                }
                Console.WriteLine("\nError: vehicle ID not found.\n");
                return -1;
            }
            else
            {
                Console.WriteLine("Fleet is empty.\n");
                return -1;
            }
        }

        public void CalculateAndDisplayRentPrice(int days, int id)
        {
            double rate = Vehicles[GetIndexFromID(id)].GetRate();
            double cost = (double)days * rate;
            Console.WriteLine($"Rent of vehicle ID:{id:000} for {days} day(s) costs {cost:.00} Eur\n({rate:.00 Eur/day})\n");
        }
    }
}
