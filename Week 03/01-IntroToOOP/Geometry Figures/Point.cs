namespace Geometry_Figures
{
    class Point
    {
        public static readonly Point Origin = new Point(0, 0);

        private readonly double x;
        private readonly double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Point()
        {
            this.x = Origin.x;
            this.y = Origin.y;
        }

        public Point(Point point)
        {
            this.x = point.x;
            this.y = point.y;
        }
        
        public double X
        {
            get
            {
                return this.x;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }
        }

        public override string ToString()
        {
            return "Point(" + this.x + "," + this.y + ")";
        }

        public override bool Equals(object obj)
        {
            if (obj is Point)
            {
                Point point1 = this;
                Point point2 = (Point)obj;

                if (point1.x == point2.x && point1.y == point2.y)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public static bool operator ==(Point point1, Point point2)
        {
            return point1.Equals(point2);
        }

        public static bool operator !=(Point point1, Point point2)
        {
            return !(point1.Equals(point2));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + x.GetHashCode();
                hash = hash * 23 + y.GetHashCode();
                return hash;
            }
        }

        public static LineSegment operator +(Point point1, Point point2)
        {
            return new LineSegment(point1, point2);
        }
    }
}