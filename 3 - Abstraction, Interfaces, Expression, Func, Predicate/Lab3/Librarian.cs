using System;

namespace Abstraction_Interfaces
{
    /// <summary>
    /// Bibliotekarz
    /// </summary>
    public class Librarian : Person
    {
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }          // good for currencies, no problems with division leakage
        public Librarian():base()
        {
            HireDate = default(DateTime);
            Salary = 0.0m;
        }

        public Librarian(string firstName, string lastName, DateTime hireDate, decimal salary)
         :base(firstName, lastName)
        {
            HireDate = hireDate;
            Salary = salary;
        }

        public override string ToString()
        {
            return base.ToString() + $"Hire date: {HireDate}, Salary: {Salary}";
        }
    }
}
