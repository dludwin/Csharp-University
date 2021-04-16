using System;

namespace Abstraction_Interfaces
{

    public class Person
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }

        public Person()
        {
            FirstName = "none";
            LastName = "none";
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }



        public override string ToString()
        {
            return $"Person data | First name: {FirstName}, Last name: {LastName} ";
        }

        public virtual void Details()
        {
            Console.WriteLine(this);
        }
    }
}
