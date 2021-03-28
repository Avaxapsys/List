using NUnit.Framework;
using List;

namespace ListTests
{
    class ArrayListTests
    {
        [TestCase(5781, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 5781 })]
        public void AddTest(int value, int[] actualArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.Add(value);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 1, 2 }, new int[] { 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        public void AddTest(int[] actualArray, int[] nextArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList next = new ArrayList(nextArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.Add(next);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(5781, new int[] { 1, 2, 3 }, new int[] { 5781, 1, 2, 3 })]
        public void AddToBeginTest(int value, int [] actualArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.AddToBegin(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 4, 5 }, new int[] { 1, 2 }, new int[] { 1, 2, 3, 4, 5 })]
        public void AddToBeginTest(int[] actualArray, int[] nextArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList next = new ArrayList(nextArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.AddToBegin(next);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(5781, 2, new int[] { 1, 2, 3 }, new int[] { 1, 2,5781, 3 })]
        public void AddByIndexTest(int value, int index, int[] actualArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.AddByIndex(value, index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 1, 4 }, new int[] { 2, 3 }, new int[] { 1, 2, 3, 4 })]
        public void AddByIndexTest(int index, int[] actualArray, int[] nextArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList next = new ArrayList(nextArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.AddByIndex(next, index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] {1, 2})]
        public void RemoveTest(int[] actualArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.Remove();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        public void RemoveFromBeginTest(int[] actualArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveFromBegin();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 1, 2, 3 }, new int[] { 1, 3 })]
        [TestCase(2, new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        public void RemoveByIndexTest(int a, int[] actualArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveByIndex(a);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3 })]
        public void RemoveMultyElementsTest(int a, int[] actualArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveMultyElements(a);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
        public void RemoveFromBeginMultyElementsTest(int a, int[] actualArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveFromBeginMultyElements(a);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2, new int[] { 1, 2, 3, 4, 5}, new int[] { 1, 2, 4, 5})]
        public void RemoveByIndexMultyElementsTest(int a, int b, int[] actualArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveByIndexMultyElements(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 2,  new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, 0, new int[] { 1, 2, 3, 4, 5 })]
        //[TestCase(6, 0, new int[] { 1, 2, 3, 4, 5 })]
        public void GetFirstIndexByValueTest(int value, int expected, int[] array)
        {
            ArrayList actualArray = new ArrayList(array);
            int actual = actualArray.GetFirstIndexByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, 0, new int[] { 1, 2, 3, 4, 5 }, new int[] {6, 2, 3, 4, 5})]
        public void SetValueByIndexTest(int value, int index, int[] actualArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.SetValueByIndex(value, index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        public void RevertListTest( int[] actualArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RevertList();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, new int[] { 1, 2, 3, 4, 5, 6 })]
        public void GetMaxValueTest(int expected, int[] array)
        {
            ArrayList actualArray = new ArrayList(array);
            int actual = actualArray.GetMaxValue();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 1, 2, 3, 4, 5, 6 })]
        public void GetMinValueTest(int expected, int[] array)
        {
            ArrayList actualArray = new ArrayList(array);
            int actual = actualArray.GetMinValue();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, new int[] { 1, 2, 3, 4, 5, 6 })]
        public void GetFirstIndexOfMaxValueTest(int expected, int[] array)
        {
            ArrayList actualArray = new ArrayList(array);
            int actual = actualArray.GetFirstIndexOfMaxValue();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 7, 2, 3, 4, 5, 6 })]
        public void GetFirstIndexOfMinValueTest(int expected, int[] array)
        {
            ArrayList actualArray = new ArrayList(array);
            int actual = actualArray.GetFirstIndexOfMinValue();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5 })]
        public void UpSortTest(int[] actualArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.UpSort();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        public void DownSortTest(int[] actualArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.DownSort();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 2, new int[] { 1, 2, 3 }, new int[] {1, 2 })]
        public void RemoveFirstByValueTest(int value, int expected, int[] actualArrayInput, int [] expectedArrayInput)
        {
            ArrayList actualArray = new ArrayList(actualArrayInput);
            int actual = actualArray.RemoveFirstByValue(value);
            ArrayList expectrdArray = new ArrayList(expectedArrayInput);
            Assert.AreEqual(expectrdArray, actualArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 3, new int[] { 1, 2, 3, 3, 3 }, new int[] { 1, 2 })]
        public void RemoveAllByValueTest(int value, int expected, int[] actualArrayInput, int[] expectedArrayInput)
        {
            ArrayList actualArray = new ArrayList(actualArrayInput);
            int actual = actualArray.RemoveAllByValue(value);
            Assert.AreEqual(expected, actual);
        }

    }
}
