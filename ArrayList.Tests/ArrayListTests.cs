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
        public void SetByIndexTest(int[] array, int idx, int newValue)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual[idx] = newValue);
        }

        [TestCase(new int[] { 2, 1, 3 }, new int[] { 1, 2, 3 })]
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
        public void DeleteNElementsFromEndNegativeNegativTest(int[] array, int number)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.DeleteNElementsFromBiginning(number));
        }

         
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 },0, 3, new int[] { 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4, 3, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4, 0, new int[] { 1, 2, 3, 4, 5, 6, 7 })]

        public void DeleteNElmentsFromTest(int[] array, int idx, int number, int[] expectedArray)
        {
            DataStructure.ArrayList actual = new DataStructure.ArrayList(array);
            actual.DeleteNElmentsFrom(idx, number);
            DataStructure.ArrayList expected = new DataStructure.ArrayList(expectedArray);
            Assert.AreEqual(expected, actual);
        }
    }
}