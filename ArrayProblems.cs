using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AvidTest
{
    class ArrayProblems
    {
        public static int GetMajorityElement(params int[] x)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            int majority = x.Length / 2;
            //Stores the number of occcurences of each item in the passed array in a dictionary
            foreach (int i in x)
                if (d.ContainsKey(i))
                {
                    d[i]++;
                    //Checks if element just added is the majority element
                    if (d[i] > majority)
                        return i;
                }
                else
                    d.Add(i, 1);
            //No majority element
            throw new Exception("No majority element in array");
        }
        
        public static bool ContainsDuplicates(params int[] x)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            foreach (int i in x)
            {
                if (d.ContainsKey(i))
                    return true;
                else
                    d.Add(i, 1);
            }
            return false;
        }

        public static int IntegersSumToTarget(int[] arr, int target)
        {
            int sumsCount = 0;
            Array.Sort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == target)
                        sumsCount++;
                    if (arr[i] + arr[j] > target) 
                        break;
                }
            }
            return sumsCount;
        }

        private static int[] RotateSub(int[] x, int start, int end)
        {
            if (x.Length < start + end)
                throw new IndexOutOfRangeException("Length < start + end");
            for (int i = start; i < end/2; i++)
            {
                int temp = x[start];
                x[start] = x[end];
                x[end] = temp;
            }
            return x;
        }
        public static int[] Rotate(int[] x, int pivot)
        {
            if (pivot < 0 || pivot >= x.Length || x == null)
                throw new Exception("Invalid argument");
            //Rotate first half
            x = RotateSub(x, 0, pivot - 1);
            //Rotate second half
            x = RotateSub(x, pivot, x.Length - 1);
            return x;
        }



        public static int[] TopNScors(int[] scores, int n)
        {
            return scores.OrderByDescending(score => score).Take(3).ToArray<int>();
        }
        public static int[] OtherThanTopNScors(int[] scores, int n)
        {
            return scores.OrderByDescending(score => score).Skip(3).ToArray<int>();
        }


    }
}
