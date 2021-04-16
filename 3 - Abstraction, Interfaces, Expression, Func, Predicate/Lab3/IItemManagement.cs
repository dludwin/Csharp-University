using System;
using System.Linq.Expressions;

namespace Abstraction_Interfaces
{
    /// <summary>
    /// IZarzadzaniePozycjami
    /// </summary>
   public interface IItemManagement       // Interface in C# is a blueprint(design plan or other technical drawing) of a class. It is like abstract class because all the methods which are declared inside the interface are abstract methods. It cannot have method body and cannot be instantiated. It is used to achieve multiple inheritance which can't be achieved by class.
    {                                     // Interface declares it's own methods but doesnt't declare it. Interface can't be inilialized
        void ShowAllItems();               // Child classes(implementing classes) must implement all of it's methods and properties.
        Item FindItemById(int id);             // Interfaces can't have fields( field is a variable that is declared directly in a class or struct ) 
        Item FindItemByTitle(string title);                              // all members of interface have to be public
        Item FindItemExpressionFunc(Expression<Func<Item, bool>> predicate);                  // Class can inherit from many interfaces simultaneously
    }
}

// Func<T,TResult> Delegate
// Encapsulates a method that has one parameter and returns a value of the type specified by the TResult parameter.

// Predicate<T> is a functional construct providing a convenient way of basically testing if something is true of a given T object.

// The Predicate will always return a boolean, by definition.

// Predicate<T> is basically identical to Func<T, bool>.

// Action is a delegate (pointer) to a method, that takes zero, one or more input parameters, but does not return anything.

// Func is a delegate (pointer) to a method, that takes zero, one or more input parameters, and returns a value (or reference).

// Predicate is a special kind of Func often used for comparisons.

// Func<int, int> square = x => x * x;         delegate to a method that takes int and returns int
// Console.WriteLine(square(5));
// Output:
// 25

// Expression lambdas can also be converted to the expression tree types, as the following example shows:

// System.Linq.Expressions.Expression<Func<int, int>> e = x => x * x;
// Console.WriteLine(e);
// Output:
// x => (x * x)


// Why would you use Expression<Func<T>> rather than Func<T>? 

// Use Expression<Func<T>> When you want to treat lambda expressions as expression trees and look inside them instead of just executing them.
// LINQ to SQL gets the expression and converts it to the equivalent SQL statement and submits it to the server(rather than executing the lambda)
// Func<T> denotes a delegate which is pointer to a method

// Expression<Func<T>> denotes a tree date structure for a lambda expression.
// This tree structure describes what lambda expression does rather than the actual thing.
// It basically holds data about the composition of expressions, variables, methods calls.
// You can use this description to convert it to an actual method with Expression.Compile
// Or do other stuff like LINQ to SQL with it.
// Func<int> myFunc = () => 10; will compile to an IL(Intermediate Language) method that gets nothing and returns 10
// Expression<Func<int>> myExpression = () => 10; will be converted to data structure that describes an expression that gets no parameters and returns 10
// Using LINQ-SQL with just Func is OutofMemoryException on larger datasets. It will iterate over each row  looking for matches

// Expression<Func<T,bool>>. Expression simply turns a delegate into a data about itself
// LINQ-SQL or others needs an Expression. Func donesn't carry information of how to translate it into a SQL/Mongo/other query
// Expression, on the other hand, allows you to look inside the delegate and see everything it wants to do.
// This empowers you to translate the delegate into whatever you want, like a SQL query
// Func didn't work because DbContext was blind to the contents of the lambda expression

// IQueryable extends IEnumerabe so IEnumerable's methods like Where() obtain overloads that accept Expression.
// When you pass expression to that, you keep an IQueryable as a result, but when you pass a Func
// you're falling back to the base IEnumerable and you'll get an IEnumerable as a result. 
// In other words, without noticing you've turned your dataset into a list to be iterated as opposed to something to query.
