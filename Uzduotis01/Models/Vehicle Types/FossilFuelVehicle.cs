namespace Uzduotis01
{
    // Toliau sukurti dvi subklases, NaftosKuroAutomobilis ir ElektrinisAutomobilis.
    // Kiekviena subklasė turi papildomą atributą, pavyzdžiui, degalų suvartojimas 100 km atstumu arba baterijos krovimo laikas.
    // Taip pat, kiekviena subklasė turi turėti savo konstruktorių, kuris prideda šiuos papildomus atributus, ir tinkamus getterius ir setterius.
    internal class FossilFuelVehicle : Vehicle
    {
        private double FuelConsumption { get; set; }

        public FossilFuelVehicle(int id, string make, string model, int year, double rate, double fuelConsmption) : base(id, make, model, year, rate)
        {
            FuelConsumption = fuelConsmption;
        }

        public double GetFuelConsumption()
        {
            return FuelConsumption;
        }
        public void SetFuelConsumption(int fuelConsumption)
        {
            FuelConsumption = fuelConsumption;
        }

        public override string ToString()
        {
            return $"ID:{GetID():000} {GetMake()} {GetModel()} {GetYear()}, {GetRate():.00}Eur/day, Fuel consumption: {GetFuelConsumption():.0} l/100km";
        }
    }
}
