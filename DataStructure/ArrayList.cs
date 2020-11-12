using System;
using System.Linq;

namespace DataStructure
{
    public class ArrayList
    {
        public int Lenght { get; private set; }

        private int[] _array;
        private int _TrueLenght
        {
            get
            {
                return _array.Length;
            }
        }

        public ArrayList()
        {
            _array = new int[9];
            Lenght = 0;
        }

        public ArrayList(int[] array)
        {
            _array = new int[(int)(array.Length * 1.33d)];
            Lenght = array.Length;
            Array.Copy(array, _array, array.Length);
        }

        public ArrayList(int value)
        {
            _array = new int[9];
            _array[0] = value;
            Lenght = 1;
        }

        public int this[int i]
        {
            get
            {
                if (i >= Lenght || i < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[i];
            }
            set
            {
                if (i >= Lenght || i < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                _array[i] = value;
            }
        }



        public void AddToEnd(int value)
        {
            if (_TrueLenght <= Lenght)
            {
                IncreaseLenght();
            }
            _array[Lenght] = value;
            Lenght++;
        }

        public void AddToBiginning(int value)
        {
            if (_TrueLenght <= Lenght+1)
            {
                IncreaseLenght();
            }
            for(int i = Lenght; i >= 0; i--)
            {
                _array[i + 1] = _array[i];
            }
            _array[0] = value;
            Lenght++;
        }

        public void AddTo(int idx, int value)
        {
            if (_TrueLenght <= Lenght)
            {
                IncreaseLenght();
            }
            if (Lenght != 0)
            {
                if (idx >= Lenght || idx < 0)
                {
                throw new IndexOutOfRangeException();
                }
                for (int i = Lenght-1; i >= idx; i--)
                {
                    _array[i + 1] = _array[i];
                }
            }
            _array[idx] = value;
            Lenght++;
        }

        public void DeleteFromEnd()
        {
            if (Lenght == 0)
            {
                throw new InvalidOperationException();
            }
            Lenght--;
            if (_TrueLenght > 2 * Lenght - 1)
            {
                DicreaseLenght();
            }
        }//---

        public void DeleteFromBiginning()
        {
            if (Lenght == 0)
            {
                throw new InvalidOperationException();
            }
            for (int i =0; i<Lenght-1; i++)
            {
                _array[i] = _array[i + 1];
            }
            Lenght--;
            if (_TrueLenght > 2 * Lenght - 1)
            {
                DicreaseLenght();
            }
        }//---

        public void DeleteFrom(int idx)
        {
            if (idx >= Lenght || idx < 0) 
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = idx; i < Lenght-1; i++)
            {
                _array[i] = _array[i + 1];
            }
            Lenght--;
            if (_TrueLenght > 2 * Lenght - 1)
            {
                DicreaseLenght();
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
            return _array[idx];
        }

        public int GetIndexByValue(int value)
        {
            for (int i =0; i<Lenght; i++)
            {
                if (_array[i] == value)
                {
                    return i;
                }
            }
            throw new ArgumentException();
        }

        public void ReversList()
        {
            ArrayList newList = new ArrayList();
            for (int i = 0; i < Lenght; i++)
            {
                newList.AddToBiginning(_array[i]);
            }
            _array = newList._array;
        }

        public ArrayList CopyList()
        {
            ArrayList newList = new ArrayList();
            for (int i = 0; i < Lenght; i++)
            {
                newList.AddToEnd(_array[i]);
            }
            return newList;
        }



        public int GetMaxElement()
        {
            if (Lenght == 0)
            {
                throw new InvalidOperationException();
            }

            int max = _array[0];
            for(int i = 1; i < Lenght; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                }
            }
            return max;
        }//---

        public int GetMinElement()
        {
            if (Lenght == 0)
            {
                throw new InvalidOperationException();
            }
            int min = _array[0];
            for (int i = 1; i < Lenght; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                }
            }
            return min;
        }//---

        public int GetIndexOfMaxElement()
        {
            if (Lenght == 0)
            {
                throw new InvalidOperationException();
            }
            int idx = 0;
            int max = _array[0];
            for (int i = 1; i < Lenght; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                    idx = i;
                }
            }
            return idx;
        }//---

