using System;

namespace Inheritance_Lists
{
  ///
    public class Person          // Base class
    {
        protected string _firstName;
        protected string _lastName;
        protected DateTime _dateOfBirth;    // It's more flexible than regular string as date. And easier to use

        public Person()
        {
            DateOfBirth = new DateTime(); //default(DateTime);
            FirstName = "none";
            LastName = "none";
        }

        /// <summary>
        /// Konstruktor klasy 
        /// </summary>
        /// <param name="firstName">imie</param>
        /// <param name="lastName">nazwisko</param>
        /// <param name="dateOfBirth"></param>
        public Person(string firstName, string lastName, DateTime dateOfBirth)   // new DateTime(1986, 8, 10,..defaults)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public string FirstName                  // property calls protected variable
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public override string ToString()
        {
            return $"Person data | First name: {FirstName}, Last name: {LastName}, Date of birth: {DateOfBirth} ";
        }

        public virtual void Details()    // It's not abstract method so class doesn't have to be abstract
        {
            Console.WriteLine(this);
        }
    }
}
