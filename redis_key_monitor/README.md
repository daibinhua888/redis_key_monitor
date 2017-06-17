# redis_key_monitor
本工具用于监控redis的某个key的操作，比如监控针对某个key的SET/GET命令


配置文件共2个：config.txt和config-key.txt
#config.txt:
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

NOTE: 最主要的就是Redis这个节点，是个List，存放需要监控的redis连接信息（分片下通常有多台redis）



#config-key.txt：

key1
key2
这个文件存放的是所有想监控的key，一行一个key