        public int GetIndexOfMinElement()
        {
            if (Lenght == 0)
            {
                throw new InvalidOperationException();
            }
            int idx = 0;
            int min = _array[0];
            for (int i = 1; i < Lenght; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                    idx = i;
                }
            }
            return idx;
        }//---

        public void QuickSort()
        {
            ArrayList newList = CopyList();
            newList = QuickSort(newList, 0, newList.Lenght - 1);
            _array = newList._array;
        }

        public void QuickSortDecrease()
        {
            ArrayList newList = CopyList();
            newList = QuickSort(newList, 0, newList.Lenght - 1);
            newList.ReversList();
            _array = newList._array;
        }


        public void DeleteFirstElementWithValue(int value)
        {
            int idx = 0;
            for (int i = 0; i < Lenght; i++)
            {
                if (_array[i] == value)
                {
                    idx = i;
                    break;
                }
            }
            if (_TrueLenght > 2 * Lenght - 1)
            {
                DicreaseLenght();
            }
            for (int i = idx; i < Lenght-1; i++)
            {
                _array[i] = _array[i + 1];
            }
            Lenght--;
        }

        public void DeleteElementsWithValue(int value)
        {
            for (int i = 1; i < Lenght; i++)
            {
                if (_array[i] == value)
                {
                    
                    if (_TrueLenght > 2 * Lenght - 1)
                    {
                        DicreaseLenght();
                    }
                    for (int j = i; j < Lenght - 1; j++)
                    {
                        _array[j] = _array[j + 1];
                    }
                    i--;
                    Lenght--;
                }
            }
            if (_array[0] == value)
            {
                if (_TrueLenght <= Lenght)
                {
                    IncreaseLenght();
                }
                _array[0] = _array[1];
                Lenght--;
            }
        }

        public void AddArrayToEnd(int[] array)
        {
            if (_TrueLenght <= Lenght + array.Length)
            {
                IncreaseLenght(array.Length);
            }
            for (int i = 0; i <array.Length; i++)
            {
                AddToEnd(array[i]);
            }
        }

        public void AddArrayToBiginning(int[] array)
        {
            if (_TrueLenght <= Lenght + array.Length)
            {
                IncreaseLenght(array.Length);
            }
            for (int i = Lenght-1; i>=0; i--)
            {
                _array[i + array.Length] = _array[i];
            }
            for (int i = 0; i<array.Length; i++)
            {
                _array[i] = array[i];
            }
            Lenght += array.Length;
        }

        public void AddArrayTo(int idx, int[] array)
        {
            if (_TrueLenght <= Lenght + array.Length)
            {
                IncreaseLenght(array.Length);
            }
            if ((idx >= Lenght || idx < 0) && idx != 0)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = Lenght-1; i >= idx; i--)
            {
                _array[i + array.Length] = _array[i];
            }
            for (int i = 0; i < array.Length; i++)
            {
                _array[i + idx] = array[i];
            }
            Lenght += array.Length;
        }

        public void DeleteNElementsFromEnd(int number)
        {
            if (number > Lenght || number < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Lenght -= number;
            if (_TrueLenght > 2 * Lenght - 1)
            {
                DicreaseLenght();
            }
        }

        public void DeleteNElementsFromBiginning(int number)
        {
            if (number > Lenght || number < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
                for (int i = 0; i < Lenght - number; i++)
                {
                    _array[i] = _array[i + number];
                }
            Lenght -= number;
            if (_TrueLenght > 2 * Lenght - 1)
            {
                DicreaseLenght();
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

            for (int i = idx; i < Lenght - number; i++)
            {
                _array[i] = _array[i + number];
            }
            Lenght-= number;

            if (_TrueLenght > 2 * Lenght - 1)
            {
                DicreaseLenght();
            }
        }

        public void PrintList()
        {
            for(int i = 0; i < Lenght; i++)
            {
                Console.Write($"{_array[i]} ");
            }
        }



       

        private void IncreaseLenght(int number = 1)
        {
            int newLenght = _TrueLenght;
            while (newLenght <= Lenght + number)
            {
                newLenght = (int)(newLenght * 1.33 + 1);
            }

            int[] newArray = new int[newLenght];
            Array.Copy(_array, newArray, _TrueLenght);

            _array = newArray;
        }

        private void DicreaseLenght()
        {
            int newLenght = _TrueLenght;
            if (Lenght > 0)
            {
                while (newLenght > 2 * (Lenght))
                {
                    newLenght = (int)(newLenght * 0.66 + 1);
                }
            }
            else
            {
                newLenght = 3;
            }
            int[] newArray = new int[newLenght];
            Array.Copy(_array, newArray, newLenght);

            _array = newArray;
        }

        static private void Swap(ref int x, ref int y)
        {
            int t = x;
            x = y;
            y = t;
        }

        private int Partition(int minIndex, int maxIndex)
        {
            int pivot = minIndex - 1;
            for(int i = minIndex; i < maxIndex; i++)
            {
                if (_array[i] < _array[maxIndex])
                {
                    pivot++;
                    Swap(ref _array[pivot], ref _array[i]);
                }
            }
            pivot++;
            Swap(ref _array[pivot], ref _array[maxIndex]);
            return pivot;
        }

        private ArrayList QuickSort(ArrayList list, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return list;
            }
            int pivotIndex = list.Partition(minIndex, maxIndex);
            list.QuickSort(list, minIndex, pivotIndex - 1);
            list.QuickSort(list, pivotIndex + 1, maxIndex);

            return list;
        }


        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Lenght != arrayList.Lenght)
            {
                return false;
            }
            for (int i = 0; i < Lenght; i++)
            {
                if (_array[i] != arrayList._array[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            return string.Join(";", _array.Take(Lenght));
        }
    }
}
