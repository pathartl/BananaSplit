using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BananaSplit.Extensions
{
    public static class ImageListExtensions
    {
        public static void Add(this ImageList imageList, Bitmap bmp, string key)
        {
            var scaledImage = new Bitmap(imageList.ImageSize.Width, imageList.ImageSize.Height);

            using (Graphics graphics = Graphics.FromImage(scaledImage))
            {
                graphics.Clear(Color.Transparent);
                graphics.InterpolationMode = InterpolationMode.High;

                RectangleF sourceRectangle = new RectangleF(0, 0, bmp.Width, bmp.Height);
                RectangleF targetRectangle = new RectangleF(0, 0, scaledImage.Width, scaledImage.Height);

                targetRectangle = sourceRectangle.ScaleToRectangle(targetRectangle);

                graphics.DrawImage(bmp, targetRectangle, sourceRectangle, GraphicsUnit.Pixel);
            }

            imageList.Images.Add(key, scaledImage);
        }

        public static RectangleF ScaleToRectangle(this RectangleF source, RectangleF target)
        {
            float sourceAspect = source.Width / (float)source.Height;
            float targetAspect = target.Width / (float)target.Height;

            float width = target.Width;
            float height = target.Height;

            if (sourceAspect > targetAspect)
            {
                height = width / sourceAspect;
            }
            else
            {
                width = height * sourceAspect;
            }

            float x = target.Left + (target.Width - width) / 2;
            float y = target.Top + (target.Height - height) / 2;

            return new RectangleF(x, y, width, height);
        }
    }
}
