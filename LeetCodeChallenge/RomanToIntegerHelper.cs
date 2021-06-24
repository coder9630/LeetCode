using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class RomanToIntegerHelper
    {
        public int RomanToInt(string s)
        {
            char[] charArray = s.ToCharArray();
            int charArrayLength = charArray.Length;

            int ret = 0;

            for (int index = 0; index < charArrayLength; ++index)
            {
                char c = charArray[index];
                char nextChar = index + 1 < charArrayLength ? charArray[index + 1] : '\0';

                //I can be placed before V(5) and X(10) to make 4 and 9.
                //X can be placed before L(50) and C(100) to make 40 and 90.
                //C can be placed before D(500) and M(1000) to make 400 and 900.
                switch (c)
                {
                    case 'M':
                        ret += 1000;
                        break;

                    case 'D':
                        ret += 500;
                        break;

                    case 'C':
                        if (nextChar == 'D' || nextChar == 'M')
                        {
                            ret -= 100;
                        }
                        else
                        {
                            ret += 100;
                        }
                        break;

                    case 'L':
                        ret += 50;
                        break;

                    case 'X':
                        if (nextChar == 'L' || nextChar == 'C')
                        {
                            ret -= 10;
                        }
                        else
                        {
                            ret += 10;
                        }
                        break;

                    case 'V':
                        ret += 5;
                        break;

                    case 'I':
                        if (nextChar == 'V' || nextChar == 'X')
                        {
                            ret -= 1;
                        }
                        else
                        {
                            ret += 1;
                        }
                        break;
                }
            }

            return ret;
        }
    }
}