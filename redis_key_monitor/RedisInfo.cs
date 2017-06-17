using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redis_key_monitor
{
    class RedisInfo
    {
        public RedisInfo()
        {
            Port = 6379;
            Auth = null;
        }

        public string Address { get; set; }

        public int Port { get; set; }

        public string Auth { get; set; }
    }
}
