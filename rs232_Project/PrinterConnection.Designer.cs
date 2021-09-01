namespace rs232_Project
{
    partial class PrinterConnection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.data_listbox = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tCPClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lbl_name = new System.Windows.Forms.Label();
            this.cbx_name = new System.Windows.Forms.ComboBox();
            this.lbl_baud = new System.Windows.Forms.Label();
            this.cbx_boud = new System.Windows.Forms.ComboBox();
            this.btn_open = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.panel_serial = new System.Windows.Forms.Panel();
            this.pnl_gross = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_cn = new System.Windows.Forms.Label();
            this.lbl_hour = new System.Windows.Forms.Label();
            this.lbl_date = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_save = new System.Windows.Forms.Button();
            this.lbl_tare = new System.Windows.Forms.Label();
            this.lbl_net = new System.Windows.Forms.Label();
            this.lbl_gross = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel_serial.SuspendLayout();
            this.pnl_gross.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(597, 389);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "a";
            // 
            // data_listbox
            // 
            this.data_listbox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.data_listbox.FormattingEnabled = true;
            this.data_listbox.Location = new System.Drawing.Point(12, 247);
            this.data_listbox.Name = "data_listbox";
            this.data_listbox.Size = new System.Drawing.Size(233, 199);
            this.data_listbox.TabIndex = 15;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serialToolStripMenuItem,
            this.tCPClientToolStripMenuItem,
            this.printToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(518, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // serialToolStripMenuItem
            // 
            this.serialToolStripMenuItem.Name = "serialToolStripMenuItem";
            this.serialToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.serialToolStripMenuItem.Text = "Serial";
            this.serialToolStripMenuItem.Click += new System.EventHandler(this.serialToolStripMenuItem_Click);
            // 
            // tCPClientToolStripMenuItem
            // 
            this.tCPClientToolStripMenuItem.Name = "tCPClientToolStripMenuItem";
            this.tCPClientToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.tCPClientToolStripMenuItem.Text = "TCP Client";
            this.tCPClientToolStripMenuItem.Click += new System.EventHandler(this.tCPClientToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_name.Location = new System.Drawing.Point(52, 7);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(35, 13);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "Name";
            // 
            // cbx_name
            // 
            this.cbx_name.FormattingEnabled = true;
            this.cbx_name.Location = new System.Drawing.Point(55, 23);
            this.cbx_name.Name = "cbx_name";
            this.cbx_name.Size = new System.Drawing.Size(120, 21);
            this.cbx_name.TabIndex = 1;
            // 
            // lbl_baud
            // 
            this.lbl_baud.AutoSize = true;
            this.lbl_baud.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_baud.Location = new System.Drawing.Point(56, 47);
            this.lbl_baud.Name = "lbl_baud";
            this.lbl_baud.Size = new System.Drawing.Size(32, 13);
            this.lbl_baud.TabIndex = 2;
            this.lbl_baud.Text = "Baud";
            // 
            // cbx_boud
            // 
            this.cbx_boud.FormattingEnabled = true;
            this.cbx_boud.Items.AddRange(new object[] {
            "9600"});
            this.cbx_boud.Location = new System.Drawing.Point(57, 66);
            this.cbx_boud.Name = "cbx_boud";
            this.cbx_boud.Size = new System.Drawing.Size(119, 21);
            this.cbx_boud.TabIndex = 3;
            // 
            // btn_open
            // 
            this.btn_open.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_open.Location = new System.Drawing.Point(63, 105);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(112, 21);
            this.btn_open.TabIndex = 4;
            this.btn_open.Text = "OPEN";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // btn_close
            // 
            this.btn_close.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_close.Location = new System.Drawing.Point(61, 136);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(114, 23);
            this.btn_close.TabIndex = 5;
            this.btn_close.Text = "CLOSE";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_print
            // 
            this.btn_print.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_print.Location = new System.Drawing.Point(59, 105);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(114, 25);
            this.btn_print.TabIndex = 14;
            this.btn_print.Text = "PRINT";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // panel_serial
            // 
            this.panel_serial.BackColor = System.Drawing.SystemColors.Info;
            this.panel_serial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_serial.Controls.Add(this.btn_print);
            this.panel_serial.Controls.Add(this.btn_close);
            this.panel_serial.Controls.Add(this.btn_open);
            this.panel_serial.Controls.Add(this.cbx_boud);
            this.panel_serial.Controls.Add(this.lbl_baud);
            this.panel_serial.Controls.Add(this.cbx_name);
            this.panel_serial.Controls.Add(this.lbl_name);
            this.panel_serial.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_serial.Location = new System.Drawing.Point(12, 58);
            this.panel_serial.Name = "panel_serial";
            this.panel_serial.Size = new System.Drawing.Size(233, 169);
            this.panel_serial.TabIndex = 16;
            // 
            // pnl_gross
            // 
            this.pnl_gross.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnl_gross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_gross.Controls.Add(this.lbl_gross);
            this.pnl_gross.Controls.Add(this.lbl_net);
            this.pnl_gross.Controls.Add(this.lbl_tare);
            this.pnl_gross.Controls.Add(this.label11);
            this.pnl_gross.Controls.Add(this.label9);
            this.pnl_gross.Controls.Add(this.label8);
            this.pnl_gross.Controls.Add(this.lbl_cn);
            this.pnl_gross.Controls.Add(this.lbl_hour);
            this.pnl_gross.Controls.Add(this.lbl_date);
            this.pnl_gross.Controls.Add(this.label4);
            this.pnl_gross.Controls.Add(this.label3);
            this.pnl_gross.Controls.Add(this.label2);
            this.pnl_gross.ForeColor = System.Drawing.Color.Black;
            this.pnl_gross.Location = new System.Drawing.Point(265, 58);
            this.pnl_gross.Name = "pnl_gross";
            this.pnl_gross.Size = new System.Drawing.Size(228, 388);
            this.pnl_gross.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(89, 355);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 16);
            this.label11.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(27, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 16);
            this.label9.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(27, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 16);
            this.label8.TabIndex = 11;
            // 
            // lbl_cn
            // 
            this.lbl_cn.AutoSize = true;
            this.lbl_cn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_cn.Location = new System.Drawing.Point(17, 162);
            this.lbl_cn.Name = "lbl_cn";
            this.lbl_cn.Size = new System.Drawing.Size(0, 16);
            this.lbl_cn.TabIndex = 10;
            // 
            // lbl_hour
            // 
            this.lbl_hour.AutoSize = true;
            this.lbl_hour.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_hour.Location = new System.Drawing.Point(17, 125);
            this.lbl_hour.Name = "lbl_hour";
            this.lbl_hour.Size = new System.Drawing.Size(0, 16);
            this.lbl_hour.TabIndex = 9;
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_date.Location = new System.Drawing.Point(17, 92);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(0, 16);
            this.lbl_date.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(46, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(46, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(46, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(305, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "FİŞ YAZDIR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_save
            // 
            this.lbl_save.Location = new System.Drawing.Point(416, 27);
            this.lbl_save.Name = "lbl_save";
            this.lbl_save.Size = new System.Drawing.Size(76, 24);
            this.lbl_save.TabIndex = 20;
            this.lbl_save.Text = "KAYDET";
            this.lbl_save.UseVisualStyleBackColor = true;
            this.lbl_save.Click += new System.EventHandler(this.lbl_save_Click);
            // 
            // lbl_tare
            // 
            this.lbl_tare.AutoSize = true;
            this.lbl_tare.Location = new System.Drawing.Point(14, 279);
            this.lbl_tare.Name = "lbl_tare";
            this.lbl_tare.Size = new System.Drawing.Size(25, 13);
            this.lbl_tare.TabIndex = 16;
            this.lbl_tare.Text = "tare";
            // 
            // lbl_net
            // 
            this.lbl_net.AutoSize = true;
            this.lbl_net.Location = new System.Drawing.Point(17, 315);
            this.lbl_net.Name = "lbl_net";
            this.lbl_net.Size = new System.Drawing.Size(22, 13);
            this.lbl_net.TabIndex = 17;
            this.lbl_net.Text = "net";
            // 
            // lbl_gross
            // 
            this.lbl_gross.AutoSize = true;
            this.lbl_gross.Location = new System.Drawing.Point(14, 256);
            this.lbl_gross.Name = "lbl_gross";
            this.lbl_gross.Size = new System.Drawing.Size(32, 13);
            this.lbl_gross.TabIndex = 18;
            this.lbl_gross.Text = "gross";
            // 
            // PrinterConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(518, 466);
            this.Controls.Add(this.lbl_save);
            this.Controls.Add(this.pnl_gross);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_serial);
            this.Controls.Add(this.data_listbox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PrinterConnection";
            this.Text = "PrinterConnection";
            this.Load += new System.EventHandler(this.PrinterConnection_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_serial.ResumeLayout(false);
            this.panel_serial.PerformLayout();
            this.pnl_gross.ResumeLayout(false);
            this.pnl_gross.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox data_listbox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tCPClientToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.ComboBox cbx_name;
        private System.Windows.Forms.Label lbl_baud;
        private System.Windows.Forms.ComboBox cbx_boud;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Panel panel_serial;
        private System.Windows.Forms.Panel pnl_gross;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_hour;
        private System.Windows.Forms.Label lbl_cn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button lbl_save;
        private System.Windows.Forms.Label lbl_tare;
        private System.Windows.Forms.Label lbl_net;
        private System.Windows.Forms.Label lbl_gross;
    }
}