using System;
using System.Collections.Generic;
using System.Text;

namespace Generic.Extensions
{
    public static class PrintExtensions       // dotted line in ClassDiagram is static
    {                                         // We can use extensionable methods because of using this operator
        public static T Print<T>(this T obj) where T:IInfo       // for single element
        {
            Console.WriteLine(obj);
            return obj;
        }

        public static IList<T> Print<T>(this IList<T> set) where T: IInfo     // List of elements
        {                                                                     // extend List not just type
            set.ForEach(d => Console.WriteLine(d));
            return set;
        }

        public static T PrintInfo<T>(this T obj) where T : IInfo
        {
            obj.Display();                         // Display from IInfo method
            return obj;
        }

        public static IList<T> PrintInfo<T>(this IList<T> set) where T:IInfo
        {
            set.ForEach(d => d.Display());          
            return set;
        }
    }
}
