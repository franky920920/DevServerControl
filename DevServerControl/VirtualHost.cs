using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DevServerControl
{
    public partial class VirtualHost : Form
    {
        public VirtualHost()
        {
            InitializeComponent();
        }

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        public Dictionary<string, Dictionary<string, string>> VhostConfig =
            new Dictionary<string, Dictionary<string, string>>();

        private void VirtualHost_Load(object sender, EventArgs e)
        {
            //Read vhost config
            //TODO: support multiple apache versions. 
            var configReader = new StreamReader(
                Form1.WampPath +
                $"bin\\apache\\apache{Form1.ApacheVersions[0]}\\conf\\extra\\httpd-vhosts.conf"
            );
            var configContent = configReader.ReadToEnd();
            configReader.Close();

            //Process <VirtualHost></VirtualHost> blocks
            var vhostRegex = new Regex("<VirtualHost[^<]*(?:<(?!/VirtualHost)[^<]*)*.*?</VirtualHost>");
            foreach (Match vhost in vhostRegex.Matches(configContent))
            {
                //Get servername
                var servernameRegex = new Regex("ServerName (.*)");
                var servername = servernameRegex
                    .Match(vhost.Value)
                    .Groups[1]
                    .ToString()
                    .Trim();
                //Skipping default host TODO:bug fix
                if (servername == "localhost") continue;

                //Get server port
                var serverPortRegex = new Regex("<VirtualHost \\*:(.*)>");
                var serverPort = serverPortRegex
                    .Match(vhost.Value)
                    .Groups[1]
                    .ToString();

                //Get DocumentRoot
                var documentrootRegex = new Regex("DocumentRoot.*\"(.*?)\"");

                VhostConfig[servername] = new Dictionary<string, string>()
                {
                    {
                        "ServerPort",
                        serverPort
                    },
                    {
                        "DocumentRoot",
                        documentrootRegex
                            .Match(vhost.Value)
                            .Groups[1]
                            .ToString()
                    }
                };

                //Append it to listbox
                listBox_hosts.Items.Add(servername + ":" + serverPort);
            }

            //Add listbox double click event
            listBox_hosts.DoubleClick += (o, args) =>
            {
                if (listBox_hosts.SelectedItem != null)
                {
                    Form1.AppendText(Form1.tbx_log, listBox_hosts.SelectedItem.ToString(), 10, Color.Black, false);
                    var selectedVhost = listBox_hosts
                        .SelectedItem
                        .ToString()
                        .Split(':')[0];
                    Form1.AppendText(Form1.tbx_log, selectedVhost, 10, Color.Black, false);
                    tbx_fqdn.Text = selectedVhost;
                    tbx_srv_root.Text = VhostConfig[selectedVhost]["DocumentRoot"];
                    
                    if (VhostConfig[selectedVhost]["ServerPort"] == "443")
                    {
                    }
                    else
                    {
                        tbx_ssl_cert.ReadOnly = true;
                        tbx_ssl_key.ReadOnly = true;
                        btn_ssl_cert_browse.Enabled = false;
                        btn_ssl_key_browse.Enabled = false;
                    }
                }
            };
        }

        private void btn_serverroot_browse_Click(object sender, EventArgs e)
        {
            var serverRootPathSelector = new FolderBrowserDialog();
            //Set dialog path to current value
            tbx_srv_root.Text = tbx_srv_root.Text.Replace('/', '\\');
            if (Directory.Exists(tbx_srv_root.Text))
            {
                serverRootPathSelector.SelectedPath = tbx_srv_root.Text;
            }

            //Show dialog
            serverRootPathSelector.ShowDialog();
            tbx_srv_root.Text = serverRootPathSelector.SelectedPath;
            //Apache config reader only recognize / but not \, replacing it.
            VhostConfig[listBox_hosts.SelectedItem.ToString().Split(':')[0]]["DocumentRoot"] =
                serverRootPathSelector.SelectedPath.Replace('\\', '/');
        }

        private void btn_save_vhost_Click(object sender, EventArgs e)
        {
            //Save current vhost config to dictionary 
            var selectedHost = listBox_hosts.SelectedItem.ToString().Split(':')[0];
            if (selectedHost == tbx_fqdn.Text)
            {
                VhostConfig[selectedHost]["DocumentRoot"] = tbx_srv_root.Text;
            }
            else
            {
                Form1.AppendText(Form1.tbx_log, tbx_fqdn.Text, 10, Color.Black, false);
                Form1.AppendText(Form1.tbx_log, tbx_srv_root.Text, 10, Color.Black, false);
                listBox_hosts.Items.Remove(listBox_hosts.SelectedItem);
                listBox_hosts.Items.Add(tbx_fqdn.Text + ":80");
                VhostConfig.Remove(selectedHost);
                if (!VhostConfig.ContainsKey(tbx_fqdn.Text))
                {
                    VhostConfig[tbx_fqdn.Text] = new Dictionary<string, string>()
                    {
                        {"DocumentRoot", ""},
                        {"ServerPort", ""}
                    };
                }
                VhostConfig[tbx_fqdn.Text]["DocumentRoot"] = tbx_srv_root.Text;
            }

            //Write config back to file and restart apache
            var config = "";
            config += @"<VirtualHost *:80>
    ServerName localhost
    ServerAlias localhost
    DocumentRoot ""${INSTALL_DIR}/www""
    <Directory ""${INSTALL_DIR}/www/"">
        Options +Indexes +Includes +FollowSymLinks +MultiViews
        AllowOverride All
        Require local
    </Directory>
</VirtualHost>" + "\r\n";
            foreach (var conf in VhostConfig)
            {
                config += $@"<VirtualHost *:80>
	ServerName {conf.Key}
	DocumentRoot ""{conf.Value["DocumentRoot"].Replace('\\', '/')}""
	<Directory  ""{conf.Value["DocumentRoot"].Replace('\\', '/')}/"">
        Options +Indexes +Includes +FollowSymLinks +MultiViews
        AllowOverride All
        Require local
    </Directory>
</VirtualHost>" + "\r\n";
            }

            try
            {
                File.WriteAllText(
                    Form1.WampPath + $"bin\\apache\\apache{Form1.ApacheVersions[0]}\\conf\\extra\\httpd-vhosts.conf",
                    config
                );
                Form1.AppendText(Form1.tbx_log, "Vhost configuration written", 10, Color.Black, false);
            }
            catch (Exception exception)
            {
                Form1.AppendText(Form1.tbx_log, $"Failed to write vhost config file. {exception}", 10, Color.Red,
                    false);
                MessageBox.Show(
                    @"Failed to write vhost config file!",
                    @"Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            //Restarting Apache
            Apache.Restart();
        }

        private void btn_delete_vhost_Click(object sender, EventArgs e)
        {
            VhostConfig.Remove(listBox_hosts.SelectedItem.ToString().Split(':')[0]);
            listBox_hosts.Items.Remove(listBox_hosts.SelectedItem);
        }

        private void btn_add_vhost_Click(object sender, EventArgs e)
        {
            listBox_hosts.Items.Add("<New vhost>");
            listBox_hosts.SelectedItem = "<New vhost>";
            tbx_fqdn.Text = @"<New vhost>";
            tbx_srv_root.Text = string.Empty;
            VhostConfig["<New vhost>"] = new Dictionary<string, string>();
        }
    }
}