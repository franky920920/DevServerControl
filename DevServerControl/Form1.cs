using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Windows.Forms;

namespace DevServerControl
{
    public partial class Form1 : Form
    {
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private Dictionary<string, string> _serviceStatus = new Dictionary<string, string>();

        // ReSharper disable once MemberCanBePrivate.Global
        public static string WampPath = "C:\\wamp64\\";

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        public List<string> PhpVersions = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Readonly: tbx_log
            tbx_log.ReadOnly = true;
            // Verify wamp installation
            if (!Directory.Exists(WampPath))
            {
                MessageBox.Show(
                    $@"Do not detected the WAMP installation, Config your install path at next window. (current: {WampPath})",
                    @"Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                var wampPathSelector = new FolderBrowserDialog();
                wampPathSelector.ShowDialog();
                WampPath = wampPathSelector.SelectedPath + "\\";
            }
            else
            {
                AppendText(tbx_log, $"Wamp install detected! {WampPath}", 10, Color.DarkGreen, true);
            }

            WindowState = FormWindowState.Normal;

            AppendText(tbx_log, $"Wamp install set to {WampPath}", 10, Color.DarkGreen, true);

            //Fetch installed php versions
            AppendText(tbx_log, "Detected PHP versions:", 10, Color.Black, false);
            foreach (var phpVersionPath in Directory.GetDirectories(WampPath + "bin\\php"))
            {
                var version = phpVersionPath
                    .Split('p').Last();
                PhpVersions.Add(version);
                AppendText(tbx_log, version, 10, Color.Black, false);
            }

            //Print fetched php versions to buttons
            var phpVersionButtons = new Dictionary<string, Button>();
            var phpVersionsDictionary = PhpVersions.Select(
                (s, i) => new {s, i}
            ).ToDictionary(
                x => x.i,
                x => x.s
            );
            foreach (var version in phpVersionsDictionary)
            {
                phpVersionButtons[version.Value] = new Button
                {
                    Location = new Point(69 + 87 * version.Key, 47),
                    Size = new Size(81, 27),
                    Text = version.Value,
                    Name = "switchPhpVersion_" + version.Value,
                    Font = new Font("Arial", 9),
                };
                phpVersionButtons[version.Value].Click += (o, args) => { SwitchPhpVersion(version.Value); };
                Controls.Add(phpVersionButtons[version.Value]);
            }

            //Get apache status
            RefreshServiceStatus("apache");
            btn_apache_toggle.Text = _serviceStatus["apache"] == "running" ? "stop" : "start";
            AppendText(tbx_log, $"Apache2 is {_serviceStatus["apache"]}", 10, Color.Brown, true);

            //Hide tray icon
            notifyIcon1.Visible = false;
        }

        private void chk_port_80_Click(object sender, EventArgs e)
        {
            check_port(80);
        }

        private void chk_port_443_Click(object sender, EventArgs e)
        {
            check_port(443);
        }

