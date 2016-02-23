using System.Drawing;

namespace Grayscale_Image
{
    class GrayscaleImage
    {
        static void GrayScaleImage(Bitmap bmp, string savePath)
        {
            int avg;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color pixel = bmp.GetPixel(i, j);
                    avg = (pixel.R + pixel.G + pixel.B) / 3;
                    Color newPixel = Color.FromArgb(avg, avg, avg);
                    bmp.SetPixel(i, j, newPixel);
                }
            }

            bmp.Save(savePath);
        }

        static void Main()
        {
            Bitmap userImage = (Bitmap)Image.FromFile("colorfulBMP.bmp");
            string path = @"C:\Users\Nicky\Desktop\newcolorfulBMP.bmp";

            GrayScaleImage(userImage, path);
        }
    }
}
