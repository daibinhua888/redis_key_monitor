# redis_key_monitor
���������ڼ��redis��ĳ��key�Ĳ��������������ĳ��key��SET/GET����


�����ļ���2����config.txt��config-key.txt
#config.txt:
{
	"ApplicationTitle":"redis key������",
	"DisplayDataOnConsole":true,
	"RedisCliPath":"redis-cli.exe",
	"MonitorLogPath":"log.txt",
	"KeysToMonitor":[],
	"Redis":[
				{"Address":"localhost","Port":6379,"Auth":null}
			]
}

NOTE: ����Ҫ�ľ���Redis����ڵ㣬�Ǹ�List�������Ҫ��ص�redis������Ϣ����Ƭ��ͨ���ж�̨redis��



#config-key.txt��

key1
key2
����ļ���ŵ����������ص�key��һ��һ��key


