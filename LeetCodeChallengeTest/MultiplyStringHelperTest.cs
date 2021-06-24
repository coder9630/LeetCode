using NUnit.Framework;
using LeetCodeChallenge;

namespace LeetCodeChallengeTest
{
    class MultiplyStringHelperTest
    {
        MultiplyStringsHelper multiplyStringsHelper;

        [SetUp]
        public void Setup()
        {
            multiplyStringsHelper = new MultiplyStringsHelper();
        }

        [Test]
        public void TestAAA()
        {
            Assert.AreEqual("0", multiplyStringsHelper.Multiply("0", "0"));
        }

        [Test]
        public void TestOrigEmpty()
        {
            Assert.AreEqual("0", multiplyStringsHelper.Multiply("0", "0"));
        }

        [Test]
        public void TestOrig1()
        {
            Assert.AreEqual("6", multiplyStringsHelper.Multiply("2", "3"));
        }

        [Test]
        public void TestOrig2()
        {
            Assert.AreEqual("56088", multiplyStringsHelper.Multiply("123", "456"));
        }

        [Test]
        public void TestOrig3()
        {
            Assert.AreEqual("81", multiplyStringsHelper.Multiply("9", "9"));
        }

        [Test]
        public void TestOrig4()
        {
            Assert.AreEqual("0", multiplyStringsHelper.Multiply("9133", "0"));
        }

        [Test]
        public void TestOrig5()
        {
            Assert.AreEqual("419254329864656431168468", multiplyStringsHelper.Multiply("498828660196", "840477629533"));
        }

        [Test]
        public void TestEH1()
        {
            Assert.AreEqual("12321", multiplyStringsHelper.Multiply("111", "111"));
        }
    }
}
