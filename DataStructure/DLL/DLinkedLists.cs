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
                DNode tmp = GetDNodeByIndex(idx);

                return tmp.Value;
            }
            set
            {
                DNode tmp = GetDNodeByIndex(idx);
                tmp.Value = value;
            }
        }

        public DLinkedList()
        {
            _head = null;
            _tail = null;
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
                Lenght++;
            }
            else
            {
                if (idx == 0)
                {
                    AddToBiginning(value);
                }
                else
                {
                    DNode current = GetDNodeByIndex(idx - 1);
                    DNode tmp = current.Next;
                    current.Next = new DNode(value);
                    current.Next.Next = tmp;
                    current.Next.Previous = tmp.Previous;
                    tmp.Previous = current.Next;
                    Lenght++;

                }
            }
        }

        public void DeleteFromEnd()
        {
            if (Lenght == 0)
            {
                throw new InvalidOperationException();
            }
            if (Lenght > 1)
            {
                DNode tmp = GetDNodeByIndex(Lenght - 2);
                _tail = tmp;
                tmp.Next = null;
                Lenght--;
            }
            else
            {
                _head = null;
                _tail = null;
                Lenght = 0;
            }
        }

        public void DeleteFromBiginning()
        {
            if (Lenght == 0)
            {
                throw new InvalidOperationException();
            }
            if (Lenght > 1)
            {
                DNode tmp = GetDNodeByIndex(1);
                _head = tmp;
                tmp.Previous = null;
                Lenght--;
            }
            else
            {
                _head = null;
                _tail = null;
                Lenght = 0;
            }
        }

        public void DeleteFrom(int idx)
        {
            if (Lenght == 0)
            {
                throw new InvalidOperationException();
            }

            if (idx == 0 && Lenght > 1)
            {
                DeleteFromBiginning();
            }

            else if (idx == Lenght - 1 && Lenght > 1)
            {
                DeleteFromEnd();
            }

            else if (Lenght > 1 && idx != 0 && idx != Lenght)
            {
                DNode tmp = GetDNodeByIndex(idx);
                tmp.Next.Previous = tmp.Previous;
                tmp.Previous.Next = tmp.Next;
                Lenght--;
            }
            else
            {
                _head = null;
                _tail = null;
                Lenght = 0;
            }




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
            DNode tmp = GetDNodeByIndex(idx);
            return tmp.Value;
        }

        public int GetIndexByValue(int value)
        {
            if (_head.Value == value)
            {
                return 0;
            }
            DNode tmp = _head;
            for (int i = 1; i < Lenght; i++)
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
            if (Lenght == 0)
            {
                return;
            }
            DNode current = _head;
            _tail = _head;
            DNode tmp;
            while (current.Next != null)
            {
                tmp = current.Next;
                current.Next = current.Previous;
                current.Previous = tmp;
                current = current.Previous;
            }
            current.Next = current.Previous;
            current.Previous = null;
            _head = current;

        }

        public int GetMaxElement()
        {
            if (Lenght == 0)
            {
                throw new InvalidOperationException();
            }
            DNode tmp = _head;
            int max = tmp.Value;
            for (int i = 1; i < Lenght; i++)
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
            DNode tmp = _head;
            int min = tmp.Value;
            for (int i = 1; i < Lenght; i++)
            {
                tmp = tmp.Next;
                if (tmp.Value < min)
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
            DNode tmp = _head;
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
            DNode tmp = _head;
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

        public void Sort()
        {
            DLinkedList list = new DLinkedList();
            list._head = _head;
            list._tail = _tail;
            list.Lenght = Lenght;
            list = MergeSort(list);
            _head = list._head;
            _tail = list._tail;
        }

        public void SortDecrease()
        {
            DLinkedList list = new DLinkedList();
            list._head = _head;
            list._tail = _tail;
            list.Lenght = Lenght;
            list = MergeSort(list);
            _head = list._head;
            _tail = list._tail;
            ReversList();
        }

        public void DeleteFirstElementWithValue(int value)
        {
            if(Lenght == 1 && _head.Value == value)
            {
                _head = null;
                _tail = null;
                Lenght = 0;
                return;
            }
            if (_head.Value == value)
            {
                _head = _head.Next;
                _head.Previous = null;
                Lenght--;
                return;
            }
            else
            {
                DNode current = _head;
                while (current.Next != null)
                {
                    if (current.Value == value)
                    {
                        DNode tmp = current.Next;
                        DNode tmp2 = current.Previous;
                        current.Next.Previous = tmp2;
                        current.Previous.Next = tmp;
                        Lenght--;
                        return;
                    }
                    
                    current = current.Next;
                }
            }
            if(_tail.Value == value)
            {
                _tail = _tail.Previous;
                Lenght--;
                
            }
        }

        public void DeleteElementsWithValue(int value)
        {
            while (_head != null && _head.Value == value)
            {
                _head = _head.Next;
                if(_head != null)
                {
                    _head.Previous = null;
                }
                Lenght--;
            }
            if (_head != null)
            {
                DNode cur = _head; 
                while(cur != null)
                {
                    if (cur.Value == value)
                    {
                        DNode tmp = cur.Next;
                        cur.Previous.Next = tmp;
                        if (tmp != null)
                        {
                            tmp.Previous = cur.Previous;
                        }
                        else
                        {
                            _tail = cur.Previous;
                        }
                        Lenght--;
                        cur = cur.Previous;
                    }
                    cur = cur.Next;
                }
            }

        }

        public void AddToEnd(int[] array)
        {
            
            DLinkedList added = new DLinkedList(array);
            if(Lenght == 0)
            {
                _head = added._head;
                _tail = added._tail;
            }
            else if (added.Lenght != 0)
            {
                _tail.Next = added._head;
                added._head.Previous = _tail;
                _tail = added._tail;
                
            }
            Lenght += added.Lenght;
        }

        public void AddToBiginning(int[] array)
        {
            DLinkedList added = new DLinkedList(array);
            if (Lenght == 0)
            {
                _head = added._head;
                _tail = added._tail;
            }
            else if (added.Lenght != 0)
            {
                DNode tmp = _head;
                _head = added._head;
                added._tail.Next = tmp;
                tmp.Previous = added._tail;

            }
            Lenght += added.Lenght;
        }

        public void AddTo(int idx, int[] array)
        {
            if(idx != 0 && (idx < 0 || idx >= Lenght))
            {
                throw new IndexOutOfRangeException();
            }
            DLinkedList added = new DLinkedList(array);
            if (Lenght == 0)
            {
                _head = added._head;
                _tail = added._tail;
            }
            else if (added.Lenght != 0)
            {
                DNode cur = GetDNodeByIndex(idx-1);
                DNode tmp = cur.Next;
                cur.Next = added._head;
                added._head.Previous = cur;
                added._tail.Next = tmp;
                tmp.Previous = added._tail;


            }
            Lenght += added.Lenght;
        }

        public void DeleteFromEnd(int n)
        {
            if (n > Lenght || n < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Lenght != 0 && n < Lenght)
            {
                DNode cur = GetDNodeByIndex(Lenght - (n+1));
                cur.Next = null;
                _tail = cur;
                Lenght -= n;
            }
            if (n == Lenght)
            {
                _head = null;
                _tail = null;
                Lenght = 0;
            }
        }

        public void DeleteFromBiginning(int n)
        {
            if (n > Lenght || n < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Lenght != 0 && n < Lenght)
            {
                DNode cur = GetDNodeByIndex(n);
                cur.Previous = null;
                _head = cur;
                Lenght -= n;
            }
            if (n == Lenght)
            {
                _head = null;
                _tail = null;
                Lenght = 0;
            }
        }

        public void DeleteFrom(int idx, int n)
        {
            if (idx > Lenght || idx < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (n + idx > Lenght || n < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (idx != 0 && idx + n != Lenght)
            {
                DNode cur = GetDNodeByIndex(idx - 1);
                DNode tmp = GetDNodeByIndex(idx + n);
                cur.Next = tmp;
                if (tmp != null)
                {
                    tmp.Previous = cur;
                }
                Lenght -= n;
            }
            else if (idx == 0)
            {
                DeleteFromBiginning(n);
            }
            else
            {
                DeleteFromEnd(n);
            }
        }

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
                if (tmpHead1.Value != tmpHead2.Value || tmpTail1.Value != tmpTail2.Value)
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


        public override string ToString()
        {
            string s = "";
            if (_head != null)
            {
                DNode tmp = _head;
                while (tmp.Next != null)
                {
                    s += tmp.Value + ";";
                    tmp = tmp.Next;
                }
                s += tmp.Value + ";";
            }
            return s;
        }

        private DNode GetDNodeByIndex(int idx)
        {
            if (idx >= Lenght || idx < 0)
            {
                throw new IndexOutOfRangeException();
            }
            DNode tmp;
            if (idx <= Lenght / 2)
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
                for (int i = Lenght - 1; i > idx; i--)
                {
                    tmp = tmp.Previous;
                }
            }
            return tmp;
        }

        static private DLinkedList MergeSort(DLinkedList list)
        {
            DLinkedList finishList = new DLinkedList();
            DLinkedList supList = new DLinkedList();
            DNode current = list._head;
            DNode tmp = list._head;
            int curLength = list.Lenght;
            if (curLength < 2)
            {
                return list;
            }
            int tL = curLength / 2;
            for (int i = 1; i < tL; i++)
            {
                current = current.Next;
            }
            tmp = current.Next;
            DNode tmp2 = current.Next.Previous;
            supList._tail = list._tail;
            current.Next.Previous = null;
            current.Next = null;
            list._tail = current;
            supList._head = tmp;
            if (curLength % 2 == 0)
            {
                list.Lenght /= 2;
                supList.Lenght = tL;
            }
            else
            {
                list.Lenght /= 2;
                supList.Lenght = tL + 1;
            }


            list = MergeSort(list);
            supList = MergeSort(supList);
            finishList.Merge(list, supList, finishList);
            return finishList;
        }

        private void Merge(DLinkedList list, DLinkedList supList, DLinkedList finishList)
        {
            while (list._head != null && supList._head != null)
            {
                if (list._head.Value <= supList._head.Value)
                {
                    finishList.AddToEnd(list._head.Value);

                    list._head = list._head.Next;
                }
                else
                {
                    finishList.AddToEnd(supList._head.Value);
                    supList._head = supList._head.Next;
                }
            }
            if (list._head == null)
            {
                while (supList._head != null)
                {
                    finishList.AddToEnd(supList._head.Value);
                    supList._head = supList._head.Next;
                }
            }
            else
            {
                while (list._head != null)
                {
                    finishList.AddToEnd(list._head.Value);
                    list._head = list._head.Next;
                }
            }
        }
    }
}
