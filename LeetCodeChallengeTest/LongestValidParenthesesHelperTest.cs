using NUnit.Framework;
using LeetCodeChallenge;

namespace LeetCodeChallengeTest
{
    public class LongestValidParenthesesHelperTest
    {
        LongestValidParenthesesHelper longestValidParenthesesHelper;

        [SetUp]
        public void Setup()
        {
            longestValidParenthesesHelper = new LongestValidParenthesesHelper();
        }

        [Test]
        public void TestAAA()
        {
            Assert.AreEqual(0, longestValidParenthesesHelper.LongestValidParentheses(""));
        }

        [Test]
        public void TestOrigEmpty()
        {
            Assert.AreEqual(0, longestValidParenthesesHelper.LongestValidParentheses(""));
        }

        [Test]
        public void TestOrig1()
        {
            Assert.AreEqual(2, longestValidParenthesesHelper.LongestValidParentheses("(()"));
        }

        [Test]
        public void TestOrig2()
        {
            Assert.AreEqual(4, longestValidParenthesesHelper.LongestValidParentheses(")()())"));
        }

        [Test]
        public void TestOrig3()
        {
            Assert.AreEqual(0, longestValidParenthesesHelper.LongestValidParentheses("("));
        }

        [Test]
        public void TestOrig4()
        {
            Assert.AreEqual(0, longestValidParenthesesHelper.LongestValidParentheses(")"));
        }

        [Test]
        public void TestEH1()
        {
            Assert.AreEqual(14, longestValidParenthesesHelper.LongestValidParentheses("((()))(((())))"));
        }
    }
}