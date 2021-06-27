using NUnit.Framework;
using LeetCodeChallenge;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace LeetCodeChallengeTest
{
    class Merge2SortedListsHelperTest
    {
        Merge2SortedListsHelper merge2SortedListsHelper;

        [SetUp]
        public void Setup()
        {
            merge2SortedListsHelper = new Merge2SortedListsHelper();
        }

        [Test]
        public void TestAAA()
        {
            var list1 = Merge2SortedListsHelper.List.CreateList(new int[] { });
            var list2 = Merge2SortedListsHelper.List.CreateList(new int[] { });

            var newList = new Merge2SortedListsHelper.List();
            newList.HeadNode = merge2SortedListsHelper.MergeTwoLists(list1.HeadNode, list2.HeadNode);

            Assert.AreEqual(null, newList.HeadNode);
        }

        [Test]
        public void TestOrigEmpty()
        {
            var list1 = Merge2SortedListsHelper.List.CreateList(new int[] { });
            var list2 = Merge2SortedListsHelper.List.CreateList(new int[] { });

            var newList = new Merge2SortedListsHelper.List();
            newList.HeadNode = merge2SortedListsHelper.MergeTwoLists(list1.HeadNode, list2.HeadNode);

            Assert.AreEqual(null, newList.HeadNode);
        }


        [Test]
        public void TestOrig1()
        {
            var list1 = Merge2SortedListsHelper.List.CreateList(new int[] { 1, 2, 4 });
            var list2 = Merge2SortedListsHelper.List.CreateList(new int[] { 1, 3, 4 });

            var newList = new Merge2SortedListsHelper.List();
            newList.HeadNode = merge2SortedListsHelper.MergeTwoLists(list1.HeadNode, list2.HeadNode);

            var arr = newList.ToArray();
            Assert.AreEqual(6, arr.Length);
            Assert.AreEqual(1, arr[0]);
            Assert.AreEqual(1, arr[1]);
            Assert.AreEqual(2, arr[2]);
            Assert.AreEqual(3, arr[3]);
            Assert.AreEqual(4, arr[4]);
            Assert.AreEqual(4, arr[5]);
        }

        [Test]
        public void TestEH1()
        {
            var list1 = Merge2SortedListsHelper.List.CreateList(new int[] { });
            var list2 = Merge2SortedListsHelper.List.CreateList(new int[] { 1, 3, 4 });

            var newList = new Merge2SortedListsHelper.List();
            newList.HeadNode = merge2SortedListsHelper.MergeTwoLists(list1.HeadNode, list2.HeadNode);

            var arr = newList.ToArray();
            Assert.AreEqual(3, arr.Length);
            Assert.AreEqual(1, arr[0]);
            Assert.AreEqual(3, arr[1]);
            Assert.AreEqual(4, arr[2]);
        }

        [Test]
        public void TestEH2()
        {
            var list1 = Merge2SortedListsHelper.List.CreateList(new int[] { 1, 3, 4 });
            var list2 = Merge2SortedListsHelper.List.CreateList(new int[] { });

            var newList = new Merge2SortedListsHelper.List();
            newList.HeadNode = merge2SortedListsHelper.MergeTwoLists(list1.HeadNode, list2.HeadNode);

            var arr = newList.ToArray();
            Assert.AreEqual(3, arr.Length);
            Assert.AreEqual(1, arr[0]);
            Assert.AreEqual(3, arr[1]);
            Assert.AreEqual(4, arr[2]);
        }

        [Test]
        public void TestEH3()
        {
            var list1 = Merge2SortedListsHelper.List.CreateList(new int[] { 1, 2, 3, 3, 3, 4 });
            var list2 = Merge2SortedListsHelper.List.CreateList(new int[] { 1, 2, 2, 2, 3, 4 });

            var newList = new Merge2SortedListsHelper.List();
            newList.HeadNode = merge2SortedListsHelper.MergeTwoLists(list1.HeadNode, list2.HeadNode);

            var arr = newList.ToArray();
            Assert.AreEqual(12, arr.Length);
            Assert.AreEqual(1, arr[0]);
            Assert.AreEqual(1, arr[1]);
            Assert.AreEqual(2, arr[2]);
            Assert.AreEqual(2, arr[3]);
            Assert.AreEqual(2, arr[4]);
            Assert.AreEqual(2, arr[5]);
            Assert.AreEqual(3, arr[6]);
            Assert.AreEqual(3, arr[7]);
            Assert.AreEqual(3, arr[8]);
            Assert.AreEqual(3, arr[9]);
            Assert.AreEqual(4, arr[10]);
            Assert.AreEqual(4, arr[11]);
        }

    }
}
