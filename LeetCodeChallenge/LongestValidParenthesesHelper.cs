using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeChallenge
{
    public class LongestValidParenthesesHelper
    {
        private class Parenthese
        {
            public int StartPos = -1;
            public int EndPos = -1;

            public bool IsValid()
            {
                return (StartPos > -1 && EndPos > -1);
            }

            public int Length()
            {
                if (IsValid())
                {
                    return EndPos - StartPos + 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int LongestValidParentheses(string s)
        {
            char[] textChars = s.ToCharArray();

            if (textChars.Length == 0)
                return 0;

            List<Parenthese> parentheseList = new List<Parenthese>();
            Stack<Parenthese> parentheseStack = new Stack<Parenthese>();

            {
                Parenthese parenthese = null;
                char lastTextChar = '\0';

                for (int textCharIndex = 0; textCharIndex < textChars.Length; ++textCharIndex)
                {
                    char textChar = textChars[textCharIndex];

                    switch (textChar)
                    {
                        case '(':
                            //if there is a ")(" combination, and there was a parenthese before, reuse the current parenthese
                            if (lastTextChar == ')' && parenthese != null)
                            {
                                //Reuse current parenthese

                                //Push current parenthese back to the stack since it was deleted from stack in the ) case
                                parentheseStack.Push(parenthese);
                            }
                            else
                            {
                                //Create new Parenthese
                                parenthese = new Parenthese()
                                {
                                    StartPos = textCharIndex,
                                };
                                parentheseList.Add(parenthese);
                                parentheseStack.Push(parenthese);
                            }
                            break;

                        case ')':
                            //If stack is populated
                            if (parentheseStack.Count > 0)
                                //Fetch the current parenthese of the current level from stack
                                parenthese = parentheseStack.Pop();
                            else  //Level<0
                                //Set parenthese to null, to make sure EndPos is not set to the wrong parenthese
                                parenthese = null;

                            if (parenthese != null)
                                parenthese.EndPos = textCharIndex;
                            break;

                        default:
                            throw new Exception("String must only contain parentheses");
                    }

                    lastTextChar = textChar;
                }
            }


            int maxParentheseLength = 0;

            foreach (Parenthese parenthese in parentheseList)
            {
                if (parenthese.IsValid())
                {
                    int parentheseLength = parenthese.Length();
                    if (maxParentheseLength < parentheseLength)
                        maxParentheseLength = parentheseLength;
                }

            }

            return maxParentheseLength;
        }
    }
}
