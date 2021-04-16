using System;

namespace Abstraction_Interfaces
{
    /// <summary>
    /// Czasopismo
    /// </summary>
    public class Journal : Item
    {
        public int Number { get; set; }

        public Journal():base()
        {
            Number = 0;
        }

        public Journal(string title, int id, string publisher, DateTime dateOfIssue, int number)
            :base(title, id, publisher, dateOfIssue)
        {
            Number = number;
        }

        public override string ToString()
        {
            return base.ToString() + $", Journal Number {Number}";
        }
        public override void Details()
        {
            Console.WriteLine(this);
        }
    }
}
