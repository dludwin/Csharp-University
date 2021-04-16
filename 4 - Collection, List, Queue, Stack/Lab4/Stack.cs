using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
   public class Stack<Type>                           // LIFO last in first out
   {
       private Node<Type> _topELement;              

       public Stack()
       {
           _topELement = null;
       }
       public void Push(Type item)
       {
           if (item == null)
               throw new Exception("The item is null");
           Node<Type> newElement = new Node<Type>(item);
           if (_topELement == null)
               _topELement = newElement;
           else
           {
               newElement.Prev = _topELement;                        // add to the end and get from the end
               _topELement = newElement;
           }
        }

       public Type Pop()
       {
           if (_topELement == null) throw new Exception("Stack is empty");
           var currentElement = _topELement;
           _topELement = _topELement.Prev;
           return currentElement.Value;
        }
   }
}
