using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redis_key_monitor
{
    class ProcessFactory
    {
        public static List<Process> GenerateProcess(Config config)
        {
            if (config.Redis == null || config.Redis.Count == 0)
                throw new Exception("没有定义redis信息");

            List<Process> processes = new List<Process>();

            foreach (var rInfo in config.Redis)
            {
                string argument = "";
                if (string.IsNullOrEmpty(rInfo.Auth))
                    argument = string.Format(@" -h {0} -p {1} monitor", rInfo.Address, rInfo.Port);
                else
                    argument = string.Format(@" -h {0} -a {1} -p {2} monitor", rInfo.Address, rInfo.Auth, rInfo.Port);

                Process myprocess = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo(config.RedisCliPath, argument);
                myprocess.StartInfo = startInfo;

                myprocess.StartInfo.UseShellExecute = false;
                myprocess.StartInfo.CreateNoWindow = true;
                myprocess.StartInfo.RedirectStandardOutput = true;

                myprocess.OutputDataReceived += Myprocess_OutputDataReceived;
                processes.Add(myprocess);
            }

            return processes;
        }

        private static object @lock = new object();
        private static void Myprocess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            try
            {
                var hint = false;
                if (e.Data != null)
                {
                    if (Program.config.KeysToMonitor.Count == 0)
                    {
                        hint = true;
                    }
                    else
                    {
                        Program.config.KeysToMonitor.ForEach((key) =>
                        {
                            if (IsKeyMatch(key, e.Data))
                                hint = true;
                        });
                    }
                }

                if (hint)
                {
                    Console.WriteLine("DATA CAPTURED");

                    var now = DateTime.Now;
                    string line = string.Format("[{0}] {1}", now, e.Data);

                    lock (@lock)
                    {
                        File.AppendAllText(Program.config.MonitorLogPath, line + "\r\n");
                    }

                    if (Program.config.DisplayDataOnConsole)
                        Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static bool IsKeyMatch(string key, string data)
        {
            var startIndex = data.IndexOf("\" \"");

            if (startIndex == -1)
                return false;

            var remainString = data.Substring(startIndex + 3);

            if (string.IsNullOrEmpty(remainString))
                return false;

            if (remainString.Length < key.Length)
                return false;

            if (remainString.Substring(0, key.Length + 1) == key + "\"")
                return true;

            return false;
        }



        public static void KillProcess(List<Process> processes)
        {
            processes.ForEach((p) =>
            {
                try
                {
                    p.Kill();
                }
                catch
                {
                }
            });
        }

        public static void StartProcessAndMonitor(List<Process> processes)
        {
            processes.ForEach((p) =>
            {
                p.Start();

                p.BeginOutputReadLine();
            });
        }
    }
}
