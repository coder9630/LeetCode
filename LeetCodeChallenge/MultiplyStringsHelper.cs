using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenge
{
    public class MultiplyStringsHelper
    {
        public string Multiply(string num1, string num2)
        {
            //numberShortLength is the normal number length.
            int numberShortLength = Math.Max(num1.Length, num2.Length);
            //numberLongLength ist double the normal number length because of multiplication.
            int numberLongLength = numberShortLength * 2;

            char[] charCiphers1 = num1.ToCharArray();
            if (charCiphers1.Length == 0)
                return "";

            char[] charCiphers2 = num2.ToCharArray();
            if (charCiphers2.Length == 0)
                return "";

            //Convert numCiphers1
            int?[] numCiphers1 = new int?[numberShortLength];
            {
                int cipherDestIndex = numCiphers1.Length - 1;
                for (int cipherSrcIndex = charCiphers1.Length - 1; cipherSrcIndex >= 0; --cipherSrcIndex)
                {
                    numCiphers1[cipherDestIndex] = charCiphers1[cipherSrcIndex] - '0';
                    --cipherDestIndex;
                }
            }

            //Convert numCiphers2
            int?[] numCiphers2 = new int?[numberShortLength];
            {
                int cipherDestIndex = numCiphers2.Length - 1;
                for (int cipherSrcIndex = charCiphers2.Length - 1; cipherSrcIndex >= 0; --cipherSrcIndex)
                {
                    numCiphers2[cipherDestIndex] = charCiphers2[cipherSrcIndex] - '0';
                    --cipherDestIndex;
                }
            }

            //Set leading zeros to null in numCiphers1
            for (int cipherIndex = 0; cipherIndex < numberShortLength; ++cipherIndex)
            {
                int? numCipher = numCiphers1[cipherIndex];
                if (numCipher > 0)
                    break;
                if (numCipher == 0)
                {
                    numCiphers1[cipherIndex] = null;
                }
            }

            //Set leading zeros to null in numCiphers2
            for (int cipherIndex = 0; cipherIndex < numberShortLength; ++cipherIndex)
            {
                int? numCipher = numCiphers2[cipherIndex];
                if (numCipher > 0)
                    break;
                if (numCipher == 0)
                {
                    numCiphers2[cipherIndex] = null;
                }
            }

            //Multiply numbers
            int?[,] numCiphersMult = new int?[numberShortLength, numberLongLength];
            for (int cipher1Index = numberShortLength - 1; cipher1Index >= 0; --cipher1Index)
            {
                if (numCiphers1[cipher1Index] == null)
                    break;

                //Multiply ciphers
                //cipher2DestIndex must be set to cipher1Index, because the multiplication numbers are diagonal
                // 111
                //  222
                //   333
                int cipher2DestIndex = numberLongLength - numberShortLength + cipher1Index;
                for (int cipher2Index = numberShortLength - 1; cipher2Index >= 0; --cipher2Index)
                {
                    if (numCiphers2[cipher2Index] == null)
                        break;
                    //Multiply cipher1 and cipher2
                    int? numCipher = numCiphers1[cipher1Index] * numCiphers2[cipher2Index];
                    //Put the cipher into the Mult Array
                    numCiphersMult[cipher1Index, cipher2DestIndex] = numCipher;
                    --cipher2DestIndex;
                }
            }

            //Adding the temp numbers into the final number
            int?[] numCiphersResult = new int?[numberLongLength];
            //Adding the ciphers of the numbers into the result
            for (int cipher2Index = numberLongLength - 1; cipher2Index >= 0; --cipher2Index)
            {
                int? numCipherAdd = null;
                for (int cipher1Index = numberShortLength - 1; cipher1Index >= 0; --cipher1Index)
                {
                    int? numCipher = numCiphersMult[cipher1Index, cipher2Index];
                    if (numCipher != null)
                    {
                        if (numCipherAdd == null)
                            numCipherAdd = 0;
                        numCipherAdd += numCipher.GetValueOrDefault();
                    }
                }

                if (numCipherAdd == null)
                    break;

                numCiphersResult[cipher2Index] = numCipherAdd;
            }

            //Move overflow ciphers to ciphers further left
            for (int cipherIndex = numberLongLength - 1; cipherIndex >= 0; --cipherIndex)
            {
                int? numCipher = numCiphersResult[cipherIndex];
                if (numCipher == null)
                    break;
                //If Cipher>=10
                if (numCipher >= 10)
                {
                    //Split up 10 and 1, e.g. 81-> 8 , 1
                    int numCipher1 = numCipher.GetValueOrDefault() % 10;
                    int numCipher10 = (numCipher.GetValueOrDefault() - numCipher1) / 10;
                    //Put the 1 into the same number back
                    numCiphersResult[cipherIndex] = numCipher1;
                    if (numCiphersResult[cipherIndex - 1] == null)
                        numCiphersResult[cipherIndex - 1] = 0;
                    //Add the 10 into the number left to it
                    numCiphersResult[cipherIndex - 1] += numCipher10;
                }
            }

            //If last cipher null, then set to 0 in order to return "0".
            if (numCiphersResult[numCiphersResult.Length - 1] == null)
            {
                numCiphersResult[numCiphersResult.Length - 1] = 0;
            }

            //Calc length of ciphersResult
            int ciphersResultLength = 0;
            for (int cipherSrcIndex = numberLongLength - 1; cipherSrcIndex >= 0; --cipherSrcIndex)
            {
                int? numCipher = numCiphersResult[cipherSrcIndex];
                if (numCipher == null)
                    break;
                ++ciphersResultLength;
            }

            //Convert numCiphersResult
            char[] charCiphersResult = new char[ciphersResultLength];
            {
                int cipherDestIndex = ciphersResultLength - 1;
                for (int cipherSrcIndex = numberLongLength - 1; cipherSrcIndex >= 0; --cipherSrcIndex)
                {
                    int? numCipher = numCiphersResult[cipherSrcIndex];
                    if (numCipher == null)
                        break;
                    charCiphersResult[cipherDestIndex] = (char)(numCipher.GetValueOrDefault() + 48);
                    --cipherDestIndex;
                }
            }

            string strCiphersResult = new string(charCiphersResult);

            return strCiphersResult;
        }
    }
}