using NUnit.Framework;
using List;

namespace ListTests
{
    class ArrayListTests
    {
        [TestCase(5781, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 5781 })]
        public void AddTest(int a, int[] actualArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.Add(a);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(5781, new int[] { 1, 2, 3 }, new int[] { 5781, 1, 2, 3 })]
        public void AddToBeginTest(int a, int [] actualArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.AddToBegin(a);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(5781, 2, new int[] { 1, 2, 3 }, new int[] { 1, 2,5781, 3 })]
        public void AddByIndexTest(int a, int b, int[] actualArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.AddByIndex(a,b);
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
    }
}
