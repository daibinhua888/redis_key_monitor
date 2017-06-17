using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redis_key_monitor
{
    class Config
    {
        public string ApplicationTitle { get; set; } = "redis key监听器";

        public bool DisplayDataOnConsole { get; set; } = true;

        public string RedisCliPath { get; set; } = "redis-cli.exe";

        public string MonitorLogPath { get; set; } = "log.txt";

        public List<string> KeysToMonitor { get; set; } = new List<string>();

        public List<RedisInfo> Redis { get; set; } = new List<RedisInfo>() {
            new RedisInfo(){  Address="localhost"}
        };
    }
}
