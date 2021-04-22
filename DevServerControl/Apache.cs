using System;
using System.Collections.Generic;
using System.Drawing;
using System.ServiceProcess;

namespace DevServerControl
{
    public static class Apache
    {
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private static ServiceController _sc = new ServiceController("wampapache64");

        public static void Start()
        {
            if (_sc.Status != ServiceControllerStatus.Running)
            {
                Form1.AppendText(Form1.tbx_log, "Starting apache service...", 10, Color.Gray, false);
                _sc.Start();
                _sc.WaitForStatus(ServiceControllerStatus.Running);
                Form1.AppendText(Form1.tbx_log, "Service apache started", 10, Color.Black, false);
                Form1.btn_apache_toggle.Text = @"stop";
            }
            else
            {
                Form1.AppendText(Form1.tbx_log, "Service apache is already running!", 10, Color.DarkRed, false);
            }

            RefreshStatus();
        }

        public static void Stop()
        {
            if (_sc.Status != ServiceControllerStatus.Stopped)
            {
                Form1.AppendText(Form1.tbx_log, "Stopping apache service...", 10, Color.Gray, false);
                _sc.Stop();
                _sc.WaitForStatus(ServiceControllerStatus.Stopped);
                Form1.AppendText(Form1.tbx_log, "Service apache stopped", 10, Color.Black, false);
                Form1.btn_apache_toggle.Text = @"start";
            }
            else
            {
                Form1.AppendText(Form1.tbx_log, "Service apache is already stopped!", 10, Color.DarkRed, false);
            }

            RefreshStatus();
        }

        public static void Restart()
        {
            if (Form1.ServiceStatus["apache"] == "running")
            {
                Stop();
            }

            Start();
        }

        public static void RefreshStatus()
        {
            switch (_sc.Status)
            {
                case ServiceControllerStatus.Running:
                    Form1.ServiceStatus["apache"] = "running";
                    break;
                case ServiceControllerStatus.Stopped:
                    Form1.ServiceStatus["apache"] = "stopped";
                    break;
                case ServiceControllerStatus.Paused:
                    Form1.ServiceStatus["apache"] = "paused";
                    break;
                case ServiceControllerStatus.StartPending:
                    Form1.ServiceStatus["apache"] = "startPending";
                    break;
                case ServiceControllerStatus.StopPending:
                    Form1.ServiceStatus["apache"] = "stopPending";
                    break;
                case ServiceControllerStatus.ContinuePending:
                    Form1.ServiceStatus["apache"] = "continuePending";
                    break;
                case ServiceControllerStatus.PausePending:
                    Form1.ServiceStatus["apache"] = "pausePending";
                    break;
                default:
                    Form1.ServiceStatus["apache"] = "changing";
                    break;
            }
        }
    }
}