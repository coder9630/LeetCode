using NUnit.Framework;
using LeetCodeChallenge;

namespace LeetCodeChallengeTest
{
    class FindMedianSortedArraysHelperTest
    {
        private FindMedianSortedArraysHelper findMedianSortedArraysHelper;

        [SetUp]
        public void Setup()
        {
            findMedianSortedArraysHelper = new FindMedianSortedArraysHelper();
        }

        [Test]
        public void TestAAA()
        {
            Assert.AreEqual(0, findMedianSortedArraysHelper.FindMedianSortedArrays(new int[] { }, new int[] { }));
        }

        [Test]
        public void TestOrigEmpty()
        {
            Assert.AreEqual(0, findMedianSortedArraysHelper.FindMedianSortedArrays(new int[] { }, new int[] { }));
        }

        [Test]
        public void TestOrig1()
        {
            Assert.AreEqual(2.0, findMedianSortedArraysHelper.FindMedianSortedArrays(new int[] { 1, 3 }, new int[] { 2 }));
        }

        [Test]
        public void TestOrig2()
        {
            Assert.AreEqual(2.5, findMedianSortedArraysHelper.FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3, 4 }));
        }

        [Test]
        public void TestOrig3()
        {
            Assert.AreEqual(0, findMedianSortedArraysHelper.FindMedianSortedArrays(new int[] { 0, 0 }, new int[] { 0, 0 }));
        }

        [Test]
        public void TestOrig4()
        {
            Assert.AreEqual(1, findMedianSortedArraysHelper.FindMedianSortedArrays(new int[] { }, new int[] { 1 }));
        }

        [Test]
        public void TestOrig5()
        {
            Assert.AreEqual(2, findMedianSortedArraysHelper.FindMedianSortedArrays(new int[] { 2 }, new int[] { }));
        }
    }
}
