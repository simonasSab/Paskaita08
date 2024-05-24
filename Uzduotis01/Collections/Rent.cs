using System.Security.Cryptography.X509Certificates;

namespace Uzduotis01
{
    // Galų gale, parašykite klasę Nuoma, kurioje yra sąrašas su turimais automobiliais.
    // Sukurti metodus, kurie leistų pridėti naujus automobilius į sąrašą, pasiimti automobilį iš sąrašo ir apskaičiuoti nuomos kainą už nurodytą dienų skaičių.
    // Pridėti viso autoparko atspausdinimą.
    internal class Rent
    {
        private List<Vehicle> RentVehicles { get; set; }
        private int RentID { get; set; }

        public Rent()
        {
            RentVehicles = new();
            RentID = 0;
        }

        public void AddVehicle(Vehicle? vehicle)
        {
            if (vehicle != null)
            {
                RentVehicles.Add(vehicle);
                RentID++;
                Console.WriteLine($"Now renting {vehicle.ToString()}, Rent ID:{RentID:000}\n");
            }
        }

        public void PrintList()
        {
            if (RentVehicles.Count > 0)
            {
                for (int i = 0; i < RentVehicles.Count; i++)
                {
                    Console.WriteLine($"Rent ID:{RentID:000}, {RentVehicles[i].ToString()}");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Rent car list is empty.\n");
            }
        }

        public bool IDExists(int id)
        {
            if (RentVehicles.Count > 0)
            {
                for (int i = 0; i < RentVehicles.Count; i++)
                {
                    if (RentVehicles[i].GetID() == id)
                        return true;
                }
                Console.WriteLine("ID not found\n");
                return false;
            }
            else
            {
                Console.WriteLine("Rent car list is empty.\n");
                return false;
            }
        }
    }
}
