using System;
using ShapesLibrary;

namespace ShapesApplication
{
    class Program
    {
        static void Main()
        {
            Square square = new Square(5, new Point(0, 0));
            Console.WriteLine(square.Width);
            square.Height = 5.23;
            Console.WriteLine(square.Width);

            Circle circle = new Circle(12, new Point(0, 0));
            Console.WriteLine(circle.Radius);
            circle.RadiusX = 21.3;
            Console.WriteLine(circle.Radius);
            Console.WriteLine();

            Console.WriteLine(square + "\n\n" + circle + "\n");
            Console.WriteLine(circle.Center);
            circle.Move(3, -1);
            Console.WriteLine(circle.Center);
        }
    }
}
