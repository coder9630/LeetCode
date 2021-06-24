namespace LeetCodeChallenge
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100000; ++i)
            {
                MinimumWindowSubstringHelper minimumWindowSubstringHelper = new MinimumWindowSubstringHelper();
                minimumWindowSubstringHelper.MinWindow("ab", "b");
                minimumWindowSubstringHelper.MinWindow("The quick brown fox jumps over the lazy dog", "xyz");
            }
        }
    }
}
