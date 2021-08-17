using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace rs232_Project
{
    public partial class EthernetConnection : Form
    {

        public EthernetConnection()
        {
            InitializeComponent();
        }
       
        //thread ile
        private TcpClient socketConnection;
        private Thread clientReceiveThread;
        private void ConnectToTcpServer()
        {
            try
            {
                clientReceiveThread = new Thread(new ThreadStart(ListenForData));
                clientReceiveThread.IsBackground = true;
                clientReceiveThread.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("ConnectToTcpServer Error");
            }
        }
        private void ListenForData()
        {
            try
            {
                socketConnection = new TcpClient(tbx_moduleip.Text, Convert.ToInt32(tbx_port.Text));
                Byte[] bytes = new Byte[1024];
                while (true)
                { // Get a stream object for reading 				
                    using (NetworkStream stream = socketConnection.GetStream())
                    {
                        int length;
                        					
                          while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                          {
                           var incommingData = new byte[length];
                           Array.Copy(bytes, 0, incommingData, 0, length);
                           byte[] bytesToRead = new byte[socketConnection.ReceiveBufferSize];
                           int bytesRead = stream.Read(bytesToRead, 0, socketConnection.ReceiveBufferSize);
                           Control.CheckForIllegalCrossThreadCalls = false;
                      
                           string value = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead); 
                           listbox_ethernetCon.Items.Add(value);
                           CheckParse(value);
                           PositiveOrNegative(value);
                           StabilOrNot(value);
                           ShowPoint(value);
                          }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Socket Exception");
            }
        }
        public void PositiveOrNegative(string value1)
        {
            byte[] ba = Encoding.Default.GetBytes(value1); 
            var hexString = BitConverter.ToString(ba);
            hexString = hexString.Replace("-", "");
            string stb = hexString.Substring(4, 2);
            string binaryval = Convert.ToString(Convert.ToInt32(stb, 16), 2);
            string bit1 = binaryval.Substring(4,1);

            if (bit1 == "1")
            {
                lbl_negative.Text = "-";
            }
            else
            {
                lbl_negative.Text = " ";
            }

        }
        public void StabilOrNot(string value1)
        {
            byte[] ba = Encoding.Default.GetBytes(value1); ;

            var hexString = BitConverter.ToString(ba);
            hexString = hexString.Replace("-", "");
            string stb = hexString.Substring(4, 2);
            string binaryval = Convert.ToString(Convert.ToInt32(stb, 16), 2);
            string bit3 = binaryval.Substring(2, 1);
         
            if (bit3 == "1")
            {
                lbl_stabil.Text = "~";
            }
            else
            {
                lbl_stabil.Text = " ";
            }

        }
        public void  ShowPoint(string value1)
        {
            byte[] ba = Encoding.Default.GetBytes(value1); 
            var hexString = BitConverter.ToString(ba);
            hexString = hexString.Replace("-", "");
            string stb = hexString.Substring(2, 2);
            string binaryval = Convert.ToString(Convert.ToInt32(stb, 16), 2);
            string bit210=binaryval.Substring(4, 3);
            int parse = value1.IndexOf(' ');
            string value2 = value1.Substring(6, parse);

            if (bit210 == "000")
            {
                double new_value = (Convert.ToInt32(value2) * 100);
                lbl_weightvalue.Text = new_value.ToString();
            }
            else if (bit210 == "001")
            {
                double new_value = (Convert.ToInt32(value2) * 10);
                lbl_weightvalue.Text = new_value.ToString();
            }
            else if (bit210 == "010")
            { 
                lbl_weightvalue.Text = value2.ToString();
            }
            else if (bit210 == "011")
            {
                double new_value = (Convert.ToInt32(value2) * 0.1);
                lbl_weightvalue.Text = new_value.ToString();
            }
            else if (bit210 == "100")
            {
                double new_value = (Convert.ToInt32(value2) * 0.01);
                lbl_weightvalue.Text = new_value.ToString();
            }
            else if (bit210 == "101")
            {
                double new_value = (Convert.ToInt32(value2) * 0.001);
                lbl_weightvalue.Text = new_value.ToString();
            }
            else if (bit210 == "110")
            {
                double new_value = (Convert.ToInt32(value2) * 0.0001);
                lbl_weightvalue.Text = new_value.ToString();
            }
            else if (bit210 == "111")
            {
                double new_value = (Convert.ToInt32(value2) * 0.00001);
                lbl_weightvalue.Text = new_value.ToString();
            }
        }
        private void CheckParse(string data1)
        //deger'i 6 bit ayirma islemi
        {
            try
            {
                int parse = data1.IndexOf(' ');
                lbl_weightvalue.Text = data1.Substring(6, parse);
                lbl_tarevalue.Text = data1.Substring(12, parse);
            }
            catch
            {
            }
        }
        private void Main()
        {
            ConnectToTcpServer();
        }
        private void btn_connect_Click(object sender, EventArgs e)
        {
            Main();
            
            btn_connect.Visible = false;
            btn_disconnect.Visible = true;
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void serialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerialConnection serialcon = new SerialConnection();
            this.Hide();
            serialcon.Show();
        }

        private void EthernetConnection_Load(object sender, EventArgs e)
        {
            btn_disconnect.Visible = false;
            btn_connect.Visible = true;
        }

        private void uDPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UdpConnection udpcon = new UdpConnection();
            this.Hide();
            udpcon.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ListenForData();
        }
    }
}

