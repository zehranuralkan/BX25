namespace rs232_Project
{
    partial class SerialConnection
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
             
                base.Dispose(disposing); 
            }
        }

        private void InitializeComponent1()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
      //      this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        //#endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_open;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Label lbl_serialname;
        private System.Windows.Forms.ComboBox cbx_serialname;
        private System.Windows.Forms.Label lbl_baud;
        private System.Windows.Forms.ComboBox cbx_boud;
        private System.Windows.Forms.Label lbl_datasize;
        private System.Windows.Forms.ComboBox cbx_datasize;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListBox listbox_values;
        private System.Windows.Forms.Panel panel_giris;
        private System.Windows.Forms.Label lbl_weight;
        private System.Windows.Forms.Label lbl_kg;
        private System.Windows.Forms.Panel panel_kilo;
        private System.Windows.Forms.Panel panel_tare;
        private System.Windows.Forms.Label lbl_tare1;
        private System.Windows.Forms.Label lbl_tare;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tCPClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uDPToolStripMenuItem;
        private System.Windows.Forms.Button btn_database;
        private System.Windows.Forms.Timer timer_disconnect;
        private System.Windows.Forms.Label lbl_stabilornot;
        private System.Windows.Forms.Panel pnl_input;
        private System.Windows.Forms.Label lbl_inputval;
        private System.Windows.Forms.Label lbl_input;
        private System.Windows.Forms.Label lbl_output;
    }
}

