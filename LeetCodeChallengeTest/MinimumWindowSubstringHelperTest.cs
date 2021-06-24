using NUnit.Framework;
using LeetCodeChallenge;

namespace LeetCodeChallengeTest
{
    class MinimumWindowSubstringHelperTest
    {
        MinimumWindowSubstringHelper minimumWindowSubstringHelper;

        [SetUp]
        public void Setup()
        {
            minimumWindowSubstringHelper = new MinimumWindowSubstringHelper();
        }

        [Test]
        public void TestAAA()
        {
            Assert.AreEqual("", minimumWindowSubstringHelper.MinWindow("", ""));
        }

        [Test]
        public void TestOrigEmpty()
        {
            Assert.AreEqual("", minimumWindowSubstringHelper.MinWindow("", ""));
        }

        [Test]
        public void TestOrig1()
        {
            Assert.AreEqual("BANC", minimumWindowSubstringHelper.MinWindow("ADOBECODEBANC", "ABC"));
        }

        [Test]
        public void TestOrig2()
        {
            Assert.AreEqual("a", minimumWindowSubstringHelper.MinWindow("a", "a"));
        }

        [Test]
        public void TestOrig3()
        {
            Assert.AreEqual("", minimumWindowSubstringHelper.MinWindow("a", "aa"));
        }

        [Test]
        public void TestOrig4()
        {
            Assert.AreEqual("b", minimumWindowSubstringHelper.MinWindow("ab", "b"));
        }

        [Test]
        public void TestEH1()
        {
            Assert.AreEqual("x jumps over the lazy", minimumWindowSubstringHelper.MinWindow("The quick brown fox jumps over the lazy dog", "xyz"));
        }

    }
}
