namespace rs232_Project
{
    partial class UdpConnection
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
            this.panel_udp = new System.Windows.Forms.Panel();
            this.btn_send = new System.Windows.Forms.Button();
            this.tbx_send1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tCPClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uDPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listbox_recieved_data = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_udp
            // 
            this.panel_udp.Location = new System.Drawing.Point(393, 41);
            this.panel_udp.Name = "panel_udp";
            this.panel_udp.Size = new System.Drawing.Size(207, 122);
            this.panel_udp.TabIndex = 0;
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(315, 266);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(83, 20);
            this.btn_send.TabIndex = 6;
            this.btn_send.Text = "SEND";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // tbx_send1
            // 
            this.tbx_send1.Location = new System.Drawing.Point(34, 266);
            this.tbx_send1.Name = "tbx_send1";
            this.tbx_send1.Size = new System.Drawing.Size(255, 20);
            this.tbx_send1.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serialToolStripMenuItem,
            this.tCPClientToolStripMenuItem,
            this.uDPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(612, 24);
            this.menuStrip1.TabIndex = 1;
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
            // 
            // uDPToolStripMenuItem
            // 
            this.uDPToolStripMenuItem.Name = "uDPToolStripMenuItem";
            this.uDPToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.uDPToolStripMenuItem.Text = "UDP";
            // 
            // listbox_recieved_data
            // 
            this.listbox_recieved_data.FormattingEnabled = true;
            this.listbox_recieved_data.Location = new System.Drawing.Point(10, 41);
            this.listbox_recieved_data.Name = "listbox_recieved_data";
            this.listbox_recieved_data.Size = new System.Drawing.Size(353, 173);
            this.listbox_recieved_data.TabIndex = 2;
            // 
            // UdpConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 503);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.listbox_recieved_data);
            this.Controls.Add(this.tbx_send1);
            this.Controls.Add(this.panel_udp);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UdpConnection";
            this.Text = "UdpConnection";
            this.Load += new System.EventHandler(this.UdpConnection_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_udp;
        private System.Windows.Forms.TextBox tbx_send1;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tCPClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uDPToolStripMenuItem;
        private System.Windows.Forms.ListBox listbox_recieved_data;
    }
}