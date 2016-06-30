using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solvers.Utils;

namespace UnitTests
{
    [TestClass]
    public class TestBinaryHeap
    {
        [TestMethod]
        public void Initialise()
        {
            BinaryHeap<int> binaryHeap = new BinaryHeap<int>();
            initOrder(binaryHeap);
            binaryHeap = new BinaryHeap<int>();
            initOrderRev(binaryHeap);

            binaryHeap = new BinaryHeap<int>(false);
            initOrder(binaryHeap, false);
            binaryHeap = new BinaryHeap<int>(false);
            initOrderRev(binaryHeap, false);

            binaryHeap = new BinaryHeap<int>(true, Comparer<int>.Default);
            initOrder(binaryHeap);
            binaryHeap = new BinaryHeap<int>(true, Comparer<int>.Default);
            initOrderRev(binaryHeap);

            binaryHeap = new BinaryHeap<int>(false, Comparer<int>.Default);
            initOrder(binaryHeap, false);
            binaryHeap = new BinaryHeap<int>(false, Comparer<int>.Default);
            initOrderRev(binaryHeap, false);

            binaryHeap = new BinaryHeap<int>(true, Comparer<int>.Create((x, y) => y - x));
            initOrder(binaryHeap, false);
            binaryHeap = new BinaryHeap<int>(true, Comparer<int>.Create((x, y) => y - x));
            initOrderRev(binaryHeap, false);

            binaryHeap = new BinaryHeap<int>(false, Comparer<int>.Create((x, y) => y - x));
            initOrder(binaryHeap);
            binaryHeap = new BinaryHeap<int>(false, Comparer<int>.Create((x, y) => y - x));
            initOrderRev(binaryHeap);
        }

        private void initOrder(BinaryHeap<int> binaryHeap, bool maximum = true)
        {
            binaryHeap.Insert(1);
            binaryHeap.Insert(2);
            Assert.IsTrue(binaryHeap.Pop() == 2 == maximum);
        }
        private void initOrderRev(BinaryHeap<int> binaryHeap, bool maximum = true)
        {
            binaryHeap.Insert(2);
            binaryHeap.Insert(1);
            Assert.IsTrue(binaryHeap.Pop() == 2 == maximum);
        }

        [TestMethod]
        public void InitialiseIEnumerable()
        {
            int[] oneTwo = new int[2] { 1, 2 };
            int[] twoOne = new int[2] { 2, 1 };

            BinaryHeap<int> binaryHeap = new BinaryHeap<int>(oneTwo);
            initOrderIEnumerable(binaryHeap);
            binaryHeap = new BinaryHeap<int>(twoOne);
            initOrderIEnumerable(binaryHeap);

            binaryHeap = new BinaryHeap<int>(oneTwo, false);
            initOrderIEnumerable(binaryHeap, false);
            binaryHeap = new BinaryHeap<int>(twoOne, false);
            initOrderIEnumerable(binaryHeap, false);

            binaryHeap = new BinaryHeap<int>(oneTwo, true, Comparer<int>.Default);
            initOrderIEnumerable(binaryHeap);
            binaryHeap = new BinaryHeap<int>(twoOne, true, Comparer<int>.Default);
            initOrderIEnumerable(binaryHeap);

            binaryHeap = new BinaryHeap<int>(oneTwo, false, Comparer<int>.Default);
            initOrderIEnumerable(binaryHeap, false);
            binaryHeap = new BinaryHeap<int>(twoOne, false, Comparer<int>.Default);
            initOrderIEnumerable(binaryHeap, false);

            binaryHeap = new BinaryHeap<int>(oneTwo, true, Comparer<int>.Create((x, y) => y - x));
            initOrderIEnumerable(binaryHeap, false);
            binaryHeap = new BinaryHeap<int>(twoOne, true, Comparer<int>.Create((x, y) => y - x));
            initOrderIEnumerable(binaryHeap, false);

            binaryHeap = new BinaryHeap<int>(oneTwo, false, Comparer<int>.Create((x, y) => y - x));
            initOrderIEnumerable(binaryHeap);
            binaryHeap = new BinaryHeap<int>(twoOne, false, Comparer<int>.Create((x, y) => y - x));
            initOrderIEnumerable(binaryHeap);
        }

        private void initOrderIEnumerable(BinaryHeap<int> binaryHeap, bool maximum = true)
        {
            Assert.IsTrue(binaryHeap.Pop() == 2 == maximum);
        }

        [TestMethod]
        public void Insert()
        {
            BinaryHeap<int> binaryHeap = new BinaryHeap<int>();
            binaryHeap.Insert(1);
            binaryHeap.Insert(3);
            binaryHeap.Insert(2);
            binaryHeap.Insert(4);
            binaryHeap.Insert(-1);
            binaryHeap.Insert(0);
            Assert.AreEqual(4, binaryHeap.Pop());
        }

        [TestMethod]
        public void Pop()
        {
            BinaryHeap<int> binaryHeap = new BinaryHeap<int>();
            binaryHeap.Insert(1);
            Assert.AreEqual(1, binaryHeap.Pop());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopInvalid()
        {
            BinaryHeap<int> binaryHeap = new BinaryHeap<int>();
            binaryHeap.Pop();
        }

        [TestMethod]
        public void Peak()
        {
            BinaryHeap<int> binaryHeap = new BinaryHeap<int>();
            binaryHeap.Insert(1);
            Assert.AreEqual(1, binaryHeap.Peak());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeakInvalid()
        {
            BinaryHeap<int> binaryHeap = new BinaryHeap<int>();
            binaryHeap.Peak();
        }
    }
}
