using System;
using System.Collections.Generic;

namespace Abstraction_Interfaces
{
    class Program           // 60% of screen code  40% UML
    {
        static void Main()
        {
            Item item1 = new Journal("JAISCR", 1, "Springer", new DateTime(2000, 1, 1), 1);
            Item item3 = new Journal("RCSISJ", 3, "Springer", new DateTime(2000, 1, 1), 1);
            Author author = new Author("Robert", "Cook", "Polish");
            Item item2 = new Book("Agile C#", 2, "SPRINGER", new DateTime(2015, 1, 1), 500);
            ((Book)item2).AddAuthor(author);
            IList<Item> items = new List<Item>();
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            Catalog catalog = new Catalog("IT C# development", items);
            Console.WriteLine(catalog);
            //--- find position
            string valueObtainedFromUser = "Agile C#";

            Item foundedItemById = catalog.FindItemExpressionFunc(item => item.Id == 1);
            Item foundedItemByTitle = catalog.FindItemExpressionFunc(item => item.Title == valueObtainedFromUser);
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Console.WriteLine(foundedItemById);
            Console.WriteLine(foundedItemByTitle);
            Item foundedOldWayId = catalog.FindItemById(1);
            Item foundedOldWayTitle = catalog.FindItemByTitle("Agile C#");
            Console.WriteLine("Found old way");
            Console.WriteLine(foundedOldWayId);
            Console.WriteLine(foundedOldWayTitle);
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            catalog.ShowAllItems();
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Console.WriteLine("ZAD 2");
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Person librarian = new Librarian("John", "Kowalsky", DateTime.Now.Date, 2000);
            Library library = new Library("Czestochowa, Armii Krajowej 36", new List<Librarian>(), new List<Catalog>());
            library.AddLibrarian((Librarian) librarian);              // Use polymorphism here
            library.ShowAllLibrarians();
            Catalog catalog2 = new Catalog("Novels", new List<Item>());
            library.AddCatalog(catalog2);
            library.AddCatalog(catalog);
            Item newItem = new Book("Song of Ice and FIre", 4, "Publisher", new DateTime(2011, 1, 1), 800);
            library.AddItem(newItem, "Novels");
            Console.WriteLine(library);
            Console.WriteLine("===========================ALL ITEMs=======================\r\n");
            library.ShowAllItems();
            Console.WriteLine("===========================FIND BY=======================\r\n");
            var findById = library.FindItemById(4);
            var findByTitle = library.FindItemByTitle("Agile C#");
            var findByLambda = library.FindItemExpressionFunc(x => x.Publisher == "Springer");  // nie wyswietla wszystkich tylko pierwszy
            Console.WriteLine(findById);
            Console.WriteLine(findByTitle);
            Console.WriteLine(findByLambda);   
            Console.ReadKey();
        }
    }
}
