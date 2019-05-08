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
    }
}
