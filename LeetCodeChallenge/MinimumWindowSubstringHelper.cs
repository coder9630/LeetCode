using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenge
{
    public class MinimumWindowSubstringHelper
    {
        private class TextSlidingWindowItem
        {
            public int CurrentCount = 0;
            public int ExpectedCount = 0;
        }

        private class TextSlidingWindow
        {
            public const int MaxLength = 100000;
            
            public int LeftPos = -1;
            public int RightPos = -1;

            private char[] textChars;
            private int textCharsLength;
            private Dictionary<char, int> patternDict = new Dictionary<char, int>();
            private Dictionary<char, TextSlidingWindowItem> textDict = new Dictionary<char, TextSlidingWindowItem>();

            public TextSlidingWindow()
            {
            }

            //Copy constructor
            public TextSlidingWindow(TextSlidingWindow srcTextSlidingWindow) : base()
            {
                this.LeftPos = srcTextSlidingWindow.LeftPos;
                this.RightPos = srcTextSlidingWindow.RightPos;
                this.textChars = srcTextSlidingWindow.textChars;
                this.textCharsLength = srcTextSlidingWindow.textCharsLength;
            }

            public void Initialize(in char[] textChars, in char[] patternChars)
            {
                //Set Pattern
                this.patternDict.Clear();

                for (int patternCharIndex = 0; patternCharIndex < patternChars.Length; ++patternCharIndex)
                {
                    char patternChar = patternChars[patternCharIndex];
                    if (!this.patternDict.ContainsKey(patternChar))
                        this.patternDict.Add(patternChar, 1);
                    else
                        this.patternDict[patternChar]++;
                }

                //Set Text
                this.textChars = textChars;
                this.textCharsLength = this.textChars.Length;

                //Prepare Text Dictionary
                this.textDict.Clear();
                foreach (char patternChar in this.patternDict.Keys)
                {
                    var patternSlidingWindowItem = new TextSlidingWindowItem()
                    {
                        CurrentCount = 0,
                        ExpectedCount = patternDict[patternChar]
                    };

                    this.textDict.Add(patternChar, patternSlidingWindowItem);
                }
            }

            public bool ContainsAllLetters()
            {
                foreach (var patternSlidingWindowItem in this.textDict.Values)
                {
                    //if one letter has smaller count than expected, go out
                    if (patternSlidingWindowItem.CurrentCount < patternSlidingWindowItem.ExpectedCount)
                        return false;
                }

                return true;
            }

            public int Length
            {
                get
                {
                    return RightPos - LeftPos + 1;
                }
            }

            public string Text
            {
                get
                {
                    return new String(this.textChars, this.LeftPos, this.Length);
                }
            }

            public void MoveFirst()
            {
                this.LeftPos = 0;
                this.RightPos = -1;
            }

            public void MoveNextLeftPos(out bool keyCharHit)
            {
                //get char from old left pos
                char textChar = this.textChars[this.LeftPos];

                //reduce char in dictionary
                if (this.textDict.ContainsKey(textChar))
                {
                    keyCharHit = true;
                    //Decrease character count
                    --this.textDict[textChar].CurrentCount;
                }
                else
                {
                    keyCharHit = false;
                }

                //move left pos
                ++this.LeftPos;
            }

            public void MoveNextRightPos(out bool keyCharHit)
            {
                //move right pos
                ++RightPos;

                if (this.EOFRightPos())
                {
                    keyCharHit = false;
                    return;
                }

                //get char from new right pos
                char textChar = this.textChars[this.RightPos];

                //increase char in dictionary
                if (this.textDict.ContainsKey(textChar))
                {
                    keyCharHit = true;
                    //Increase character count
                    ++this.textDict[textChar].CurrentCount;
                }
                else
                {
                    keyCharHit = false;
                }
            }

            public bool EOFLeftPos()
            {
                if (this.LeftPos > this.textCharsLength - 1)
                    return true;

                return false;
            }

            public bool EOFRightPos()
            {
                if (this.RightPos > this.textCharsLength - 1)
                    return true;

                return false;
            }
        }


        public string MinWindow(string text, string pattern)
        {
            if (String.IsNullOrWhiteSpace(text))
                return string.Empty;

            if (String.IsNullOrWhiteSpace(pattern))
                return string.Empty;

            if (text.Length < pattern.Length)
                return string.Empty;

            char[] textChars = text.ToCharArray();
            char[] patternChars = pattern.ToCharArray();

            TextSlidingWindow textSlidingWindow = new TextSlidingWindow();
            textSlidingWindow.Initialize(textChars, patternChars);

            TextSlidingWindow minTextSlidingWindow = new TextSlidingWindow(textSlidingWindow);
            minTextSlidingWindow.LeftPos = 0;
            minTextSlidingWindow.RightPos = TextSlidingWindow.MaxLength;

            textSlidingWindow.MoveFirst();

            string ret;

            {
                bool keyCharHitRight = false;

                while (!textSlidingWindow.EOFRightPos())
                {
                    if (keyCharHitRight)
                    {
                        if (textSlidingWindow.ContainsAllLetters())
                        {
                            //if minTextSlidingWindow is not set
                            //if minTextSlidingWindow is bigger than current sliding window
                            //remember this sliding window
                            if (minTextSlidingWindow.Length > textSlidingWindow.Length)
                            {
                                minTextSlidingWindow.LeftPos = textSlidingWindow.LeftPos;
                                minTextSlidingWindow.RightPos = textSlidingWindow.RightPos;
                            }

                            if (minTextSlidingWindow != null)
                            {
                                //If window length is equal pattern length, then the window cannot be smaller (short-cut out)
                                if (minTextSlidingWindow.Length == patternChars.Length)
                                    break;

                            }

                            bool keyCharHitLeft = false;

                            while (!textSlidingWindow.EOFLeftPos())
                            {
                                if (keyCharHitLeft)
                                {
                                    if (textSlidingWindow.ContainsAllLetters())
                                    {
                                        //if minTextSlidingWindow is bigger than current sliding window
                                        //remember this one.
                                        if (minTextSlidingWindow.Length > textSlidingWindow.Length)
                                        {
                                            minTextSlidingWindow.LeftPos = textSlidingWindow.LeftPos;
                                            minTextSlidingWindow.RightPos = textSlidingWindow.RightPos;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                textSlidingWindow.MoveNextLeftPos(out keyCharHitLeft);
                            }

                            //If the recent left character was a hit
                            if (keyCharHitLeft)
                            {
                                //since leftpos was increased, the sliding window does not contain the hit character anymore under leftpos.
                                //if minTextSlidingWindow is bigger than current sliding window
                                //remember this one.
                                if (minTextSlidingWindow.Length > textSlidingWindow.Length + 1)
                                {
                                    minTextSlidingWindow.LeftPos = textSlidingWindow.LeftPos - 1;
                                    minTextSlidingWindow.RightPos = textSlidingWindow.RightPos;
                                }
                            }
                        }
                    }

                    textSlidingWindow.MoveNextRightPos(out keyCharHitRight);
                }
            }

            //Get Text from min sliding window
            if (minTextSlidingWindow.RightPos < TextSlidingWindow.MaxLength)
            {
                ret = minTextSlidingWindow.Text;
            }
            else
            {
                ret = "";
            }

            return ret;
        }
    }
}
