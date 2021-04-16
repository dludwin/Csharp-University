using System;

namespace Abstraction_Interfaces
{
    /// <summary>
    ///  Pozycja
    /// </summary>
    public abstract class Item               // UML in cursive. Abstract class cannot be initialized. It's used as a base for other classes. Child class must implement all of it's abstact methods and properties.
    {                                                           // Abstract class can have not abstract methods and properties that aren't abstract. 
        public string Title { get; protected set; }
        public int Id { get; protected set; }
        public string Publisher { get; protected set; }
        public DateTime DateOfIssue { get; protected set; }

        public Item()
        {
            Title = "NONE";
            Id = 0;
            Publisher = "NONE";
            DateOfIssue = default(DateTime);    
        }

        public Item(string title, int id, string publisher, DateTime dateOfIssue)
        {
            Title = title;
            Id = id;
            Publisher = publisher;
            DateOfIssue = dateOfIssue;
        }

        public override string ToString()
        {
            return $"ITEM : || ID: {Id}, Title {Title}, Publisher {Publisher}, Date of Issue: {DateOfIssue}";
        }

        public virtual void MoreDetails()   // Virtual method can be overrides by child class
        {
            Console.Write("Information");

            // instructions
        }

        public abstract void Details();     // abstract method needs to be in abstract class, but abstract class doen't need to have abstract method.
    }                                       // abstract method has only declaration. Have implementation in child classes. Can't be private method.
}                                           // GeometricFigure g = new Square(5.0); GeometricFigure is abstract class
