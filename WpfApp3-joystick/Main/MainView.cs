using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;

namespace WpfApp3_joystick
{
    public class MainView
    {
        MainModel mainModel;

        public VideoCapture RulerCamera
        {
            get { return mainModel.RulerCamera; }
            set { mainModel.RulerCamera = value; }
        }
        public VideoCapture RecognitionCamera
        {
            get { return mainModel.RecognitionCamera; }
            set { mainModel.RecognitionCamera = value; }
        }

        public MainView(MainModel mainModel)
        {
            this.mainModel = mainModel;
        }
    }
}
