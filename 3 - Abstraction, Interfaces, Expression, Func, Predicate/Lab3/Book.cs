using System;
using System.Collections.Generic;

namespace Abstraction_Interfaces
{
    /// <summary>
    /// Ksiażka
    /// </summary>
    public class Book : Item
    {
        public int PageCount { get; set; }
        public IList<Author> Authors { get; set; }

        public Book() : base()
        {
            PageCount = 0;
            Authors = new List<Author>();
        }

        public Book(string title, int id, string publisher, DateTime dateOfIssue, int pageCount)
        : base(title, id, publisher, dateOfIssue)
        {
            PageCount = pageCount;
            Authors = new List<Author>();
        }
        public override string ToString()
        {
            var str = base.ToString() + $", Page count: {PageCount} \r\n Authors: \r\n";
            foreach (var author in Authors)
                str += author + "\r\n";
            return str;
        }
        public override void Details()
        {
            Console.WriteLine(this);
        }

        public void AddAuthor(Author author)
        {
            Authors.Add(author);
        }
    }
}
