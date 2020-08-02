using System;
using System.Collections.Generic;
using System.Text;

namespace AvidTest
{
    class BitProblems
    {
        static int SparseBitcount(int n)
        {
            int count = 0;
            while (n != 0)
            {
                count++;
                n &= (n - 1);
            }
            return count;
        }
    }
}
