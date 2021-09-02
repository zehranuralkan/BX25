using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rs232_Project
{
    public partial class PrinterConnection : Form
    {
        public PrinterConnection()
        {
            InitializeComponent();
        }
       
        public static SerialPort serialPort = new SerialPort();//serial port tanitimi
        public static string[] ports = SerialPort.GetPortNames();
        public void OpenConnection(string portName, int boudrate)
        {
            if (serialPort.IsOpen)
                serialPort.Close();
            if (!serialPort.IsOpen)
            {
                try
                {
                    serialPort.PortName = portName;
                    serialPort.BaudRate = boudrate;
                    serialPort.Open();
                    serialPort.Handshake = Handshake.None; //baglanti noktasi iletisiimde denetim
                    data_listbox.Items.Add("Serial port" + " " + cbx_name.Text + " " + "is open");
                 
                }
                catch
                {
                    MessageBox.Show("Connection Error");
                    data_listbox.Items.Add("Serial port" + " " + cbx_name.Text + " opening error");
                }
            }

        }
        public string value = "";
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                value = serialPort.ReadLine();//serial okuma 
                Control.CheckForIllegalCrossThreadCalls = false;
                data_listbox.Items.Add(value); //okunan degerler listbox gosterilir
              

            }

            catch (InvalidOperationException)
            {
                value = "";
            }

            catch (FormatException)
            {
                MessageBox.Show("Format exception");
            }

            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Index Expection");

            }
            catch (SocketException)
            {
                MessageBox.Show("Socket Exception ");
            }
            catch (System.IO.IOException)
            {
            }

         }
       public void  CheckParse(string newvalue)
        {
        }
        public void ComPortList()
        {
            //mevcut comportlari combobox'da listeleyen metod
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cbx_name.Items.Add(port);
            }
        }

        private void PrinterConnection_Load(object sender, EventArgs e)
        {
            serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived); //verileri alır
            ComPortList();
            btn_close.Visible = false;
            btn_print.Visible = false; 
        }

        private void serialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerialConnection serialcon = new SerialConnection();
            this.Hide();
            serialcon.Show();
        }

        private void tCPClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EthernetConnection netcon = new EthernetConnection();
            this.Hide();
            netcon.Show();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrinterConnection printcon = new PrinterConnection();
            this.Hide();
            printcon.Show();
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            if (cbx_name.Text != " " && cbx_boud.Text != " ")
            {
                OpenConnection(cbx_name.Text, Convert.ToInt32(cbx_boud.Text)); //kulanilacak port
                //serialPort.PortName = cbx_name.SelectedItem.ToString();
                backgroundWorker1.RunWorkerAsync();
         
            }
            else
            {
                MessageBox.Show("Gerekli alanları doldurunuz");
            }
            btn_open.Visible = false;
            btn_print.Visible = true;
            btn_close.Visible = true;
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            serialPort.Write("P"); 
            label2.Text = " ";
            label3.Text = " ";
            label4.Text = " ";
            lbl_date.Text = "";
            lbl_hour.Text = "";
            lbl_cn.Text = "";
            label8.Text = "  ";
            label9.Text = " ";
            lbl_gross.Text = "";
            lbl_tare.Text = "";
            lbl_net.Text = ""; 
            label11.Text = "  ";
     
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
                label2.Text = "Baykon A.S.";
                label3.Text = "www.baykon.com";
                label4.Text = "Istanbul,Türkiye";
                lbl_date.Text = value.Substring(0,10);
                lbl_hour.Text = value.Substring(13, 5);
                lbl_cn.Text = value.Substring(27, 3);
                label8.Text = "Operator:  Zehra Nur Alkan ";
                label9.Text = "Malzeme: Bilinmiyor";
                lbl_gross.Text = value.Substring(39, 5);
                lbl_tare.Text = value.Substring(56, 4);
                lbl_net.Text = value.Substring(71, 5);
                label11.Text = "*Teşekkürler*";
                
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            serialPort.Close();
            data_listbox.Items.Add("Serial port" + " " + cbx_name.Text + " is closed");
            btn_open.Visible = true;
            btn_close.Visible = false;
            btn_print.Visible = false;
            label2.Text = " ";
            label3.Text = " ";
            label4.Text = " ";
            lbl_date.Text = "";
            lbl_hour.Text = "";
            lbl_cn.Text = "";
            label8.Text = " ";
            label9.Text = " ";
            lbl_gross.Text = "";
            lbl_tare.Text = "";
            lbl_net.Text = "";
            label11.Text = " ";
             
        }
       
        SqlConnection sqldata = new SqlConnection("Data Source=emansuroglu; Initial Catalog=BX25_Project; User Id=sa; password=Baykon1987");

        private void lbl_save_Click(object sender, EventArgs e)
        { 
            CheckDatabase();
            SqlCommand command = new SqlCommand("insert into Receipt (Date,Time,Cn,Gross,Tare,Net) values ('" + lbl_date.Text  + "','" + lbl_hour.Text  + "','" + lbl_cn.Text  + "','" + lbl_gross.Text  + "','" + lbl_tare.Text  + "','" + lbl_net.Text  + "')", sqldata);
            command.ExecuteNonQuery();
            sqldata.Close();
            data_listbox.Items.Clear();
            MessageBox.Show("kaydedildi");
        } 

        public void CheckDatabase()
        {
            try
            {
                sqldata.Open();
            }
            catch (SqlException)
            {
                MessageBox.Show("Sql Exception");
            }
        }
    }
}
