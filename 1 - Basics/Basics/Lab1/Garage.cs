using System;

namespace Basics_Garage_Car_Person
{
    /// <summary>
    /// Auto-properties were used in this example
    /// </summary>
    public class Garage
    {
        public Car[] Cars { get; set; }              // Table of cars. Aggregation
 
        public string Address { get; set; }          // auto-properties were used to shorten the code
        public int CarsCount { get; set; }
        private int _capacity;

        public int Capacity                          // property
        {
            get => _capacity;                        // "expression-bodied members". They are similar to lambdas
            set
            {
                _capacity = value;
                Cars = new Car[value];       // when we call constructor we also call this function and allocate specified amount of space 
            }
        }

        public Garage()
        {
            Capacity = 0;
            Address = "none";
            CarsCount = 0;                           // garage is created but empty for now
        }

        public Garage(string address, int capacity)
        {
            Capacity = capacity;
            Address = address;
            CarsCount = 0;
        }

        public void CarEnter(Car car)
        {
            if (CarsCount >= Capacity)
                Console.WriteLine($"The garage at {Address} is full.");
            else
            {
                Cars[CarsCount] = car;             
                CarsCount++;                        // if capacity wasn't reached then increment car count
            }
        }

        public Car CarLeave()                      // This function returns the car Object or null
        {
            if (CarsCount == 0)
            {
                Console.WriteLine("There is no cars to leave.");
                return null;
            }
            else
            {
                Car car = Cars[CarsCount - 1];        // Indexing from 0. Create copy of that memory
                Cars[CarsCount - 1] = null;           // one reference is pointing to null but car is still pointing to that value
                CarsCount--;
                return car;
            }
        }

        public override string ToString()           // override the Object class method 
        {
            string str = $"Garage | Address: {Address}, Capacity: {Capacity}, Cars count: {CarsCount} \r\n CARS: \r\n";     // \r means carriage return. It means that the cursor should go back to the beginning of the line.
            foreach (var car in Cars)
                str += car + "\r\n";                                                                // car calls Car's ToString() method
            str +="+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++";
            return str;
        }

        public void Details()
        {
            Console.WriteLine(this);
        }
    }
}
