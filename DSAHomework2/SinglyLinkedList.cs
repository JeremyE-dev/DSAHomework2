using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAHomework2
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public class Element
        {
            internal SinglyLinkedList<T> Owner { get; set; }
            public T Data { get; internal set; }
            public Element Next { get; internal set; }

            internal Element(SinglyLinkedList<T> owner, T data)
            {
                Owner = owner;
                Data = data;
                Next = null;
            }
        }

        public Element Head { get; private set; }
        public Element Tail { get; private set; }
        public int Size { get; private set; }
        public bool Empty { get { return Size == 0; } }

        public Element InsertAfter(Element elem, T data)
        {
            // Check pre-conditions
            if (elem != null && elem.Owner != this)
            {
                throw new ArgumentException("elem does not belong to this list");
            }

            // Insert new element
            var newElem = new Element(this, data);
            if (Size == 0)
            {
                // Only element in the list
                newElem.Next = null;
                Head = newElem;
                Tail = newElem;
            }
            else if (elem == null)
            {
                // New head
                newElem.Next = Head;
                Head = newElem;
            }
            else if (elem == Tail)
            {
                // New tail
                newElem.Next = null;
                elem.Next = newElem;
                Tail = newElem;
            }
            else
            {
                // Middle of the list
                newElem.Next = elem.Next;
                elem.Next = newElem;
            }

            ++Size;

            return newElem;
        }

        public T RemoveAfter(Element elem)
        {
            // Check pre-conditions
            if (Size == 0)
            {
                throw new InvalidOperationException("cannot remove from empty list");
            }
            if (elem != null && elem.Owner != this)
            {
                throw new ArgumentException("elem does not belong to this list");
            }

            // Remove element
            T data;
            if (elem == null)
            {
                // Remove head
                data = Head.Data;
                Head = Head.Next;
            }
            else if (elem.Next == null)
            {
                // Cannot remove after tail
                throw new InvalidOperationException("cannot remove after tail");
            }
            else if (elem.Next == Tail)
            {
                // Remove tail
                data = Tail.Data;
                elem.Next = null;
                Tail = elem;
            }
            else
            {
                // Remove from middle
                data = elem.Next.Data;
                elem.Next = elem.Next.Next;
            }

            --Size;

            return data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var elem = Head; elem != null; elem = elem.Next)
            {
                yield return elem.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
