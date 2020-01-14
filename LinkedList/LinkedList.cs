using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedList<Type> : IList<Type> where Type : IComparable<Type>
    {
        private class Node<Type>
        {
            public Node(Type data)
            {
                Data = data;
            }
            public Type Data { get; set; }
            public Node<Type> Next { get; set; }
        }

        Node<Type> head;
        int count;

        public Type this[int index]
        {
            get
            {
                Node<Type> node = GetElement(index);
                return node.Data;
            }
            set
            {
                Node<Type> node = GetElement(index);
                node.Data = value;
            }
        }

        private Node<Type> GetElement(int index)
        {
            Node<Type> node = head;
            while (index > 0 && node.Next != null)
            {
                node = node.Next;
                index--;
            }

            if (index == 0)
            {
                return node;
            }

            throw new ArgumentOutOfRangeException();
        }

        //добавление
        public void Add(Type data)
        {
            Node<Type> node = new Node<Type>(data);

            if (head == null)
            {
                head = node;
            }
            Node<Type> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = node;
            node.Next = null;

            count++;
        }

        //удаление
        public bool Remove(Type data)
        {
            Node<Type> current = head;
            Node<Type> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                    }
                    else
                    {
                        head = head.Next;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        //количество
        public int Count
        {
            get
            {
                return count;
            }
        }

        //проверка на пустоту
        public bool IsEmpty
        {
            get
            {
                return count == 0;
            }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        //очистка
        public void Clear()
        {
            head = null;
            count = 0;
        }

        //содержание элемента
        public bool Contains(Type data)
        {
            Node<Type> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        //индекс первого вхождения элемента
        public int IndexOf(Type data)
        {
            var index = 0;
            Node<Type> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1;
        }

        //добвление в начало
        public void AppendFirst(Type data)
        {
            Node<Type> node = new Node<Type>(data);
            node.Next = head;
            head = node;
            count++;
        }

        //реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Type> GetEnumerator()
        {
            Node<Type> current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public void Insert(int index, Type data)
        {
            if (count == 0)
            {
                AppendFirst(data);
                return;
            }

            if(count == index)
            {
                Add(data);
                return;
            }
            
            Node<Type> node = GetElement(index - 1);
            Node<Type> newNode = new Node<Type>(data);
            newNode.Next = node.Next;

            node.Next = newNode;
            count++;
        }

        public void RemoveAt(int index)
        {
            if (index > 0)
            {
                Node<Type> node = GetElement(index - 1);
                Node<Type> node2 = GetElement(index);
                if (node2.Next != null)
                {
                    node.Next = node2.Next;
                }
                else
                {
                    node.Next = null;
                }
            }
            else
            {
                Node<Type> node = head.Next;
                head = node;
            }
        }

        public void CopyTo(Type[] array, int arrayIndex)
        {
            if (array.Length < Count + arrayIndex)
            {
                throw new ArgumentOutOfRangeException();
            }

            Node<Type> node = head;
            var i = 0;

            while (node != null)
            {
                array[arrayIndex + i] = node.Data;
                node = node.Next;
                i++;
            }
        }
    }
}