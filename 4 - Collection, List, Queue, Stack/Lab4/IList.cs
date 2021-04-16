using System;
using System.Collections.Generic;

namespace Lab4
{
    public interface IList<Type>:IEnumerable<Type>      // Interface so every method has to be implemented in implementing classes. IEnumerable has to be implemented in implementing classes so we can iterate over different collections
    {                                                                 // Beacuse of this we can use Find where single All Any methods foreach etc. Without it we can't do anything
        void Add(Type item);
        void Remove(Type item);
        void Insert(Type item, int beforeIndex);
        Type Get(int index);
        Type this[int i] { get; set; }

        int Count { get; }
    }
}
