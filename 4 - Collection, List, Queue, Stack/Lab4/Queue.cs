using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Queue<Type>                  // FIFO First in First out
    {
        private Node<Type> _firstElement;

        public Queue()
        {
            _firstElement = null;
        }

        public void Enqueue(Type item)                  // Add element to Queue
        {
            if (item == null)
                throw new Exception("The item is null");
            Node<Type> newElement = new Node<Type>(item);      // Create new node
            if (_firstElement == null)
                _firstElement = newElement;
            else
            {
                Node<Type> lastElement = _firstElement;       // we go different direction, first is last and last is first. Return first and add to last
                while (lastElement.Prev != null)
                {
                    lastElement = lastElement.Prev;
                }
                lastElement.Prev = newElement;
            }
        }

        public Type Dequeue()
        {
            if (_firstElement == null) throw new Exception("Queue is empty");
            var currentElement = _firstElement;
            _firstElement = _firstElement.Prev;
            return currentElement.Value;
        }
    }
}
