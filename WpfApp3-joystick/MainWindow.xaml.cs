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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectInput;
using System.Windows.Interop;
using OpenCvSharp.ML;
using WebCam_Capture;
using System.ComponentModel;
using Microsoft.Win32;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Windows.Threading;
using Emgu.CV;
using Emgu.CV.Structure;

namespace WpfApp3_joystick
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {

        //изображение`  
        private VideoCapture Defaultcapture = new VideoCapture(700);
        private VideoCapture Secondcapture = new VideoCapture(1);
        private VideoCapture Firstcapture = new VideoCapture(0);

        DispatcherTimer VideoTimer = new DispatcherTimer();
        private Recognition Recognition = new Recognition();
        private FiguresView figuresView = new FiguresView(new FiguresModel());
        private MainView mainView = new MainView(new MainModel());

        private bool FirstWindowaCtivated = true;

        public MainWindow()
        {
            InitializeComponent();
            Firstcapture.FlipHorizontal = true;
            GoupBox_Grid.DataContext = figuresView;
        }
        private void MainWin_Loaded(object sender, RoutedEventArgs e)
        {
            //установка цветов некоторым элементам
            ME_test.Visibility = Visibility.Collapsed;

            //инициализация камер
            if (!Firstcapture.IsOpened)
            {
                RulerFirstCamera_RB.Visibility = Visibility.Collapsed;
                RecognitionFirstCamera_RB.Visibility = Visibility.Collapsed;
            }
            try
            {
                Mat Test = Firstcapture.QueryFrame();
                if (Test == null) throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                RulerFirstCamera_RB.Visibility = Visibility.Collapsed;
                RecognitionFirstCamera_RB.Visibility = Visibility.Collapsed;
            }
            if (!Secondcapture.IsOpened)
            {
                RulerSecondCamera_RB.Visibility = Visibility.Collapsed;
                RecognitionSecondCamera_RB.Visibility = Visibility.Collapsed;
            }
            VideoTimer.Tick += new EventHandler(VTimer_Tick);
            VideoTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            VideoTimer.Start();

        }

        public void ContinueCamera(object sender, EventArgs e)
        {
            VideoTimer.Start();
        }

        private void Keyboard_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key == System.Windows.Input.Key.P)
            {
                if (ME_test.Visibility != Visibility.Visible)
                {
                    ME_test.Visibility = Visibility.Visible;
                    VideoTimer.Stop();
                    ME_test.Play();
                }
                else
                {
                    ME_test.Stop();
                    ME_test.Visibility = Visibility.Collapsed;
                    VideoTimer.Start();
                }
            }
            if (e.Key == System.Windows.Input.Key.Enter)
            {

                System.Windows.Controls.Image capturedimage = new System.Windows.Controls.Image();
                capturedimage.Source = ImageWebcam1.Source;
                capturedimage.MaxWidth = 60;
                capturedimage.MaxHeight = 60;
                capturedimage.MouseDown += capturedimage_MouseDown;
                Images_Box.Items.Add(capturedimage);
                
            }
        }
        private void capturedimage_MouseDown(object sender, RoutedEventArgs e)
        {
            SelectedImage selectedImage = new SelectedImage();
            System.Windows.Controls.Image mainimage = (System.Windows.Controls.Image)sender;
            selectedImage.Owner = this;
            selectedImage.Selected_Image.Source = mainimage.Source;
            selectedImage.WindowClosed += ContinueCamera;
            selectedImage.Show();
            VideoTimer.Stop();
        }
        private void ComboBox_StartP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void VTimer_Tick(object sender, EventArgs e)
        {
            Mat Rulerimage = mainView.RulerCamera.QueryFrame();
            Mat Recognitionimage = mainView.RecognitionCamera.QueryFrame();
            if (FirstWindowaCtivated) ImageWebcam1.Source = BitmapSourceConvert.ToBitmapSource(Rulerimage.ToImage<Bgr, Byte>());
            else
            {
                Image1.Source = Recognition.FindFigures(Recognitionimage);
                figuresView.Circles = Recognition.Circles;
                figuresView.Lines = Recognition.Lines;
                figuresView.Triangles = Recognition.Triangles;
                figuresView.Squares = Recognition.Squares;
            }
        }

        private void Recognition_Tab_GotFocus(object sender, RoutedEventArgs e)
        {
            FirstWindowaCtivated = false;
        }

        private void Ruler_Tab_GotFocus(object sender, RoutedEventArgs e)
        {
            FirstWindowaCtivated = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            const double Iron = 7.87;
            const double Bronze = 8.03;
            double Density = 0;
            if (Density_CB.SelectedItem == AF_CBItem) Density = Bronze;
            else if (Density_CB.SelectedItem == BF_IC_CBItem) Density = Iron;
            else if (Density_CB.SelectedItem == FPF_CBItem) Density = Iron;
            else if (Density_CB.SelectedItem == TF_JRA_CBItem) Density = Iron;
            double R1 = Convert.ToDouble(R1_TextBox.Text);
            double R2 = Convert.ToDouble(R2_TextBox.Text);
            double R3 = Convert.ToDouble(R3_TextBox.Text);
            double L = Convert.ToDouble(Height_TextBox.Text);
            double V = Math.PI * L * (R1 * R1 + R1 * R2 + R2 * R2) / 3.0;
            V = V - Math.PI * R3 * R3 * L;
            double M = V * Density;
            OutputData_Label.Content = "V= " + V + '\n' + "M= " + M;
        }

        private void Calculation_Tab_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void RecognitionStandartCamera_RB_Checked(object sender, RoutedEventArgs e)
        {
            mainView.RecognitionCamera = Defaultcapture;
        }

        private void RecognitionFirstCamera_RB_Checked(object sender, RoutedEventArgs e)
        {
            mainView.RecognitionCamera = Firstcapture;
        }

        private void RecognitionSecondCamera_RB_Checked(object sender, RoutedEventArgs e)
        {
            mainView.RecognitionCamera = Secondcapture;
        }

        private void RulerStandartCamera_RB_Checked(object sender, RoutedEventArgs e)
        {
            mainView.RulerCamera = Defaultcapture;
        }

        private void RulerFirstCamera_RB_Checked(object sender, RoutedEventArgs e)
        {
            mainView.RulerCamera = Firstcapture;
        }

        private void RulerSecondCamera_RB_Checked(object sender, RoutedEventArgs e)
        {
            mainView.RulerCamera = Secondcapture;
        }
    }
}
