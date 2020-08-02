using System;
using System.Collections.Generic;
using System.Text;

namespace AvidTest
{
    class StackProblems
    {
        internal class StackNode
        {
            internal int Data;
            internal StackNode Min;
            public StackNode(int d)
            {
                Data = d;
            }
        }

        internal class SetOfStacks
        {
            List<Stack<StackNode>> stacks = new List<Stack<StackNode>>();
            internal int capacity;
            public SetOfStacks(int capacity) { this.capacity = capacity; }
            //public void push(int v) { ... }
            //public int pop() { ... }
        }
        internal class MinStacks
        {
            Stack<StackNode> stack = new Stack<StackNode>();
            public void push(int v) 
            {
                var peek = stack.Peek();
                if (true)
                {

                }
            }
            //public int pop() { ... }
        }

    }
}
