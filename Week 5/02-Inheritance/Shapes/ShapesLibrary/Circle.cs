namespace ShapesLibrary
{
    public class Circle : Ellipse
    {
        private double radius;

        public Circle(double Radius, Point Center) : base(Radius, Radius, Center)
        {
            this.radius = Radius;
        }

        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
                RadiusX = value;
                RadiusY = value;
            }
        }

        public override double RadiusX
        {
            get
            {
                return base.RadiusX;
            }
            set
            {
                base.RadiusX = value;
                if (base.RadiusY != base.RadiusX)
                    base.RadiusY = value;
                radius = value;
            }
        }

        public override double RadiusY
        {
            get
            {
                return base.RadiusY;
            }

            set
            {
                base.RadiusY = value;
                if (base.RadiusX != base.RadiusY)
                    base.RadiusX = value;
                radius = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Shape: Circle\nRadius: {0}\nCircumference: {1}\nArea: {2}", Radius, GetPerimeter(), GetArea());
        }

    }
}