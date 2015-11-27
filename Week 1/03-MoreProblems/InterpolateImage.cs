using System;
using System.Drawing;

namespace Interpolate_image
{
    class InterpolateImage
    {
        static void RescaleImage(Bitmap bitmap, Size newSize, string savePath)
        {
            Bitmap newBitmap = new Bitmap(newSize.Width, newSize.Height);

            double widthRatio = (double)newBitmap.Width / bitmap.Width;
            double heightRatio = (double)newBitmap.Height / bitmap.Height;

            for (int i = 0; i < newBitmap.Width; i++)
            {
                for (int j = 0; j < newBitmap.Height; j++)
                {
                    int getX = (int)Math.Round(i / widthRatio);
                    int getY = (int)Math.Round(j / heightRatio);

                    if (getX >= bitmap.Width)
                        getX--;

                    if (getY >= bitmap.Height)
                        getY--;


                    Color pixel = bitmap.GetPixel(getX, getY);
                    newBitmap.SetPixel(i, j, pixel);
                }
            }

            newBitmap.Save(savePath);
        }

        static void Main()
        {
            Bitmap userImage = (Bitmap)Image.FromFile("kobeBryantBMP.bmp");
            Size newSize = new Size(1366, 768);
            string path = @"C:\Users\Nicky\Desktop\newKobeBryantBMP.bmp";

            RescaleImage(userImage, newSize, path);
        }
    }
}
