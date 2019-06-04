using System;
using System.Collections.Generic;
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
        double x, y, x1, y1, x2, y2, x3, y3, x4, y4;
        int mark = 0;
        double k;
        double distance;
        bool Mouseclick = false;//клавиша нажата

        public Line myLine;
        public Line my2Line;

        private void ImageGrid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point position = System.Windows.Input.Mouse.GetPosition(null);
            x3 = position.X;
            y3 = position.Y;
            mark = 3;
            my2Line.X1 = x3;
            my2Line.Y1 = y3;
        }

        private void ImageGrid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point position = System.Windows.Input.Mouse.GetPosition(null);
            x4 = x;
            y4 = y;
            k = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)) / distance;
            TextBox1.Text = "range = " + Math.Round((Math.Sqrt((x4 - x3) * (x4 - x3) + (y4 - y3) * (y4 - y3)) / k) * 100) / 100;//вывод результата
        }

        private void ImageGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point position = System.Windows.Input.Mouse.GetPosition(null);
            x1 = position.X;
            y1 = position.Y;
            mark = 1;
            myLine.X1 = x1;
            myLine.Y1 = y1;
        }

        private void ImageGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //инициализация линий
            myLine = new Line();
            myLine.StrokeThickness = 1;
            ImageGrid.Children.Add(myLine);
            my2Line = new Line();
            my2Line.StrokeThickness = 1;
            myLine.Stroke = System.Windows.Media.Brushes.Blue;
            my2Line.Stroke = System.Windows.Media.Brushes.Red;
            ImageGrid.Children.Add(my2Line);
        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                distance = Convert.ToDouble(TextBox2.Text);
            }
            catch (Exception ex)
            {
                distance = 50;
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
            x = position.X;
            y = position.Y;

            //конец первой линии
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                myLine.X2 = x;
                myLine.Y2 = y;
                k = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)) / distance;
                TextBox1.Text = "range = " + Math.Round((Math.Sqrt((x4 - x3) * (x4 - x3) + (y4 - y3) * (y4 - y3)) / k) * 100) / 100;//вывод результата
            }
            //конец второй линии
            if (e.RightButton == MouseButtonState.Pressed)
            {
                my2Line.X2 = x;
                my2Line.Y2 = y;
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
        }
    }
}
