using System.Windows.Forms;

namespace DevServerControl
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chk_port_80 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_port_443 = new System.Windows.Forms.Button();
            this.lbl_apache = new System.Windows.Forms.Label();
            Form1.btn_apache_toggle = new System.Windows.Forms.Button();
            this.btn_apache_restart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            Form1.tbx_log = new System.Windows.Forms.RichTextBox();
            this.btn_apache_vhost = new System.Windows.Forms.Button();
            this.btn_hosts = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_dynamodb_toggle = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chk_port_80
            // 
            this.chk_port_80.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.chk_port_80.Location = new System.Drawing.Point(69, 103);
            this.chk_port_80.Name = "chk_port_80";
            this.chk_port_80.Size = new System.Drawing.Size(47, 27);
            this.chk_port_80.TabIndex = 1;
            this.chk_port_80.Text = "80";
            this.chk_port_80.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.label1.Location = new System.Drawing.Point(8, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Check \r\nPort";
            // 
            // chk_port_443
            // 
            this.chk_port_443.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.chk_port_443.Location = new System.Drawing.Point(122, 103);
            this.chk_port_443.Name = "chk_port_443";
            this.chk_port_443.Size = new System.Drawing.Size(47, 27);
            this.chk_port_443.TabIndex = 3;
            this.chk_port_443.Text = "443";
            this.chk_port_443.UseVisualStyleBackColor = true;
            // 
            // lbl_apache
            // 
            this.lbl_apache.AutoSize = true;
            this.lbl_apache.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.lbl_apache.Location = new System.Drawing.Point(8, 12);
            this.lbl_apache.Name = "lbl_apache";
            this.lbl_apache.Size = new System.Drawing.Size(55, 20);
            this.lbl_apache.TabIndex = 5;
            this.lbl_apache.Text = "Apache";
            // 
            // btn_apache_toggle
            // 
            Form1.btn_apache_toggle.Font = new System.Drawing.Font("Arial Narrow", 12F);
            Form1.btn_apache_toggle.Location = new System.Drawing.Point(69, 9);
            Form1.btn_apache_toggle.Name = "btn_apache_toggle";
            Form1.btn_apache_toggle.Size = new System.Drawing.Size(81, 27);
            Form1.btn_apache_toggle.TabIndex = 6;
            Form1.btn_apache_toggle.Text = "start";
            Form1.btn_apache_toggle.UseVisualStyleBackColor = true;
            // 
            // btn_apache_restart
            // 
            this.btn_apache_restart.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.btn_apache_restart.Location = new System.Drawing.Point(156, 9);
            this.btn_apache_restart.Name = "btn_apache_restart";
            this.btn_apache_restart.Size = new System.Drawing.Size(81, 27);
            this.btn_apache_restart.TabIndex = 7;
            this.btn_apache_restart.Text = "restart";
            this.btn_apache_restart.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "PHP";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "DevServerControl";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // btn_apache_vhost
            // 
            this.btn_apache_vhost.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.btn_apache_vhost.Location = new System.Drawing.Point(243, 9);
            this.btn_apache_vhost.Name = "btn_apache_vhost";
            this.btn_apache_vhost.Size = new System.Drawing.Size(81, 27);
            this.btn_apache_vhost.TabIndex = 10;
            this.btn_apache_vhost.Text = "vhost";
            this.btn_apache_vhost.UseVisualStyleBackColor = true;
            this.btn_apache_vhost.Click += new System.EventHandler(this.btn_apache_vhost_Click);
            // 
            // btn_hosts
            // 
            this.btn_hosts.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.btn_hosts.Location = new System.Drawing.Point(243, 103);
            this.btn_hosts.Name = "btn_hosts";
            this.btn_hosts.Size = new System.Drawing.Size(81, 27);
            this.btn_hosts.TabIndex = 12;
            this.btn_hosts.Text = "hosts";
            this.btn_hosts.UseVisualStyleBackColor = true;
            this.btn_hosts.Click += new System.EventHandler(this.btn_hosts_Click);
            // 
            // tbx_log
            // 
            Form1.tbx_log.Location = new System.Drawing.Point(12, 179);
            Form1.tbx_log.Name = "tbx_log";
            Form1.tbx_log.Size = new System.Drawing.Size(555, 227);
            Form1.tbx_log.TabIndex = 9;
            Form1.tbx_log.Text = "";
            //
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.label3.Location = new System.Drawing.Point(8, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "DynamoDB";
            // 
            // btn_dynamodb_toggle
            // 
            this.btn_dynamodb_toggle.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.btn_dynamodb_toggle.Location = new System.Drawing.Point(122, 142);
            this.btn_dynamodb_toggle.Name = "btn_dynamodb_toggle";
            this.btn_dynamodb_toggle.Size = new System.Drawing.Size(81, 27);
            this.btn_dynamodb_toggle.TabIndex = 14;
            this.btn_dynamodb_toggle.Text = "start";
            this.btn_dynamodb_toggle.UseVisualStyleBackColor = true;
            this.btn_dynamodb_toggle.Click += new System.EventHandler(this.btn_dynamodb_toggle_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.label4.Location = new System.Drawing.Point(455, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Version: 2.1.1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 418);
            this.Controls.Add(Form1.tbx_log);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_dynamodb_toggle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_hosts);
            this.Controls.Add(this.btn_apache_vhost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_apache_restart);
            this.Controls.Add(Form1.btn_apache_toggle);
            this.Controls.Add(this.lbl_apache);
            this.Controls.Add(this.chk_port_443);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chk_port_80);
            this.Name = "Form1";
            this.Text = "DevServerControl";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Button btn_dynamodb_toggle;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Button btn_hosts;
        
        private System.Windows.Forms.Button btn_apache_vhost;

        #endregion
        private System.Windows.Forms.Button chk_port_80;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button chk_port_443;
        private System.Windows.Forms.Label lbl_apache;
        public static System.Windows.Forms.Button btn_apache_toggle;
        private System.Windows.Forms.Button btn_apache_restart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        public static System.Windows.Forms.RichTextBox tbx_log;
    }
}

