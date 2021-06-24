using NUnit.Framework;
using LeetCodeChallenge;

namespace LeetCodeChallengeTest
{
    class RomanToIntegerHelperTest
    {
        RomanToIntegerHelper romanToIntegerHelper;

        [SetUp]
        public void Setup()
        {
            romanToIntegerHelper = new RomanToIntegerHelper();
        }

        [Test]
        public void TestAAA()
        {
            Assert.AreEqual(0, romanToIntegerHelper.RomanToInt(""));
        }

        [Test]
        public void TestOrigEmpty()
        {
            Assert.AreEqual(0, romanToIntegerHelper.RomanToInt(""));
        }

        [Test]
        public void TestOrig1()
        {
            Assert.AreEqual(3, romanToIntegerHelper.RomanToInt("III"));
        }

        [Test]
        public void TestOrig2()
        {
            Assert.AreEqual(4, romanToIntegerHelper.RomanToInt("IV"));
        }

        [Test]
        public void TestOrig3()
        {
            Assert.AreEqual(9, romanToIntegerHelper.RomanToInt("IX"));
        }

        [Test]
        public void TestOrig4()
        {
            Assert.AreEqual(58, romanToIntegerHelper.RomanToInt("LVIII"));
        }

        [Test]
        public void TestOrig5()
        {
            Assert.AreEqual(1994, romanToIntegerHelper.RomanToInt("MCMXCIV"));
        }

    }
}
