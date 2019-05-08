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
        private void Selected_Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine(e.LeftButton);
            Mouseclick = true;
            if (Mouseclick)
            {
                //начало первой линии
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    x1 = x;
                    y1 = y;
                    mark = 1;
                    myLine.X1 = x1;
                    myLine.Y1 = y1;
                }
                //начало второй линии
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    x3 = x;
                    y3 = y;
                    mark = 3;
                    my2Line.X1 = x3;
                    my2Line.Y1 = y3;
                }
                if (e.MiddleButton == MouseButtonState.Pressed)
                {
                    myLine.X1 = 0;
                    myLine.Y1 = 0;
                    myLine.X2 = 0;
                    myLine.Y2 = 0;
                    my2Line.X1 = 0;
                    my2Line.Y1 = 0;
                    my2Line.X2 = 0;
                    my2Line.Y2 = 0;
                }
            }
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

        private void Selected_Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Mouseclick = false;
            System.Windows.Point position = System.Windows.Input.Mouse.GetPosition(null);//запись позиции мыши
            Console.WriteLine(e.MiddleButton);
            if (e.LeftButton == MouseButtonState.Released)//конец 2 линии
            {
                x4 = x;
                y4 = y;
                try
                {
                    distance = Convert.ToDouble(TextBox2.Text);
                }
                catch (Exception ex)
                {
                    distance = 50;
                }
                k = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)) / distance;
                TextBox1.Text = "range = " + Math.Round(Math.Sqrt((x4 - x3) * (x4 - x3) + (y4 - y3) * (y4 - y3)) / k);//вывод результата
                mark = 0;
            }

            if (e.LeftButton == MouseButtonState.Released)//конец 1 линии
            {
                x2 = x;
                y2 = y;
                mark = 2;
            }
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
            TextBox1.Text = "range = " + Math.Round(Math.Sqrt((x4 - x3) * (x4 - x3) + (y4 - y3) * (y4 - y3)) / k);//вывод результата

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

        double k;
        double distance;
        bool Mouseclick = false;//клавиша нажата

        public Line myLine;
        public Line my2Line;

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
                TextBox1.Text = "range = " + Math.Round(Math.Sqrt((x4 - x3) * (x4 - x3) + (y4 - y3) * (y4 - y3)) / k);//вывод результата
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
                x4 = x;
                y4 = y;
                k = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)) / distance;
                TextBox1.Text = "range = " + Math.Round(Math.Sqrt((x4 - x3) * (x4 - x3) + (y4 - y3) * (y4 - y3)) / k);//вывод результата

            }
        }
    }
}
