using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenge
{
    public class FirstMissingPositiveHelper
    {
        public int FirstMissingPositive(int[] nums)
        {
            int minPossibleInt = 1;
            int maxPossibleInt = nums.Length;

            bool[] numsAllocated = new bool[maxPossibleInt];

            // Loop through array and mark the allocated numbers
            for (int numIndex = 0; numIndex < nums.Length; ++numIndex)
            {
                int num = nums[numIndex];
                if (num >= minPossibleInt && num <= maxPossibleInt)
                {
                    numsAllocated[num - minPossibleInt] = true;
                }
            }

            // Set minUnallocatedNumber to maxPossibleInt + 1
            // e.g. when we have number 1 to 5 allocated, then the first unallocated number is 6.
            int minUnallocatedNumber = maxPossibleInt + 1;

            // Find first unallocated number
            for (int numIndex = 0; numIndex < maxPossibleInt; ++numIndex)
            {
                if (!numsAllocated[numIndex])
                {
                    minUnallocatedNumber = numIndex + minPossibleInt;
                    break;
                }
            }

            return minUnallocatedNumber;
        }
    }
}
