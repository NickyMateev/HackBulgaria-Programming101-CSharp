using System;

namespace Geometry_Figures
{
    class Rectangle
    {
        private readonly Point lowerLeftPoint;
        private readonly Point lowerRightPoint;
        private readonly Point upperRightPoint;
        private readonly Point upperLeftPoint;

        public Rectangle(Point lowerLeftPoint, Point upperRightPoint)
        {
            if (lowerLeftPoint.X == upperRightPoint.X || lowerLeftPoint.Y == upperRightPoint.Y)
            {
                throw new ArgumentException("ERROR: Invalid input points, the opposite vertices cannot be on the same coordinate axis.");
            }

            this.lowerLeftPoint = lowerLeftPoint;
            this.upperRightPoint = upperRightPoint;

            this.lowerRightPoint = new Point(upperRightPoint.X, lowerLeftPoint.Y);
            this.upperLeftPoint = new Point(lowerLeftPoint.X, upperRightPoint.Y);
        }

        public Rectangle(Rectangle rect)
        {
            this.lowerLeftPoint = rect.lowerLeftPoint;
            this.lowerRightPoint = rect.lowerRightPoint;
            this.upperLeftPoint = rect.upperLeftPoint;
            this.upperRightPoint = rect.upperRightPoint;
        }

        public Point LowerLeftPoint { get { return lowerLeftPoint; } }
        public Point LowerRightPoint { get { return lowerRightPoint; } }
        public Point UpperLeftPoint { get { return upperLeftPoint; } }
        public Point UpperRightPoint { get { return upperRightPoint; } }

        public LineSegment DownSide { get { return new LineSegment(lowerLeftPoint, lowerRightPoint); } }
        public LineSegment RightSide { get { return new LineSegment(lowerRightPoint, upperRightPoint); } }
        public LineSegment UpSide { get { return new LineSegment(upperRightPoint, upperLeftPoint); } }
        public LineSegment LeftSide { get { return new LineSegment(upperLeftPoint, lowerLeftPoint); } }

        public double Width { get { return DownSide.GetLength(); } }
        public double Height { get { return LeftSide.GetLength(); } }

        public Point CenterPoint { get { return new Point(Width / 2.0, Height / 2.0); } }

        public double GetParameter { get { return Width * 2 + Height * 2; } }
        public double GetArea { get { return Width * Height; } }

        public override string ToString()
        {
            return string.Format("Rectangle[({0},{1}), ({2},{3})]", UpperLeftPoint.X, UpperLeftPoint.Y, Height, Width);
        }

        public override bool Equals(object obj)
        {
            if (obj is Rectangle)
            {
                Rectangle obj1 = this;
                Rectangle obj2 = (Rectangle)obj;

                if (obj1.lowerLeftPoint == obj2.lowerLeftPoint && obj1.upperRightPoint == obj2.upperRightPoint)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public static bool operator ==(Rectangle rect1, Rectangle rect2)
        {
            return rect1.Equals(rect2);
        }
        
        public static bool operator !=(Rectangle rect1, Rectangle rect2)
        {
            return !(rect1.Equals(rect2));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + lowerLeftPoint.GetHashCode();
                hash = hash * 23 + upperRightPoint.GetHashCode();
                return hash;
            }
        }

    }
}