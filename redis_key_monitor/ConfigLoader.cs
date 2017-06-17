using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redis_key_monitor
{
    class ConfigLoader
    {
        public static Config Load()
        {
            var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt");
            var keyConfigFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config-key.txt");
            return Load(configFile, keyConfigFile);
        }

        private static Config Load(string configPath, string keysConfigPath)
        {
            if (!File.Exists(configPath))
            {
                var cfg = new Config();
                var defaultJson=Utils.ObjectToJson(cfg);
                File.WriteAllText(configPath, defaultJson);
            }

            if (!File.Exists(keysConfigPath))
            {
                File.WriteAllText(keysConfigPath, "");
            }

            var json=File.ReadAllText(configPath);

            var cfg2= Utils.JsonToObject(json);

            foreach (var key in File.ReadLines(keysConfigPath))
            {
                cfg2.KeysToMonitor.Add(key);
            }
            

            return cfg2;
        }
    }
}
