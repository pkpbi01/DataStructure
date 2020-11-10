using NUnit.Framework;
using DataStructure;
using System;
using System.Collections;

namespace ArrayList.Tests
{
    class ArrayListTest
    {
        [TestCase(new int[] { 1, 2, 3 }, 5, 8)]
        [TestCase(new int[] { 1, 2, 3 }, -5, 8)]
        [TestCase(new int[] { 1, 2, 3 }, 5000, 8)]
        public void SetByIndexNegativeTest(int[] array, int idx, int newValue)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual[idx] = newValue);
        }
        
        [TestCase(new int[] {1, 2, 3 }, 4, new int[] {1, 2, 3, 4} )]
        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 1, 2, 3, 0 })]
        [TestCase(new int[] { 1, 2, 3 }, -65, new int[] { 1, 2, 3, -65 })]
        [TestCase(new int[] { 1, 2, 3 }, 47887, new int[] { 1, 2, 3, 47887 })]
        public void AddToEndTest(int[] array, int value, int[] expectedArray)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            actual.AddToEnd(value);
            DataStructure.ArrayList expected = new DataStructure.ArrayList(expectedArray);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] {4, 1, 2, 3 })]
        [TestCase(new int[] { }, 0, new int[] { 0 })]
        [TestCase(new int[] { 1, 2, 3 }, 5122, new int[] { 5122, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, -44, new int[] { -44, 1, 2, 3 })]
        public void AddToBigginingTest(int[] array, int value, int[] expectedArray)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            actual.AddToBiginning(value);
            DataStructure.ArrayList expected = new DataStructure.ArrayList(expectedArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 2, 2, new int[] { 1, 2, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 0, 11, new int[] { 11, 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 0, new int[] { 1, 2, 3, 4, 0, 5 })]
        [TestCase(new int[] { }, 0, 45, new int[] { 45 })]
        public void AddToTest(int[] array,int idx, int value, int[] expectedArray)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            actual.AddTo(idx, value);
            DataStructure.ArrayList expected = new DataStructure.ArrayList(expectedArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 15, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -15, 8)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1500, 45)]
        public void AddToNegativeTest(int[] array, int idx, int value)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.AddTo(idx, value));
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 4, 12, 6 }, new int[] { 4, 12 })]
        [TestCase(new int[] { 545, 23, 6 }, new int[] { 545, 23 })]
        public void DeleteFromEndTest(int[] array, int[] expectedArray)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            actual.DeleteFromEnd();
            DataStructure.ArrayList expected = new DataStructure.ArrayList(expectedArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 4, 12, 6 }, new int[] { 12, 6 })]
        [TestCase(new int[] { 545, 23, 6 }, new int[] { 23, 6 })]
        public void DeleteFromBiginningTest(int[] array, int[] expectedArray)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            actual.DeleteFromBiginning();
            DataStructure.ArrayList expected = new DataStructure.ArrayList(expectedArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] {2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 45, -15 }, 5, new int[] { 1, 2, 3, 4, 5, 7, 45, -15 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 1, 2, 3, 4 })]
        public void DeleteFromTest(int[] array, int idx, int[] expectedArray)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            actual.DeleteFrom(idx);
            DataStructure.ArrayList expected = new DataStructure.ArrayList(expectedArray);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] {1,2,3,4,5 }, 15)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -15)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1500)]
        public void DeleteFromNegativeTest(int[] array, int idx)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.DeleteFrom(idx));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 3, 5, 3 }, 8)]
        [TestCase(new int[] { }, 0)]
        public void GetLenghtTest(int[] array, int expected)
        {
            DataStructure.ArrayList list = new DataStructure.ArrayList(array);
            int actual = list.GetLenght();
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] {1, 2, 3, 4, 5 }, 2, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 5)]
        public void GetByIndexTest(int[] array, int idx, int expected)
        {
            DataStructure.ArrayList list = new DataStructure.ArrayList(array);
            int actual = list.GetByIndex(idx);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1000)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6)]
        public void GetByIndexNegativeTest(int[] array, int idx)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.GetByIndex(idx));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 1)]
        [TestCase(new int[] { 1, 3, 0, 7, 5 }, 0, 2)]
        [TestCase(new int[] { 1, 2, 3, 6, 5, 12 }, 12, 5)]
        public void GetIndexByValueTest(int[] array, int value, int expected)
        {
            DataStructure.ArrayList list = new DataStructure.ArrayList(array);
            int actual = list.GetIndexByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1000)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6)]
        public void GetIndexByValueNegativeTest(int[] array, int value)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            Assert.Throws<ArgumentException>(() => actual.GetIndexByValue(value));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5,4,3,2,1 })]
        [TestCase(new int[] { 1, 6, 3, 456, 5 }, new int[] { 5,456,3,6,1 })]
        [TestCase(new int[] { -1, -2, 3, -4, 5 }, new int[] {5,-4,3,-2,-1 })]
        [TestCase(new int[] { }, new int[] { })]
        public void ReversListTest(int[] array, int[] expectedArray)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            actual.ReversList();
            DataStructure.ArrayList expected = new DataStructure.ArrayList(expectedArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 6, 3, 456, 5 }, new int[] { 1, 6, 3, 456, 5 })]
        [TestCase(new int[] { -1, -2, 3, -4, 5 }, new int[] { -1, -2, 3, -4, 5 })]
        [TestCase(new int[] { }, new int[] { })]
        public void CopyListTest(int[] array, int[] expectedArray)
        {
            DataStructure.ArrayList list = new DataStructure.ArrayList(array);
            DataStructure.ArrayList actual = list.CopyList();
            DataStructure.ArrayList expected = new DataStructure.ArrayList(expectedArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 1, 6, 3, 456, 5 }, 456)]
        [TestCase(new int[] { -1, -2, 3, -4, 5 }, 5)]        
        public void GetMaxElementTest(int[] array, int expected)
        {
            DataStructure.ArrayList list = new DataStructure.ArrayList(array);
            int actual = list.GetMaxElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1)]
        [TestCase(new int[] { 1, 6, 3, 456, 5 }, 1)]
        [TestCase(new int[] { -1, -2, 3, -4, 5 }, -4)]
        public void GetMinElementTest(int[] array, int expected)
        {
            DataStructure.ArrayList list = new DataStructure.ArrayList(array);
            int actual = list.GetMinElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { 1, 6, 3, 456, 5 }, 3)]
        [TestCase(new int[] { -1, -2, 3, -4, 5 }, 4)]
        public void GetIndexOfMaxElementTest(int[] array, int expected)
        {
            DataStructure.ArrayList list = new DataStructure.ArrayList(array);
            int actual = list.GetIndexOfMaxElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { 1, 6, 3, 456, 5 }, 0)]
        [TestCase(new int[] { -1, -2, 3, -4, 5 }, 3)]
        public void GetIndexOfMinElementTest(int[] array, int expected)
        {
            DataStructure.ArrayList list = new DataStructure.ArrayList(array);
            int actual = list.GetIndexOfMinElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 1, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 582, 1, 3, 4, 5 }, new int[] { 1,3,4,5,582 })]
        [TestCase(new int[] { -68, 365, 14, -5, 8, 14 }, new int[] {-68,-5,8,14,14,365})]
        [TestCase(new int[] { 0, -8 }, new int[] { -8, 0 })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        public void QuickSortTest(int[] array, int[] expectedArray)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            DataStructure.ArrayList expected = new DataStructure.ArrayList(expectedArray);
            actual.QuickSort();
            Assert.AreEqual(expected, actual);
            
        }


        [TestCase(new int[] { }, new int[] { 18, 36, -13, 6, 15 }, new int[] {18, 36, -13, 6, 15})]
        [TestCase(new int[] { 18, 36 }, new int[] {-13, 6, 15, 66, -3589 }, new int[] { 18, 36, -13, 6, 15, 66, -3589 })]
        [TestCase(new int[] { }, new int[] {}, new int[] {})]
        [TestCase(new int[] { 18, 36, -13, 6 }, new int[] {}, new int[] { 18, 36, -13, 6 })]
        public void AddArrayToEndTest(int[] array ,int[] addedArray, int[] expectedArray)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            actual.AddArrayToEnd(addedArray);
            DataStructure.ArrayList expected = new DataStructure.ArrayList(expectedArray);

            Assert.AreEqual(expected, actual);

        }


        [TestCase(new int[] {4, 5, 6, 7}, new int[] {1, 2, 3 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { }, new int[] { 18, 36, -13, 6, 15 }, new int[] { 18, 36, -13, 6, 15 })]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        [TestCase(new int[] { 18, 36, -13, 6 }, new int[] { }, new int[] { 18, 36, -13, 6 })]
        public void AddArrayToBiginningTest(int[] array, int[] addedArray, int[] expectedArray)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            actual.AddArrayToBiginning(addedArray);
            DataStructure.ArrayList expected = new DataStructure.ArrayList(expectedArray);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { }, 0, new int[] { 18, 36, -13, 6, 15 }, new int[] { 18, 36, -13, 6, 15 })]
        [TestCase(new int[] {1, 2, 3 }, 1, new int[] { 4, 5, 6 }, new int[] { 1, 4, 5, 6, 2, 3 })]
        [TestCase(new int[] { }, 0, new int[] { }, new int[] { })]
        [TestCase(new int[] { 18, 36, -13, 6 }, 2, new int[] { }, new int[] { 18, 36, -13, 6 })]
        [TestCase(new int[] { 18, 36, -13, 6 }, 0, new int[] { }, new int[] { 18, 36, -13, 6 })]
        public void AddArrayToTest(int[] array, int idx, int[] addedArray, int[] expectedArray)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            actual.AddArrayTo(idx, addedArray);
            DataStructure.ArrayList expected = new DataStructure.ArrayList(expectedArray);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { }, -1, new int[] { 18, 36, -13, 6, 15 })]
        [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3 }, 400, new int[] { 4, 5, 6 })]
        public void AddArrayToNegativTest(int[] array, int idx, int[] addedArray)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.AddArrayTo(idx, addedArray));
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 5, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 6, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 7, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        public void DeleteNElementsFromEndTest(int[] array, int number, int[] expectedArray)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            actual.DeleteNElementsFromEnd(number);
            DataStructure.ArrayList expected = new DataStructure.ArrayList(expectedArray);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 8)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 1000)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, -8)]
        public void DeleteNElementsFromEndNegativeTest(int[] array, int number)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            Assert.Throws<ArgumentOutOfRangeException> (() => actual.DeleteNElementsFromEnd(number));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 1, new int[] { 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 6, new int[] { 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 7, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        public void DeleteNElementsFromBiginning(int[] array, int number, int[] expectedArray)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            actual.DeleteNElementsFromBiginning(number);
            DataStructure.ArrayList expected = new DataStructure.ArrayList(expectedArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 8)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 1000)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, -8)]
        public void DeleteNElementsFromEndNegativTest(int[] array, int number)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.DeleteNElementsFromBiginning(number));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0, 3, new int[] { 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4, 3, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4, 0, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0, 0, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0, 7, new int[] { })]

        public void DeleteNElmentsFromTest(int[] array, int idx, int number, int[] expectedArray)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            actual.DeleteNElementsFrom(idx, number);
            DataStructure.ArrayList expected = new DataStructure.ArrayList(expectedArray);
            Assert.AreEqual(expected, actual);
        }


        //[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, -2, 2)]
        //[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 1000, 1001)]
        //[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, -8, -45)]
        //[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4, 4)]
        //[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4, 1001)]
        //[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, -8, 2)]
        //public void DeleteNElementsFromNegativTest(int[] array, int idx, int number)//--------------------------------------
        //{
        //    DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
        //    Assert.Throws<ArgumentOutOfRangeException>(() => actual.DeleteNElementsFrom(idx, number));
        //    Assert.Throws<IndexOutOfRangeException>(() => actual.DeleteNElementsFrom(idx, number));
        //}
    }
}