        private void btn_apache_toggle_Click(object sender, EventArgs e)
        {
            RefreshServiceStatus("apache");
            if (_serviceStatus["apache"] == "running")
            {
                apache_stop();
            }
            else
            {
                apache_start();
            }

            RefreshServiceStatus("apache");
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static void AppendText(RichTextBox textBox, string str, int fontSize, Color fontColor, bool bold)
        {
            textBox.SelectionColor = Color.LightGray;
            textBox.SelectionFont =
                new Font("Arial", fontSize, FontStyle.Regular);
            textBox.AppendText(DateTime.Now.ToString("HH:mm:ss tt \t"));
            textBox.SelectionColor = fontColor;
            textBox.SelectionFont =
                new Font("Arial", fontSize, bold ? FontStyle.Bold : FontStyle.Regular);
            textBox.AppendText(str + "\r\n");

            // scroll it automatically
            textBox.SelectionStart = textBox.Text.Length;
            textBox.ScrollToCaret();
        }

        private static void check_port(int port)
        {
            var ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            var ipEndPoints = ipProperties.GetActiveTcpListeners();

            if (ipEndPoints.Any(endPoint => endPoint.Port == port))
            {
                get_port_used_by(port);
                //used
                AppendText(tbx_log, $"Port {port} in use!", 10, Color.DarkRed, true);
                AppendText(tbx_log, $"Port {port} is used by {_processPid}", 10, Color.DarkRed, true);
                var killTask = MessageBox.Show(
                    // ReSharper disable once LocalizableElement
                    $"Port {port} is used by {_processName} (PID: {_processPid})\r\nDo you want to kill this process?",
                    @"Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (killTask != DialogResult.Yes) return;
                try
                {
                    using (var process = new Process())
                    {
                        process.StartInfo = new ProcessStartInfo
                        {
                            FileName = "taskkill",
                            CreateNoWindow = true,
                            WindowStyle = ProcessWindowStyle.Hidden,
                            Arguments = "/F /PID \"" + _processPid + "\""
                        };
                        process.Start();
                        process.WaitForExit(60000);
                        AppendText(tbx_log, $"{_processPid} killed!", 10, Color.LightGreen, true);
                    }
                }
                catch (Exception e)
                {
                    AppendText(tbx_log, $"Failed to kill task {_processPid}", 10, Color.DarkRed, true);
                    AppendText(tbx_log, e.ToString(), 10, Color.DarkRed, false);
                }
            }
            else
            {
                //free
                AppendText(tbx_log, $"Port {port} is free!", 10, Color.Black, false);
            }
        }

        private void RefreshServiceStatus(string service)
        {
            ServiceController sc;
            switch (service)
            {
                case "apache":
                    sc = new ServiceController("wampapache64");
                    break;
                default:
                    return;
            }

            switch (sc.Status)
            {
                case ServiceControllerStatus.Running:
                    _serviceStatus[service] = "running";
                    break;
                case ServiceControllerStatus.Stopped:
                    _serviceStatus[service] = "stopped";
                    break;
                case ServiceControllerStatus.Paused:
                    _serviceStatus[service] = "paused";
                    break;
                case ServiceControllerStatus.StartPending:
                    _serviceStatus[service] = "startPending";
                    break;
                case ServiceControllerStatus.StopPending:
                    _serviceStatus[service] = "stopPending";
                    break;
                case ServiceControllerStatus.ContinuePending:
                    _serviceStatus[service] = "continuePending";
                    break;
                case ServiceControllerStatus.PausePending:
                    _serviceStatus[service] = "pausePending";
                    break;
                default:
                    _serviceStatus[service] = "changing";
                    break;
            }
        }

        private void SwitchPhpVersion(string version)
        {
            AppendText(tbx_log, $"Switching to PHP {version}...", 10, Color.Black, false);
            var cmd = new Process
            {
                StartInfo =
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd",
                    Arguments =
                        $"/C {WampPath}bin\\php\\php{PhpVersions[0]}\\php.exe {WampPath}scripts\\switchPhpVersion.php {version}"
                }
            };
            cmd.Start();
            cmd.WaitForExit();
            apache_restart();
        }

        private void apache_restart()
        {
            if (_serviceStatus["apache"] == "running")
            {
                apache_stop();
            }

            apache_start();
        }

        private void apache_stop()
        {
            var apacheSc = new ServiceController("wampapache64");
            if (apacheSc.Status != ServiceControllerStatus.Stopped)
            {
                AppendText(tbx_log, "Stopping apache service...", 10, Color.Gray, false);
                apacheSc.Stop();
                apacheSc.WaitForStatus(ServiceControllerStatus.Stopped);
                AppendText(tbx_log, "Service apache stopped", 10, Color.Black, false);
                btn_apache_toggle.Text = @"start";
            }
            else
            {
                AppendText(tbx_log, "Service apache is already stopped!", 10, Color.DarkRed, false);
            }

            RefreshServiceStatus("apache");
        }

        private void apache_start()
        {
            var apacheSc = new ServiceController("wampapache64");
            if (apacheSc.Status != ServiceControllerStatus.Running)
            {
                AppendText(tbx_log, "Starting apache service...", 10, Color.Gray, false);
                apacheSc.Start();
                apacheSc.WaitForStatus(ServiceControllerStatus.Running);
                AppendText(tbx_log, "Service apache started", 10, Color.Black, false);
                btn_apache_toggle.Text = @"stop";
            }
            else
            {
                AppendText(tbx_log, "Service apache is already running!", 10, Color.DarkRed, false);
            }

            RefreshServiceStatus("apache");
        }

        private void btn_apache_restart_Click(object sender, EventArgs e)
        {
            apache_restart();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized) return;
            Hide();
            notifyIcon1.Visible = true;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        //@return PID of process
        private static string _processPid;
        private static string _processName;

        private static void get_port_used_by(int port)
        {
            foreach (var p in ProcessPorts.ProcessPortMap.FindAll(x => x.PortNumber == port))
            {
                _processName = p.ProcessPortDescription
                    .Split(' ')[0];
                _processPid = p.ProcessPortDescription
                    .Split(' ')[5]
                    .Split(')')[0];
                return;
            }

            _processName = string.Empty;
            _processPid = string.Empty;
        }
    }
}