using NUnit.Framework;
using DataStructure.DLinkedList;
using System;

namespace ArrayList.Tests
{
    class DLLTests
    {
        [TestCase(new int[] { 1, 2, 3 }, 5, 8)]
        [TestCase(new int[] { 1, 2, 3 }, -5, 8)]
        [TestCase(new int[] { 1, 2, 3 }, 5000, 8)]
        public void SetByIndexNegativeTest(int[] array, int idx, int newValue)
        {
            DLinkedList actual = new DLinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual[idx] = newValue);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 1, 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 2, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 3, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 4, 5)]
        [TestCase(new int[] { 1, 2, 12, 4, 5, 6 }, 2, 12)]
        [TestCase(new int[] { 999, 2, 3, 4, 5, 6 }, 0, 999)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 666 }, 5, 666)]
        [TestCase(new int[] { 1, 2, 12, 4, 9, 6 }, 4, 9)]
        [TestCase(new int[] { 1, 2, 12, 4, 5, 6 }, 3, 4)]
        public void SetByIndexTest(int[] array, int idx, int expected)
        {
            DLinkedList actualList = new DLinkedList(array);
            int actual = actualList[idx];
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, 4, new int[] { 4 })]
        [TestCase(new int[] { 1 }, 4, new int[] { 1, 4 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 1, 2, 3, 0 })]
        [TestCase(new int[] { 1, 2, 3 }, -65, new int[] { 1, 2, 3, -65 })]
        [TestCase(new int[] { 1, 2, 3 }, 47887, new int[] { 1, 2, 3, 47887 })]
        public void AddToEndTest(int[] array, int value, int[] expectedArray)
        {
            DLinkedList actual = new DLinkedList(array);
            DLinkedList expected = new DLinkedList(expectedArray);

            actual.AddToEnd(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { 4, 1, 2, 3 })]
        [TestCase(new int[] { }, 0, new int[] { 0 })]
        [TestCase(new int[] { 1, 2, 3 }, 5122, new int[] { 5122, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, -44, new int[] { -44, 1, 2, 3 })]
        public void AddToBigginingTest(int[] array, int value, int[] expectedArray)
        {
            DLinkedList actual = new DLinkedList(array);
            DLinkedList expected = new DLinkedList(expectedArray);

            actual.AddToBiginning(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1 }, 0, 45, new int[] { 45, 1 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, 2, new int[] { 1, 2, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 2, 5, new int[] { 1, 2, 5, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 0, 11, new int[] { 11, 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4, 0, new int[] { 1, 2, 3, 4, 0, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 6, 0, new int[] { 1, 2, 3, 4, 5, 6, 0, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 2, 0, new int[] { 1, 2, 0, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, 0, new int[] { 1, 2, 3, 0, 4, 5, 6, 7 })]
        [TestCase(new int[] { }, 0, 45, new int[] { 45 })]
        public void AddToTest(int[] array, int idx, int value, int[] expectedArray)
        {
            DLinkedList actual = new DLinkedList(array);
            DLinkedList expected = new DLinkedList(expectedArray);

            actual.AddTo(idx, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 15, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -15, 8)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1500, 45)]
        public void AddToNegativeTest(int[] array, int idx, int value)
        {
            DLinkedList actual = new DLinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.AddTo(idx, value));
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { 4, 12, 6 }, new int[] { 4, 12 })]
        [TestCase(new int[] { 545, 23, 6 }, new int[] { 545, 23 })]
        public void DeleteFromEndTest(int[] array, int[] expectedArray)
        {
            DLinkedList actual = new DLinkedList(array);
            DLinkedList expected = new DLinkedList(expectedArray);

            actual.DeleteFromEnd();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 4, 12, 6 }, new int[] { 12, 6 })]
        [TestCase(new int[] { 545, 23, 6 }, new int[] { 23, 6 })]
        public void DeleteFromBiginningTest(int[] array, int[] expectedArray)
        {
            DLinkedList actual = new DLinkedList(array);
            DLinkedList expected = new DLinkedList(expectedArray);

            actual.DeleteFromBiginning();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 2, 3 })]
        [TestCase(new int[] { 1 }, 0, new int[] {  })]
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 1, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 45, -15 }, 4, new int[] { 1, 2, 3, 4, 6, 7, 45, -15 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 1, 2, 3, 4 })]
        public void DeleteFromTest(int[] array, int idx, int[] expectedArray)
        {
            DLinkedList actual = new DLinkedList(array);
            DLinkedList expected = new DLinkedList(expectedArray);

            actual.DeleteFrom(idx);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 15)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -15)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1500)]
        public void DeleteFromNegativeTest(int[] array, int idx)
        {
            DLinkedList actual = new DLinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.DeleteFrom(idx));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 3, 5, 3 }, 8)]
        [TestCase(new int[] { }, 0)]
        public void GetLenghtTest(int[] array, int expected)
        {
            DLinkedList list = new DLinkedList(array);

            int actual = list.GetLenght();
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 5)]
        public void GetByIndexTest(int[] array, int idx, int expected)
        {
            DLinkedList list = new DLinkedList(array);

            int actual = list.GetByIndex(idx);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1000)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6)]
        public void GetByIndexNegativeTest(int[] array, int idx)
        {
            DLinkedList actual = new DLinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.GetByIndex(idx));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 1)]
        [TestCase(new int[] { 1, 3, 0, 7, 5 }, 0, 2)]
        [TestCase(new int[] { 1, 3, 0, 7, 5 }, 1, 0)]
        [TestCase(new int[] { 1, 2, 3, 6, 5, 12 }, 12, 5)]
        public void GetIndexByValueTest(int[] array, int value, int expected)
        {
            DLinkedList list = new DLinkedList(array);

            int actual = list.GetIndexByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1000)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6)]
        public void GetIndexByValueNegativeTest(int[] array, int value)
        {
            DLinkedList actual = new DLinkedList(array);
            Assert.Throws<ArgumentException>(() => actual.GetIndexByValue(value));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 6, 3, 456, 5 }, new int[] { 5, 456, 3, 6, 1 })]
        [TestCase(new int[] { -1, -2, -4, 5 }, new int[] { 5, -4, -2, -1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { }, new int[] { })]
        public void ReversListTest(int[] array, int[] expectedArray)
        {
            DLinkedList actual = new DLinkedList(array);
            DLinkedList expected = new DLinkedList(expectedArray);

            actual.ReversList();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 1, 6, 3, 456, 5 }, 456)]
        [TestCase(new int[] { -1, -2, 3, -4, 5 }, 5)]
        public void GetMaxElementTest(int[] array, int expected)
        {
            DLinkedList list = new DLinkedList(array);

            int actual = list.GetMaxElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMaxElementNegativeTest(int[] array)
        {
            DLinkedList actual = new DLinkedList(array);
            Assert.Throws<InvalidOperationException>(() => actual.GetMaxElement());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1)]
        [TestCase(new int[] { 1, 6, 3, 456, 5 }, 1)]
        [TestCase(new int[] { -1, -2, 3, -4, 5 }, -4)]
        public void GetMinElementTest(int[] array, int expected)
        {
            DLinkedList list = new DLinkedList(array);

            int actual = list.GetMinElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMinElementNegativeTest(int[] array)
        {
            DLinkedList actual = new DLinkedList(array);
            Assert.Throws<InvalidOperationException>(() => actual.GetMinElement());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { 1, 6, 3, 456, 5 }, 3)]
        [TestCase(new int[] { -1, -2, 3, -4, 5 }, 4)]
        public void GetIndexOfMaxElementTest(int[] array, int expected)
        {
            DLinkedList list = new DLinkedList(array);

            int actual = list.GetIndexOfMaxElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetIndexOfMaxElementNegativeTest(int[] array)
        {
            DLinkedList actual = new DLinkedList(array);
            Assert.Throws<InvalidOperationException>(() => actual.GetIndexOfMaxElement());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { 1, 6, 3, 456, 5 }, 0)]
        [TestCase(new int[] { -1, -2, 3, -4, 5 }, 3)]
        public void GetIndexOfMinElementTest(int[] array, int expected)
        {
            DLinkedList list = new DLinkedList(array);

            int actual = list.GetIndexOfMinElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetIndexOfMinElementNegativeTest(int[] array)
        {
            DLinkedList actual = new DLinkedList(array);
            Assert.Throws<InvalidOperationException>(() => actual.GetIndexOfMinElement());
        }

        [TestCase(new int[] { 2, 1, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 582, 1, 3, 4, 5 }, new int[] { 1, 3, 4, 5, 582 })]
        [TestCase(new int[] { 582, 1, 1, 4, 5 }, new int[] { 1, 1, 4, 5, 582 })]
        [TestCase(new int[] { 582, 1, 3, 1, 5 }, new int[] { 1, 1, 3, 5, 582 })]
        [TestCase(new int[] { 582, 1, 1, 1, 5 }, new int[] { 1, 1, 1, 5, 582 })]
        [TestCase(new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1 })]
        [TestCase(new int[] { 1, 1, 2, 1, 1 }, new int[] { 1, 1, 1, 1, 2 })]
        [TestCase(new int[] { 2, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 2 })]
        [TestCase(new int[] { 1, 1, 2, 1, 2 }, new int[] { 1, 1, 1, 2, 2 })]
        [TestCase(new int[] { -68, 365, 14, -5, 8, 14 }, new int[] { -68, -5, 8, 14, 14, 365 })]//
        [TestCase(new int[] { -68, 365, 8, -5, 14, 14 }, new int[] { -68, -5, 8, 14, 14, 365 })]//
        [TestCase(new int[] { -68, 14, 365, -5, 8, 14 }, new int[] { -68, -5, 8, 14, 14, 365 })]
        [TestCase(new int[] { -68, 14, 365, 19, 8, 14 }, new int[] { -68, 8, 14, 14, 19, 365 })]
        [TestCase(new int[] { -70, 365, 14, -5, 8, 14, 1, 88 }, new int[] { -70, -5, 1, 8, 14, 14, 88, 365 })]
        [TestCase(new int[] { 0, -8 }, new int[] { -8, 0 })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        public void MergeSortTest(int[] array, int[] expectedArray)
        {
            DLinkedList actual = new DLinkedList(array);
            DLinkedList expected = new DLinkedList(expectedArray);

            actual.Sort();
            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { 2, 1, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 582, 1, 3, 4, 5 }, new int[] { 582, 5, 4, 3, 1 })]
        [TestCase(new int[] { -68, 365, 14, -5, 8, 14 }, new int[] { 365, 14, 14, 8, -5, -68 })]
        [TestCase(new int[] { 0, -8 }, new int[] { 0, -8 })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        public void MergeDecreaseSortTest(int[] array, int[] expectedArray)
        {
            DLinkedList actual = new DLinkedList(array);
            DLinkedList expected = new DLinkedList(expectedArray);
            actual.SortDecrease();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 1, 3 }, 1, new int[] { 2, 3 })]
        [TestCase(new int[] { 582, 1, 3, 1, 3, 5 }, 3, new int[] { 582, 1, 1, 3, 5 })]
        [TestCase(new int[] { 0, -8 }, -8, new int[] { 0 })]
        [TestCase(new int[] { 2 }, 2, new int[] { })]
        [TestCase(new int[] { 2, 3, 4 }, 2, new int[] { 3, 4 })]
        public void DeleteFirstElementWithValueTest(int[] array, int value, int[] expectedArray)
        {
            DLinkedList actual = new DLinkedList(array);
            DLinkedList expected = new DLinkedList(expectedArray);
            actual.DeleteFirstElementWithValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 1, 3 }, 1, new int[] { 2, 3 })]
        [TestCase(new int[] { 582, 1, 3, 3, 1, 3, 5 }, 3, new int[] { 582, 1, 1, 5 })]
        [TestCase(new int[] { 0, -8 }, -8, new int[] { 0 })]
        [TestCase(new int[] { 2 }, 2, new int[] { })]
        [TestCase(new int[] { 3, 2, 2, 2, 2 }, 2, new int[] { 3 })]
        [TestCase(new int[] { 3, 2, 2, 2, 2, 3 }, 2, new int[] { 3, 3 })]
        [TestCase(new int[] { 2, 2, 2, 2 }, 2, new int[] { })]
        [TestCase(new int[] { 2, 1, 2, 1, 1 }, 2, new int[] { 1, 1, 1 })]
        public void DeleteElementsWithValueTest(int[] array, int value, int[] expectedArray)
        {
            DLinkedList actual = new DLinkedList(array);
            DLinkedList expected = new DLinkedList(expectedArray);
            actual.DeleteElementsWithValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { 18, 36, -13, 6, 15 }, new int[] { 18, 36, -13, 6, 15 })]
        [TestCase(new int[] { 18, 36 }, new int[] { -13, 6, 15, 66, -3589 }, new int[] { 18, 36, -13, 6, 15, 66, -3589 })]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        [TestCase(new int[] { 18, 36, -13, 6 }, new int[] { }, new int[] { 18, 36, -13, 6 })]
        public void AddArrayToEndTest(int[] array, int[] addedArray, int[] expectedArray)
        {
            DLinkedList actual = new DLinkedList(array);
            DLinkedList expected = new DLinkedList(expectedArray);

            actual.AddToEnd(addedArray);
            Assert.AreEqual(expected, actual);

        }


        [TestCase(new int[] { 4, 5, 6, 7 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { }, new int[] { 18, 36, -13, 6, 15 }, new int[] { 18, 36, -13, 6, 15 })]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        [TestCase(new int[] { 18, 36, -13, 6 }, new int[] { }, new int[] { 18, 36, -13, 6 })]
        public void AddArrayToBiginningTest(int[] array, int[] addedArray, int[] expectedArray)
        {
            DLinkedList actual = new DLinkedList(array);
            DLinkedList expected = new DLinkedList(expectedArray);

            actual.AddToBiginning(addedArray);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { }, 0, new int[] { 18, 36, -13, 6, 15 }, new int[] { 18, 36, -13, 6, 15 })]
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 4, 5, 6 }, new int[] { 1, 4, 5, 6, 2, 3 })]
        [TestCase(new int[] { }, 0, new int[] { }, new int[] { })]
        [TestCase(new int[] { 18, 36, -13, 6 }, 2, new int[] { }, new int[] { 18, 36, -13, 6 })]
        [TestCase(new int[] { 18, 36, -13, 6 }, 0, new int[] { }, new int[] { 18, 36, -13, 6 })]
        public void AddArrayToTest(int[] array, int idx, int[] addedArray, int[] expectedArray)
        {
            DLinkedList actual = new DLinkedList(array);
            DLinkedList expected = new DLinkedList(expectedArray);

            actual.AddTo(idx, addedArray);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { }, -1, new int[] { 18, 36, -13, 6, 15 })]
        [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3 }, 400, new int[] { 4, 5, 6 })]
        public void AddArrayToNegativTest(int[] array, int idx, int[] addedArray)
        {
            DLinkedList actual = new DLinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.AddTo(idx, addedArray));
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 5, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 6, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 7, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        public void DeleteNElementsFromEndTest(int[] array, int number, int[] expectedArray)
        {
            DLinkedList actual = new DLinkedList(array);
            DLinkedList expected = new DLinkedList(expectedArray);

            actual.DeleteFromEnd(number);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 8)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 1000)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, -8)]
        public void DeleteNElementsFromEndNegativeTest(int[] array, int number)
        {
            DLinkedList actual = new DLinkedList(array);
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.DeleteFromEnd(number));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 1, new int[] { 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 6, new int[] { 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 7, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        public void DeleteNElementsFromBiginning(int[] array, int number, int[] expectedArray)
        {
            DLinkedList actual = new DLinkedList(array);
            DLinkedList expected = new DLinkedList(expectedArray);

            actual.DeleteFromBiginning(number);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 8)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 1000)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, -8)]
        public void DeleteNElementsFromBiginningNegativeTest(int[] array, int number)
        {
            DLinkedList actual = new DLinkedList(array);
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.DeleteFromBiginning(number));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0, 3, new int[] { 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0, 5, new int[] { 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0, 6, new int[] { 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 1, 6, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4, 3, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4, 2, new int[] { 1, 2, 3, 4, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, 1, new int[] { 1, 2, 3, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 2, 3, new int[] { 1, 2, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4, 0, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0, 0, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0, 7, new int[] { })]

        public void DeleteNElmentsFromTest(int[] array, int idx, int number, int[] expectedArray)
        {
            DLinkedList actual = new DLinkedList(array);
            DLinkedList expected = new DLinkedList(expectedArray);


            actual.DeleteFrom(idx, number);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, -2, 2, "Index")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 1000, 1001, "Index")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, -8, -45, "Index")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4, 4, "Argument")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4, 1001, "Argument")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, -8, 2, "Index")]
        public void DeleteNElementsFromNegativTest(int[] array, int idx, int number, string excepyion)
        {
            DLinkedList actual = new DLinkedList(array);
            switch (excepyion)
            {
                case "Index":
                    Assert.Throws<IndexOutOfRangeException>(() => actual.DeleteFrom(idx, number));
                    break;
                case "Argument":
                    Assert.Throws<ArgumentOutOfRangeException>(() => actual.DeleteFrom(idx, number));
                    break;
            }
        }
    }
}
