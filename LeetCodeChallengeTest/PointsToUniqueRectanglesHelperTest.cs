using NUnit.Framework;
using LeetCodeChallenge;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace LeetCodeChallengeTest
{
    class PointsToUniqueRectanglesHelperTest
    {
        PointsToUniqueRectanglesHelper pointsToUniqueRectanglesHelper;
         
        [SetUp]
        public void Setup()
        {
            pointsToUniqueRectanglesHelper = new PointsToUniqueRectanglesHelper();
        }

        [Test]
        public void TestAAA()
        {
            var points = new List<Point>();

            var rectangles = pointsToUniqueRectanglesHelper.PointsToUniqueRectangles(points);
            rectangles.Sort(CompareRectangles);

            Assert.AreEqual(0, rectangles.Count);
        }

        [Test]
        public void TestOrigEmpty()
        {
            var points = new List<Point>();

            var rectangles = pointsToUniqueRectanglesHelper.PointsToUniqueRectangles(points);
            rectangles.Sort(CompareRectangles);

            Assert.AreEqual(0, rectangles.Count);
        }


        [Test]
        public void TestEH1()
        {
            var points = new List<Point>();
            points.Add(new Point(0, 1));
            points.Add(new Point(1, 1));
            points.Add(new Point(0, 0));
            points.Add(new Point(1, 0));

            var rectangles = pointsToUniqueRectanglesHelper.PointsToUniqueRectangles(points);
            rectangles.Sort(CompareRectangles);

            Assert.AreEqual(1, rectangles.Count);
            Assert.AreEqual(new Rectangle(0, 1, 1, 1), rectangles[0]);
        }

        [Test]
        public void TestEH2()
        {
            var points = new List<Point>();
            points.Add(new Point(0, 1));
            points.Add(new Point(1, 1));
            points.Add(new Point(2, 1));
            points.Add(new Point(0, 0));
            points.Add(new Point(1, 0));
            points.Add(new Point(2, 0));
            
            var rectangles = pointsToUniqueRectanglesHelper.PointsToUniqueRectangles(points);
            rectangles.Sort(CompareRectangles);

            Assert.AreEqual(3, rectangles.Count);
            Assert.AreEqual(new Rectangle(0, 1, 1, 1), rectangles[0]);
            Assert.AreEqual(new Rectangle(1, 1, 1, 1), rectangles[1]);
            Assert.AreEqual(new Rectangle(0, 1, 2, 1), rectangles[2]);
        }


        private int CompareRectangles(Rectangle r1, Rectangle r2)
        {
            if (r1.Height < r2.Height)
                return -1;
            if (r1.Height > r2.Height)
                return 1;
            if (r1.Width < r2.Width)
                return -1;
            if (r1.Width > r2.Width)
                return 1;

            if (r1.Y < r2.Y)
                return 1;//Sortierung bei Y umdrehen
            if (r1.Y > r2.Y)
                return -1;//Sortierung bei Y umdrehen
            if (r1.X < r2.X)
                return -1;
            if (r1.X > r2.X)
                return 1;

            return 0;
        }

    }
}
