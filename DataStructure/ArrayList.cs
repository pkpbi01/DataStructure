using System;

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
            if (_TrueLenght <= Lenght)
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
            for (int i = Lenght; i >= idx; i--)
            {
                _array[i + 1] = _array[i];
            }
            _array[idx] = value;
            Lenght++;
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

        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Lenght != arrayList.Lenght)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Lenght; i++)
                {
                    if (_array[i] != arrayList._array[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
