using System.Drawing;

namespace ApplyLinearFilter
{
    class LinearFilter
    {
        static Color CalculatePixel(params Color[] pixels)
        {
            int newRed = 0;
            int newGreen = 0;
            int newBlue = 0;

            foreach (var pixel in pixels)
            {
                newRed += pixel.R;
                newGreen += pixel.G;
                newBlue += pixel.B;
            }

            newRed /= pixels.Length;
            newGreen /= pixels.Length;
            newBlue /= pixels.Length;

            Color newPixel = Color.FromArgb(newRed, newGreen, newBlue);
            return newPixel;
        }

        static void BlurImage(Bitmap bitmap, string savePath)
        {
            Bitmap blurred = new Bitmap(bitmap.Width, bitmap.Height);

            int cols = blurred.Width;
            int rows = blurred.Height;

            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    Color currentPixel = bitmap.GetPixel(col, row);
                    if (row == 0)
                    {
                        if (col == 0)   // top left corner
                        {
                            Color newPixel = CalculatePixel(bitmap.GetPixel(col + 1, row), bitmap.GetPixel(col, row + 1), bitmap.GetPixel(col + 1, row + 1));
                            blurred.SetPixel(col, row, newPixel);
                        }
                        else if (col == cols - 1)   // top right corner
                        {
                            Color newPixel = CalculatePixel(bitmap.GetPixel(col - 1, row), bitmap.GetPixel(col, row + 1), bitmap.GetPixel(col - 1, row + 1));
                            blurred.SetPixel(col, row, newPixel);
                        }
                        else   // somewhere on the first row (excluding corners)
                        {
                            Color newPixel = CalculatePixel(bitmap.GetPixel(col - 1, row), bitmap.GetPixel(col + 1, row), bitmap.GetPixel(col - 1, row + 1), bitmap.GetPixel(col, row + 1), bitmap.GetPixel(col + 1, row + 1));
                            blurred.SetPixel(col, row, newPixel);
                        }
                    }
                    else if (row == rows - 1)
                    {
                        if (col == 0)   // down left corner
                        {
                            Color newPixel = CalculatePixel(bitmap.GetPixel(col, row - 1), bitmap.GetPixel(col + 1, row - 1), bitmap.GetPixel(col + 1, row));
                            blurred.SetPixel(col, row, newPixel);
                        }
                        else if (col == cols - 1)   // down right corner
                        {
                            Color newPixel = CalculatePixel(bitmap.GetPixel(col - 1, row), bitmap.GetPixel(col - 1, row - 1), bitmap.GetPixel(col, row - 1));
                            blurred.SetPixel(col, row, newPixel);
                        }
                        else   // somewhere on the last row (excluding corners)
                        {
                            Color newPixel = CalculatePixel(bitmap.GetPixel(col - 1, row), bitmap.GetPixel(col + 1, row), bitmap.GetPixel(col - 1, row - 1), bitmap.GetPixel(col, row - 1), bitmap.GetPixel(col + 1, row - 1));
                            blurred.SetPixel(col, row, newPixel);
                        }
                    }
                    else if (col == 0)  // somewhere on the first col (excluding corners)
                    {
                        Color newPixel = CalculatePixel(bitmap.GetPixel(col, row - 1), bitmap.GetPixel(col, row + 1), bitmap.GetPixel(col + 1, row - 1), bitmap.GetPixel(col + 1, row), bitmap.GetPixel(col + 1, row + 1));
                        blurred.SetPixel(col, row, newPixel);
                    }
                    else if (col == cols - 1) // somewhere on the last col (excluding corners)
                    {
                        Color newPixel = CalculatePixel(bitmap.GetPixel(col, row - 1), bitmap.GetPixel(col, row + 1), bitmap.GetPixel(col - 1, row - 1), bitmap.GetPixel(col - 1, row), bitmap.GetPixel(col - 1, row + 1));
                        blurred.SetPixel(col, row, newPixel);
                    }
                    else   // somewhere inside the frame(the pixel is neither from the sides, nor from the corners)
                    {
                        Color newPixel = CalculatePixel(bitmap.GetPixel(col - 1, row - 1), bitmap.GetPixel(col, row - 1), bitmap.GetPixel(col + 1, row - 1), bitmap.GetPixel(col - 1, row), bitmap.GetPixel(col + 1, row), bitmap.GetPixel(col - 1, row + 1), bitmap.GetPixel(col, row + 1), bitmap.GetPixel(col + 1, row + 1));
                        blurred.SetPixel(col, row, newPixel);
                    }
                }
            }

            blurred.Save(savePath);
        }

        static void Main()
        {
            Bitmap userImage = (Bitmap)Image.FromFile("landscapeBMP.bmp");
            string savePath = @"C:\Users\Nicky\Desktop\blurredLandscapeBMP.bmp";

            BlurImage(userImage, savePath);
        }
    }
}
