using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class BitVector64
    {
        /// <summary>
        /// Test all getters and setters within normal range
        /// </summary>
        [TestMethod]
        public void GetterSetter()
        {
            Solvers.Utils.BitVector64 bitVector64 = new Solvers.Utils.BitVector64();
            for (int i = 0; i < 64; i++)
            {
                bitVector64[i] = true;
                for (int j = 0; j < 64; j++)
                {
                    if (j == i)
                    {
                        if(!bitVector64[j]) throw new InvalidDataException($"false while supposed to be true, i: {i}, j: {j}");
                    }
                    else
                    {
                        if(bitVector64[j]) throw new InvalidDataException($"true while supposed to be false, i: {i}, j: {j}");
                    }
                }
                bitVector64[i] = false;
            }
        }

        /// <summary>
        /// Test set for -1
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SetIndexOutOfRangeMinus1()
        {
            Solvers.Utils.BitVector64 bitVector64 = new Solvers.Utils.BitVector64 {[-1] = true};
        }

        /// <summary>
        /// Test set for 64
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SetIndexOutOfRange64()
        {
            Solvers.Utils.BitVector64 bitVector64 = new Solvers.Utils.BitVector64 {[64] = true};
        }

        /// <summary>
        /// Test get for -1
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetIndexOutOfRangeMinus1()
        {
            Solvers.Utils.BitVector64 bitVector64 = new Solvers.Utils.BitVector64();
            bool bitFlag = bitVector64[-1];
        }

        /// <summary>
        /// Test get for 64
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetIndexOutOfRange64()
        {
            Solvers.Utils.BitVector64 bitVector64 = new Solvers.Utils.BitVector64();
            bool bitFlag = bitVector64[64];
        }
    }
}
