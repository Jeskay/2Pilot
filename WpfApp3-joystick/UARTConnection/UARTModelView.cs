using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfApp3_joystick
{
    public class UARTModelView : INotifyPropertyChanged
    {
        UARTModel model;
        private string sendingdata = "NoData";
        private void ChangeSendData()
        {
            SendingData = "MotorPower: " + MotorPower + '\n' + "Direction: " + Direction + '\n' + "LightBrightness: " + LightBrightness;
        }
        public int MotorPower
        {
            get
            {
                return model.MotorPower;
            }
            set
            {
                model.MotorPower = value;
                ChangeSendData();
                OnPropertyChanged("MotorPower");
            }
        }
        public int LightBrightness
        {
            get
            {
                return model.LightBrightness;
            }
            set
            {
                model.LightBrightness = value;
                ChangeSendData();
                OnPropertyChanged("LightBrightness");
            }
        }
        public int Direction
        {
            get
            {
                return model.Direction;
            }
            set
            {
                model.Direction = value;
                ChangeSendData();
                OnPropertyChanged("Direction");
            }
        }
        public string SendingData
        {
            get
            {
                return sendingdata;
            }
            set
            {
                sendingdata = value;
                OnPropertyChanged("SendingData");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged; // Событие, которое нужно вызывать при изменении
        public void OnPropertyChanged(string propertyName)//RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));//1
        }
        public UARTModelView(UARTModel model)
        {
            this.model = model;
        }
    }
}
