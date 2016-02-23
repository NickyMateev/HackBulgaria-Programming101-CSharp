using System;

namespace Geometry_Figures
{
    class LineSegment
    {
        private readonly Point point1;
        private readonly Point point2;

        public LineSegment(Point point1, Point point2)
        {
            if (point1 == point2)
            {
                throw new ArgumentException("Cannot create a line segment with zero length");
            }
            else
            {
                this.point1 = point1;
                this.point2 = point2;
            }
        }

        public LineSegment(LineSegment line)
        {
            this.point1 = line.point1;
            this.point2 = line.point2;
        }

        public Point StartPoint
        {
            get
            {
                return this.point1;
            }
        }

        public Point EndPoint
        {
            get
            {
                return this.point2;
            }
        }

        public double GetLength()
        {
            return Math.Sqrt(Math.Pow((point2.X - point1.X), 2) + Math.Pow((point2.Y - point1.Y), 2));
        }

        public override string ToString()
        {
            return string.Format("Line[({0},{1}), ({2},{3})]", point1.X, point1.Y, point2.X, point2.Y);
        }

        public override bool Equals(object obj)
        {
            if (obj is LineSegment)
            {
                LineSegment line1 = this;
                LineSegment line2 = (LineSegment)obj;
                
                if (line1.StartPoint == line2.StartPoint && line1.EndPoint == line2.EndPoint)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public static bool operator ==(LineSegment line1, LineSegment line2)
        {
            return line1.Equals(line2);
        }

        public static bool operator !=(LineSegment line1, LineSegment line2)
        {
            return !(line1.Equals(line2));
        }

        public static bool operator <(LineSegment line1, LineSegment line2)
        {
            if (line1.GetLength() < line2.GetLength())
                return true;
            else
                return false;
        }

        public static bool operator >(LineSegment line1, LineSegment line2)
        {
            return !(line1 < line2);
        }

        public static bool operator <=(LineSegment line1, LineSegment line2)
        {
            if (line1.GetLength() <= line2.GetLength())
                return true;
            else
                return false;
        }

        public static bool operator >=(LineSegment line1, LineSegment line2)
        {
            return !(line1 < line2);
        }

        public static bool operator <(LineSegment line, double length)
        {
            if (line.GetLength() < length)
                return true;
            else
                return false;
        }

        public static bool operator >(LineSegment line, double length)
        {
            return !(line.GetLength() < length);
        }

        public static bool operator <=(LineSegment line, double length)
        {
            if (line.GetLength() <= length)
                return true;
            else
                return false;
        }

        public static bool operator >=(LineSegment line, double length)
        {
            return !(line.GetLength() < length);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + point1.GetHashCode();
                hash = hash * 23 + point2.GetHashCode();
                return hash;
            }
        }
    }
}