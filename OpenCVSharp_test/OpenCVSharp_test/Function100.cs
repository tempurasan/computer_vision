using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using System.Drawing;

namespace Classes {
    public class Function100 {
        public static Bitmap GrayScale(Bitmap src) {
            FastBitmap original = new FastBitmap(src);
            for (int j = 0; j < original.Width; j++) {
                for (int i = 0; i < original.Height; i++) {
                    Color c = original.GetPixel(i, j);
                    int grayPixel = (int)(c.R * 0.2126 + c.G * 0.7152 + c.B * 0.0722);
                    original.SetPixel(i, j, Color.FromArgb(grayPixel, grayPixel, grayPixel));
                }
            }
            return original.ToBitmap();
        }


    }

    

}
