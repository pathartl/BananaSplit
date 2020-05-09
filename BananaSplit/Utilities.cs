using System.Drawing;
using System.IO;

namespace BananaSplit
{
    public static class Utilities
    {
        public static Bitmap BytesToImage(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Bitmap bmp = new Bitmap(ms);

                return bmp;
            }

        }
    }
}
