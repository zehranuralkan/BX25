using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace rs232_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public string deger = "";

     
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {

                deger = Rs232_connection.serialPort.ReadLine();
                Control.CheckForIllegalCrossThreadCalls = false;
                listbox_degerler.Items.Add(deger);
                CheckParse(deger);
                lbl_kg.Text = "KG";
                lbl_tare1.Text = "TARE";


            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Geçersiz i/o");
            }
            catch (InvalidOperationException)
            {
                deger = "";
            }
            try
            {
                base.Invoke(new EventHandler(this.DisplayText));
            }
            catch (FormatException)
            {
                MessageBox.Show("Geçersiz format");
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Geçersiz yöntem cagrisi");

            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Geçersiz dizin");

            }

        }


        private void CheckParse(string veri1)
        //deger'i 6 bit ayirma islemi
        {
            try
            {
                int ayir = veri1.IndexOf(' ');
                lbl_kilo.Text = veri1.Substring(6, ayir);
                lbl_tare.Text = veri1.Substring(12, ayir);
            }

            catch
            {

            }

        }
    private void DisplayText(object sender, EventArgs e)
        {
            // terazi_olcum.EditValue = Rs232_connection.gelen_Deger(deger);

        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            //Rs232_connection.PortOpen("COM4", 9600); //kulanilacak port
            
            Rs232_connection.serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived); //verileri alır

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (cbx_serialname.Text != " " && cbx_boud.Text != " " && cbx_datasize.Text != "" )
            {
                //bos deger girilmesi engellendi
                if (Convert.ToInt32(cbx_datasize.Text) == 8)
                {
                    Rs232_connection.PortOpen(cbx_serialname.Text, Convert.ToInt32(cbx_boud.Text)); //kulanilacak port
                    serialPort.PortName = cbx_serialname.SelectedItem.ToString();
                    //listbox_degerler.Items.Add("Serial port " +" " + cbx_serialname.Text.ToString() +" "+ "opened");

                    //serialPort.Open();
                    backgroundWorker1.RunWorkerAsync();
                      }
            }

            else MessageBox.Show("Gerekli alanları doldurunuz");
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
            {
           //textBox.Text += serialPort.ReadLine();
            }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_open = new System.Windows.Forms.Button();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.lbl_serialname = new System.Windows.Forms.Label();
            this.cbx_serialname = new System.Windows.Forms.ComboBox();
            this.lbl_baud = new System.Windows.Forms.Label();
            this.cbx_boud = new System.Windows.Forms.ComboBox();
            this.lbl_datasize = new System.Windows.Forms.Label();
            this.cbx_datasize = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.listbox_degerler = new System.Windows.Forms.ListBox();
            this.panel_giris = new System.Windows.Forms.Panel();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.lbl_kilo = new System.Windows.Forms.Label();
            this.lbl_kg = new System.Windows.Forms.Label();
            this.panel_kilo = new System.Windows.Forms.Panel();
            this.panel_tare = new System.Windows.Forms.Panel();
            this.lbl_tare1 = new System.Windows.Forms.Label();
            this.lbl_tare = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tCPClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_giris.SuspendLayout();
            this.panel_kilo.SuspendLayout();
            this.panel_tare.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 0;
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(18, 299);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(133, 32);
            this.btn_open.TabIndex = 7;
            this.btn_open.Text = "Connect";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_serialname
            // 
            this.lbl_serialname.AutoSize = true;
            this.lbl_serialname.Location = new System.Drawing.Point(15, 40);
            this.lbl_serialname.Name = "lbl_serialname";
            this.lbl_serialname.Size = new System.Drawing.Size(49, 17);
            this.lbl_serialname.TabIndex = 6;
            this.lbl_serialname.Text = "Name:";
            // 
            // cbx_serialname
            // 
            this.cbx_serialname.FormattingEnabled = true;
            this.cbx_serialname.Items.AddRange(new object[] {
            "COM4",
            "COM5"});
            this.cbx_serialname.Location = new System.Drawing.Point(18, 60);
            this.cbx_serialname.Name = "cbx_serialname";
            this.cbx_serialname.Size = new System.Drawing.Size(133, 24);
            this.cbx_serialname.TabIndex = 1;
            // 
            // lbl_baud
            // 
            this.lbl_baud.AutoSize = true;
            this.lbl_baud.Location = new System.Drawing.Point(15, 109);
            this.lbl_baud.Name = "lbl_baud";
            this.lbl_baud.Size = new System.Drawing.Size(41, 17);
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
            this.cbx_boud.Size = new System.Drawing.Size(132, 24);
            this.cbx_boud.TabIndex = 2;
            // 
            // lbl_datasize
            // 
            this.lbl_datasize.AutoSize = true;
            this.lbl_datasize.Location = new System.Drawing.Point(15, 181);
            this.lbl_datasize.Name = "lbl_datasize";
            this.lbl_datasize.Size = new System.Drawing.Size(69, 17);
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
            this.cbx_datasize.Size = new System.Drawing.Size(131, 24);
            this.cbx_datasize.TabIndex = 3;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // listbox_degerler
            // 
            this.listbox_degerler.BackColor = System.Drawing.SystemColors.Info;
            this.listbox_degerler.FormattingEnabled = true;
            this.listbox_degerler.HorizontalScrollbar = true;
            this.listbox_degerler.ItemHeight = 16;
            this.listbox_degerler.Location = new System.Drawing.Point(12, 87);
            this.listbox_degerler.Name = "listbox_degerler";
            this.listbox_degerler.Size = new System.Drawing.Size(499, 388);
            this.listbox_degerler.TabIndex = 18;
            // 
            // panel_giris
            // 
            this.panel_giris.BackColor = System.Drawing.Color.PeachPuff;
            this.panel_giris.Controls.Add(this.btn_disconnect);
            this.panel_giris.Controls.Add(this.cbx_datasize);
            this.panel_giris.Controls.Add(this.lbl_datasize);
            this.panel_giris.Controls.Add(this.cbx_boud);
            this.panel_giris.Controls.Add(this.lbl_baud);
            this.panel_giris.Controls.Add(this.cbx_serialname);
            this.panel_giris.Controls.Add(this.lbl_serialname);
            this.panel_giris.Controls.Add(this.btn_open);
            this.panel_giris.Location = new System.Drawing.Point(517, 87);
            this.panel_giris.Name = "panel_giris";
            this.panel_giris.Size = new System.Drawing.Size(168, 388);
            this.panel_giris.TabIndex = 24;
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Location = new System.Drawing.Point(18, 337);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(133, 30);
            this.btn_disconnect.TabIndex = 17;
            this.btn_disconnect.Text = "Disconnect";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lbl_kilo
            // 
            this.lbl_kilo.AutoSize = true;
            this.lbl_kilo.Location = new System.Drawing.Point(48, 12);
            this.lbl_kilo.Name = "lbl_kilo";
            this.lbl_kilo.Size = new System.Drawing.Size(0, 17);
            this.lbl_kilo.TabIndex = 19;
            // 
            // lbl_kg
            // 
            this.lbl_kg.AutoSize = true;
            this.lbl_kg.Location = new System.Drawing.Point(89, 12);
            this.lbl_kg.Name = "lbl_kg";
            this.lbl_kg.Size = new System.Drawing.Size(28, 17);
            this.lbl_kg.TabIndex = 20;
            this.lbl_kg.Text = "KG";
            // 
            // panel_kilo
            // 
            this.panel_kilo.BackColor = System.Drawing.Color.LightSalmon;
            this.panel_kilo.Controls.Add(this.lbl_kg);
            this.panel_kilo.Controls.Add(this.lbl_kilo);
            this.panel_kilo.Location = new System.Drawing.Point(119, 38);
            this.panel_kilo.Name = "panel_kilo";
            this.panel_kilo.Size = new System.Drawing.Size(131, 32);
            this.panel_kilo.TabIndex = 23;
            // 
            // panel_tare
            // 
            this.panel_tare.BackColor = System.Drawing.Color.Tan;
            this.panel_tare.Controls.Add(this.lbl_tare1);
            this.panel_tare.Controls.Add(this.lbl_tare);
            this.panel_tare.Location = new System.Drawing.Point(273, 39);
            this.panel_tare.Name = "panel_tare";
            this.panel_tare.Size = new System.Drawing.Size(135, 31);
            this.panel_tare.TabIndex = 25;
            // 
            // lbl_tare1
            // 
            this.lbl_tare1.AutoSize = true;
            this.lbl_tare1.Location = new System.Drawing.Point(77, 11);
            this.lbl_tare1.Name = "lbl_tare1";
            this.lbl_tare1.Size = new System.Drawing.Size(45, 17);
            this.lbl_tare1.TabIndex = 24;
            this.lbl_tare1.Text = "TARE";
            // 
            // lbl_tare
            // 
            this.lbl_tare.AutoSize = true;
            this.lbl_tare.Location = new System.Drawing.Point(54, 11);
            this.lbl_tare.Name = "lbl_tare";
            this.lbl_tare.Size = new System.Drawing.Size(0, 17);
            this.lbl_tare.TabIndex = 23;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serialToolStripMenuItem,
            this.tCPClientToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(696, 28);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // serialToolStripMenuItem
            // 
            this.serialToolStripMenuItem.Name = "serialToolStripMenuItem";
            this.serialToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.serialToolStripMenuItem.Text = "Serial";
            // 
            // tCPClientToolStripMenuItem
            // 
            this.tCPClientToolStripMenuItem.Name = "tCPClientToolStripMenuItem";
            this.tCPClientToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.tCPClientToolStripMenuItem.Text = "TCP Client";
            this.tCPClientToolStripMenuItem.Click += new System.EventHandler(this.tCPClientToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(696, 496);
            this.Controls.Add(this.panel_tare);
            this.Controls.Add(this.panel_giris);
            this.Controls.Add(this.panel_kilo);
            this.Controls.Add(this.listbox_degerler);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
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

        private void tCPClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EthernetConnection ethernetcon = new EthernetConnection();
            this.Hide();
            ethernetcon.Show();
            
        }

       
    }
}
