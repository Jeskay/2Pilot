using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emgu.CV;
using Emgu.CV.Structure;

namespace WpfApp3_joystick
{
    public class MainView : INotifyPropertyChanged
    {
        MainModel mainModel;
        public double Density
        {
            get { return mainModel.Density; }
            set
            {
                mainModel.Density = value;
                DataChanged();
            }
        }
        public string CalculationResult
        {
            get { return mainModel.CalculationResult; }
            set
            {
                mainModel.CalculationResult = value;
                OnPropertyChanged("CalculationResult");
            }
        }
        public string SmallRadius
        {
            get { return mainModel.SmallRadius; }
            set
            {
                mainModel.SmallRadius = value;
                OnPropertyChanged("SmallRadius");
                DataChanged();
            }
        }
        public string BigRadius
        {
            get { return mainModel.BigRadius; }
            set
            {
                mainModel.BigRadius = value;
                OnPropertyChanged("BigRadius");
                DataChanged();
            }
        }
        public string CavityRadius
        {
            get { return mainModel.CavityRadius; }
            set
            {
                mainModel.CavityRadius = value;
                OnPropertyChanged("CavityRadius");
                DataChanged();
            }
        }
        public string TotalLength
        {
            get { return mainModel.TotalLenght; }
            set
            {
                mainModel.TotalLenght = value;
                OnPropertyChanged("TotalLength");
                DataChanged();
            }
        }
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
        public VideoCapture MicroROVCamera
        {
            get { return mainModel.MicroROVCamera; }
            set { mainModel.MicroROVCamera = value; }
        }

        private void DataChanged()
        {
            try
            {
                double R1 = Convert.ToDouble(BigRadius);
                double R2 = Convert.ToDouble(SmallRadius);
                double R3 = Convert.ToDouble(CavityRadius);
                double L = Convert.ToDouble(TotalLength);
                double V = Math.PI * L * (R1 * R1 + R1 * R2 + R2 * R2) / 3.0;
                V = V - Math.PI * R3 * R3 * L;
                double M = V * Density;
                CalculationResult = "V= " + V + '\n' + "M= " + M;
            }
            catch (FormatException)
            { }
        }
        public event PropertyChangedEventHandler PropertyChanged; // Событие, которое нужно вызывать при изменении
        public void OnPropertyChanged(string propertyName)//RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));//1
        }
        public MainView(MainModel mainModel)
        {
            this.mainModel = mainModel;
        }
    }
}
