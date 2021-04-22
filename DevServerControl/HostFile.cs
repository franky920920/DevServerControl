using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DevServerControl
{
    public partial class HostFile : Form
    {
        public HostFile()
        {
            InitializeComponent();
        }

        private string _hostsContent;
        private void HostFile_Load(object sender, EventArgs e)
        {
            //Load hosts file
            var hostsReader = new StreamReader("C:\\Windows\\System32\\drivers\\etc\\hosts");
            _hostsContent = hostsReader.ReadToEnd();
            hostsReader.Close();
            
            //Process with hosts
            foreach (var host in _hostsContent.Split('\n'))
            {
                Form1.AppendText(Form1.tbx_log, host, 10, Color.Black, false);
            }
        }
    }
}