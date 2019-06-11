using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp3_joystick
{
    public static class SelectionControl
    {
        public static int RectX { get; set; }
        public static int RectY { get; set; }
        public static int RectX2 { get; set; }
        public static int RectY2 { get; set; }
        
        public static Rectangle CreateRectangle()
        {
            return new Rectangle(Math.Min(RectX, RectX2), Math.Min(RectY, RectY2), Math.Abs(RectX2 - RectX), Math.Abs(RectY2 - RectY));
        }

    }
}
