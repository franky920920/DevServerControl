using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace DevServerControl
{
    public static class Php
    {
        public static List<string> Versions = new List<string>();

        public static void SwitchVersion(string version)
        {
            Form1.AppendText(Form1.tbx_log, $"Switching to PHP {version}...", 10, Color.Black, false);
            var cmd = new Process
            {
                StartInfo =
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd",
                    Arguments =
                        $"/C {Form1.WampPath}bin\\php\\php{Versions[0]}\\php.exe {Form1.WampPath}scripts\\switchPhpVersion.php {version}"
                }
            };
            cmd.Start();
            cmd.WaitForExit();
            Apache.Restart();
        }
    }
}