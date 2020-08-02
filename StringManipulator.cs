using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AvidTest
{
    public class StringManipulator
    {
        public static string BoldString(string input, string target)
        {
            try
            {
                if (String.IsNullOrEmpty(target))
                    throw new ArgumentException("The string to find may not be empty", "target");
                List<int> indexes = new List<int>();
                for (int index = 0; ; index += 1)
                {
                    index = input.IndexOf(target, index);
                    if (index == -1)
                        break;
                    indexes.Add(index);
                }
                StringBuilder result = new StringBuilder("");
                var endPosition = 0;
                for (int i = 0; i < indexes.Count; i++)
                {
                    var startPos = indexes[i];
                    result.Append(input.Substring(endPosition, startPos - endPosition));
                    result.Append("<b>");
                    while (i < indexes.Count - 1 && indexes[i + 1] - indexes[i] < target.Length)
                        i++;
                    endPosition = indexes[i] + target.Length;
                    result.Append(input.Substring(startPos, endPosition - startPos));
                    result.Append("</b>");
                }
                result.Append(input.Substring(endPosition));
                return result.ToString();
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //A palindrome is those String whose reverse is equal to the original.
        public static bool isPalindromString(String input)
        {
            for (int i = 0; i < input.Length / 2; i++)
                if (input[i] != input[input.Length - 1 - i])
                    return false;
            return true;
        }

        #region MidWordCnt
        //solution 1 : This solution uses custom loop with comparing char and access strings using array indexes for better performance
        public static string MidWordCntCoder(string input)
        {
            //StringBuilder For better performance
            StringBuilder output = new StringBuilder();
            List<char> list = new List<char>();
            char first, last;
            if (input == null)
                return input;
            for (int i = 0; i < input.Length; i++)
            {
                //Processing the word
                if (IsLetterAtIndex(input, i))
                {
                    first = last = input[i];
                    while (IsLetterAtIndex(input, i + 1))
                    {
                        i++;
                        last = input[i];
                        if (!IsLetterAtIndex(input, i + 1))
                        {
                            //input[i] is End of the word
                            break;
                        }
                        if (!list.Contains(last))
                        {
                            list.Add(last);
                        }
                    }
                    output.Append(first + list.Count.ToString() + last);
                    list.Clear();
                }
                //Processing the separator
                else
                {
                    output.Append(input[i]);
                }
            }
            return output.ToString();
        }

        private static bool IsLetterAtIndex(string str, int index)
        {
            if (index >= str.Length)
                return false;
            char ch = str[index];
            return (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z');
        }
        #endregion

        //Two words are said to be Anagrams of each other if they share the same set of letters to form the respective words.
        public static bool AreAnagramString(String word1, String word2)
        {
            //step 1  
            char[] char1 = word1.ToLower().ToCharArray();
            char[] char2 = word2.ToLower().ToCharArray();
            //Step 2  
            Array.Sort(char1);
            Array.Sort(char2);
            //Step 3  
            string NewWord1 = new string(char1);
            string NewWord2 = new string(char2);
            //Step 4  
            //ToLower allows to compare the words in same case, in this case, lower case.  
            //ToUpper will also do exact same thing in this context  
            if (NewWord1 == NewWord2)
                return true;
            return false;
        }

    }
}
