# redis key监控
本工具用于监控redis的某个key的操作，比如监控针对某个key的SET/GET命令，保存到日志文件中，里面有具体的时间、客户端IP，以及相应的命令<br>

<br><br>
##配置文件共2个：config.txt和config-key.txt<br>
###config.txt:
{
    "ApplicationTitle":"redis key监听器",
	"DisplayDataOnConsole":true,
	"RedisCliPath":"redis-cli.exe",
	"MonitorLogPath":"log.txt",
	"KeysToMonitor":[],
	"Redis":[
				{"Address":"localhost","Port":6379,"Auth":null}
			]
}
<br>
NOTE: 最主要的就是Redis这个节点，是个List，存放需要监控的redis连接信息（分片下通常有多台redis）<br>


<br><br><br>
###config-key.txt：

key1<br>
key2<br>
这个文件存放的是所有想监控的key，一行一个key
<br><br><br>

##关于作者

卡行天下一资深码候
