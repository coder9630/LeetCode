﻿using NUnit.Framework;
using LeetCodeChallenge;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace LeetCodeChallengeTest
{
    class ReverseLinkedList2HelperTest
    {
        ReverseLinkedList2Helper reverseLinkedList2Helper;

        [SetUp]
        public void Setup()
        {
            reverseLinkedList2Helper = new ReverseLinkedList2Helper();
        }

        [Test]
        public void TestAAA()
        {
            var list = ReverseLinkedList2Helper.List.CreateList(new int[] {  });

            var newList = new ReverseLinkedList2Helper.List();
            newList.HeadNode = reverseLinkedList2Helper.ReverseBetween(list.HeadNode, 1, 1);

            Assert.AreEqual(null, newList.HeadNode);
        }

        [Test]
        public void TestOrigEmpty()
        {
            var list = ReverseLinkedList2Helper.List.CreateList(new int[] { });

            var newList = new ReverseLinkedList2Helper.List();
            newList.HeadNode = reverseLinkedList2Helper.ReverseBetween(list.HeadNode, 1, 1);

            Assert.AreEqual(null, newList.HeadNode);
        }


        [Test]
        public void TestOrig1()
        {
            var list = ReverseLinkedList2Helper.List.CreateList(new int[] { 1, 2, 3, 4, 5 });

            var newList = new ReverseLinkedList2Helper.List();
            newList.HeadNode = reverseLinkedList2Helper.ReverseBetween(list.HeadNode, 2, 4);

            var arr = newList.ToArray();
            Assert.AreEqual(5, arr.Length);
            Assert.AreEqual(1, arr[0]);
            Assert.AreEqual(4, arr[1]);
            Assert.AreEqual(3, arr[2]);
            Assert.AreEqual(2, arr[3]);
            Assert.AreEqual(5, arr[4]);
        }

        [Test]
        public void TestOrig2()
        {
            var list = ReverseLinkedList2Helper.List.CreateList(new int[] { 5 });

            var newList = new ReverseLinkedList2Helper.List();
            newList.HeadNode = reverseLinkedList2Helper.ReverseBetween(list.HeadNode, 1, 1);

            var arr = newList.ToArray();
            Assert.AreEqual(1, arr.Length);
            Assert.AreEqual(5, arr[0]);
        }

        [Test]
        public void TestEH1()
        {
            var list = ReverseLinkedList2Helper.List.CreateList(new int[] { 1, 2, 3, 4, 5 });

            var newList = new ReverseLinkedList2Helper.List();
            newList.HeadNode = reverseLinkedList2Helper.ReverseBetween(list.HeadNode, 1, 5);

            var arr = newList.ToArray();
            Assert.AreEqual(5, arr.Length);
            Assert.AreEqual(5, arr[0]);
            Assert.AreEqual(4, arr[1]);
            Assert.AreEqual(3, arr[2]);
            Assert.AreEqual(2, arr[3]);
            Assert.AreEqual(1, arr[4]);
        }

        [Test]
        public void TestEH2()
        {
            var list = ReverseLinkedList2Helper.List.CreateList(new int[] { 1, 2, 3, 4, 5 });

            var newList = new ReverseLinkedList2Helper.List();
            newList.HeadNode = reverseLinkedList2Helper.ReverseBetween(list.HeadNode, 1, 4);

            var arr = newList.ToArray();
            Assert.AreEqual(5, arr.Length);
            Assert.AreEqual(4, arr[0]);
            Assert.AreEqual(3, arr[1]);
            Assert.AreEqual(2, arr[2]);
            Assert.AreEqual(1, arr[3]);
            Assert.AreEqual(5, arr[4]);
        }

        [Test]
        public void TestEH3()
        {
            var list = ReverseLinkedList2Helper.List.CreateList(new int[] { 1, 2, 3, 4, 5 });

            var newList = new ReverseLinkedList2Helper.List();
            newList.HeadNode = reverseLinkedList2Helper.ReverseBetween(list.HeadNode, 1, 1);

            var arr = newList.ToArray();
            Assert.AreEqual(5, arr.Length);
            Assert.AreEqual(1, arr[0]);
            Assert.AreEqual(2, arr[1]);
            Assert.AreEqual(3, arr[2]);
            Assert.AreEqual(4, arr[3]);
            Assert.AreEqual(5, arr[4]);
        }

        [Test]
        public void TestEH4()
        {
            var list = ReverseLinkedList2Helper.List.CreateList(new int[] { 1, 2, 3, 4, 5 });

            var newList = new ReverseLinkedList2Helper.List();
            newList.HeadNode = reverseLinkedList2Helper.ReverseBetween(list.HeadNode, 2, 5);

            var arr = newList.ToArray();
            Assert.AreEqual(5, arr.Length);
            Assert.AreEqual(1, arr[0]);
            Assert.AreEqual(5, arr[1]);
            Assert.AreEqual(4, arr[2]);
            Assert.AreEqual(3, arr[3]);
            Assert.AreEqual(2, arr[4]);
        }
    }
}
