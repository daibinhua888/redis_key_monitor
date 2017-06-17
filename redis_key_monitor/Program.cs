using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redis_key_monitor
{
    class Program
    {
        public static Config config;

        static void Main(string[] args)
        {
            config = ConfigLoader.Load();

            Console.Title = config.ApplicationTitle;

            var processes = ProcessFactory.GenerateProcess(config);

            ProcessFactory.StartProcessAndMonitor(processes);

            Console.WriteLine("STARTED");
            Console.ReadKey();

            ProcessFactory.KillProcess(processes);
        }

    }
}
