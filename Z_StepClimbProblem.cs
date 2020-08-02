using System;
using System.Collections.Generic;
using System.Text;

namespace AvidTest
{
    class Z_StepClimbProblem
    {
        //Stack overfellow 
        public int Num_way_x(int steps)
        {
            //jumps = { 1, 3, 5 }
            if (steps == 0)
                return 0;
            if (steps == 1)
                return 1;
            return Num_way_x(steps - 1) + Num_way_x(steps - 3) + Num_way_x(steps - 5);
        }
        //Stack overfellow 
        public int Num_way_x(int steps, int[] jumps)
        {
            if (steps == 0)
            {
                return 0;
            }
            int total = 0;
            jumps = new int[] { 1, 3, 5 };
            foreach (var i in jumps)
            {
                if (steps - i >= 0)
                {
                    total += Num_way_x(steps, jumps);
                }
            }
            return total;
        }
        //No Stack overfellow 
        public int Num_way_x_bottom_up(int n)
        {
            var ways = new int[n+1];
            ways[0] = 0;
            for (int i = 0; i <= n; i++)
            {
                int total = 0;
                var jumps = new int[] { 1, 3, 5 };
                foreach (var j in jumps)
                {
                    if (i-j >= 0)
                    {
                        total += ways[i-j];
                    }
                }
                ways[i] = total;
            }
            return ways[n];
        }

    }
}
