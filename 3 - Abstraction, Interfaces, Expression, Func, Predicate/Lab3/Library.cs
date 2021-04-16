using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Abstraction_Interfaces
{
    public class Library : IItemManagement               // Library has address, librarians and catalogs in Lists . Aggregation so Librarians and catalogs can exist on their own
    {
        public string Address { get; set; }                 // Aggregation means no default constructors
        public IList<Librarian> Librarians { get; set; }    // aggregation 1 to 0..*  means: 1 Library and 0..* Librarians
        public IList<Catalog> Catalogs { get; set; }        // aggregation 1 to 0..*  

        public Library(string address, IList<Librarian> librarians, IList<Catalog> catalogs)
        {
            Address = address;
            Catalogs = catalogs;
            Librarians = librarians;
        }

        // Library doesn't have default constructor because this is aggregation and not composition. Aggregation is weaker than composition, Librarians and Catalogs can exist without library

        public void AddLibrarian(Librarian librarian)
        {
            if (librarian != null)                
                Librarians.Add(librarian);
        }

        public void ShowAllLibrarians()        
        {
            string str = "Librarians: \r\n";            // string to copy to plus intro carriage return is ok but not necessary
            foreach (var librarian in Librarians)       // iterate over each item
            {
                str += librarian + "\r\n";             // add ToString() of every individual instance in Librarians to str 
            }
            Console.WriteLine(str);
        }

        public void AddCatalog(Catalog catalog)
        {
            if (catalog != null)                // check if catalog isn't empty
                Catalogs.Add(catalog);          // Add to list
        }

        public void AddItem(Item item, string thematicDepartment)       // item = pozycja
        {
            if (string.IsNullOrWhiteSpace(thematicDepartment) || item == null) return;              // Error check. Even in void function we can return
            var catalog = Catalogs.FirstOrDefault(x => x.ThematicDepartment == thematicDepartment);    // Returns the first element of a sequence, or a default value if no element is found.
            catalog?.AddItem(item);    // if catalog exists then add found item
        }

        public void ShowAllItems()           // first implemented method from IItemManagement
        {
            foreach (var catalog in Catalogs)
            {
                Console.WriteLine(catalog);     // calls ToString()
            }
        }

        public Item FindItemById(int id)
        {
            foreach (var catalog in Catalogs)    // for each Catalog
            {
                foreach (var item in catalog.Items)    // for each Item in each Catalog
                {
                    if (item.Id == id)
                        return item;
                }
            }
            throw new Exception("Item of given id is not found");   // throw new Exception if Item isn't present in Catalogs
        }

        public Item FindItemByTitle(string title)
        {
            foreach (var catalog in Catalogs)
            {
                foreach (var item in catalog.Items)
                {
                    if (String.Compare(item.Title, title, StringComparison.Ordinal) == 0)      // StringComparison.Ordinal is good for String.Compare
                        return item;
                }
            }
            throw new Exception("Item of given title is not found");
        }

        public Item FindItemExpressionFunc(Expression<Func<Item, bool>> predicate)
        {
            var item = Catalogs.SelectMany(x => x.Items).FirstOrDefault(predicate.Compile());     // this has to be Catalogs.SelectMany because Items aren't here they are in Catalogs. This returns just one flattened list
            if (item != null)
                return item;
            throw new Exception("Item is not found");
        }

        // Catalogs.SelectMany(x => x.Items)   is looping through all Items. Then first encounter or default value with that predicate

        // Select gets a list of lists of phone numbers
        // IEnumerable<IEnumerable<PhoneNumber>> phoneLists = people.Select(p => p.PhoneNumbers);

        // SelectMany flattens it to just a list of phone numbers.
        // IEnumerable<PhoneNumber> phoneNumbers = people.SelectMany(p => p.PhoneNumbers);

        public override string ToString()
        {
            var str = $"LIBRARY \r\n Address: {Address}\r\n Librarians: \r\n";
            foreach (var librarian in Librarians)
                str += librarian;
            str += " Catalogs: \r\n ";
            foreach (var catalog in Catalogs)
                str += catalog;
            return str;
        }
    }
}



// string[] names = { "Hartono, Tommy", "Adams, Terry",
//                     "Andersen, Henriette Thaulow",
//                     "Hedlund, Magnus", "Ito, Shu" };

// string firstLongName = names.FirstOrDefault(name => name.Length > 20);

// Console.WriteLine("The first long name is '{0}'.", firstLongName);

// string firstVeryLongName = names.FirstOrDefault(name => name.Length > 30);

// Console.WriteLine(
//    "There is {0} name longer than 30 characters.",
//    string.IsNullOrEmpty(firstVeryLongName) ? "not a" : "a");

///*
// This code produces the following output:

// The first long name is 'Andersen, Henriette Thaulow'.
// There is not a name longer than 30 characters.
//*/



//class PetOwner
//{
//    public string Name { get; set; }
//    public List<string> Pets { get; set; }
//}

//public static void SelectManyEx3()
//{
//    PetOwner[] petOwners =
//        { new PetOwner { Name="Higa",
//              Pets = new List<string>{ "Scruffy", "Sam" } },
//          new PetOwner { Name="Ashkenazi",
//              Pets = new List<string>{ "Walker", "Sugar" } },
//          new PetOwner { Name="Price",
//              Pets = new List<string>{ "Scratches", "Diesel" } },
//          new PetOwner { Name="Hines",
//              Pets = new List<string>{ "Dusty" } } };

//    // Project the pet owner's name and the pet's name.
//    var query =
//        petOwners
//        .SelectMany(petOwner => petOwner.Pets, (petOwner, petName) => new { petOwner, petName })
//        .Where(ownerAndPet => ownerAndPet.petName.StartsWith("S"))
//        .Select(ownerAndPet =>
//                new
//                {
//                    Owner = ownerAndPet.petOwner.Name,
//                    Pet = ownerAndPet.petName
//                }
//        );

//    // Print the results.
//    foreach (var obj in query)
//    {
//        Console.WriteLine(obj);
//    }
//}