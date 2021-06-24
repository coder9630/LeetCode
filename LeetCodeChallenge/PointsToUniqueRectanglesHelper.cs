using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LeetCodeChallenge
{
    public class PointsToUniqueRectanglesHelper
    {
        public List<Rectangle> PointsToUniqueRectangles(List<Point> points)
        {
            List<Rectangle> rectangles = new List<Rectangle>();

            int pointsCount = points.Count;

            for (int point1Index = 0; point1Index < pointsCount; ++point1Index)
            {
                Point point1 = points[point1Index];

                for (int point2Index = 0; point2Index < pointsCount; ++point2Index)
                {
                    Point point2 = points[point2Index];

                    if (point2.X > point1.X && point2.Y == point1.Y)
                    {
                        for (int point3Index = 0; point3Index < pointsCount; ++point3Index)
                        {
                            Point point3 = points[point3Index];

                            if (point3.X == point2.X && point3.Y < point2.Y)
                            {
                                for (int point4Index = 0; point4Index < pointsCount; ++point4Index)
                                {
                                    Point point4 = points[point4Index];

                                    if (point4.X < point3.X && point4.Y == point3.Y)
                                    {
                                        if (point1.X == point4.X && point1.Y > point4.Y)
                                        {
                                            Rectangle rectangle = new Rectangle(point1.X, point1.Y, point3.X - point1.X, -(point3.Y - point1.Y));
                                            if (!rectangles.Contains(rectangle))
                                                rectangles.Add(rectangle);
                                            else
                                                Console.WriteLine($"Duplicate key: {rectangle.ToString()}");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return rectangles;
        }
    }
}