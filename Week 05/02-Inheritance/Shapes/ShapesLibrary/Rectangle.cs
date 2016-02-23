namespace ShapesLibrary
{
    public class Rectangle : Shape
    {
        private double width;
        private double height;
        private Point center;
           
        public Rectangle(double width, double height, Point center)
        {
            this.width = width;
            this.height = height;
            this.center = center;
        }
        
        public virtual double Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
                if(this is Square)
                    height = value;
            }
        }

        public virtual double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
                if (this is Square)
                    width = value;
            }
        }

        public Point Center { get { return center; } set { center = value; } }

        public override double GetPerimeter()
        {
            return Width * 2 + Height * 2;
        }

        public override double GetArea()
        {
            return Width * Height;
        }

        public override string ToString()
        {
            return string.Format("Shape: Rectangle\nWidth: {0}\nHeight: {1}\nPerimeter: {2}\nArea: {3}", Width, Height, GetPerimeter(), GetArea());
        }

        public override void Move(double x, double y)
        {
            Center.Move(x, y);
        }
    }
}