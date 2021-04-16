namespace Abstraction_Interfaces
{
    public class Author : Person
    {
        public string Nationality { get; set; }

        public Author()
        {
            Nationality = "NONE";
        }

        public Author(string firstName, string lastName, string nationality) : base(firstName, lastName)
        {
            Nationality = nationality;
        }

        public override string ToString()
        {
            return base.ToString() + $"Nationality: {Nationality} ";
        }
    }
}
