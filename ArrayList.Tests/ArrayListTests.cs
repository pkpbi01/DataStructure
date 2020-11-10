using NUnit.Framework;
using DataStructure;
using System;
using System.Collections;

namespace ArrayList.Tests
{
    class ArrayListTest
    {
        DataStructure.ArrayList listMock;
        DataStructure.ArrayList expectedMock;
       
        public void GetMock(int n)
        {
            switch(n)
            {
                case 1:
                    listMock = new DataStructure.ArrayList();
                    listMock.AddToEnd(-5);
                    listMock.AddToEnd(3);
                    listMock.AddToEnd(0);
                    listMock.AddToEnd(8);
                    listMock.AddToEnd(-1);

                    expectedMock = new DataStructure.ArrayList();
                    expectedMock.AddToEnd(-5);
                    expectedMock.AddToEnd(-1);
                    expectedMock.AddToEnd(0);
                    expectedMock.AddToEnd(3);
                    expectedMock.AddToEnd(8);
                    break;
            }
        }

        [TestCase(1)]
        public void QuickSortTest(int n)
        {
            GetMock(n);
            DataStructure.ArrayList list = listMock;
            DataStructure.ArrayList expected = expectedMock;
            DataStructure.ArrayList actual = list.QuickSort();
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
    }
}