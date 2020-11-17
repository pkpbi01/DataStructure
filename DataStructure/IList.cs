using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public interface IList
    {
        public void AddToEnd(int value);

        public void AddToBiginning(int value);

        public void AddTo(int idx, int value);

        public void DeleteFromEnd();

        public void DeleteFromBiginning();

        public void DeleteFrom(int idx);

        public int GetLenght();

        public int GetByIndex(int idx);

        public int GetIndexByValue(int value);

        public void ReversList();

        public int GetMaxElement();

        public int GetMinElement();

        public int GetIndexOfMaxElement();

        public int GetIndexOfMinElement();

        public void Sort();

        public void SortDecrease();

        public void DeleteFirstElementWithValue(int value);

        public void DeleteElementsWithValue(int value);
    }
}
