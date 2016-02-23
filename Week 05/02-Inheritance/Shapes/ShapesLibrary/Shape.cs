namespace ShapesLibrary
{
    public abstract class Shape : IMovable
    {
        public abstract double GetPerimeter();
        public abstract double GetArea();

        public abstract void Move(double x, double y);
    }
}
