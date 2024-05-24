namespace Uzduotis01
{
    // Jums reikės sukurti pagrindinę klasę Automobilis, kuri turės šiuos atributus: marke, modelis, metai ir kaina už dieną.
    // Sukurkite reikiamus getterius ir setterius, taip pat konstruktorių, leidžiantį sukurti automobilio objektą su nurodytais atributais.
    internal class Vehicle
    {
        private int ID { get; set; }
        private string Make { get; set; }
        private string Model { get; set; }
        private int Year { get; set; }
        private double Rate { get; set; }

        public Vehicle(int id, string make, string model, int year, double rate)
        {
            ID = id;
            Make = make;
            Model = model;
            Year = year;
            Rate = rate;
        }
        public int GetID()
        {
            return ID;
        }
        public void SetID(int id)
        {
            ID = id;
        }

        public string GetMake()
        {
            return Make;
        }
        public void SetMake(string newValue)
        {
            Make = newValue;
        }
        public string GetModel()
        {
            return Model;
        }
        public void SetModel(string newValue)
        {
            Model = newValue;
        }
        public int GetYear()
        {
            return Year;
        }
        public void SetYear(int newValue)
        {
            Year = newValue;
        }
        public double GetRate()
        {
            return Rate;
        }
        public void SetRate(double newValue)
        {
            Rate = newValue;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            Vehicle vehicle = (Vehicle)obj;
            if (vehicle.GetID() == this.ID)
                return true;

            return false;
        }
    }
}
