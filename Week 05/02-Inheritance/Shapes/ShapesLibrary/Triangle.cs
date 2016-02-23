using System;

namespace ShapesLibrary
{
    public class Triangle : Shape
    {
        public Triangle(Point Vertex1, Point Vertex2, Point Vertex3, Point Center)
        {
            this.Vertex1 = Vertex1;
            this.Vertex2 = Vertex2;
            this.Vertex3 = Vertex3;
            this.Center = Center;
        }

        public Point Vertex1 { get; set; }
        public Point Vertex2 { get; set; }
        public Point Vertex3 { get; set; }
        public Point Center { get; set; }

        public override double GetPerimeter()
        {
            double firstSide = Math.Sqrt(Math.Pow(Vertex2.X - Vertex1.X, 2));
            double secondSide = Math.Sqrt(Math.Pow(Vertex3.X - Vertex2.X, 2));
            double thirdSide = Math.Sqrt(Math.Pow(Vertex3.X - Vertex1.X, 2));

            return firstSide + secondSide + thirdSide;
        }

        public override double GetArea()
        {
            double firstSide = Math.Sqrt(Math.Pow(Vertex2.X - Vertex1.X, 2));
            double secondSide = Math.Sqrt(Math.Pow(Vertex3.X - Vertex2.X, 2));
            double thirdSide = Math.Sqrt(Math.Pow(Vertex3.X - Vertex1.X, 2));

            double semiPerimeter = (firstSide + secondSide + thirdSide) / 3;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - firstSide) * (semiPerimeter - secondSide) * (semiPerimeter - thirdSide)); // Heron's formula
            return area;
        }

        public override string ToString()
        {
            return string.Format("Shape: Triangle\nPerimeter: {0}\nArea: {1}", GetPerimeter(), GetArea());
        }


        public override void Move(double x, double y)
        {
            Center.Move(x, y);
        }
    }
}