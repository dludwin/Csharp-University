using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics_Garage_Car_Person
{
    /// <summary>
    /// Auto-properties were used in this example
    /// </summary>
    public class Person
    {
        public static int MaxCarCount { get; set; }    

        public string FirstName { get; set; }               //  =  { get { return FirstName;} set { FirstName = value;} }
        public string LastName { get; set; }       
        public string Address { get; set; }
        public int CarsCount => RegistationNumbers.Count;     
        public IList<string> RegistationNumbers { get; set; }     //  The idea is that you hide the implementation details from the user, and instead provide them with a stable interface. This is to reduce dependency on details that might change in the future
                                                                  // Say you had originally used List<T> and wanted to change to use a specialized CaseInsensitiveList<T>, both of which implement IList<T>. If you use the concrete type all callers need to be updated. If exposed as IList<T> the caller doesn't have to be changed
        public Person()
        {
            FirstName = "none";
            LastName = "none";
            Address = "none";
            RegistationNumbers = new List<string>();   //  we cannot create instance for an IList as it is an interface
        }

        public Person(string firstName, string lastName, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            RegistationNumbers = new List<string>();                // We could provide values with constructor
        }

        public void AddCarRegistrationNumber(string registrationNumber)
        {
            if (MaxCarCount <= RegistationNumbers.Count)
                Console.WriteLine("The Person already have maximum number of cars");
            else
                RegistationNumbers.Add(registrationNumber);
        }

        public void RemoveCarRegistrationNumber(string registrationNumber)
        {
            string regNum = RegistationNumbers.FirstOrDefault(x => x.CompareTo(registrationNumber) == 0);
            if (regNum == null)
                Console.WriteLine($"The given registration number is not assigned to a person.");
            else
                RegistationNumbers.Remove(registrationNumber);
        }

        public override string ToString()
        {
            string str = $"First name: {FirstName}, Last name: {LastName}, Address: {Address}, Cars count: {CarsCount} \r\n Registration numbers: ";
            foreach (var regNum in RegistationNumbers)
                str += regNum  +", ";                    // get the value and then separator
            return str;
        }
        public void Details()
        {
            Console.WriteLine(this);
        }

    }
}
