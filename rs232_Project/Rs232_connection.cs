using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports; //seri port baglantısı saglandı

namespace rs232_Project
{
    class Rs232_connection
    {
        public static SerialPort serialPort = new SerialPort(); // serial port tanıtımı  
        public static string[] ports = SerialPort.GetPortNames(); // bilgisayardaki mevcut portlar 
        //private static int[] brate = new int[] { 2400, 4800, 9600, 19200, 38400 }; //seri portta veri okuma hizi
        public static void PortOpen(string portName, int baudrate) //serialport baglantisi açildi
        {
            if (serialPort.IsOpen)
            
            serialPort.Close();
            serialPort.Handshake = Handshake.XOnXOff;

            if (!serialPort.IsOpen)
            {
                try
                {
                    serialPort.PortName = portName;
                    serialPort.BaudRate = baudrate;
                    serialPort.Open();
                    serialPort.Handshake = Handshake.None; //baglanti noktasi iletisiminde denetim 

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.GetType().Name + Environment.NewLine + ex.Message);
                }
            }
        }
    }

    
}
