using System;
using System.Collections.Generic;
using System.Text;

namespace AvidTest
{
    class LinkedListProblems
    {
        internal class Node
        {
            internal int data;
            internal Node prev;
            internal Node next;
            public Node(int d)
            {
                data = d;
                next = null;
                prev = null;
            }
        }

        public bool DetectCycle(Node head)
        {
            //Create two pointers
            Node lag = head;
            Node lead = lag.next;
            //Move the lag pointer ahead one position in the list and move the leader ahead 2 positions
            while (lead.next != null)
            {
                //If the two pointers point at the same object there is a cycle
                if (lag == lead)
                    return true;
                lag = lag.next;
                for (int i = 0; i < 2; i++)
                {
                    //Checking here avoids NullReference exception
                    if (lead.next == null)
                        return false;
                    lead = lead.next;
                }
            }
            //If the lead pointer points at a null there is no cycle
            return false;
        }
        public Node MergeSortedList(Node first, Node second)
        {
            if (first == null) 
                return second;
            if (second == null)
                return first;
            Node head, tail;
            if (first.data<second.data)
            {
                head = first;
                first = first.next;
            }
            else
            {
                head = second;
                second = second.next;
            }
            tail = head; 
            while (first != null && second != null)
            {
                if (first.data < second.data)
                {
                    tail.next = first;
                    first = first.next;
                }
                else
                {
                    tail.next = second;
                    second = second.next;
                }
            }
            if (first != null)
                tail.next = first;
            else
                tail.next = second;
            return head;
        }
        public void RemoveDuplicates(Node head)
        {
            Node lead, lag;
            lead = lag = head;
            List<int> dic = new List<int>();
            while (lead != null)
                if (!dic.Contains(lead.data))
                {
                    dic.Add(lead.data);
                    lag = lead;
                    lead = lead.next;
                }
                else
                {
                    lag.next = lead.next;
                    //todo: Dispose lead Node
                    lead = lag.next;
                }
        }

    }
}
