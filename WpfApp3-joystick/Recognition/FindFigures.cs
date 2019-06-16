using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace WpfApp3_joystick
{
    public class Recognition
    {
       private Mat bin1Mat = new Mat();
       private Mat binMat = new Mat();
       private VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();

        public int Circles      { get; set; }
        public int Lines        { get; set; }
        public int Triangles    { get; set; }
        public int Squares      { get; set; }

        public BitmapSource FindFigures(Mat image)
        {
            //Rectangle area = AreaExtracting(image);
            Mat binImage = Binarization(image);
            VectorOfVectorOfPoint findfigures = Finding_Contours(binImage);
            Circles     = 0;
            Triangles   = 0;
            Squares     = 0;
            Lines       = 0;
            for (int i = 0; i < findfigures.Size; i++)
            {
                if (CvInvoke.ContourArea(findfigures[i]) > 20)
                {
                    
                    if (Is_Circle(findfigures[i]))
                    {
                        CvInvoke.DrawContours(image, findfigures, i, new MCvScalar(0, 0, 255), 3);
                        Circles++;
                        
                    }
                    else if (Is_Rectangle(findfigures[i]))
                    {
                        CvInvoke.DrawContours(image, findfigures, i, new MCvScalar(255, 0, 255), 3);
                        Lines++;
                    }
                    else if (Is_Square(findfigures[i]))
                    {
                        CvInvoke.DrawContours(image, findfigures, i, new MCvScalar(255, 0, 0), 3);
                        Squares++;
                    }
                    
                    else if (Is_Triangle(findfigures[i]))
                    {
                        CvInvoke.DrawContours(image, findfigures, i, new MCvScalar(0, 255, 0), 3);
                        Triangles++;
                    }

                }
            }
            return BitmapSourceConvert.ToBitmapSource(image.ToImage<Bgr, Byte>()); 
        }
        public Mat Binarization(Mat source)
        {
            if (source.IsEmpty) return source;
            /// конвертация изображения в серое
            CvInvoke.CvtColor(source, binMat, ColorConversion.Bgr2Gray);
            /// бинаризация черно-белой картинки
            CvInvoke.Threshold(binMat, bin1Mat, 100, 200, ThresholdType.Binary);
            CvInvoke.Threshold(bin1Mat, bin1Mat, 25, 255, ThresholdType.BinaryInv);
            CvInvoke.Threshold(bin1Mat, bin1Mat, 0, 255, ThresholdType.Otsu);
            //CvInvoke.Imshow("BIN", bin1Mat);
            return bin1Mat;
        }
        public Rectangle  AreaExtracting(Mat inputimage)
        {
            
            Mat binimage = new Mat();
            inputimage.CopyTo(binimage);
            CvInvoke.Threshold(binMat, bin1Mat, 200, 255, ThresholdType.Binary);
            VectorOfVectorOfPoint contours = Finding_Contours(binimage);
            VectorOfPoint maxcontour = new VectorOfPoint();
            for (int i = 0; i < contours.Size; i++)
                if (contours[i].Size >= maxcontour.Size) maxcontour = contours[i];

            if (maxcontour.Size > 600) return CvInvoke.BoundingRectangle(maxcontour);
            else return new Rectangle(0, 0, inputimage.Width, inputimage.Height);
        }
        public VectorOfVectorOfPoint Finding_Contours(Mat source)
        {
            if (source.IsEmpty) return null;

            Mat hierarchy = new Mat();
            /// поиск контуров и их отрисовка на изображениии
            CvInvoke.FindContours(bin1Mat, contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxSimple);
            CvInvoke.DrawContours(bin1Mat, contours, -1, new MCvScalar(100, 0, 0), 4);

            return contours;
        }
        public bool Inrectangle(Rectangle rect, VectorOfPoint hull)
        {
            Rectangle h = CvInvoke.BoundingRectangle(hull);
            if (h.X < rect.X) return false;
            if (h.Y < rect.Y) return false;
            if (rect.Right < h.X) return false;
            if (rect.Top < h.Y) return false;
            return true;
        }
        public bool Is_Rectangle(VectorOfPoint hull)
        {
            Console.WriteLine(hull.Size);
            if (hull.Size < 5) return false;
               PointF[] points = CvInvoke.FitEllipse(hull).GetVertices();
            double R1 = getR(points[0].X, points[0].Y, points[1].X, points[1].Y);
            double R2 = getR(points[0].X, points[0].Y, points[2].X, points[2].Y);
            double R3 = getR(points[0].X, points[0].Y, points[3].X, points[3].Y);
            double maximum = Math.Max(Math.Max(R1, R2), R3);
            double width, height;
            if (R1 == maximum)
            {
                width = R2;
                height = R3;
            }
            else if(R2== maximum)
            {
                width = R1;
                height = R3;
            }
            else
            {
                width = R1;
                height = R2;
            }
            VectorOfPoint newhull = new VectorOfPoint();
                CvInvoke.ApproxPolyDP(hull, newhull, 10, true);
                if (newhull.Size != 4) return false;
                double minr = Math.Min(width, height);
                double maxr = Math.Max(height, width);
            if (minr / maxr < 0.5)
            {
                return true;
            }
            else return false;
            
        }
        private double getR(double x1, double y1, double x2, double y2)
        {
            double x = Math.Abs(x1 - x2);
            double y = Math.Abs(y1 - y2);
            return Math.Sqrt(x * x + y * y);
        }
        
        public bool Is_Square(VectorOfPoint hull)
        {
            Console.WriteLine(hull.Size);
            if (hull.Size < 5) return false;
            PointF[] points = CvInvoke.FitEllipse(hull).GetVertices();
            double R1 = getR(points[0].X, points[0].Y, points[1].X, points[1].Y);
            double R2 = getR(points[0].X, points[0].Y, points[2].X, points[2].Y);
            double R3 = getR(points[0].X, points[0].Y, points[3].X, points[3].Y);
            double maximum = Math.Max(Math.Max(R1, R2), R3);
            double width, height;
            if (R1 == maximum)
            {
                width = R2;
                height = R3;
            }
            else if (R2 == maximum)
            {
                width = R1;
                height = R3;
            }
            else
            {
                width = R1;
                height = R2;
            }

            VectorOfPoint newhull = new VectorOfPoint();
            CvInvoke.ApproxPolyDP(hull, newhull, 10, true);
            if (newhull.Size != 4) return false;
                double minr = Math.Min(width, height);
                double maxr = Math.Max(height, width);
                if (minr / maxr >= 0.5)
                {
                    return true;
                }
                else return false;
        }
        public bool Is_Circle(VectorOfPoint hull)
        {
            Console.WriteLine(hull.Size);

            VectorOfPoint newhull = new VectorOfPoint();
            CvInvoke.ApproxPolyDP(hull, newhull, 5, true);
            if (newhull.Size >= 5)
            {
                double area = CvInvoke.ContourArea(newhull);
                System.Drawing.Rectangle r = CvInvoke.BoundingRectangle(newhull);
                double radius = r.Width / 2;
                if (Math.Abs(1.0 - ((double)r.Width / (double)r.Height)) <= 0.4 && Math.Abs(1.0 - (area / (Math.PI * Math.Pow(radius, 2.0)))) <= 0.4)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Is_Triangle(VectorOfPoint hull)
        {
            Console.WriteLine(hull.Size);

            VectorOfPoint newhull = new VectorOfPoint();
            CvInvoke.ApproxPolyDP(hull, newhull, 10, true);
            if (newhull.Size == 3) return true;
            else return false;
        }
    }
}
