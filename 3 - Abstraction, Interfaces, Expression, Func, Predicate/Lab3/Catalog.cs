using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Abstraction_Interfaces
{
    /// <summary>
    /// Katalog
    /// </summary>
    public class Catalog : IItemManagement
    {

        public IList<Item> Items { get; set; }
        public string ThematicDepartment { get; set; }

        public Catalog(IList<Item> items)        // List<Item> items if fine but it's generic that way
        {
            Items = items;
            ThematicDepartment = "NONE";
        }

        public Catalog(string thematicDepartment, IList<Item> items)
        {
            Items = items;
            ThematicDepartment = thematicDepartment;
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public Item FindItemExpressionFunc(Expression<Func<Item, bool>> predicate)  // In program take catalog by iteration over every item and checking for true
        {
            var item = Items.First(predicate.Compile());   // we have this list of items here in Catalog
            return item;
        }

        public Item FindItemByTitle(string title)
        {
            foreach (var item in Items)
                if (String.Compare(item.Title, title, StringComparison.Ordinal) == 0)
                    return item;
            return null;
        }

        public Item FindItemById(int id)
        {
            foreach (var item in Items)
                if (item.Id == id)
                    return item;
            return null;
        }
        public override string ToString()
        {
            var str = "CATALOG:\r\n";
            str += $"Thematic department: {ThematicDepartment} \r\n ITEMS: \r\n";
            foreach (var item in Items)
                str += item + "\r\n";
            return str;
        }

        public void ShowAllItems()
        {
            var str = "Catalog ITEMS: \r\n";
            foreach (var item in Items)
                str += item + "\r\n";
            Console.WriteLine(str);
        }

    }
}
