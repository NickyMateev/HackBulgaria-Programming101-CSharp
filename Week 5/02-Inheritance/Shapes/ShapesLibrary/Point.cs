namespace ShapesLibrary
{
    public class Point : IMovable
    {
        private double x;
        private double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }

        public override string ToString()
        {
            return string.Format("Point ({0}, {1})", X, Y);
        }

        public void Move(double x, double y)
        {
            X += x;
            Y += y;
        }
    }
}