import psutil
import time
import datetime
from prettytable import PrettyTable

x = PrettyTable(["名称", "结果"])
x.align = "l"  # 左对齐
x.padding_width = 1  # 列数据左右的空格数量

# 用户信息
for u in psutil.users():
    x.add_row(["当前用户", u.name])
    x.add_row(["IP 地址", u.host])
date = "当前用户: " + str(psutil.users()[0][0]) + '\n'
date2 = "IP 地址: " + str(psutil.users()[0][2]) + '\n\n'

now_time = time.strftime('%Y-%m-%d-%H:%M:%S', time.localtime(time.time()))
start_time = datetime.datetime.fromtimestamp(psutil.boot_time()).strftime("%Y-%m-%d %H: %M: %S")

# CPU信息
cpu_num = psutil.cpu_count(logical=False)
cpu = (str(psutil.cpu_percent(1))) + '%'

# 内存信息
total = str(round(psutil.virtual_memory().total / (1024.0 * 1024.0 * 1024.0), 2)) + 'G'
total_used = str(round(psutil.virtual_memory().used / (1024.0 * 1024.0 * 1024.0), 2)) + 'G'
total_free = str(round(psutil.virtual_memory().free / (1024.0 * 1024.0 * 1024.0), 2)) + 'G'
memory = str(psutil.virtual_memory().percent) + '%'

# 网卡信息
net = psutil.net_io_counters()
bytes_sent = '{0:.2f} Mb'.format(net.bytes_recv / 1024 / 1024)
bytes_rcvd = '{0:.2f} Mb'.format(net.bytes_sent / 1024 / 1024)

x.add_row(["系统当前时间", now_time])
x.add_row(["系统开机时间", start_time])
x.add_row(["CPU信息", ""])
x.add_row(["CPU个数", cpu_num])
x.add_row(["CPU使用率", cpu])
x.add_row(["内存信息", ""])
x.add_row(["内存总量", total])
x.add_row(["内存已使用", total_used])
x.add_row(["剩余内存", total_free])
x.add_row(["内存使用率", memory])
x.add_row(["流量信息", ""])
x.add_row(["网卡发送流量", bytes_sent])
x.add_row(["网卡接收流量", bytes_rcvd])

# 磁盘信息
io = psutil.disk_partitions()
for i in io:
    pan = i[0][0][0] + '盘使用情况'
    o = psutil.disk_usage(i.device)
    disk = str(int(o.total / (1024.0 * 1024.0 * 1024.0))) + "G"
    disk_use = str(int(o.used / (1024.0 * 1024.0 * 1024.0))) + "G"
    disk_free = str(int(o.free / (1024.0 * 1024.0 * 1024.0))) + "G"
    x.add_row([pan, ""])
    x.add_row(['总容量', disk])
    x.add_row(['已用容量', disk_use])
    x.add_row(['可用容量', disk_free])
print( x)