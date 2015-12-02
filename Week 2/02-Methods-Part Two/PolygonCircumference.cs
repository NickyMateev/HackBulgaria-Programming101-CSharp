using System;
using System.Drawing;

namespace Polygon_Circumference
{
    class PolygonCircumference
    {
        static float CalcCircumference(PointF[] points)
        {
            float sum = 0;
            for (int i = 0; i < points.Length; i++)
            {
                if (i != points.Length - 1)
                {
                    sum += (float)Math.Sqrt(Math.Pow(points[i + 1].X - points[i].X, 2) + Math.Pow(points[i + 1].Y - points[i].Y, 2));
                }
                else
                {
                    sum += (float)Math.Sqrt(Math.Pow(points[i].X - points[0].X, 2) + Math.Pow(points[i].Y - points[0].Y, 2));
                }
            }
            return sum;
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

            Console.WriteLine("Circumference: {0}", CalcCircumference(points));
        }
    }
}
