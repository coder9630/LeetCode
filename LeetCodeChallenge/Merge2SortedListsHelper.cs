using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenge
{

    public class Merge2SortedListsHelper
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public class List
        {
            private ListNode headNode;

            public List()
            {
            }

            public ListNode HeadNode
            {
                get
                {
                    return this.headNode;
                }
                set
                {
                    this.headNode = value;
                }
            }

            public static List CreateList(int[] values)
            {
                var list = new List();

                if (values.Length == 0)
                    return list;

                list.headNode = new ListNode();
                list.headNode.val = values[0];

                var newEndNode = list.headNode;
                for (int index = 1; index < values.Length; ++index)
                {
                    newEndNode.next = new ListNode();
                    newEndNode = newEndNode.next;
                    newEndNode.val = values[index];
                }

                return list;
            }

            public System.Collections.Generic.IEnumerable<ListNode> Nodes
            {
                get
                {
                    if (this.headNode != null)
                    {
                        yield return this.headNode;

                        var endNode = this.headNode;
                        while (endNode.next != null)
                        {
                            endNode = endNode.next;
                            yield return endNode;
                        }
                    }
                }
            }

            public int[] ToArray()
            {
                int count = this.Count();

                if (count == 0)
                    return new int[0];

                int[] ret = new int[count];

                int index = 0;
                foreach (ListNode node in this.Nodes)
                {
                    ret[index] = node.val;
                    ++index;
                }

                return ret;
            }

            public int Count()
            {
                int count = 0;
                foreach (ListNode node in this.Nodes)
                {
                    ++count;
                }
                return count;
            }

            public ListNode FindNode(int searchIndex)
            {
                int index = 1;
                foreach (ListNode node in this.Nodes)
                {
                    if (index == searchIndex)
                        return node;
                    ++index;
                }

                return null;
            }
        }

        public ListNode MergeTwoLists(ListNode headNode1, ListNode headNode2)
        {
            if (headNode1 == null && headNode2 == null)
                return null;

            List retlist = new List();

            ListNode currNode1 = headNode1;
            ListNode currNode2 = headNode2;
            ListNode retHeadNode = null;
            ListNode newEndNode = null;

            while (currNode1 != null || currNode2 != null)
            {
                int currVal = 0;
                if (currNode1 != null && currNode2 == null)
                {
                    currVal = currNode1.val;
                    currNode1 = currNode1.next;
                }
                else if (currNode1 == null && currNode2 != null)
                {
                    currVal = currNode2.val;
                    currNode2 = currNode2.next;
                }
                else
                {
                    if (currNode1.val < currNode2.val)
                    {
                        currVal = currNode1.val;
                        currNode1 = currNode1.next;
                    }
                    else if (currNode1.val > currNode2.val)
                    {
                        currVal = currNode2.val;
                        currNode2 = currNode2.next;
                    }
                    else if (currNode1.val == currNode2.val)
                    {
                        currVal = currNode1.val;
                        currNode1 = currNode1.next;
                    }
                }


                if (retHeadNode == null)
                {
                    retHeadNode = new ListNode();
                    retHeadNode.val = currVal;
                    newEndNode = retHeadNode;
                }
                else
                {
                    newEndNode.next = new ListNode();
                    newEndNode = newEndNode.next;
                    newEndNode.val = currVal;
                }
            }

            return retHeadNode;
        }
    }
}