//timer ile çalısan hali
//private void Main()
//{
//    //int PORT_NO = Convert.ToInt32(tbx_port.Text);
//    string SERVER_IP = tbx_moduleip.Text;
//    //---data to send to the server---
//    string textToSend = DateTime.Now.ToString();
//    int PORT_NO = Convert.ToInt32(tbx_port.Text);
//    //---create a TCPClient object at the IP and port no.---
//    TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
//    NetworkStream nwStream = client.GetStream();
//    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

//    //---send the text---
//    Console.WriteLine("Sending : " + textToSend);
//    nwStream.Write(bytesToSend, 0, bytesToSend.Length);

//    //---read back the text---
//    byte[] bytesToRead = new byte[client.ReceiveBufferSize];
//    int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
//    lbl_deger.Text = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
//    Console.ReadLine();
//    client.Close();
//}
//private void serialToolStripMenuItem_Click(object sender, EventArgs e)
//{
//    Form1 serialconnection = new Form1();
//    this.Hide();
//    serialconnection.Show();
//}
//public static TcpClient tcpclnt = new TcpClient();

//Socket client;
//byte[] data;
////private void Baglanti()
////{


////    data = new byte[60];

////    IPHostEntry iphostInfo = Dns.GetHostEntry(Dns.GetHostName());
////    IPAddress ipAdress;
////    ipAdress = IPAddress.Parse(tbx_moduleip.Text);
////    int port = Convert.ToInt32(tbx_port.Text);
////    IPEndPoint ipEndpoint = new IPEndPoint(ipAdress, port);

////    client = new Socket(ipAdress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

////    try
////    {
////        client.Connect(ipEndpoint);



////        byte[] sendmsg = Encoding.ASCII.GetBytes("This is from Client\n");

////        int n = client.Send(sendmsg);

////        int m = client.Receive(data);
////        lbl_deger.Text = Encoding.ASCII.GetString(data);
////        listbox_ethernetCon.Items.Add(Encoding.ASCII.GetString(data));


////    }
////    catch (Exception e)
////    {
////        Console.WriteLine(e.ToString());
////    }




////}

//private void btn_connect_Click(object sender, EventArgs e)
//{
//    //Baglanti();
//}

//private void btn_disconnect_Click(object sender, EventArgs e)
//{
//    Close();
//}
//public void BeginReceive(byte[] ReadBuffer)
//{
//    client.BeginReceive(ReadBuffer, 0, ReadBuffer.Length, SocketFlags.None, EndReceive, null);
//}

//protected void EndReceive(IAsyncResult async)
//{
//    string msg = "";

//    int bytesRead = client.EndReceive(async);
//    try
//    {
//        //msg = ByteArrayToString(ReadBuffer, bytesRead);
//    }
//    catch (Exception e)
//    {
//        //Debug.LogError(e);
//    }

//    BeginReceive(data);
//}

//private void timer1_Tick(object sender, EventArgs e)
//{
//    try
//    {
//        Main();

//    }
//    catch { }
//}

