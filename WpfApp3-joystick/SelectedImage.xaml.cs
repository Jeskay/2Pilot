using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp3_joystick
{
    /// <summary>
    /// Логика взаимодействия для SelectedImage.xaml
    /// </summary>
    public partial class SelectedImage : Window
    {
        //линейка
        double x1, y1, x2, y2, x3, y3, x4, y4;
        double k;
        double distance;
        bool mark = false;
        public Mat Source { get; set; }
        public Line myLine;
        public Line my2Line;
        private System.Drawing.Rectangle rect = new System.Drawing.Rectangle();
        
        private void Selected_Image_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point position = System.Windows.Input.Mouse.GetPosition(null);
            x3 = position.X;
            y3 = position.Y;
            my2Line.X1 = x3;
            my2Line.Y1 = y3;
        }

        private void Selected_Image_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point position = System.Windows.Input.Mouse.GetPosition(null);
            x4 = position.X;
            y4 = position.Y;
            my2Line.X2 = x4;
            my2Line.Y2 = y4;
            k = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)) / distance;
            TextBox1.Text = "range = " + Math.Round((Math.Sqrt((x4 - x3) * (x4 - x3) + (y4 - y3) * (y4 - y3)) / k) * 100) / 100;//вывод результата
        }

        private void Selected_Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point position = System.Windows.Input.Mouse.GetPosition(null);
            x1 = position.X;
            y1 = position.Y;
            myLine.X1 = x1;
            myLine.Y1 = y1;
        }

        private void Selected_Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point position = System.Windows.Input.Mouse.GetPosition(null);
            x2 = position.X;
            y2 = position.Y;
            try
            {
                distance = Convert.ToDouble(TextBox2.Text);
            }
            catch (Exception ex)
            {
                distance = 50;
            }
            k = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)) / distance;
            TextBox1.Text = "range = " + Math.Round((Math.Sqrt((x4 - x3) * (x4 - x3) + (y4 - y3) * (y4 - y3)) / k) * 100) / 100;//вывод результата

        }

        private void Selected_Image_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var matrix = Selected_Image.RenderTransform.Value;

            if (e.Delta > 0)
            {
                matrix.ScaleAt(1.5, 1.5, e.GetPosition(this).X, e.GetPosition(this).Y);
            }
            else
            {
                matrix.ScaleAt(1.0 / 1.5, 1.0 / 1.5, e.GetPosition(this).X, e.GetPosition(this).Y);
            }

            Selected_Image.RenderTransform = new MatrixTransform(matrix);
        }

        ///delete this\\\

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //инициализация линий
            myLine = new Line();
            myLine.StrokeThickness = 1;
            MainGrid.Children.Add(myLine);
            my2Line = new Line();
            my2Line.StrokeThickness = 1;
            myLine.Stroke = System.Windows.Media.Brushes.Blue;
            my2Line.Stroke = System.Windows.Media.Brushes.Red;
            MainGrid.Children.Add(my2Line);
        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                distance = Convert.ToDouble(TextBox2.Text);
            }
            catch (Exception ex)
            {
                distance = 1;
            }
            k = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)) / distance;
            TextBox1.Text = "range = " + Math.Round((Math.Sqrt((x4 - x3) * (x4 - x3) + (y4 - y3) * (y4 - y3)) / k), 2);//вывод результата

        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public event EventHandler WindowClosed;
        private void SelectedImage_Window_Closed(object sender, EventArgs e)
        {
            if (WindowClosed != null)
            {
                WindowClosed(this, EventArgs.Empty);
            }
        }

        
        public SelectedImage()
        {
            InitializeComponent();
        }

        private void Selected_Image_MouseMove(object sender, MouseEventArgs e)
        {
            //получение координат текущей позиции мыши и привязка к ней конца линии
            System.Windows.Point position = System.Windows.Input.Mouse.GetPosition(null);
            double x, y;
            x = position.X;
            y = position.Y;
            //конец первой линии
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                myLine.X2 = x;
                myLine.Y2 = y;
                x2 = x;
                y2 = y;
                k = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)) / distance;
                TextBox1.Text = "range = " + Math.Round((Math.Sqrt((x4 - x3) * (x4 - x3) + (y4 - y3) * (y4 - y3)) / k) * 100) / 100;//вывод результата
            }
            //конец второй линии
            if (e.RightButton == MouseButtonState.Pressed)
            {
                my2Line.X2 = x;
                my2Line.Y2 = y;
                x4 = x;
                y4 = y;
                try
                {
                    distance = Convert.ToDouble(TextBox2.Text);
                }
                catch (Exception ex)
                {
                    distance = 1;
                }
                k = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)) / distance;
                TextBox1.Text = "range = " + Math.Round((Math.Sqrt((x4 - x3) * (x4 - x3) + (y4 - y3) * (y4 - y3)) / k) * 100) / 100;//вывод результата

            }
        }
    }
}
