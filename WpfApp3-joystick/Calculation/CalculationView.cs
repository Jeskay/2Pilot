using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfApp3_joystick
{
    public class CalculationView : INotifyPropertyChanged
    {
        private CalculationModel calculationModel;
        public CalculationView(CalculationModel calculationModel)
        {
            calculationModel = this.calculationModel;
        }
        public double Volume
        {
            get
            {
                return calculationModel.Volume;
            }
            set
            {
                calculationModel.Volume = value;
            }
        }
        public double R1
        {
            get
            {
                return calculationModel.R1;
            }
            set
            {
                calculationModel.R1 = value;
            }
        }
        public double R2
        {
            get
            {
                return calculationModel.R2;
            }
            set
            {
                calculationModel.R2 = value;
            }
        }
        public double R3
        {
            get
            {
                return calculationModel.R3;
            }
            set
            {
                calculationModel.R3 = value;
            }
        }
        public double Density
        {
            get
            {
                return calculationModel.Density;
            }
            set
            {
                calculationModel.Density = value;
            }
        }
        public double Lenght
        {
            get
            {
                return calculationModel.Lenght;
            }
            set
            {
                calculationModel.Lenght = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
