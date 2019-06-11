using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;

namespace WpfApp3_joystick
{
    public class MainModel
    {
        private VideoCapture rulerCamera;
        private VideoCapture recognitionCamera;
        private VideoCapture microROVCamera;
        public int SelectedWindow = 1;
        public VideoCapture RulerCamera
        {
            get { return rulerCamera; }
            set { rulerCamera = value; }
        }
        public VideoCapture RecognitionCamera
        {
            get { return recognitionCamera; }
            set { recognitionCamera = value; }
        }
        public VideoCapture MicroROVCamera
        {
            get { return microROVCamera; }
            set { microROVCamera = value; }
        }
    }
}
