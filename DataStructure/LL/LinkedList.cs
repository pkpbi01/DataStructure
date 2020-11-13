using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.LinkedLists
{
    public class LinkedList
    {
        public int Lenght { get; set; }

        private Node _root;

        public int this[int idx]
        {
            get
            {
                if(idx >= Lenght || idx < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                Node tmp = _root;
                for (int i = 1; i <= idx; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }
            set
            {
                if (idx >= Lenght || idx < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                Node tmp = _root;
                for (int i = 1; i <= idx; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }

        public LinkedList()
        {
            Lenght = 0;
        }

        public LinkedList(int value)
        {
            _root = new Node(value);
            Lenght = 1;
        }

        public LinkedList(int[] array)
        {
            if (array.Length != 0)
            {
                _root = new Node(array[0]);
                Node tmp = _root;

                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new Node(array[i]);
                    tmp = tmp.Next;
                }
                Lenght = array.Length;
            }
            else
            {
                Lenght = 0;
                _root = null;
            }
        }



        public void AddToEnd(int value)
        {
            Node current = _root;
            for (int i = 1; i < Lenght; i++)
            {
                current = current.Next;
            }
            Node tmp = current.Next;
            current.Next = new Node(value);
            current.Next.Next = tmp;
            Lenght++;
        }

        public void AddToBiginning(int value)
        {
            Node tmp = _root;
            _root = new Node(value);
            _root.Next = tmp;
            Lenght++;
        }

        public void AddTo(int idx, int value)
        {
            if ((idx >= Lenght || idx < 0) && idx != 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (idx == 0)
            {
                Node tmp = _root;
                _root = new Node(value);
                _root.Next = tmp;
            }
            else
            {
                Node current = _root;
                for (int i = 1; i < idx; i++)
                {
                    current = current.Next;
                }
                Node tmp = current.Next;
                current.Next = new Node(value);
                current.Next.Next = tmp;
            }
            Lenght++;
        }

        public void DeleteFromEnd()
        {
            Node current = _root;
            for (int i = 1; i < Lenght-1; i++)
            {
                current = current.Next;
            }
            
            current.Next = null;
            Lenght--;
        }

        public void DeleteFromBiginning()
        {
            _root = _root.Next;
            Lenght--;
        }

        public void DeleteFrom(int idx)
        {
            if (idx >= Lenght || idx < 0)
            {
                throw new IndexOutOfRangeException();
            }
            Node current = _root;
            if (idx == 0)
            {
                _root = _root.Next;
            }
            for (int i = 1; i < idx; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
            Lenght--;
        }

        public int GetLenght()
        {
            return Lenght;
        }

        public int GetByIndex(int idx)
        {
            if (idx >= Lenght || idx < 0)
            {
                throw new IndexOutOfRangeException();
            }
            Node tmp = _root;
            for(int i = 1; i <= idx; i++){
                tmp = tmp.Next;
            }
            return tmp.Value;
        }

        public int GetIndexByValue(int value)
        {
            if (_root.Value == value)
            {
                return 0;
            }
            Node tmp = _root;
            for (int i = 1; i<Lenght; i++)
            {
                tmp = tmp.Next;
                if (tmp.Value == value)
                {
                    return i;
                }
                
            }
            throw new ArgumentException();
        }

        public void ReversList()
        {
            if (_root != null)
            {
                Node head = _root;
                Node curRoot = _root;
                Node tmp = _root;
                Node fir = _root;
                while (head.Next != null)
                {
                    fir = curRoot;
                    curRoot = head.Next;
                    tmp = head.Next.Next;
                    head.Next.Next = fir;
                    head.Next = tmp;
                }
                _root = curRoot;
            }
        }

        public int GetMaxElement()
        {
            if (Lenght == 0)
            {
                throw new InvalidOperationException();
            }
            Node tmp = _root;
            int max = tmp.Value;
            for(int i = 1; i<Lenght; i++)
            {
                tmp = tmp.Next;
                if (tmp.Value > max)
                {
                    max = tmp.Value;
                }
            }
            return max;
        }

        public int GetMinElement()
        {
            if (Lenght == 0)
            {
                throw new InvalidOperationException();
            }
            Node tmp = _root;
            int min = tmp.Value;
            for(int i = 1; i < Lenght; i++)
            {
                tmp = tmp.Next;
                if(tmp.Value < min)
                {
                    min = tmp.Value;
                }                
            }
            return min;
        }

        public int GetIndexOfMaxElement()
        {
            if (Lenght == 0)
            {
                throw new InvalidOperationException();
            }
            Node tmp = _root;
            int max = tmp.Value;
            int idx = 0;
            for (int i = 1; i < Lenght; i++)
            {
                tmp = tmp.Next;
                if (tmp.Value > max)
                {
                    max = tmp.Value;
                    idx = i;
                }
            }
            return idx;
        }

        public int GetIndexOfMinElement()
        {
            if (Lenght == 0)
            {
                throw new InvalidOperationException();
            }
            Node tmp = _root;
            int min = tmp.Value;
            int idx = 0;
            for (int i = 1; i < Lenght; i++)
            {
                tmp = tmp.Next;
                if (tmp.Value < min)
                {
                    min = tmp.Value;
                    idx = i;
                }
            }
            return idx;
        }

        public void QuickSort()
        {

        }

        public void QuickSortDecrease()
        {

        }

        public void DeleteFirstElementWithValue(int value)
        {
            if (_root.Value == value)
            {
                _root = _root.Next;
                Lenght--;
            }
            else
            {
                Node previous = _root;
                Node current = _root.Next;

                while (current != null)
                {
                    if (current.Value == value)
                    {
                        previous.Next = current.Next;
                        Lenght--;
                        return;
                    }
                    previous = current;
                    current = current.Next;
                }
            }

        }

        public void DeleteElementsWithValue(int value)
        {
            while (_root != null && _root.Value == value)
            {
                _root = _root.Next;
                Lenght--;
            }
            if(_root != null)
            {
                Node previous = _root;
                Node current = _root.Next;

                while (current != null)
                {
                    if (current.Value == value)
                    {
                        previous.Next = current.Next;
                        Lenght--;
                        current = previous;
                    }

                    previous = current;
                    current = current.Next;
                }
            }

        }

        public void AddArrayToEnd(int[] array)
        {
            LinkedList added = new LinkedList(array);
            Node first = added._root;
            Node tmp = _root;
            if (_root != null)
            {
                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = first;
            }
            else
            {
                _root = first;
            }
            Lenght += array.Length;

        }

        public void AddArrayToBiginning(int[] array)
        {
            LinkedList added = new LinkedList(array);
            if(added._root != null)
            {
                Node first = added._root;
                Node tmp = _root;
                if (_root != null)
                {
                    _root = added._root;
                    while (first.Next != null)
                    {
                        first = first.Next;
                    }
                    first.Next = tmp;
                }
                else
                {
                    _root = first;
                }
                Lenght += array.Length;
            }

        }

        public void AddArrayTo(int idx, int[] array)
        {
            if (idx != 0 && idx >= Lenght || idx < 0)
            {
                throw new IndexOutOfRangeException();
            }
            LinkedList added = new LinkedList(array);
            Node first = added._root;
            Node tmp = _root;
            if (_root != null)
            {
                for(int i = 1; i < idx; i++)
                {
                    tmp = tmp.Next;
                }
                Node sup = tmp.Next;
                tmp.Next = first;
                while(tmp.Next != null)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = sup;
            }
            else
            {
                _root = first;
            }
            Lenght += array.Length;

        }

        public void DeleteNElementsFromEnd(int number)
        {
            if (number > Lenght || number < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Node tmp = _root;
            for (int i = 1; i < Lenght - number; i++)
            {
                tmp = tmp.Next;
            }
            tmp.Next = null;
            Lenght -= number;
        }

        public void DeleteNElementsFromBiginning(int number)
        {
            if (number > Lenght || number < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Node tmp = _root;
            if (number != 0) {
                for (int i = 1; i < number; i++)
                {
                    tmp = tmp.Next;
                }
                _root = tmp.Next;
                Lenght -= number;
            }
            
        }

        public void DeleteNElementsFrom(int idx, int number)
        {
            if (idx > Lenght || idx < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (number + idx > Lenght || number < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Node first = _root;
            Node second = _root;
            if (number != 0)
            {
                for (int i = 0; i < idx + number - 1; i++)
                {
                    second = second.Next;

                }
                for (int i = 0; i < idx - 1; i++)
                {
                    first = first.Next;
                }
                if (idx == 0)
                {
                    _root = second.Next;
                }
                first.Next = second.Next;
            }
            Lenght -= number;

        }





        public override bool Equals(object obj)
        {
            LinkedList linkedList = (LinkedList)obj;

            if (Lenght != linkedList.Lenght)
            {
                return false;
            }

            Node tmp1 = _root;
            Node tmp2 = linkedList._root;
            for (int i = 0; i < Lenght; i++)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            return true;
        }

        public override string ToString()
        {
            string s = "";
            if (_root != null)
            {
                Node tmp = _root;
                while (tmp.Next != null)
                {
                    s += tmp.Value + ";";
                    tmp = tmp.Next;
                }
                s += tmp.Value + ";";
            }
            return s;
        }

        private Node GetNodeByIndex(int idx)
        {
            if (idx >= Lenght || idx < 0)
            {
                throw new IndexOutOfRangeException();
            }
            Node tmp = _root;
            for (int i = 1; i <= idx; i++)
            {
                tmp = tmp.Next;
            }
            return tmp;
        }

    }
}
