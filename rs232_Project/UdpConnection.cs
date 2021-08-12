

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
            UdpClient client = new UdpClient();
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("192.168.15.136"), 3250); 
            byte[] bytes = Encoding.ASCII.GetBytes(tbx_send1.Text);
            client.Send(bytes, bytes.Length, ip);
            client.Close();
          
        }


		//private void btn_send2_Click(object sender, EventArgs e)
		//{
		//	UdpClient client = new UdpClient();
		//	IPEndPoint ip = new IPEndPoint(IPAddress.Parse("192.168.15.136"), 3250);
  //          byte[] bytes = Encoding.ASCII.GetBytes(tbx_send1.Text);
  //          client.Send(bytes, bytes.Length, ip);
  //          client.Close();
         
		//}





		//public void Server()
  //      {
  //          try
  //          {
  //              IPAddress ipAd = IPAddress.Parse("192.168.15.135");
               
  //              TcpListener myList = new TcpListener(ipAd, 3250);

              
  //              myList.Start();

             

  //              Socket s = myList.AcceptSocket();
             
  //              byte[] b = new byte[100];
  //              int k = s.Receive(b);
  //               for (int i = 0; i < k; i++)
  //                  Console.Write(Convert.ToChar(b[i]));

  //              ASCIIEncoding asen = new ASCIIEncoding();
  //              s.Send(asen.GetBytes(asen));
               
  //              /* clean up */
  //              s.Close();
  //              myList.Stop();

  //          }
  //          catch (Exception e)
  //          {
              
  //          }
  //      }

        private void UdpConnection_Load(object sender, EventArgs e)
        {
          
        }
    }
}


