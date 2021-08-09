using System;

namespace rs232_Project
{
    partial class EthernetConnection
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
            if (Handle != IntPtr.Zero)
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
            this.listbox_ethernetCon = new System.Windows.Forms.ListBox();
            this.lbl_moduleip = new System.Windows.Forms.Label();
            this.tbx_moduleip = new System.Windows.Forms.TextBox();
            this.lbl_port = new System.Windows.Forms.Label();
            this.tbx_port = new System.Windows.Forms.TextBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tCPClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.lbl_deger = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_kilo = new System.Windows.Forms.Label();
            this.lbl_tare = new System.Windows.Forms.Label();
            this.lbl_kilodeger = new System.Windows.Forms.Label();
            this.lbl_taredeger = new System.Windows.Forms.Label();
            this.lbl_negative = new System.Windows.Forms.Label();
            this.lbl_stabil = new System.Windows.Forms.Label();
            this.panel_bilgi = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panel_bilgi.SuspendLayout();
            this.SuspendLayout();
            // 
            // listbox_ethernetCon
            // 
            this.listbox_ethernetCon.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listbox_ethernetCon.FormattingEnabled = true;
            this.listbox_ethernetCon.Location = new System.Drawing.Point(9, 34);
            this.listbox_ethernetCon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listbox_ethernetCon.Name = "listbox_ethernetCon";
            this.listbox_ethernetCon.Size = new System.Drawing.Size(307, 368);
            this.listbox_ethernetCon.TabIndex = 0;
            // 
            // lbl_moduleip
            // 
            this.lbl_moduleip.AutoSize = true;
            this.lbl_moduleip.Location = new System.Drawing.Point(333, 61);
            this.lbl_moduleip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_moduleip.Name = "lbl_moduleip";
            this.lbl_moduleip.Size = new System.Drawing.Size(54, 13);
            this.lbl_moduleip.TabIndex = 1;
            this.lbl_moduleip.Text = "Module Ip";
            // 
            // tbx_moduleip
            // 
            this.tbx_moduleip.Location = new System.Drawing.Point(335, 85);
            this.tbx_moduleip.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbx_moduleip.Name = "tbx_moduleip";
            this.tbx_moduleip.Size = new System.Drawing.Size(115, 20);
            this.tbx_moduleip.TabIndex = 2;
            this.tbx_moduleip.Text = "192.168.15.250";
            // 
            // lbl_port
            // 
            this.lbl_port.AutoSize = true;
            this.lbl_port.Location = new System.Drawing.Point(459, 61);
            this.lbl_port.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_port.Name = "lbl_port";
            this.lbl_port.Size = new System.Drawing.Size(26, 13);
            this.lbl_port.TabIndex = 3;
            this.lbl_port.Text = "Port";
            // 
            // tbx_port
            // 
            this.tbx_port.Location = new System.Drawing.Point(461, 85);
            this.tbx_port.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbx_port.Name = "tbx_port";
            this.tbx_port.Size = new System.Drawing.Size(70, 20);
            this.tbx_port.TabIndex = 4;
            this.tbx_port.Text = "502";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(382, 115);
            this.btn_connect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(68, 20);
            this.btn_connect.TabIndex = 5;
            this.btn_connect.Text = "CONNECT";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serialToolStripMenuItem,
            this.tCPClientToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(571, 24);
            this.menuStrip1.TabIndex = 6;
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
            // btn_disconnect
            // 
            this.btn_disconnect.Location = new System.Drawing.Point(461, 116);
            this.btn_disconnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(93, 20);
            this.btn_disconnect.TabIndex = 7;
            this.btn_disconnect.Text = "DISCONNECT";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // lbl_deger
            // 
            this.lbl_deger.AutoSize = true;
            this.lbl_deger.Location = new System.Drawing.Point(331, 107);
            this.lbl_deger.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_deger.Name = "lbl_deger";
            this.lbl_deger.Size = new System.Drawing.Size(0, 13);
            this.lbl_deger.TabIndex = 8;
            // 
            // lbl_kilo
            // 
            this.lbl_kilo.AutoSize = true;
            this.lbl_kilo.Location = new System.Drawing.Point(90, 46);
            this.lbl_kilo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_kilo.Name = "lbl_kilo";
            this.lbl_kilo.Size = new System.Drawing.Size(22, 13);
            this.lbl_kilo.TabIndex = 9;
            this.lbl_kilo.Text = "KG";
            // 
            // lbl_tare
            // 
            this.lbl_tare.AutoSize = true;
            this.lbl_tare.Location = new System.Drawing.Point(22, 15);
            this.lbl_tare.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_tare.Name = "lbl_tare";
            this.lbl_tare.Size = new System.Drawing.Size(36, 13);
            this.lbl_tare.TabIndex = 10;
            this.lbl_tare.Text = "TARE";
            // 
            // lbl_kilodeger
            // 
            this.lbl_kilodeger.AutoSize = true;
            this.lbl_kilodeger.Location = new System.Drawing.Point(58, 46);
            this.lbl_kilodeger.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_kilodeger.Name = "lbl_kilodeger";
            this.lbl_kilodeger.Size = new System.Drawing.Size(0, 13);
            this.lbl_kilodeger.TabIndex = 11;
            // 
            // lbl_taredeger
            // 
            this.lbl_taredeger.AutoSize = true;
            this.lbl_taredeger.Location = new System.Drawing.Point(62, 15);
            this.lbl_taredeger.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_taredeger.Name = "lbl_taredeger";
            this.lbl_taredeger.Size = new System.Drawing.Size(0, 13);
            this.lbl_taredeger.TabIndex = 12;
            // 
            // lbl_negative
            // 
            this.lbl_negative.AutoSize = true;
            this.lbl_negative.Location = new System.Drawing.Point(51, 46);
            this.lbl_negative.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_negative.Name = "lbl_negative";
            this.lbl_negative.Size = new System.Drawing.Size(0, 13);
            this.lbl_negative.TabIndex = 16;
            // 
            // lbl_stabil
            // 
            this.lbl_stabil.AutoSize = true;
            this.lbl_stabil.Location = new System.Drawing.Point(32, 46);
            this.lbl_stabil.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_stabil.Name = "lbl_stabil";
            this.lbl_stabil.Size = new System.Drawing.Size(0, 13);
            this.lbl_stabil.TabIndex = 17;
            // 
            // panel_bilgi
            // 
            this.panel_bilgi.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel_bilgi.Controls.Add(this.lbl_stabil);
            this.panel_bilgi.Controls.Add(this.lbl_negative);
            this.panel_bilgi.Controls.Add(this.lbl_taredeger);
            this.panel_bilgi.Controls.Add(this.lbl_kilodeger);
            this.panel_bilgi.Controls.Add(this.lbl_tare);
            this.panel_bilgi.Controls.Add(this.lbl_kilo);
            this.panel_bilgi.Location = new System.Drawing.Point(368, 209);
            this.panel_bilgi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel_bilgi.Name = "panel_bilgi";
            this.panel_bilgi.Size = new System.Drawing.Size(162, 92);
            this.panel_bilgi.TabIndex = 18;
            // 
            // EthernetConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 427);
            this.Controls.Add(this.panel_bilgi);
            this.Controls.Add(this.lbl_deger);
            this.Controls.Add(this.btn_disconnect);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.tbx_port);
            this.Controls.Add(this.lbl_port);
            this.Controls.Add(this.tbx_moduleip);
            this.Controls.Add(this.lbl_moduleip);
            this.Controls.Add(this.listbox_ethernetCon);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EthernetConnection";
            this.Text = "EthernetConnection";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_bilgi.ResumeLayout(false);
            this.panel_bilgi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listbox_ethernetCon;
        private System.Windows.Forms.Label lbl_moduleip;
        private System.Windows.Forms.TextBox tbx_moduleip;
        private System.Windows.Forms.Label lbl_port;
        private System.Windows.Forms.TextBox tbx_port;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tCPClientToolStripMenuItem;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.Label lbl_deger;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_kilo;
        private System.Windows.Forms.Label lbl_tare;
        private System.Windows.Forms.Label lbl_kilodeger;
        private System.Windows.Forms.Label lbl_taredeger;
        private System.Windows.Forms.Label lbl_negative;
        private System.Windows.Forms.Label lbl_stabil;
        private System.Windows.Forms.Panel panel_bilgi;
    }
}