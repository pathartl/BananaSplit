using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
