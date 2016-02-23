using System;

namespace ShapesLibrary
{
    public class Ellipse : Shape
    {
        public virtual double RadiusX { get; set; }
        public virtual double RadiusY { get; set; }
        public Point Center { get; set; }

        public Ellipse(double RadiusX, double RadiusY, Point Center)
        {
            this.RadiusX = RadiusX;
            this.RadiusY = RadiusY;
            this.Center = Center;
        }

        public override double GetPerimeter()
        {
            return 4 * Math.Sqrt(Math.Pow(RadiusX, 2) + Math.Pow(RadiusY, 2));
        }

        public override double GetArea()
        {
            return Math.PI * RadiusX * RadiusY;
        }


        public override string ToString()
        {
            return string.Format("Shape: Ellipse\nRadiusX: {0}\nRadiusY: {1}\nCircumference: {2}\nArea: {3}", RadiusX, RadiusY, GetPerimeter(), GetArea());
        }

        public override void Move(double x, double y)
        {
            Center.Move(x, y);
        }
    }
}