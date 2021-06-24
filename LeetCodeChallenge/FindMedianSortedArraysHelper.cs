using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenge
{
    public class FindMedianSortedArraysHelper
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int sum12 = 0;
            int count12 = 0;

            for (int nums1Index = 0; nums1Index < nums1.Length; ++nums1Index)
            {
                sum12 += nums1[nums1Index];
                ++count12;
            }

            for (int nums2Index = 0; nums2Index < nums2.Length; ++nums2Index)
            {
                sum12 += nums2[nums2Index];
                ++count12;
            }

            double ret;
            if (count12 == 0)
            {
                ret = 0;
            }
            else
            {
                ret = (double)sum12 / count12;
            }

            return ret;
        }
    }
}
