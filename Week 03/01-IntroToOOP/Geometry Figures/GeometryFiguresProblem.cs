using System;

namespace Geometry_Figures
{
    class GeometryFiguresProblem
    {
        static void Main()
        {
            // point
            Point one = new Point(2, 2);
            Point two = new Point(3, -2);
            Console.WriteLine(one.ToString());

            // line
            LineSegment line1 = new LineSegment(one, two);

            Console.WriteLine("Length: " + line1.GetLength());
            Console.WriteLine(line1.ToString());

            LineSegment line2 = new LineSegment(new Point(2, 3), new Point(5, 6));
            Console.WriteLine(line1 < line2);

            LineSegment testLine = one + two;
            Console.WriteLine(testLine.EndPoint);

            // rectangle
            Console.WriteLine();
            Rectangle rect = new Rectangle(new Point(0, 0), new Point(3, 2));
            Console.WriteLine(rect.ToString());
        }
    }
}
