using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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
                    CheckParse(value);
                    StabilOrNot(value);
                    ShowPoint(value);
                    PositiveOrNegative(value);
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
              
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("Index Out Of Range Exception");
                }
            }  
        }
        private void CheckParse(string value1)
        {
            try
            {
                int parse = value1.IndexOf(' '); 
                lbl_tare.Text = value1.Substring(11, 6);
                lbl_inputval.Text = value1.Substring(4, 2);
            }
            catch
            {
            }
        }
        public void StabilOrNot(string value1)
        {
            byte[] ba = Encoding.Default.GetBytes(value1); ;

            var hexString = BitConverter.ToString(ba);
            hexString = hexString.Replace("-", "");   
            string stb = hexString.Substring(4, 2);
            string binaryval = Convert.ToString(Convert.ToInt32(stb, 16), 2);
            if (binaryval.Length == 7)
            {
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
            else
            {
                string newbinary = binaryval + "0";
                string bit3 = newbinary.Substring(2, 1);
                if (bit3 == "1")
                {
                    lbl_stabil.Text = "~";
                }
                else
                {
                    lbl_stabil.Text = " ";
                }
            }
        }
        public void ShowPoint(string value1)
        {
            byte[] ba = Encoding.Default.GetBytes(value1);
            var hexString = BitConverter.ToString(ba);
            hexString = hexString.Replace("-", "");
            string stb = hexString.Substring(2, 2);
            string binaryval = Convert.ToString(Convert.ToInt32(stb, 16), 2);
                if (binaryval.Length == 7)
                {
                string value2 = value1.Substring(6, 4);
                string bit210 = binaryval.Substring(4, 3);
                    if (bit210 == "100")
                    {
                        double new_value = (Convert.ToInt32(value2) * (0.01));
                        lbl_weight.Text = new_value.ToString("0.00");
                    }
                }
            else
            {
               
                string newbinary = binaryval + "0";
                string value2 = value1.Substring(0, 4);
                string bit210 = newbinary.Substring(4, 3);
                if (bit210 == "100")
                {
                    double new_value = (Convert.ToInt32(value2) * (0.01));
                    lbl_weight.Text = new_value.ToString("0.00");
                }
            }
        }

        public void PositiveOrNegative(string value1)
        {
            byte[] ba = Encoding.Default.GetBytes(value1);
            var hexString = BitConverter.ToString(ba);
            hexString = hexString.Replace("-", "");
            string stb = hexString.Substring(4, 2);
            string binaryval = Convert.ToString(Convert.ToInt32(stb, 16), 2);
            string bit1 = binaryval.Substring(4, 1);

            if (bit1 == "1")
            {
                lbl_negative.Text = "-";
            }
            else
            {
                lbl_negative.Text = " ";
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
            lbl_listinfo.Visible = false;
            lbl_search.Visible = false;
            lbl_searchvalue.Visible = false;
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
            string databaseweight = lbl_negative.Text + " " + lbl_weight.Text;
            SqlCommand command = new SqlCommand("insert into Serial (Names,Bauds,DataSizes,Weights,Tare,Input,isStabil) values ('" + cbx_serialname.Text.ToString() + "','" + cbx_boud.Text.ToString() + "','" +cbx_datasize.Text.ToString() + "','" + databaseweight + "','" + lbl_tare.Text+"','" + lbl_inputval.Text + "','"+lbl_stabil.Text+"')", sqldata);
            command.ExecuteNonQuery();
            sqldata.Close();
            ListData();
        }

        private void btn_list_Click(object sender, EventArgs e)
        {
            ListData();
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            if (cbx_serialname.Text != " " && cbx_boud.Text != " " && cbx_datasize.Text != "") //// blank value input denied
            {
                if (Convert.ToInt32(cbx_datasize.Text) == 8)
                {
                    Rs232_connection.PortOpen(cbx_serialname.Text, Convert.ToInt32(cbx_boud.Text)); //port to be used
                    serialPort.PortName = cbx_serialname.SelectedItem.ToString();
                    backgroundWorker1.RunWorkerAsync();
                    btn_open.Visible = false;
                    btn_disconnect.Visible = true;
                    btn_database.Visible = true;
                    lbl_listinfo.Visible = true;
                    btn_list.Visible = true;
                    btn_delete.Visible = true;
                }
            }
            else MessageBox.Show("Gerekli alanları doldurunuz");
        }
        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            serialPort.Close();
            btn_open.Visible = true;
            btn_disconnect.Visible = false;
            btn_database.Visible = false;
            lbl_weight.Text = " ";
            lbl_tare.Text = " ";
            lbl_inputval.Text = " ";
            lbl_stabil.Text = " ";
            lbl_listinfo.Text = " ";
        }
        int id = 1;
        private void datagrid_values_MouseClick(object sender, MouseEventArgs e)
        {
            lbl_changeid.Text = datagrid_values.CurrentRow.Cells[0].Value.ToString();
            txt_changenames.Text= datagrid_values.CurrentRow.Cells[1].Value.ToString();
            txt_changebauds.Text= datagrid_values.CurrentRow.Cells[2].Value.ToString();
            txt_changedatasizes.Text= datagrid_values.CurrentRow.Cells[3].Value.ToString();
            lbl_weights.Text= datagrid_values.CurrentRow.Cells[4].Value.ToString();
            lbl_changetare.Text= datagrid_values.CurrentRow.Cells[5].Value.ToString();
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_changenames.Text != "" && txt_changebauds.Text != "" && txt_changedatasizes.Text != "")
            {
               sqldata.Open();
               SqlCommand command = new SqlCommand("update Serial set Names=@Names, Bauds=@Bauds, DataSizes=@DataSizes where Serial_Id='"+ lbl_changeid .Text+ "'", sqldata);
               command.Parameters.AddWithValue("@Names", txt_changenames.Text);
               command.Parameters.AddWithValue("@Bauds", txt_changebauds.Text);
               command.Parameters.AddWithValue("@DataSizes", txt_changedatasizes.Text);
               command.ExecuteNonQuery();
               sqldata.Close();
               ListData();
               lbl_changeid.Text = "";
               txt_changenames.Clear();
               txt_changebauds.Clear();
               txt_changedatasizes.Clear();
               lbl_weights.Text = "";
               lbl_changetare.Text = "";
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (tbx_serialid.Text != "")
            {
                SqlCommand komut = new SqlCommand("delete from Serial where Serial_Id=@serialid", sqldata);
                sqldata.Open();
                komut.Parameters.AddWithValue("@serialid", tbx_serialid.Text);
                komut.ExecuteNonQuery();
                ListData();
                sqldata.Close();
            }

            else
                MessageBox.Show("Please enter the id.");
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
        public void ListData()
        {
            string sql = "select * from Serial";
            SqlDataAdapter adp = new SqlDataAdapter(sql, sqldata);
            DataSet ds = new DataSet(); 
            adp.Fill(ds); 
            datagrid_values.DataSource = ds.Tables[0];
            sqldata.Close();
        }

        DataTable dt;
        private void lbl_searchvalue_TextChanged(object sender, EventArgs e)
        {
            sqldata.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select * from Serial where Weights like '" + lbl_searchvalue.Text + "%'", sqldata);
            dt = new DataTable();
            adp.Fill(dt);
            datagrid_values.DataSource = dt;
            sqldata.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lblserialidupdate.Visible = false;
            lbl_changeid.Visible = false;
            lbl_updatenames.Visible = false;
            txt_changenames.Visible = false;
            lbl_updatebauds.Visible = false;
            txt_changebauds.Visible = false;
            lbl_updatedatasize.Visible = false;
            txt_changedatasizes.Visible = false;
            lbl_updateweight.Location = new Point(148, 56);
            lbl_updatetare.Visible = false;
            lbl_weights.Visible = false;
            lbl_changetare.Visible = false;
            btn_update.Visible = false;
            lbl_search.Visible = true;
            lbl_search.Location=new Point(15, 94);
            lbl_searchvalue.Location=new Point(235, 57);
            lbl_searchvalue.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            lblserialidupdate.Visible = true;
            lbl_changeid.Visible = true;
            lbl_updatenames.Visible = true;
            txt_changenames.Visible = true;
            lbl_updatebauds.Visible = true;
            lbl_updateweight.Location = new Point(148, 120);
            txt_changebauds.Visible = true;
            lbl_updatedatasize.Visible = true;
            txt_changedatasizes.Visible = true;
            lbl_updatetare.Visible = true;
            lbl_weights.Visible = true;
            lbl_changetare.Visible = true;
            btn_update.Visible = true;
            lbl_search.Visible = false;
            lbl_searchvalue.Visible = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialConnection));
            this.btn_open = new System.Windows.Forms.Button();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.lbl_serialname = new System.Windows.Forms.Label();
            this.cbx_serialname = new System.Windows.Forms.ComboBox();
            this.lbl_baud = new System.Windows.Forms.Label();
            this.cbx_boud = new System.Windows.Forms.ComboBox();
            this.lbl_datasize = new System.Windows.Forms.Label();
            this.cbx_datasize = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel_giris = new System.Windows.Forms.Panel();
            this.btn_database = new System.Windows.Forms.Button();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.lbl_weight = new System.Windows.Forms.Label();
            this.lbl_kg = new System.Windows.Forms.Label();
            this.panel_kilo = new System.Windows.Forms.Panel();
            this.lbl_stabil = new System.Windows.Forms.Label();
            this.lbl_output = new System.Windows.Forms.Label();
            this.lbl_stabilornot = new System.Windows.Forms.Label();
            this.panel_tare = new System.Windows.Forms.Panel();
            this.lbl_tare1 = new System.Windows.Forms.Label();
            this.lbl_tare = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tCPClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uDPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_disconnect = new System.Windows.Forms.Timer(this.components);
            this.pnl_input = new System.Windows.Forms.Panel();
            this.lbl_inputval = new System.Windows.Forms.Label();
            this.lbl_input = new System.Windows.Forms.Label();
            this.datagrid_values = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_listinfo = new System.Windows.Forms.Label();
            this.btn_list = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_deletedata = new System.Windows.Forms.Label();
            this.btn_delete = new System.Windows.Forms.Button();
            this.tbx_serialid = new System.Windows.Forms.TextBox();
            this.lbl_serialid = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_searchvalue = new System.Windows.Forms.TextBox();
            this.lbl_search = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_update = new System.Windows.Forms.Button();
            this.lbl_searchandupdate = new System.Windows.Forms.Label();
            this.lbl_changetare = new System.Windows.Forms.Label();
            this.lbl_weights = new System.Windows.Forms.Label();
            this.txt_changedatasizes = new System.Windows.Forms.TextBox();
            this.txt_changebauds = new System.Windows.Forms.TextBox();
            this.txt_changenames = new System.Windows.Forms.TextBox();
            this.lbl_changeid = new System.Windows.Forms.Label();
            this.lbl_updatetare = new System.Windows.Forms.Label();
            this.lbl_updateweight = new System.Windows.Forms.Label();
            this.lbl_updatedatasize = new System.Windows.Forms.Label();
            this.lbl_updatebauds = new System.Windows.Forms.Label();
            this.lbl_updatenames = new System.Windows.Forms.Label();
            this.lblserialidupdate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_values = new System.Windows.Forms.Label();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lbl_negative = new System.Windows.Forms.Label();
            this.panel_giris.SuspendLayout();
            this.panel_kilo.SuspendLayout();
            this.panel_tare.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnl_input.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_values)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(16, 155);
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
            this.lbl_serialname.Location = new System.Drawing.Point(14, 9);
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
            this.cbx_serialname.Location = new System.Drawing.Point(17, 29);
            this.cbx_serialname.Name = "cbx_serialname";
            this.cbx_serialname.Size = new System.Drawing.Size(133, 21);
            this.cbx_serialname.TabIndex = 1;
            // 
            // lbl_baud
            // 
            this.lbl_baud.AutoSize = true;
            this.lbl_baud.Location = new System.Drawing.Point(15, 53);
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
            this.cbx_boud.Location = new System.Drawing.Point(18, 69);
            this.cbx_boud.Name = "cbx_boud";
            this.cbx_boud.Size = new System.Drawing.Size(132, 21);
            this.cbx_boud.TabIndex = 2;
            // 
            // lbl_datasize
            // 
            this.lbl_datasize.AutoSize = true;
            this.lbl_datasize.Location = new System.Drawing.Point(15, 100);
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
            this.cbx_datasize.Location = new System.Drawing.Point(18, 116);
            this.cbx_datasize.Name = "cbx_datasize";
            this.cbx_datasize.Size = new System.Drawing.Size(131, 21);
            this.cbx_datasize.TabIndex = 3;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // panel_giris
            // 
            this.panel_giris.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel_giris.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_giris.Controls.Add(this.btn_database);
            this.panel_giris.Controls.Add(this.btn_disconnect);
            this.panel_giris.Controls.Add(this.cbx_datasize);
            this.panel_giris.Controls.Add(this.lbl_datasize);
            this.panel_giris.Controls.Add(this.cbx_boud);
            this.panel_giris.Controls.Add(this.lbl_baud);
            this.panel_giris.Controls.Add(this.cbx_serialname);
            this.panel_giris.Controls.Add(this.lbl_serialname);
            this.panel_giris.Controls.Add(this.btn_open);
            this.panel_giris.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel_giris.Location = new System.Drawing.Point(7, 68);
            this.panel_giris.Name = "panel_giris";
            this.panel_giris.Size = new System.Drawing.Size(165, 233);
            this.panel_giris.TabIndex = 24;
            // 
            // btn_database
            // 
            this.btn_database.Location = new System.Drawing.Point(16, 155);
            this.btn_database.Name = "btn_database";
            this.btn_database.Size = new System.Drawing.Size(133, 30);
            this.btn_database.TabIndex = 18;
            this.btn_database.Text = "Database";
            this.btn_database.UseVisualStyleBackColor = true;
            this.btn_database.Click += new System.EventHandler(this.btn_database_Click);
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Location = new System.Drawing.Point(16, 193);
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
            this.lbl_weight.Location = new System.Drawing.Point(82, 7);
            this.lbl_weight.Name = "lbl_weight";
            this.lbl_weight.Size = new System.Drawing.Size(0, 18);
            this.lbl_weight.TabIndex = 19;
            // 
            // lbl_kg
            // 
            this.lbl_kg.AutoSize = true;
            this.lbl_kg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_kg.Location = new System.Drawing.Point(134, 10);
            this.lbl_kg.Name = "lbl_kg";
            this.lbl_kg.Size = new System.Drawing.Size(32, 18);
            this.lbl_kg.TabIndex = 20;
            this.lbl_kg.Text = "KG";
            // 
            // panel_kilo
            // 
            this.panel_kilo.BackColor = System.Drawing.Color.Wheat;
            this.panel_kilo.Controls.Add(this.lbl_negative);
            this.panel_kilo.Controls.Add(this.lbl_stabil);
            this.panel_kilo.Controls.Add(this.lbl_output);
            this.panel_kilo.Controls.Add(this.lbl_stabilornot);
            this.panel_kilo.Controls.Add(this.lbl_kg);
            this.panel_kilo.Controls.Add(this.lbl_weight);
            this.panel_kilo.Location = new System.Drawing.Point(6, 380);
            this.panel_kilo.Name = "panel_kilo";
            this.panel_kilo.Size = new System.Drawing.Size(175, 31);
            this.panel_kilo.TabIndex = 23;
            // 
            // lbl_stabil
            // 
            this.lbl_stabil.AutoSize = true;
            this.lbl_stabil.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_stabil.Location = new System.Drawing.Point(45, 10);
            this.lbl_stabil.Name = "lbl_stabil";
            this.lbl_stabil.Size = new System.Drawing.Size(0, 18);
            this.lbl_stabil.TabIndex = 29;
            // 
            // lbl_output
            // 
            this.lbl_output.AutoSize = true;
            this.lbl_output.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_output.Location = new System.Drawing.Point(1, 16);
            this.lbl_output.Name = "lbl_output";
            this.lbl_output.Size = new System.Drawing.Size(43, 13);
            this.lbl_output.TabIndex = 28;
            this.lbl_output.Text = "output";
            // 
            // lbl_stabilornot
            // 
            this.lbl_stabilornot.AutoSize = true;
            this.lbl_stabilornot.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_stabilornot.Location = new System.Drawing.Point(70, 8);
            this.lbl_stabilornot.Name = "lbl_stabilornot";
            this.lbl_stabilornot.Size = new System.Drawing.Size(0, 18);
            this.lbl_stabilornot.TabIndex = 27;
            // 
            // panel_tare
            // 
            this.panel_tare.BackColor = System.Drawing.Color.Wheat;
            this.panel_tare.Controls.Add(this.lbl_tare1);
            this.panel_tare.Controls.Add(this.lbl_tare);
            this.panel_tare.Location = new System.Drawing.Point(6, 411);
            this.panel_tare.Name = "panel_tare";
            this.panel_tare.Size = new System.Drawing.Size(175, 31);
            this.panel_tare.TabIndex = 25;
            // 
            // lbl_tare1
            // 
            this.lbl_tare1.AutoSize = true;
            this.lbl_tare1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_tare1.Location = new System.Drawing.Point(115, 9);
            this.lbl_tare1.Name = "lbl_tare1";
            this.lbl_tare1.Size = new System.Drawing.Size(51, 18);
            this.lbl_tare1.TabIndex = 24;
            this.lbl_tare1.Text = "TARE";
            // 
            // lbl_tare
            // 
            this.lbl_tare.AutoSize = true;
            this.lbl_tare.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_tare.Location = new System.Drawing.Point(70, 9);
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
            this.menuStrip1.Size = new System.Drawing.Size(976, 24);
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
            this.tCPClientToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.tCPClientToolStripMenuItem.Text = "TCP Client";
            this.tCPClientToolStripMenuItem.Click += new System.EventHandler(this.tCPClientToolStripMenuItem_Click);
            // 
            // uDPToolStripMenuItem
            // 
            this.uDPToolStripMenuItem.Name = "uDPToolStripMenuItem";
            this.uDPToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.uDPToolStripMenuItem.Text = "UDP";
            // 
            // pnl_input
            // 
            this.pnl_input.BackColor = System.Drawing.Color.Wheat;
            this.pnl_input.Controls.Add(this.lbl_inputval);
            this.pnl_input.Controls.Add(this.lbl_input);
            this.pnl_input.Location = new System.Drawing.Point(6, 350);
            this.pnl_input.Name = "pnl_input";
            this.pnl_input.Size = new System.Drawing.Size(175, 31);
            this.pnl_input.TabIndex = 27;
            // 
            // lbl_inputval
            // 
            this.lbl_inputval.AutoSize = true;
            this.lbl_inputval.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_inputval.Location = new System.Drawing.Point(85, 9);
            this.lbl_inputval.Name = "lbl_inputval";
            this.lbl_inputval.Size = new System.Drawing.Size(0, 18);
            this.lbl_inputval.TabIndex = 1;
            // 
            // lbl_input
            // 
            this.lbl_input.AutoSize = true;
            this.lbl_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_input.Location = new System.Drawing.Point(3, 12);
            this.lbl_input.Name = "lbl_input";
            this.lbl_input.Size = new System.Drawing.Size(39, 15);
            this.lbl_input.TabIndex = 0;
            this.lbl_input.Text = "input";
            // 
            // datagrid_values
            // 
            this.datagrid_values.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.datagrid_values.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_values.Location = new System.Drawing.Point(3, 39);
            this.datagrid_values.MultiSelect = false;
            this.datagrid_values.Name = "datagrid_values";
            this.datagrid_values.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagrid_values.Size = new System.Drawing.Size(764, 178);
            this.datagrid_values.TabIndex = 28;
            this.datagrid_values.MouseClick += new System.Windows.Forms.MouseEventHandler(this.datagrid_values_MouseClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl_listinfo);
            this.panel1.Controls.Add(this.btn_list);
            this.panel1.Controls.Add(this.datagrid_values);
            this.panel1.Location = new System.Drawing.Point(187, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 249);
            this.panel1.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mistral", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(325, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 38);
            this.label2.TabIndex = 31;
            this.label2.Text = "DATA LIST";
            // 
            // lbl_listinfo
            // 
            this.lbl_listinfo.AutoSize = true;
            this.lbl_listinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_listinfo.Location = new System.Drawing.Point(256, 227);
            this.lbl_listinfo.Name = "lbl_listinfo";
            this.lbl_listinfo.Size = new System.Drawing.Size(266, 15);
            this.lbl_listinfo.TabIndex = 30;
            this.lbl_listinfo.Text = "NOTE: Click list to see the recorded data";
            // 
            // btn_list
            // 
            this.btn_list.Location = new System.Drawing.Point(688, 221);
            this.btn_list.Name = "btn_list";
            this.btn_list.Size = new System.Drawing.Size(79, 26);
            this.btn_list.TabIndex = 29;
            this.btn_list.Text = "LIST";
            this.btn_list.UseVisualStyleBackColor = true;
            this.btn_list.Click += new System.EventHandler(this.btn_list_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PowderBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lbl_deletedata);
            this.panel2.Controls.Add(this.btn_delete);
            this.panel2.Controls.Add(this.tbx_serialid);
            this.panel2.Controls.Add(this.lbl_serialid);
            this.panel2.Location = new System.Drawing.Point(187, 292);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(299, 166);
            this.panel2.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(3, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "NOTE: Enter the id of the data you want to delete.";
            // 
            // lbl_deletedata
            // 
            this.lbl_deletedata.AutoSize = true;
            this.lbl_deletedata.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl_deletedata.Font = new System.Drawing.Font("Mistral", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_deletedata.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_deletedata.Location = new System.Drawing.Point(68, 0);
            this.lbl_deletedata.Name = "lbl_deletedata";
            this.lbl_deletedata.Size = new System.Drawing.Size(153, 38);
            this.lbl_deletedata.TabIndex = 0;
            this.lbl_deletedata.Text = "DATA DELETE";
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(138, 90);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(83, 22);
            this.btn_delete.TabIndex = 3;
            this.btn_delete.Text = "DELETE";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // tbx_serialid
            // 
            this.tbx_serialid.Location = new System.Drawing.Point(138, 59);
            this.tbx_serialid.Name = "tbx_serialid";
            this.tbx_serialid.Size = new System.Drawing.Size(83, 20);
            this.tbx_serialid.TabIndex = 2;
            // 
            // lbl_serialid
            // 
            this.lbl_serialid.AutoSize = true;
            this.lbl_serialid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_serialid.Location = new System.Drawing.Point(62, 61);
            this.lbl_serialid.Name = "lbl_serialid";
            this.lbl_serialid.Size = new System.Drawing.Size(60, 16);
            this.lbl_serialid.TabIndex = 1;
            this.lbl_serialid.Text = "Serial Id:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.lbl_searchvalue);
            this.panel3.Controls.Add(this.lbl_search);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.btn_update);
            this.panel3.Controls.Add(this.lbl_searchandupdate);
            this.panel3.Controls.Add(this.lbl_changetare);
            this.panel3.Controls.Add(this.lbl_weights);
            this.panel3.Controls.Add(this.txt_changedatasizes);
            this.panel3.Controls.Add(this.txt_changebauds);
            this.panel3.Controls.Add(this.txt_changenames);
            this.panel3.Controls.Add(this.lbl_changeid);
            this.panel3.Controls.Add(this.lbl_updatetare);
            this.panel3.Controls.Add(this.lbl_updateweight);
            this.panel3.Controls.Add(this.lbl_updatedatasize);
            this.panel3.Controls.Add(this.lbl_updatebauds);
            this.panel3.Controls.Add(this.lbl_updatenames);
            this.panel3.Controls.Add(this.lblserialidupdate);
            this.panel3.Location = new System.Drawing.Point(501, 292);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(461, 166);
            this.panel3.TabIndex = 31;
            // 
            // lbl_searchvalue
            // 
            this.lbl_searchvalue.Location = new System.Drawing.Point(332, 124);
            this.lbl_searchvalue.Name = "lbl_searchvalue";
            this.lbl_searchvalue.Size = new System.Drawing.Size(100, 20);
            this.lbl_searchvalue.TabIndex = 17;
            this.lbl_searchvalue.TextChanged += new System.EventHandler(this.lbl_searchvalue_TextChanged);
            // 
            // lbl_search
            // 
            this.lbl_search.AutoSize = true;
            this.lbl_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_search.Location = new System.Drawing.Point(15, 35);
            this.lbl_search.Name = "lbl_search";
            this.lbl_search.Size = new System.Drawing.Size(431, 18);
            this.lbl_search.TabIndex = 15;
            this.lbl_search.Text = "NOTE:Please enter the weight value you want to search.";
            // 
            // pictureBox2
            // 
            this.pictureBox2.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.ErrorImage")));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(60, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::rs232_Project.Properties.Resources.magnifying_glass;
            this.pictureBox1.Location = new System.Drawing.Point(361, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(202, 142);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(71, 21);
            this.btn_update.TabIndex = 12;
            this.btn_update.Text = "UPDATE";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // lbl_searchandupdate
            // 
            this.lbl_searchandupdate.AutoSize = true;
            this.lbl_searchandupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbl_searchandupdate.Font = new System.Drawing.Font("Mistral", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_searchandupdate.Location = new System.Drawing.Point(95, 0);
            this.lbl_searchandupdate.Name = "lbl_searchandupdate";
            this.lbl_searchandupdate.Size = new System.Drawing.Size(260, 38);
            this.lbl_searchandupdate.TabIndex = 0;
            this.lbl_searchandupdate.Text = "DATA UPDATE- SEARCH";
            // 
            // lbl_changetare
            // 
            this.lbl_changetare.AutoSize = true;
            this.lbl_changetare.Location = new System.Drawing.Point(307, 126);
            this.lbl_changetare.Name = "lbl_changetare";
            this.lbl_changetare.Size = new System.Drawing.Size(0, 13);
            this.lbl_changetare.TabIndex = 11;
            // 
            // lbl_weights
            // 
            this.lbl_weights.AutoSize = true;
            this.lbl_weights.Location = new System.Drawing.Point(232, 126);
            this.lbl_weights.Name = "lbl_weights";
            this.lbl_weights.Size = new System.Drawing.Size(0, 13);
            this.lbl_weights.TabIndex = 10;
            // 
            // txt_changedatasizes
            // 
            this.txt_changedatasizes.Location = new System.Drawing.Point(235, 103);
            this.txt_changedatasizes.Name = "txt_changedatasizes";
            this.txt_changedatasizes.Size = new System.Drawing.Size(100, 20);
            this.txt_changedatasizes.TabIndex = 9;
            // 
            // txt_changebauds
            // 
            this.txt_changebauds.Location = new System.Drawing.Point(235, 81);
            this.txt_changebauds.Name = "txt_changebauds";
            this.txt_changebauds.Size = new System.Drawing.Size(100, 20);
            this.txt_changebauds.TabIndex = 8;
            // 
            // txt_changenames
            // 
            this.txt_changenames.Location = new System.Drawing.Point(235, 57);
            this.txt_changenames.Name = "txt_changenames";
            this.txt_changenames.Size = new System.Drawing.Size(100, 20);
            this.txt_changenames.TabIndex = 7;
            // 
            // lbl_changeid
            // 
            this.lbl_changeid.AutoSize = true;
            this.lbl_changeid.Location = new System.Drawing.Point(232, 40);
            this.lbl_changeid.Name = "lbl_changeid";
            this.lbl_changeid.Size = new System.Drawing.Size(0, 13);
            this.lbl_changeid.TabIndex = 6;
            // 
            // lbl_updatetare
            // 
            this.lbl_updatetare.AutoSize = true;
            this.lbl_updatetare.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_updatetare.Location = new System.Drawing.Point(275, 123);
            this.lbl_updatetare.Name = "lbl_updatetare";
            this.lbl_updatetare.Size = new System.Drawing.Size(42, 18);
            this.lbl_updatetare.TabIndex = 5;
            this.lbl_updatetare.Text = "Tare:";
            // 
            // lbl_updateweight
            // 
            this.lbl_updateweight.AutoSize = true;
            this.lbl_updateweight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_updateweight.Location = new System.Drawing.Point(148, 120);
            this.lbl_updateweight.Name = "lbl_updateweight";
            this.lbl_updateweight.Size = new System.Drawing.Size(66, 18);
            this.lbl_updateweight.TabIndex = 4;
            this.lbl_updateweight.Text = "Weights:";
            // 
            // lbl_updatedatasize
            // 
            this.lbl_updatedatasize.AutoSize = true;
            this.lbl_updatedatasize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_updatedatasize.Location = new System.Drawing.Point(148, 102);
            this.lbl_updatedatasize.Name = "lbl_updatedatasize";
            this.lbl_updatedatasize.Size = new System.Drawing.Size(84, 18);
            this.lbl_updatedatasize.TabIndex = 3;
            this.lbl_updatedatasize.Text = "Data Sizes:";
            // 
            // lbl_updatebauds
            // 
            this.lbl_updatebauds.AutoSize = true;
            this.lbl_updatebauds.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_updatebauds.Location = new System.Drawing.Point(148, 81);
            this.lbl_updatebauds.Name = "lbl_updatebauds";
            this.lbl_updatebauds.Size = new System.Drawing.Size(54, 18);
            this.lbl_updatebauds.TabIndex = 2;
            this.lbl_updatebauds.Text = "Bauds:";
            // 
            // lbl_updatenames
            // 
            this.lbl_updatenames.AutoSize = true;
            this.lbl_updatenames.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_updatenames.Location = new System.Drawing.Point(148, 56);
            this.lbl_updatenames.Name = "lbl_updatenames";
            this.lbl_updatenames.Size = new System.Drawing.Size(60, 18);
            this.lbl_updatenames.TabIndex = 1;
            this.lbl_updatenames.Text = "Names:";
            // 
            // lblserialidupdate
            // 
            this.lblserialidupdate.AutoSize = true;
            this.lblserialidupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblserialidupdate.Location = new System.Drawing.Point(148, 38);
            this.lblserialidupdate.Name = "lblserialidupdate";
            this.lblserialidupdate.Size = new System.Drawing.Size(64, 18);
            this.lblserialidupdate.TabIndex = 0;
            this.lblserialidupdate.Text = "Serial Id:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label4.Font = new System.Drawing.Font("Mistral", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(47, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 33);
            this.label4.TabIndex = 32;
            this.label4.Text = "SERIAL";
            // 
            // lbl_values
            // 
            this.lbl_values.AutoSize = true;
            this.lbl_values.BackColor = System.Drawing.Color.Wheat;
            this.lbl_values.Font = new System.Drawing.Font("Mistral", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_values.Location = new System.Drawing.Point(48, 330);
            this.lbl_values.Name = "lbl_values";
            this.lbl_values.Size = new System.Drawing.Size(72, 29);
            this.lbl_values.TabIndex = 33;
            this.lbl_values.Text = "VALUES";
            // 
            // ımageList1
            // 
            this.ımageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ımageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lbl_negative
            // 
            this.lbl_negative.AutoSize = true;
            this.lbl_negative.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_negative.Location = new System.Drawing.Point(70, 7);
            this.lbl_negative.Name = "lbl_negative";
            this.lbl_negative.Size = new System.Drawing.Size(0, 16);
            this.lbl_negative.TabIndex = 30;
            // 
            // SerialConnection
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::rs232_Project.Properties.Resources.deneme;
            this.ClientSize = new System.Drawing.Size(976, 458);
            this.Controls.Add(this.lbl_values);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_input);
            this.Controls.Add(this.panel_kilo);
            this.Controls.Add(this.panel_tare);
            this.Controls.Add(this.panel_giris);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SerialConnection";
            this.Text = "SERIAL";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.panel_giris.ResumeLayout(false);
            this.panel_giris.PerformLayout();
            this.panel_kilo.ResumeLayout(false);
            this.panel_kilo.PerformLayout();
            this.panel_tare.ResumeLayout(false);
            this.panel_tare.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnl_input.ResumeLayout(false);
            this.pnl_input.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_values)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }
    }
    }
