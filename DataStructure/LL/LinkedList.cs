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

            Node current = _root;
            for(int i = 1; i <= Lenght/2; i++)
            {
                Node tmp = _root;
                for (int j= 0; j<Lenght-i; j++)
                {
                    tmp = tmp.Next;
                }
                int t = current.Value;
                current.Value = tmp.Value;
                tmp.Value = t;
                current = current.Next;
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
            return 1;
        }

        public int GetIndexOfMinElement()
        {
            if (Lenght == 0)
            {
                throw new InvalidOperationException();
            }
            return 1;
        }

        public void QuickSort()
        {

        }

        public void QuickSortDecrease()
        {

        }

        public void DeleteFirstElementWithValue(int value)
        {

        }

        public void DeleteElementsWithValue(int value)
        {

        }

        public void AddArrayToEnd(int[] array)
        {

        }

        //public void AddArrayToEnd(int[] array)
        //{

        //}

        public void AddArrayToBiginning(int[] array)
        {

        }

        public void AddArrayTo(int idx, int[] array)
        {

        }

        public void DeleteNElementsFromEnd(int number)
        {

        }

        public void DeleteNElementsFromBiginning(int number)
        {

        }

        public void DeleteNElementsFrom(int idx, int number)
        {

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

    }
}
