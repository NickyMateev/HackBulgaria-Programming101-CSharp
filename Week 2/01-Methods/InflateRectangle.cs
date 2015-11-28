using System.Drawing;

namespace Inflate_Rectangle
{
    class InflateRectangle
    {
        static void Inflate(ref Rectangle rect, Size inflateSize)
        {
            rect.X -= inflateSize.Height;
            rect.Y -= inflateSize.Width;
            rect.Height += 2 * inflateSize.Height;
            rect.Width += 2 * inflateSize.Width;
        }

        static void Main()
        {
            Rectangle rect = new Rectangle(0, 0, 10, 10);
            Size inflateSize = new Size(2, 2);
            Inflate(ref rect, inflateSize);
        }
    }
}
