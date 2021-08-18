using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace rs232_Project
{
    public partial class SerialConnection : Form
    {


        public SerialConnection()
        {
            InitializeComponent();
        }



        public string value = "";



        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
         
            if (btn_open.Visible == false)
            {
                try
                {
                  
                    value = Rs232_connection.serialPort.ReadLine();
                    Control.CheckForIllegalCrossThreadCalls = false;
                    listbox_values.Items.Add(value);
                    CheckParse(value);
                    lbl_kg.Text = "KG";
                    lbl_tare1.Text = "TARE";
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("I/o Exception");
                }
                catch (InvalidOperationException)
                {
                    value = "";
                }
                try
                {
                    base.Invoke(new EventHandler(this.DisplayText));
                }
                catch (FormatException)
                {
                    MessageBox.Show("Format Exception");
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception");
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("Index Out Of Range Exception");
                }



            }
            
           
           
        }

         
        private void CheckParse(string value1)
        //deger'i 6 bit ayirma islemi
        {
            try
            {
                int parse = value1.IndexOf(' ');
                lbl_weight.Text = value1.Substring(6, parse);
                lbl_tare.Text = value1.Substring(12, parse);
            }
            catch
            {
            }
        }
        private void DisplayText(object sender, EventArgs e)
        {
        }
        public void ComboboxData()
        {
            string[] ports = SerialPort.GetPortNames(); // port isimlerini al
            foreach (string port in ports) // portları comboboxa ekle
            {
                cbx_serialname.Items.Add(port);
            }
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            ComboboxData();
            btn_open.Visible = true;
            btn_disconnect.Visible = false;
            btn_database.Visible = false;
            Rs232_connection.serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived); //verileri alir


        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
     
        private void tCPClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EthernetConnection ethernetcon = new EthernetConnection();
            this.Hide();
            ethernetcon.Show();

        }
     
        private void btn_database_Click(object sender, EventArgs e)
        {

            CheckDatabase();
            SqlCommand komut = new SqlCommand("insert into Serial (Names,Bauds,DataSizes,Weights,Tare) values ('" + cbx_serialname.Text.ToString() + "','" + cbx_boud.Text.ToString() + "','" +cbx_datasize.Text.ToString() + "','" + lbl_weight.Text+"','" + lbl_tare.Text+"')", sqldata);
            komut.ExecuteNonQuery();
            sqldata.Close();


        }

        private void btn_open_Click(object sender, EventArgs e)
        {
           
            if (cbx_serialname.Text != " " && cbx_boud.Text != " " && cbx_datasize.Text != "")
            {
                //bos deger girilmesi engellendi
                if (Convert.ToInt32(cbx_datasize.Text) == 8)
                {
                    Rs232_connection.PortOpen(cbx_serialname.Text, Convert.ToInt32(cbx_boud.Text)); //kulanilacak port
                    serialPort.PortName = cbx_serialname.SelectedItem.ToString();
                    //listbox_degerler.Items.Add("Serial port " +" " + cbx_serialname.Text.ToString() +" "+ "opened");
                    //serialPort.Open();
                    backgroundWorker1.RunWorkerAsync();
                    btn_open.Visible = false;
                    btn_disconnect.Visible = true;
                    btn_database.Visible = true;
                }
            }
            else MessageBox.Show("Gerekli alanları doldurunuz");
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
           
            serialPort.Close();
            listbox_values.Items.Clear();
            btn_open.Visible = true;
            btn_disconnect.Visible = false;
            btn_database.Visible = false;
            lbl_weight.Text = " ";
            lbl_tare.Text = " ";
        }
        SqlConnection sqldata = new SqlConnection("Data Source=emansuroglu; Initial Catalog=BX25_Project; User Id=sa; password=Baykon1987");

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
            private void uDPToolStripMenuItem_Click(object sender, EventArgs e)
            {
                UdpConnection udpcon = new UdpConnection();
                this.Hide();
                udpcon.Show();
            }
            private void InitializeComponent()
            {
            this.components = new System.ComponentModel.Container();
            this.btn_open = new System.Windows.Forms.Button();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.lbl_serialname = new System.Windows.Forms.Label();
            this.cbx_serialname = new System.Windows.Forms.ComboBox();
            this.lbl_baud = new System.Windows.Forms.Label();
            this.cbx_boud = new System.Windows.Forms.ComboBox();
            this.lbl_datasize = new System.Windows.Forms.Label();
            this.cbx_datasize = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.listbox_values = new System.Windows.Forms.ListBox();
            this.panel_giris = new System.Windows.Forms.Panel();
            this.btn_database = new System.Windows.Forms.Button();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.lbl_weight = new System.Windows.Forms.Label();
            this.lbl_kg = new System.Windows.Forms.Label();
            this.panel_kilo = new System.Windows.Forms.Panel();
            this.panel_tare = new System.Windows.Forms.Panel();
            this.lbl_tare1 = new System.Windows.Forms.Label();
            this.lbl_tare = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tCPClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uDPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_disconnect = new System.Windows.Forms.Timer(this.components);
            this.panel_giris.SuspendLayout();
            this.panel_kilo.SuspendLayout();
            this.panel_tare.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(17, 256);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(133, 32);
            this.btn_open.TabIndex = 7;
            this.btn_open.Text = "Connect";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // lbl_serialname
            // 
            this.lbl_serialname.AutoSize = true;
            this.lbl_serialname.Location = new System.Drawing.Point(15, 40);
            this.lbl_serialname.Name = "lbl_serialname";
            this.lbl_serialname.Size = new System.Drawing.Size(38, 13);
            this.lbl_serialname.TabIndex = 6;
            this.lbl_serialname.Text = "Name:";
            // 
            // cbx_serialname
            // 
            this.cbx_serialname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbx_serialname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbx_serialname.FormattingEnabled = true;
            this.cbx_serialname.Items.AddRange(new object[] {
            ""});
            this.cbx_serialname.Location = new System.Drawing.Point(18, 60);
            this.cbx_serialname.Name = "cbx_serialname";
            this.cbx_serialname.Size = new System.Drawing.Size(133, 21);
            this.cbx_serialname.TabIndex = 1;
            // 
            // lbl_baud
            // 
            this.lbl_baud.AutoSize = true;
            this.lbl_baud.Location = new System.Drawing.Point(15, 109);
            this.lbl_baud.Name = "lbl_baud";
            this.lbl_baud.Size = new System.Drawing.Size(32, 13);
            this.lbl_baud.TabIndex = 8;
            this.lbl_baud.Text = "Baud";
            // 
            // cbx_boud
            // 
            this.cbx_boud.FormattingEnabled = true;
            this.cbx_boud.Items.AddRange(new object[] {
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600"});
            this.cbx_boud.Location = new System.Drawing.Point(18, 135);
            this.cbx_boud.Name = "cbx_boud";
            this.cbx_boud.Size = new System.Drawing.Size(132, 21);
            this.cbx_boud.TabIndex = 2;
            // 
            // lbl_datasize
            // 
            this.lbl_datasize.AutoSize = true;
            this.lbl_datasize.Location = new System.Drawing.Point(15, 181);
            this.lbl_datasize.Name = "lbl_datasize";
            this.lbl_datasize.Size = new System.Drawing.Size(53, 13);
            this.lbl_datasize.TabIndex = 10;
            this.lbl_datasize.Text = "Data Size";
            // 
            // cbx_datasize
            // 
            this.cbx_datasize.FormattingEnabled = true;
            this.cbx_datasize.Items.AddRange(new object[] {
            "7",
            "8"});
            this.cbx_datasize.Location = new System.Drawing.Point(18, 210);
            this.cbx_datasize.Name = "cbx_datasize";
            this.cbx_datasize.Size = new System.Drawing.Size(131, 21);
            this.cbx_datasize.TabIndex = 3;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // listbox_values
            // 
            this.listbox_values.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listbox_values.FormattingEnabled = true;
            this.listbox_values.HorizontalScrollbar = true;
            this.listbox_values.Location = new System.Drawing.Point(12, 89);
            this.listbox_values.Name = "listbox_values";
            this.listbox_values.Size = new System.Drawing.Size(499, 303);
            this.listbox_values.TabIndex = 18;
            // 
            // panel_giris
            // 
            this.panel_giris.BackColor = System.Drawing.Color.PeachPuff;
            this.panel_giris.Controls.Add(this.btn_database);
            this.panel_giris.Controls.Add(this.btn_disconnect);
            this.panel_giris.Controls.Add(this.cbx_datasize);
            this.panel_giris.Controls.Add(this.lbl_datasize);
            this.panel_giris.Controls.Add(this.cbx_boud);
            this.panel_giris.Controls.Add(this.lbl_baud);
            this.panel_giris.Controls.Add(this.cbx_serialname);
            this.panel_giris.Controls.Add(this.lbl_serialname);
            this.panel_giris.Controls.Add(this.btn_open);
            this.panel_giris.Location = new System.Drawing.Point(517, 50);
            this.panel_giris.Name = "panel_giris";
            this.panel_giris.Size = new System.Drawing.Size(168, 341);
            this.panel_giris.TabIndex = 24;
            // 
            // btn_database
            // 
            this.btn_database.Location = new System.Drawing.Point(16, 258);
            this.btn_database.Name = "btn_database";
            this.btn_database.Size = new System.Drawing.Size(133, 30);
            this.btn_database.TabIndex = 18;
            this.btn_database.Text = "Database";
            this.btn_database.UseVisualStyleBackColor = true;
            this.btn_database.Click += new System.EventHandler(this.btn_database_Click);
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Location = new System.Drawing.Point(17, 294);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(133, 30);
            this.btn_disconnect.TabIndex = 17;
            this.btn_disconnect.Text = "Disconnect";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // lbl_weight
            // 
            this.lbl_weight.AutoSize = true;
            this.lbl_weight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_weight.Location = new System.Drawing.Point(40, 6);
            this.lbl_weight.Name = "lbl_weight";
            this.lbl_weight.Size = new System.Drawing.Size(0, 18);
            this.lbl_weight.TabIndex = 19;
            // 
            // lbl_kg
            // 
            this.lbl_kg.AutoSize = true;
            this.lbl_kg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_kg.Location = new System.Drawing.Point(87, 6);
            this.lbl_kg.Name = "lbl_kg";
            this.lbl_kg.Size = new System.Drawing.Size(32, 18);
            this.lbl_kg.TabIndex = 20;
            this.lbl_kg.Text = "KG";
            // 
            // panel_kilo
            // 
            this.panel_kilo.BackColor = System.Drawing.Color.Tan;
            this.panel_kilo.Controls.Add(this.lbl_kg);
            this.panel_kilo.Controls.Add(this.lbl_weight);
            this.panel_kilo.Location = new System.Drawing.Point(100, 50);
            this.panel_kilo.Name = "panel_kilo";
            this.panel_kilo.Size = new System.Drawing.Size(131, 31);
            this.panel_kilo.TabIndex = 23;
            // 
            // panel_tare
            // 
            this.panel_tare.BackColor = System.Drawing.Color.Tan;
            this.panel_tare.Controls.Add(this.lbl_tare1);
            this.panel_tare.Controls.Add(this.lbl_tare);
            this.panel_tare.Location = new System.Drawing.Point(254, 50);
            this.panel_tare.Name = "panel_tare";
            this.panel_tare.Size = new System.Drawing.Size(131, 31);
            this.panel_tare.TabIndex = 25;
            // 
            // lbl_tare1
            // 
            this.lbl_tare1.AutoSize = true;
            this.lbl_tare1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_tare1.Location = new System.Drawing.Point(77, 6);
            this.lbl_tare1.Name = "lbl_tare1";
            this.lbl_tare1.Size = new System.Drawing.Size(51, 18);
            this.lbl_tare1.TabIndex = 24;
            this.lbl_tare1.Text = "TARE";
            // 
            // lbl_tare
            // 
            this.lbl_tare.AutoSize = true;
            this.lbl_tare.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_tare.Location = new System.Drawing.Point(40, 6);
            this.lbl_tare.Name = "lbl_tare";
            this.lbl_tare.Size = new System.Drawing.Size(0, 18);
            this.lbl_tare.TabIndex = 23;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serialToolStripMenuItem,
            this.tCPClientToolStripMenuItem,
            this.uDPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(696, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // serialToolStripMenuItem
            // 
            this.serialToolStripMenuItem.Name = "serialToolStripMenuItem";
            this.serialToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.serialToolStripMenuItem.Text = "Serial";
            // 
            // tCPClientToolStripMenuItem
            // 
            this.tCPClientToolStripMenuItem.Name = "tCPClientToolStripMenuItem";
            this.tCPClientToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.tCPClientToolStripMenuItem.Text = "TCP Client";
            this.tCPClientToolStripMenuItem.Click += new System.EventHandler(this.tCPClientToolStripMenuItem_Click);
            // 
            // uDPToolStripMenuItem
            // 
            this.uDPToolStripMenuItem.Name = "uDPToolStripMenuItem";
            this.uDPToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.uDPToolStripMenuItem.Text = "UDP";
            // 
            // SerialConnection
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(696, 400);
            this.Controls.Add(this.panel_tare);
            this.Controls.Add(this.panel_giris);
            this.Controls.Add(this.panel_kilo);
            this.Controls.Add(this.listbox_values);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SerialConnection";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.panel_giris.ResumeLayout(false);
            this.panel_giris.PerformLayout();
            this.panel_kilo.ResumeLayout(false);
            this.panel_kilo.PerformLayout();
            this.panel_tare.ResumeLayout(false);
            this.panel_tare.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

    }
    }
