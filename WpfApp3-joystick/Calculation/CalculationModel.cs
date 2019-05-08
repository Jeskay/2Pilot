using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3_joystick
{
    public class CalculationModel
    {
        private double volume;
        private double r1;
        private double r2;
        private double r3;
        private double density;
        private double lenght;

        public double Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
            }
        }
        public double R1
        {
            get
            {
                return r1;
            }
            set
            {
                r1 = value;
            }
        }
        public double R2
        {
            get
            {
                return r2;
            }
            set
            {
                r2 = value;
            }
        }
        public double R3
        {
            get
            {
                return r3;
            }
            set
            {
                r3 = value;
            }
        }
        public double Density
        {
            get
            {
                return density;
            }
            set
            {
                density = value;
            }
        }
        public double Lenght
        {
            get
            {
                return lenght;
            }
            set
            {
                lenght = value;
            }
        }
    }
}
