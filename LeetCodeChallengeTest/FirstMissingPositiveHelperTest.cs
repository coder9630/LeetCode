using NUnit.Framework;
using LeetCodeChallenge;

namespace LeetCodeChallengeTest
{
    class FirstMissingPositiveHelperTest
    {
        FirstMissingPositiveHelper firstMissingPositiveHelper;

        [SetUp]
        public void Setup()
        {
            firstMissingPositiveHelper = new FirstMissingPositiveHelper();
        }

        [Test]
        public void TestAAA()
        {
            Assert.AreEqual(1, firstMissingPositiveHelper.FirstMissingPositive(new int[] { }));
        }

        [Test]
        public void TestOrigEmpty()
        {
            Assert.AreEqual(1, firstMissingPositiveHelper.FirstMissingPositive(new int[] { }));
        }

        [Test]
        public void TestOrig1()
        {
            Assert.AreEqual(3, firstMissingPositiveHelper.FirstMissingPositive(new int[] { 1, 2, 0 }));
        }

        [Test]
        public void TestOrig2()
        {
            Assert.AreEqual(2, firstMissingPositiveHelper.FirstMissingPositive(new int[] { 3, 4, -1, 1 }));
        }

        [Test]
        public void TestOrig3()
        {
            Assert.AreEqual(1, firstMissingPositiveHelper.FirstMissingPositive(new int[] { 7, 8, 9, 11, 12 }));
        }

        [Test]
        public void TestOrig4()
        {
            Assert.AreEqual(2, firstMissingPositiveHelper.FirstMissingPositive(new int[] { 1 }));
        }
    }
}
