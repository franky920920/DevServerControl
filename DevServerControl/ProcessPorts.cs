using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
// Code from: https://www.cheynewallace.com/get-active-ports-and-associated-process-names-in-c/
namespace DevServerControl
{
    public static class ProcessPorts
    {
        /// <summary>
        /// A list of ProcesesPorts that contain the mapping of processes and the ports that the process uses.
        /// </summary>
        public static List<ProcessPort> ProcessPortMap
        {
            get { return GetNetStatPorts(); }
        }


        /// <summary>
        /// This method distills the output from netstat -a -n -o into a list of ProcessPorts that provide a mapping between
        /// the process (name and id) and the ports that the process is using.
        /// </summary>
        /// <returns></returns>
        private static List<ProcessPort> GetNetStatPorts()
        {
            var processPorts = new List<ProcessPort>();

            try
            {
                using (var proc = new Process())
                {
                    var startInfo = new ProcessStartInfo
                    {
                        FileName = "netstat.exe",
                        Arguments = "-a -n -o",
                        WindowStyle = ProcessWindowStyle.Hidden,
                        UseShellExecute = false,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    };

                    proc.StartInfo = startInfo;
                    proc.Start();

                    var standardOutput = proc.StandardOutput;
                    var standardError = proc.StandardError;

                    var netStatContent = standardOutput.ReadToEnd() + standardError.ReadToEnd();
                    var netStatExitStatus = proc.ExitCode.ToString();

                    if (netStatExitStatus != "0")
                    {
                        Console.WriteLine(@"NetStat command failed. This may require elevated permissions.");
                    }

                    var netStatRows = Regex.Split(netStatContent, "\r\n");

                    foreach (var netStatRow in netStatRows)
                    {
                        var tokens = Regex.Split(netStatRow, "\\s+");
                        if (tokens.Length > 4 && (tokens[1].Equals("UDP") || tokens[1].Equals("TCP")))
                        {
                            var ipAddress = Regex.Replace(tokens[2], @"\[(.*?)\]", "1.1.1.1");
                            try
                            {
                                processPorts.Add(new ProcessPort(
                                    tokens[1] == "UDP"
                                        ? GetProcessName(Convert.ToInt16(tokens[4]))
                                        : GetProcessName(Convert.ToInt16(tokens[5])),
                                    tokens[1] == "UDP" ? Convert.ToInt16(tokens[4]) : Convert.ToInt16(tokens[5]),
                                    ipAddress.Contains("1.1.1.1")
                                        ? $"{tokens[1]}v6"
                                        : String.Format("{0}v4", tokens[1]),
                                    Convert.ToInt32(ipAddress.Split(':')[1])
                                ));
                            }
                            catch
                            {
                                Console.WriteLine(@"Could not convert the following NetStat row to a Process to Port mapping.");
                                Console.WriteLine(netStatRow);
                            }
                        }
                        else
                        {
                            if (netStatRow.Trim().StartsWith("Proto") || netStatRow.Trim().StartsWith("Active") ||
                                string.IsNullOrWhiteSpace(netStatRow)) continue;
                            Console.WriteLine(@"Unrecognized NetStat row to a Process to Port mapping.");
                            Console.WriteLine(netStatRow);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return processPorts;
        }

        /// <summary>
        /// Private method that handles pulling the process name (if one exists) from the process id.
        /// </summary>
        /// <param name="processId"></param>
        /// <returns></returns>
        private static string GetProcessName(int processId)
        {
            var procName = "UNKNOWN";

            try
            {
                procName = Process.GetProcessById(processId).ProcessName;
            }
            catch
            {
                // ignored
            }

            return procName;
        }
    }

    /// <summary>
    /// A mapping for processes to ports and ports to processes that are being used in the system.
    /// </summary>
    public class ProcessPort
    {
        /// <summary>
        /// Internal constructor to initialize the mapping of process to port.
        /// </summary>
        /// <param name="processName">Name of process to be </param>
        /// <param name="processId"></param>
        /// <param name="protocol"></param>
        /// <param name="portNumber"></param>
        internal ProcessPort(string processName, int processId, string protocol, int portNumber)
        {
            ProcessName = processName;
            ProcessId = processId;
            Protocol = protocol;
            PortNumber = portNumber;
        }

        public string ProcessPortDescription => $"{ProcessName} ({Protocol} port {PortNumber} pid {ProcessId})";

        public string ProcessName { get; }

        public int ProcessId { get; }

        public string Protocol { get; }

        public int PortNumber { get; }
    }
}