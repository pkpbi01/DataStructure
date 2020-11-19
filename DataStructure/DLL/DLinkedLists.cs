using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.DLinkedList
{
    public class DLinkedList
    {
        public int Lenght { get; set; }

        private DNode _head;

        private DNode _tail;

        public int this[int idx]
        {
            get
            {
                if (idx >= Lenght || idx < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                DNode tmp;
                if (idx < Lenght / 2)
                {
                    tmp = _head;
                    for (int i = 1; i <= idx; i++)
                    {
                        tmp = tmp.Next;
                    }
                }
                else
                {
                    tmp = _tail;
                    for (int i = Lenght-1; i > idx; i--)
                    {
                        tmp = tmp.Previous;
                    }
                }

                return tmp.Value;
            }
            set
            {
                if (idx >= Lenght || idx < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                DNode tmp;
                if (idx < Lenght / 2)
                {
                    tmp = _head;
                    for (int i = 1; i <= idx; i++)
                    {
                        tmp = tmp.Next;
                    }
                }
                else
                {
                    tmp = _tail;
                    for (int i = Lenght; i > idx; i--)
                    {
                        tmp = tmp.Previous;
                    }
                }
                tmp.Value = value;
            }
        }

        public DLinkedList()
        {
            Lenght = 0;
        }

        public DLinkedList(int value)
        {
            _head = new DNode(value);
            _tail = _head;
            Lenght = 1;
        }

        public DLinkedList(int[] array)
        {
            if (array.Length != 0)
            {
                _head = new DNode(array[0]);
                _tail = _head;
                DNode tmp = _head;

                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new DNode(array[i]);
                    tmp.Next.Previous = tmp;
                    tmp = tmp.Next;
                    _tail = tmp;
                }
                Lenght = array.Length;
            }
            else
            {
                Lenght = 0;
                _head = null;
                _tail = null;
            }
        }


        public void AddToEnd(int value)
        {
            if (Lenght == 0)
            {
                _head = new DNode(value);
                _tail = _head;
            }
            else
            {
                DNode current = _tail;
                DNode tmp = current.Next;
                current.Next = new DNode(value);
                current.Next.Previous = _tail;
                current.Next.Next = tmp;
                _tail = current.Next;
                if (Lenght == 1)
                {
                    _head.Next = _tail;
                }
            }
            Lenght++;
        }

        public void AddToBiginning(int value)
        {
            if (Lenght == 0)
            {
                _head = new DNode(value);
                _tail = _head;
            }
            else
            {
                DNode tmp = _head;
                _head.Previous = new DNode(value);
                _head.Previous.Previous = null;
                _head.Previous.Next = tmp;
                _head = tmp.Previous;
            }
            Lenght++;
        }

        public void AddTo(int idx, int value)
        {            
            if (Lenght == 0)
            {
                _head = new DNode(value);
                _tail = new DNode(value);
            }
            else
            {                
                DNode current = _head;
                if (idx <= Lenght / 2)
                {
                    for (int i = 1; i <= idx; i++)
                    {
                        current = current.Next; 
                    }
                    DNode tmp = current.Next;
                    current.Next = new DNode(value);
                    current.Next.Next = tmp;
                    DNode tmp2 = current.Previous;
                    current.Previous = new DNode(value);
                    current.Previous.Previous = tmp2;                    
                }
                else
                {
                    current = _tail;
                    for (int i = Lenght - 1; i > idx; i--)
                    {
                        current = current.Previous;
                    }
                    DNode tmp = current.Previous;
                    DNode tmp2 = current.Previous.Next;
                    current.Previous = new DNode(value);
                    current.Previous.Previous = tmp;
                    tmp.Next = current.Previous;
                    current.Previous.Next = tmp2;
                                       
                    
                }

            }
            Lenght++;
        }

        public void DeleteFromEnd()
        {

        }

        public void DeleteFromBiginning()
        {

        }

        public void DeleteFrom(int idx)
        {

        }

        public int GetLenght()
        {
            return 1;
        }

        public int GetByIndex(int idx)
        {
            return 1;
        }

        public int GetIndexByValue(int value)
        {
            return 1;
        }

        public void ReversList()
        {

        }

        public int GetMaxElement()
        {
            return 1;
        }

        public int GetMinElement()
        {
            return 1;
        }

        public int GetIndexOfMaxElement()
        {
            return 1;
        }

        public int GetIndexOfMinElement()
        {
            return 1;
        }

        public void Sort()
        {

        }

        public void SortDecrease()
        {

        }

        public void DeleteFirstElementWithValue(int value)
        {

        }

        public void DeleteElementsWithValue(int value)
        {

        }

        //public void AddToEnd(int[] array)
        //{

        //}

        //public void AddToBiginning(int[] array)
        //{

        //}

        //public void AddTo(int idx, int[] array)
        //{

        //}

        //public void DeleteFromEnd(int n)
        //{

        //}

        //public void DeleteFromBiginning(int n)
        //{

        //}

        //public void DeleteFrom(int idx, int n)
        //{

        //}

        public override bool Equals(object obj)
        {
            DLinkedList dlinkedList = (DLinkedList)obj;

            if (Lenght != dlinkedList.Lenght)
            {
                return false;
            }

            DNode tmpHead1 = _head;
            DNode tmpTail1 = _tail;
            DNode tmpHead2 = dlinkedList._head;
            DNode tmpTail2 = dlinkedList._tail;
            for (int i = 0; i < Lenght; i++)
            {
                if (tmpHead1.Value != tmpHead2.Value && tmpTail1.Value != tmpTail2.Value)
                {
                    return false;
                }
                tmpHead1 = tmpHead1.Next;
                tmpHead2 = tmpHead2.Next;
                tmpTail1 = tmpTail1.Previous;
                tmpTail2 = tmpTail2.Previous;
            }
            return true;
        }
    }
}
