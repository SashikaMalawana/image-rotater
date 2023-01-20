using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Assignment01Question01
{
    class Rotate
    {
        IplImage src, grayImage;

        public void LoadOriginalImage(string fname)
        {
            src = Cv.LoadImage(fname, LoadMode.Color);
            Cv.SaveImage(fname, src);
        }

        public void LoadGrayScaleImage()
        {
            grayImage = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            Cv.CvtColor(src, grayImage, ColorConversion.RgbToGray);
            Cv.SaveImage("gray.jpg", grayImage);
        }

        public Bitmap RotateImage(Image image, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            PointF offset = new PointF((float)image.Width / 2, (float)image.Height / 2);

            //create a new empty bitmap to hold rotated image
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(rotatedBmp);

            //Put the rotation point in the center of the image
            g.TranslateTransform(offset.X, offset.Y);

            //rotate the image
            g.RotateTransform(angle);

            //move the image back
            g.TranslateTransform(-offset.X, -offset.Y);

            //draw passed in image onto graphics object
            g.DrawImage(image, new PointF(0, 0));

            return rotatedBmp;
        }
    }
}
