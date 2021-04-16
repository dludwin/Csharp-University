using System;         // This is used for common basic operations, Console.WriteLine() etc.

namespace Basics_Garage_Car_Person              // Every file with this namespace will make classes within it cooperate
{
    /// <summary>
    /// Auto-properties weren't used in this example
    /// </summary>
    public class Car
    {
        private string _brand;
        private string _model;
        private int _doorCount;                 // without auto-properties _variable
        private float _engineVolume;
        private double _avgConsump;
        private string _registrationNumber;

        private static int _carCount = 0;        // Static variable means that is just one and every new Cars constructor will increment that value

        public string Brand                   // That's property. It's getting and setting variable. That one is basic so auto-properties could be used here
        {
            get { return _brand; }
            set { _brand = value; }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public int DoorCount
        {
            get { return _doorCount; }
            set { _doorCount = value; }
        }

        public float EngineVolume
        {
            get { return _engineVolume; }
            set { _engineVolume = value; }
        }

        public double AvgConsump
        {
            get { return _avgConsump; }
            set { _avgConsump = value; }
        }

        public string RegistrationNumber
        {
            get => _registrationNumber;                    // "expression-bodied members". They are similar to lambdas, but still fundamentally different. Obviously they can't capture local variables like lambdas do. Also, unlike lambdas, they are accessible via their name:) You will probably understand this better if you try to pass an expression-bodied property as a delegate.
            set => _registrationNumber = value;
        }

        public Car()
        {
            _avgConsump = 0.0;
            _brand = "none";
            _doorCount = 0;
            _engineVolume = 0.0F;
            _model = "none";
            _registrationNumber = "none";
            _carCount++;
        }

        public Car(string brand, string model, int doorCount, float engineVolume, double avgConsump, string registrationNumber)
        {
            _brand = brand;
            _model = model;
            _doorCount = doorCount;
            _engineVolume = engineVolume;
            _avgConsump = avgConsump;
            _registrationNumber = registrationNumber;
            _carCount++;                              // increment static variable
        }

        public override string ToString()            // Every class inherits from Object class so we can overrise ToString() method 
        {
            return $"Car | Brand: {_brand}, Model: {_model}, NumOfDoors: {_doorCount}, EngineVol: {_engineVolume}, AvgConsump: {_avgConsump}, RegistrationNumber: {_registrationNumber}";   // $"text {variable}"
        }

        public double CalculateConsump(double roadLength)
        {
            return (_avgConsump * roadLength) / 100.0;
        }

        public double CalculateCost(double roadLength, double petrolCost)
        {
            return CalculateConsump(roadLength) * petrolCost;
        }

        public void Details()
        {
            Console.WriteLine(this);   // this.ToString() by default
        }

        public static void DisplayCarCount()
        {
            Console.WriteLine($"Car instances count: {_carCount}");
        }

    }
}
