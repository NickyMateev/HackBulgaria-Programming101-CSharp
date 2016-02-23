using System;
using System.Drawing;

namespace Polygon_Area
{
    class PolygonArea
    {
        static float CalcArea(PointF[] points)
        {
            float area = 0;
            for (int i = 0; i < points.Length; i++)
            {
                if (i != points.Length - 1)
                {
                    area += (points[i].X * points[i + 1].Y) - (points[i + 1].X * points[i].Y);
                }
                else
                {
                    area += (points[i].X * points[0].Y) - (points[i].Y * points[0].X);
                }
            }
            return area;
        }

        static void Main()
        {
            PointF[] points = new PointF[]
            {
                new PointF(1, 0),
                new PointF(1, 1),
                new PointF(0, 1),
                new PointF(0, 0)
            };
            Console.WriteLine("Area: {0}", CalcArea(points));
        }
    }
}