using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3_joystick
{
    public class UARTConnection
    {
        public static string COMport = "COM20";
        public static int BaudRate = 9600;
        public static string status = "Disconnected";

        SerialPort sp = new SerialPort();
        public void InitializePort()
        {
            try
            {
                sp.PortName = COMport;
                sp.BaudRate = BaudRate;
                status = "Connected";
                sp.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Возникло Исключение: " + ex);
            }
        }
        public void UARTWrite(int firstdata, int seconddata )
        {
            byte[] message = new byte[4];
            message[0] = (byte)'*';
            message[1] = (byte)firstdata;
            message[2] = (byte)seconddata;
            message[3] = (byte)'-';
            sp.Write(message, 0, message.Length);

        }
        public void UARTDisconnect()
        {
            try
            {
                sp.Close();
                status = "Disconnected";
            }
            catch (Exception ex)
            {
                Console.WriteLine("возникло исключение: " + ex);
            }
        }
    }
}
