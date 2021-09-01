

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace rs232_Project
{
    public partial class UdpConnection : Form
    {
        public UdpConnection()
        {
            InitializeComponent();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            
            Send();
        }

        public void Send()
        {

            UdpClient client = new UdpClient();
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("192.168.15.136"), 3250);
            byte[] bytes = Encoding.ASCII.GetBytes(tbx_send1.Text);
            client.Send(bytes, bytes.Length, ip);

            client.Close();
            //Receive(null);
            timer1.Start();
            timer1.Stop();

        }
   
        private TcpClient socketConnection;
        public void ListenToData()
        {
            UdpClient udpServer = new UdpClient();
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

            TcpListener listener = new TcpListener(IPAddress.Parse("192.168.15.135"), 3250);
            listener.Start();
            Socket sck = listener.AcceptTcpClient().Client;

            var data = udpServer.Receive(ref remoteEP);
            string result = Encoding.UTF8.GetString(data);

            //socketConnection = new TcpClient("192.168.15.136", 3250);
            //Byte[] bytes = new Byte[1024];
            //while (true)
            //{
            //    using (NetworkStream stream = socketConnection.GetStream())
            //    {
            //        int length;

            //        while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
            //        {
            //            var incommingData = new byte[length];
            //            Array.Copy(bytes, 0, incommingData, 0, length);
            //            byte[] bytesToRead = new byte[socketConnection.ReceiveBufferSize];
            //            int bytesRead = stream.Read(bytesToRead, 0, socketConnection.ReceiveBufferSize);
            //            Control.CheckForIllegalCrossThreadCalls = false;

            //            string value = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
            //        }

            //    }
            //}
        }

        private void serialToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    ListenToData();

        //}

        //private Thread clientReceiveThread;
        //private void ConnectToUdp()
        //{
        //    try
        //    {
        //        clientReceiveThread = new Thread(new ThreadStart(ListenToData));
        //        clientReceiveThread.IsBackground = true;
        //        clientReceiveThread.Start();
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("ConnectToUdpServer Error");
        //    }
        //}


    }
}


