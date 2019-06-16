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
        private string smallRadius;
        private string bigRadius;
        private string cavityRadius;
        private string totalLenght;
        private string calculationResult;
        private double density;

        public int SelectedWindow = 1;

        public double Density
        {
            get { return density; }
            set { density = value; }
        }
        public string CalculationResult
        {
            get { return calculationResult; }
            set { calculationResult = value; }
        }
        public string SmallRadius
        {
            get { return smallRadius;  }
            set { smallRadius = value; }
        }
        public string BigRadius
        {
            get { return bigRadius; }
            set { bigRadius = value; }
        }
        public string CavityRadius
        {
            get { return cavityRadius; }
            set { cavityRadius = value; }
        }
        public string TotalLenght
        {
            get { return totalLenght; }
            set { totalLenght = value; }
        }
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
