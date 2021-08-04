using System;
using System.Collections.Generic;
using System.Drawing;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace DevServerControl
{
    public static class Apache
    {
        public static List<string> Versions = new List<string>();
        
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private static ServiceController _sc = new ServiceController("wampapache64");

        public static async Task Start()
        {
            if (_sc.Status != ServiceControllerStatus.Running)
            {
                try
                {
                    Form1.AppendText(Form1.tbx_log, "Starting apache service...", 10, Color.Gray, false);
                    _sc.Start();
                    await _sc.WaitForStatusAsync(ServiceControllerStatus.Running, new TimeSpan(0,0,0,20));
                    Form1.AppendText(Form1.tbx_log, "Service apache started", 10, Color.Black, false);
                    Form1.btn_apache_toggle.Text = @"stop";
                }
                catch (Exception exception)
                {
                    Form1.AppendText(Form1.tbx_log, $"Failed to start apache service: {exception}", 10, Color.DarkRed, true);
                }
            }
            else
            {
                Form1.AppendText(Form1.tbx_log, "Service apache is already running!", 10, Color.DarkRed, false);
            }

            RefreshStatus();
        }

        public static async void Stop(bool restart = false)
        {
            if (_sc.Status != ServiceControllerStatus.Stopped)
            {
                try
                {
                    Form1.AppendText(Form1.tbx_log, "Stopping apache service...", 10, Color.Gray, false);
                    _sc.Stop();
                    await _sc.WaitForStatusAsync(ServiceControllerStatus.Stopped, new TimeSpan(0,0,0,20));
                    Form1.AppendText(Form1.tbx_log, "Service apache stopped", 10, Color.Black, false);
                    Form1.btn_apache_toggle.Text = @"start";
                    if (restart)
                    {
                        await Start();
                    }
                }
                catch (Exception exception)
                {
                    Form1.AppendText(Form1.tbx_log, $"Failed to stop apache service: {exception}", 10, Color.DarkRed, true);
                }
            }
            else
            {
                Form1.AppendText(Form1.tbx_log, "Service apache is already stopped!", 10, Color.DarkRed, false);
            }

            RefreshStatus();
        }

        public static void Restart()
        {
            Stop(true);
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