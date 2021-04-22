using System.ComponentModel;

namespace DevServerControl
{
    partial class VirtualHost
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.lbl_apache = new System.Windows.Forms.Label();
            this.tbx_fqdn = new System.Windows.Forms.TextBox();
            this.tbx_srv_root = new System.Windows.Forms.TextBox();
            this.btn_serverroot_browse = new System.Windows.Forms.Button();
            this.lbl_srv_root = new System.Windows.Forms.Label();
            this.listBox_hosts = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_ssl_cert = new System.Windows.Forms.TextBox();
            this.btn_ssl_cert_browse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_ssl_key = new System.Windows.Forms.TextBox();
            this.btn_ssl_key_browse = new System.Windows.Forms.Button();
            this.btn_add_vhost = new System.Windows.Forms.Button();
            this.btn_save_vhost = new System.Windows.Forms.Button();
            this.btn_delete_vhost = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_apache
            // 
            this.lbl_apache.AutoSize = true;
            this.lbl_apache.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.lbl_apache.Location = new System.Drawing.Point(17, 175);
            this.lbl_apache.Name = "lbl_apache";
            this.lbl_apache.Size = new System.Drawing.Size(69, 20);
            this.lbl_apache.TabIndex = 6;
            this.lbl_apache.Text = "Hostname";
            // 
            // tbx_fqdn
            // 
            this.tbx_fqdn.Location = new System.Drawing.Point(113, 173);
            this.tbx_fqdn.Name = "tbx_fqdn";
            this.tbx_fqdn.Size = new System.Drawing.Size(242, 22);
            this.tbx_fqdn.TabIndex = 7;
            // 
            // tbx_srv_root
            // 
            this.tbx_srv_root.Location = new System.Drawing.Point(113, 208);
            this.tbx_srv_root.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tbx_srv_root.Name = "tbx_srv_root";
            this.tbx_srv_root.Size = new System.Drawing.Size(213, 22);
            this.tbx_srv_root.TabIndex = 9;
            // 
            // btn_serverroot_browse
            // 
            this.btn_serverroot_browse.Location = new System.Drawing.Point(326, 207);
            this.btn_serverroot_browse.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btn_serverroot_browse.Name = "btn_serverroot_browse";
            this.btn_serverroot_browse.Size = new System.Drawing.Size(31, 23);
            this.btn_serverroot_browse.TabIndex = 10;
            this.btn_serverroot_browse.Text = "...";
            this.btn_serverroot_browse.UseVisualStyleBackColor = true;
            this.btn_serverroot_browse.Click += new System.EventHandler(this.btn_serverroot_browse_Click);
            // 
            // lbl_srv_root
            // 
            this.lbl_srv_root.AutoSize = true;
            this.lbl_srv_root.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.lbl_srv_root.Location = new System.Drawing.Point(17, 210);
            this.lbl_srv_root.Name = "lbl_srv_root";
            this.lbl_srv_root.Size = new System.Drawing.Size(76, 20);
            this.lbl_srv_root.TabIndex = 11;
            this.lbl_srv_root.Text = "Server root";
            // 
            // listBox_hosts
            // 
            this.listBox_hosts.FormattingEnabled = true;
            this.listBox_hosts.ItemHeight = 12;
            this.listBox_hosts.Location = new System.Drawing.Point(12, 12);
            this.listBox_hosts.Name = "listBox_hosts";
            this.listBox_hosts.Size = new System.Drawing.Size(343, 148);
            this.listBox_hosts.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.label1.Location = new System.Drawing.Point(17, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "SSL cert.";
            // 
            // tbx_ssl_cert
            // 
            this.tbx_ssl_cert.Location = new System.Drawing.Point(113, 244);
            this.tbx_ssl_cert.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tbx_ssl_cert.Name = "tbx_ssl_cert";
            this.tbx_ssl_cert.Size = new System.Drawing.Size(213, 22);
            this.tbx_ssl_cert.TabIndex = 14;
            // 
            // btn_ssl_cert_browse
            // 
            this.btn_ssl_cert_browse.Location = new System.Drawing.Point(326, 244);
            this.btn_ssl_cert_browse.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btn_ssl_cert_browse.Name = "btn_ssl_cert_browse";
            this.btn_ssl_cert_browse.Size = new System.Drawing.Size(31, 23);
            this.btn_ssl_cert_browse.TabIndex = 15;
            this.btn_ssl_cert_browse.Text = "...";
            this.btn_ssl_cert_browse.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.label2.Location = new System.Drawing.Point(17, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "SSL key";
            // 
            // tbx_ssl_key
            // 
            this.tbx_ssl_key.Location = new System.Drawing.Point(113, 278);
            this.tbx_ssl_key.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tbx_ssl_key.Name = "tbx_ssl_key";
            this.tbx_ssl_key.Size = new System.Drawing.Size(213, 22);
            this.tbx_ssl_key.TabIndex = 17;
            // 
            // btn_ssl_key_browse
            // 
            this.btn_ssl_key_browse.Location = new System.Drawing.Point(326, 278);
            this.btn_ssl_key_browse.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btn_ssl_key_browse.Name = "btn_ssl_key_browse";
            this.btn_ssl_key_browse.Size = new System.Drawing.Size(31, 23);
            this.btn_ssl_key_browse.TabIndex = 18;
            this.btn_ssl_key_browse.Text = "...";
            this.btn_ssl_key_browse.UseVisualStyleBackColor = true;
            // 
            // btn_add_vhost
            // 
            this.btn_add_vhost.Location = new System.Drawing.Point(21, 327);
            this.btn_add_vhost.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btn_add_vhost.Name = "btn_add_vhost";
            this.btn_add_vhost.Size = new System.Drawing.Size(66, 28);
            this.btn_add_vhost.TabIndex = 19;
            this.btn_add_vhost.Text = "Add";
            this.btn_add_vhost.UseVisualStyleBackColor = true;
            this.btn_add_vhost.Click += new System.EventHandler(this.btn_add_vhost_Click);
            // 
            // btn_save_vhost
            // 
            this.btn_save_vhost.Location = new System.Drawing.Point(289, 327);
            this.btn_save_vhost.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btn_save_vhost.Name = "btn_save_vhost";
            this.btn_save_vhost.Size = new System.Drawing.Size(66, 28);
            this.btn_save_vhost.TabIndex = 20;
            this.btn_save_vhost.Text = "Save";
            this.btn_save_vhost.UseVisualStyleBackColor = true;
            this.btn_save_vhost.Click += new System.EventHandler(this.btn_save_vhost_Click);
            // 
            // btn_delete_vhost
            // 
            this.btn_delete_vhost.Location = new System.Drawing.Point(93, 327);
            this.btn_delete_vhost.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btn_delete_vhost.Name = "btn_delete_vhost";
            this.btn_delete_vhost.Size = new System.Drawing.Size(66, 28);
            this.btn_delete_vhost.TabIndex = 21;
            this.btn_delete_vhost.Text = "Delete";
            this.btn_delete_vhost.UseVisualStyleBackColor = true;
            this.btn_delete_vhost.Click += new System.EventHandler(this.btn_delete_vhost_Click);
            // 
            // VirtualHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 376);
            this.Controls.Add(this.btn_delete_vhost);
            this.Controls.Add(this.btn_save_vhost);
            this.Controls.Add(this.btn_add_vhost);
            this.Controls.Add(this.btn_ssl_key_browse);
            this.Controls.Add(this.tbx_ssl_key);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_ssl_cert_browse);
            this.Controls.Add(this.tbx_ssl_cert);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_hosts);
            this.Controls.Add(this.lbl_srv_root);
            this.Controls.Add(this.btn_serverroot_browse);
            this.Controls.Add(this.tbx_srv_root);
            this.Controls.Add(this.tbx_fqdn);
            this.Controls.Add(this.lbl_apache);
            this.Name = "VirtualHost";
            this.Text = "VirtualHost";
            this.Load += new System.EventHandler(this.VirtualHost_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btn_delete_vhost;

        private System.Windows.Forms.Label lbl_srv_root;

        private System.Windows.Forms.TextBox tbx_fqdn;

        private System.Windows.Forms.Button btn_serverroot_browse;
        private System.Windows.Forms.TextBox tbx_srv_root;

        private System.Windows.Forms.Label lbl_apache;

        #endregion

        private System.Windows.Forms.ListBox listBox_hosts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_ssl_cert;
        private System.Windows.Forms.Button btn_ssl_cert_browse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_ssl_key;
        private System.Windows.Forms.Button btn_ssl_key_browse;
        private System.Windows.Forms.Button btn_add_vhost;
        private System.Windows.Forms.Button btn_save_vhost;
    }
}