using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics_Garage_Car_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car();
            car1.Details();
            car1.Brand = "Fiat";
            car1.Model = "126p";
            car1.DoorCount = 2;
            car1.EngineVolume = 650;
            car1.AvgConsump = 6.0;
            car1.RegistrationNumber = "KR12345";
            car1.Details();
            Car car2 = new Car("Syrena", "105", 2, 0.8f, 7.6d, "WE1234");
            car2.Details();
            Console.WriteLine(car1);
            double routeConsumption = car2.CalculateConsump(500);
            Console.WriteLine($"Route consumption: {routeConsumption} liters");
            double routeCost = car2.CalculateCost(500, 5);
            Console.WriteLine($"Route cost: {routeCost}");
            Car.DisplayCarCount();
            Console.WriteLine("\r\n=========================================\r\n");
            Garage garage1 = new Garage();
            garage1.Address = "ul. Garażowa 1";
            garage1.Capacity = 1;
            Garage garage2 = new Garage("ul. Garażowa 2", 2);
            garage1.CarEnter(car1);
            garage1.Details();
            garage1.CarEnter(car2);
            garage2.CarEnter(car2);
            var movedCar = garage1.CarLeave();          //  he equivalent of auto in C# is var - the compiler will deduce the appropriate type . We save the returned car Object 
            garage2.Details();
            garage2.CarEnter(movedCar);
            garage2.Details();
            garage1.Details();
            garage2.CarLeave();
            garage2.Details();
            garage2.CarLeave();
            garage2.CarLeave();
            garage2.Details();
            garage1.Details();
            Console.WriteLine("\r\n=========================================\r\n");
            Person.MaxCarCount = 3;
            Person person1 = new Person();
            person1.FirstName = "Jan";
            person1.LastName = "Kowalski";
            person1.Address = "Al. NMP 1";
            person1.AddCarRegistrationNumber("SCZ 12345");
            person1.AddCarRegistrationNumber("SC 9863");
            person1.AddCarRegistrationNumber("SCZ 37893");
            person1.AddCarRegistrationNumber("SCZ 4912");
            person1.Details();
            Person person2 = new Person("Piotr", "Nowak", "Al. Wolnosci 10");
            person2.AddCarRegistrationNumber("DW 9866");
            person2.Details();
            person2.RemoveCarRegistrationNumber("DW 9866");
            person2.Details();
            person2.RemoveCarRegistrationNumber("DW 9866");

            Console.ReadKey();
        }
    }
}
