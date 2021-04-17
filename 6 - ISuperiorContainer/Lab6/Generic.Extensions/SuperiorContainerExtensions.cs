using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Generic.Extensions
{
    public static class SuperiorContainerExtensions       // static class and static methods
    {                            // Set  = group of unique values. Generic method
        public static IList<T> Set<T, TSetSuperiorContainer>(this TSetSuperiorContainer container)  // this means that we expend that type
            where T : IInfo where TSetSuperiorContainer : ISuperiorContainer         // T has to implement IInfo and TSet.. implements ISuper.. cage,cagesupervisor,zoo
        {
            Type containerType = container.GetType();            // Uses reflection. In runtime gets dynamically information about data types. Gets every information about container, parameters, inheritance, fields, constructors,filters, what is it, how many etc methods
            var propertyInfo = containerType.GetProperties().FirstOrDefault(p => p.PropertyType == typeof(IList<T>));
            var propertyValue = propertyInfo?.GetValue(container);  // if not null then we get it.         // Get Properties - All properties, FirstOrDefault is filter that gets first match that has list. typeof returns type of IList, typeof knows at compilation time. GetType na etapie uruchomienia
            return propertyValue as IList<T>;    // unboxing from general type to specific type of IList // returns generic IList of elements T
        }

        public static void ForEach<T>(this IList<T> list, Action<T> action)      // Action - add,read etc. Returns void. Func returns bool, so thats predicate
        {
            foreach (T t in list)
                action(t);           // for each element we run that action
        }

        public static IList<T> AddRange<T>(this IList<T> list, IList<T> elementsToAdd)
        {
            foreach (var element in elementsToAdd)
                list.Add(element);                 // extend list, for example list+list2
            return list; 
        }

        public static T Get<T>(this ISuperiorContainer container, Func<T, bool> searchPredicate = null) where T: IInfo
        {
            return searchPredicate == null ?
                container.Set<T, ISuperiorContainer>().FirstOrDefault() :      // null
                container.Set<T, ISuperiorContainer>().FirstOrDefault(searchPredicate);   // not null
        }    
           // here we use previously defined Set
        public static IList<T> GetList<T>(this ISuperiorContainer container, Func<T, bool> searchPredicate = null) where T: IInfo
        {
            return searchPredicate == null ? container.Set<T, ISuperiorContainer>() : container.Set<T, ISuperiorContainer>().Where(searchPredicate).ToList();
        }

        public static TSetSuperiorContainer Add<T, TSetSuperiorContainer>(this TSetSuperiorContainer container, T element) where TSetSuperiorContainer : ISuperiorContainer where T: IInfo
        {
            container.Set<T, TSetSuperiorContainer>().Add(element);
            return container;
        }


        public static TSetSuperiorContainer AddRange<T, TSetSuperiorContainer>(this TSetSuperiorContainer container, IList<T> element) where TSetSuperiorContainer : ISuperiorContainer where T: IInfo
        {
            container.Set<T, TSetSuperiorContainer>().AddRange(element);
            return container;
        }

        public static T Remove<T>(this ISuperiorContainer container, Func<T,bool> searchPredicate) where T: IInfo
        {
            var obj = container.Set<T, ISuperiorContainer>().SingleOrDefault(searchPredicate);
            if(obj != null)
            {
                container.Set<T, ISuperiorContainer>().Remove(obj);
            }
            return obj;
        }

        public static T AddInto<T>(this T obj, ISuperiorContainer container) where T : IInfo
        {
            container.Set<T, ISuperiorContainer>().Add(obj);
            return obj;
        }    
    }
}





















