using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace List.ListTests
{
    [TestFixture("ArrayList")]
    [TestFixture("LinkedList")]
    [TestFixture("DoubleLinkedList")]
    public class ListTest
    {
        IList actual;
        IList expected;
        IList added;
        string str = "";
        public ListTest(string type)
        {
            str = type;
        }

        
        public void Setup(int [] array, int [] addedArray, int [] expectedArray)
        {
            switch (str)
            {
                case "ArrayList":
                    actual = new ArrayList(array);
                    added = new ArrayList(addedArray);
                    expected = new ArrayList(expectedArray);
                    break;
                case "LinkedList":
                    actual = new LinkedList(array);
                    added = new LinkedList(addedArray);
                    expected = new LinkedList(expectedArray);
                    break;
                case "DoubleLinkedList":
                    actual = new DoubleLinkedList(array);
                    added = new DoubleLinkedList(addedArray);
                    expected = new DoubleLinkedList(expectedArray);
                    break;
            }
        }
        public void Setup(int[] array, int[] expectedArray)
        {
            switch (str)
            {
                case "ArrayList":
                    actual = new ArrayList(array);
                    expected = new ArrayList(expectedArray);
                    break;

                case "LinkedList":
                    actual = new LinkedList(array);
                    expected = new LinkedList(expectedArray);
                    break;

                case "DoubleLinkedList":
                    actual = new DoubleLinkedList(array);
                    expected = new DoubleLinkedList(expectedArray);
                    break;
            }
        }
        public void Setup(int[] array)
        {
            switch (str)
            {
                case "ArrayList":
                    actual = new ArrayList(array);
                    break;

                case "LinkedList":
                    actual = new LinkedList(array);
                    break;

                case "DoubleLinkedList":
                    actual = new DoubleLinkedList(array);
                    break;
            }
        }

        [TestCase(5781, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 5781 })]
        [TestCase(0, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 0 })]
        [TestCase(-5781, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, -5781 })]
        public void AddTest(int value, int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.Add(value);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 1, 2 }, new int[] { 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 }, new int[] { 1, 2, 3, 3, 2, 1})]
        public void AddMultyTest(int[] actualArray, int[] addedArray, int[] expectedArray)
        {
            Setup(actualArray, addedArray, expectedArray);
            actual.Add(added);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(5781, new int[] { 1, 2, 3 }, new int[] { 5781, 1, 2, 3 })]
        [TestCase(-5781, new int[] { 1, 2, 3 }, new int[] { -5781, 1, 2, 3 })]
        [TestCase(0, new int[] { 1, 2, 3 }, new int[] { 0, 1, 2, 3 })]
        public void AddToBeginTest(int value, int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.AddToBegin(value);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 3, 4, 5 }, new int[] { 1, 2 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 3, 4, 5 }, new int[] { -1, -2 }, new int[] { -1, -2, 3, 4, 5 })]
        public void AddMultyToBeginTest(int[] actualArray, int[] addedArray, int[] expectedArray)
        {
            Setup(actualArray, addedArray, expectedArray);
            actual.AddToBegin(added);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(5781, 2, new int[] { 1, 2, 3 }, new int[] { 1, 2, 5781, 3 })]
        public void AddByIndexTest(int value, int index, int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.AddByIndex(value, index);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(1, new int[] { 1, 4 }, new int[] { 2, 3 }, new int[] { 1, 2, 3, 4 })]
        public void AddMultyByIndexTest(int index, int[] actualArray, int[] addedArray, int[] expectedArray)
        {
            Setup(actualArray, addedArray, expectedArray);
            actual.AddByIndex(added, index);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        public void RemoveTest(int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.Remove();
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        public void RemoveFromBeginTest(int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.RemoveFromBegin();
            Assert.AreEqual(actual, expected);
        }

        [TestCase(1, new int[] { 1, 2, 3 }, new int[] { 1, 3 })]
        [TestCase(2, new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        public void RemoveByIndexTest(int index, int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.RemoveByIndex(index);
            Assert.AreEqual(actual, expected);
        }


        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3 })]
        public void RemoveMultyElementsTest(int count, int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.RemoveMultyElements(count);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
        public void RemoveFromBeginMultyElementsTest(int count, int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.RemoveByIndexMultyElements(count);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 5 })]
        public void RemoveByIndexMultyElements(int count, int index, int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.RemoveByIndexMultyElements(count, index);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(3, 2, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, 0, new int[] { 1, 2, 3, 4, 5 })]
        public void GetFirstIndexByValueTest(int value, int expected, int[] actualArray)
        {
            Setup(actualArray);
            int actualvalue = actual.GetFirstIndexByValue(value);
            Assert.AreEqual(expected, actualvalue);
        }

        [TestCase(6, 0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 2, 3, 4, 5 })]
        public void SetValueByIndexTest(int value, int index, int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.SetValueByIndex(value, index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        public void RevertListTest(int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.RevertList();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, new int[] { 1, 2, 3, 4, 5, 6 })]
        public void GetMaxValueTest(int expected, int[] actualArray)
        {
            Setup(actualArray);
            int actualvalue = actual.GetMaxValue();
            Assert.AreEqual(expected, actualvalue);
        }

        [TestCase(1, new int[] { 1, 2, 3, 4, 5, 6 })]
        public void GetMinValueTest(int expected, int[] actualArray)
        {
            Setup(actualArray);
            int actualvalue = actual.GetMinValue();
            Assert.AreEqual(expected, actualvalue);
        }

        [TestCase(5, new int[] { 1, 2, 3, 4, 5, 6 })]
        public void GetFirstIndexOfMaxValueTest(int expected, int[] actualArray)
        {
            Setup(actualArray);
            int actualValue = actual.GetFirstIndexOfMaxValue();
            Assert.AreEqual(expected, actualValue);
        }

        [TestCase(1, new int[] { 7, 2, 3, 4, 5, 6 })]
        public void GetFirstIndexOfMinValueTest(int expected, int[] actualArray)
        {
            Setup(actualArray);
            int actualValue = actual.GetFirstIndexOfMinValue();
            Assert.AreEqual(expected, actualValue);
        }

        [TestCase(new int[] { 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5 })]
        public void UpSortTest(int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.UpSort();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        public void DownSortTest(int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.DownSort();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 2, new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        public void RemoveFirstByValueTest(int value, int expectedValue, int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            int actualValue = actual.RemoveFirstByValue(value);
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 3, new int[] { 1, 2, 3, 3, 3 }, new int[] { 1, 2 })]
        public void RemoveAllByValueTest(int value, int expectedValue, int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            int actualValue = actual.RemoveAllByValue(value);
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expected, actual);
        }

    }
}
