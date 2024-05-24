namespace Uzduotis01
{
    // Toliau sukurti dvi subklases, NaftosKuroAutomobilis ir ElektrinisAutomobilis.
    // Kiekviena subklasė turi papildomą atributą, pavyzdžiui, degalų suvartojimas 100 km atstumu arba baterijos krovimo laikas.
    // Taip pat, kiekviena subklasė turi turėti savo konstruktorių, kuris prideda šiuos papildomus atributus, ir tinkamus getterius ir setterius.
    internal class ElectricVehicle : Vehicle
    {
        private int ChargeTime { get; set; }

        public ElectricVehicle(int id, string make, string model, int year, double rate, int chargeTime) : base(id, make, model, year, rate)
        {
            ChargeTime = chargeTime;
        }

        public int GetChargeTime()
        {
            return ChargeTime;
        }
        public void SetChargeTime(int chargeTime)
        {
            ChargeTime = chargeTime;
        }

        public override string ToString()
        {
            int minutes = GetChargeTime();
            int hours = minutes / 60;
            minutes %= 60;

            return $"ID:{GetID():000} {GetMake()} {GetModel()} {GetYear()}, {GetRate():.00}Eur/day, Charge time: {hours:00}h {minutes:00}min";
        }
    }
}
