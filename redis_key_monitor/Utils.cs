using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace redis_key_monitor
{
    class Utils
    {
        // 序列化
        public static string ObjectToJson(Config obj)
        {
            JavaScriptSerializer jsonSerialize = new JavaScriptSerializer();
            return jsonSerialize.Serialize(obj);
        }
        // 反序列化
        public static Config JsonToObject(string jsonStr)
        {
            JavaScriptSerializer jsonSerialize = new JavaScriptSerializer();
            return jsonSerialize.Deserialize<Config>(jsonStr);
        }
    }
}
