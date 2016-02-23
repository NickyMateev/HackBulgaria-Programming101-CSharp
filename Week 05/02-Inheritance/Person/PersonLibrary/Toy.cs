using System.Drawing;

namespace PersonLibrary
{
    public class Toy
    {
        private Color color;
        private Size size;

        public Toy(Color color, Size size)
        {
            this.color = color;
            this.size = size;
        }

        public override string ToString()
        {
            return string.Format("Toy color: {0}\nToy size: {1}", color, size);
        }
    }
}