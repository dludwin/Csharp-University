using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab4
{
    public class List<T> : IList<T>                 // We are inserting new nodes into a list
    {
        private Node<T> _firstElement;

        public int Count
        {
            get
            {
                int count = 0;
                Node<T> current = _firstElement;
                while(current != null)
                {
                    count++;
                    current = current.Next;
                }
                return count;
            }
        }

        public void Add(T item)
        {
            Node<T> element = new Node<T>(item);       // every Node has Prev Next and Value. This new item is new Node
            if (_firstElement == null)
                _firstElement = element;              // list is null then new item is first item
            else
            {
                Node<T> lastElement = _firstElement;
                while (lastElement.Next != null)       // otherwise go from first until current element doesn't have next, so it's last 
                {
                    lastElement = lastElement.Next;   
                }
                lastElement.Next = element;            // when while is over and we found lastElement current lastElement.Next is element
                lastElement.Next.Prev = lastElement;   // and next.prev is current last
            }
        }

        public void Remove(T item)
        {
            Node<T> elementToRemove = _firstElement;
            while (!Equals(item, elementToRemove.Value))      // while will end when item it found
            {
                elementToRemove = elementToRemove.Next;
            }
            elementToRemove.Prev.Next = elementToRemove.Next;   // previous next is current next
            elementToRemove.Next.Prev = elementToRemove.Prev;   // next previous is current previous . Basically skipping that element to remove
        }

        public void Insert(T item, int beforeIndex)       // insert item after beforeIndex
        {
            Node<T> insertElement = new Node<T>(item);    // new Node element to insert
            Node<T> beforeElement = _firstElement;
            for (int i = 0; i != beforeIndex;)         
            {
                beforeElement = beforeElement.Next;
                if (i != beforeIndex) ++i;
            }
            if ((beforeElement.Next != null && beforeElement.Prev != null) ||
                (beforeElement.Next != null && beforeElement.Prev == null))
            {
                beforeElement.Next.Prev = insertElement;        // X   new  X.next
                insertElement.Next = beforeElement.Next;
                beforeElement.Next = insertElement;             //  X   new
                insertElement.Prev = beforeElement;
            }
            else if (beforeElement.Next == null && beforeElement.Prev != null)      // if before is last and list isn't empty
            {
                beforeElement.Next = insertElement;                 
                insertElement.Prev = beforeElement;
            }
        }

        public T Get(int index)
        {
            Node<T> element = _firstElement;     // element to 0 index
            for (int i = 0; i != index;)
            {
                element = element.Next;         // if we don't take 0 index then we must go to the next
                if (i != index) ++i;
            }
            return element.Value;
        }

        public T this[int index]            // Indexer, we can get value with [index]
        {
            get => Get(index);
            set
            {
                Node<T> element = _firstElement;
                for (int i = 0; i != index;)
                {
                    element = element.Next;
                    if (i != index) ++i;
                }
                element.Value = value;
            }
        }

        public IEnumerator<T> GetEnumerator()              // Non-Generic. Required by IInumerable
        {
            return new Enumerator<T>(_firstElement);
        }

        IEnumerator IEnumerable.GetEnumerator()             // Generic
        {
            return new Enumerator<T>(_firstElement);
        }

   

    }
}

