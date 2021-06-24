using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenge
{

    public class ReverseLinkedList2Helper
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
                    return null;

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

            public bool SwapNodeByIndex(int leftIndex, int rightIndex)
            {
                if (leftIndex > rightIndex)
                    return false;

                var leftNodePrev = FindNode(leftIndex - 1);
                //leftNodePrev can be null (=before headnode)
                //leftNodePrev can be not null (=on or after headnode)

                var rightNodePrev = FindNode(rightIndex - 1);
                if (rightNodePrev == null)
                    return false;

                //LeftNode
                ListNode leftNode;
                if (leftNodePrev != null)
                    leftNode = leftNodePrev.next;
                else
                    leftNode = FindNode(leftIndex);
                if (leftNode == null)
                    return false;

                //RightNode
                ListNode rightNode;
                if (rightNodePrev != null)
                    rightNode = rightNodePrev.next;
                else
                    rightNode = FindNode(rightIndex);
                if (rightNode == null)
                    return false;

                //if leftNodePrev before head and rightNodePrev after head
                if (leftNodePrev == null && rightNodePrev != null)
                {
                    //Set rightNodePrev->Next to headNode
                    rightNodePrev.next = this.headNode;
                    this.headNode = rightNode;
                }
                //if both leftNodePrev and rightNodePrev are set
                else if (leftNodePrev != null && rightNodePrev != null)
                {
                    //Swap prev->next pointers 
                    //even if one of these values is null, it has to be swapped
                    SwapNode(ref leftNodePrev.next, ref rightNodePrev.next);
                }

                //Swap current->next pointers
                //even if one of these values is null, it has to be swapped
                SwapNode(ref leftNode.next, ref rightNode.next);

                return true;
            }

            /// <summary>
            /// Swaps 2 list nodes
            /// </summary>
            /// <param name="listNode1"></param>
            /// <param name="listNode2"></param>
            public void SwapNode(ref ListNode listNode1, ref ListNode listNode2)
            {
                ListNode tempNode;
                tempNode = listNode1;
                listNode1 = listNode2;
                listNode2 = tempNode;
            }
        }


        public ListNode ReverseBetween(ListNode headNode, int fromLeftIndex, int toRightIndex)
        {
            if (headNode == null)
                return null;

            if (fromLeftIndex < 1)
                return null;

            if (toRightIndex < 1)
                return null;

            if (fromLeftIndex > toRightIndex)
                return null;

            //Create a list wrapper from given headNode
            List list = new List();
            list.HeadNode = headNode;

            for (int leftIndex = fromLeftIndex, rightIndex = toRightIndex;
                 leftIndex < rightIndex;
                 ++leftIndex, --rightIndex)
            {
                list.SwapNodeByIndex(leftIndex, rightIndex);
            }

            //return the current headnode
            return list.HeadNode;
        }
    }
}
