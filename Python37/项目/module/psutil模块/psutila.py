#!/usr/bin/env python
#coding:utf-8
import psutil
import datetime
import time
# 系统用户
#users_count = len(psutil.users())
#
# >>> for u in psutil.users():
# ...   print(u)
# ...
# suser(name='root', terminal='pts/0', host='61.135.18.162', started=1505483904.0)
# suser(name='root', terminal='pts/5', host='61.135.18.162', started=1505469056.0)
# >>> u.name
# 'root'
# >>> u.terminal
# 'pts/5'
# >>> u.host
# '61.135.18.162'
# >>> u.started
# 1505469056.0
# >>>

#users_list = ",".join([u.name for u in psutil.users()])
#print(u"当前有%s个用户，分别是 %s" % (users_count, users_list))

print('-----------------------------用户信息---------------------------------------')
# 用户信息
for u in psutil.users():
    print("当前登陆用户："+u.name)
    print("IP 地址："+u.host)

print('-----------------------------CPU信息---------------------------------------')
# CPU信息
cpu_num = "物理CPU个数: %s" % psutil.cpu_count(logical=False)
cpu = u"cup使用率: " + (str(psutil.cpu_percent(1))) + '%'
print(cpu_num)
print(cpu)

print('-----------------------------时间信息---------------------------------------')
now_time = u"系统当前时间: " + time.strftime('%Y-%m-%d-%H:%M:%S', time.localtime(time.time()))
start_time = u"系统开机时间: " + datetime.datetime.fromtimestamp(psutil.boot_time()).strftime(
    "%Y-%m-%d %H: %M: %S") + '\n'
print(now_time)
print(start_time)

#网卡，可以得到网卡属性，连接数，当前流量等信息
print('-----------------------------流量信息---------------------------------------')
net = psutil.net_io_counters()
bytes_sent = u"网卡发送流量: " + '{0:.2f} Mb'.format(net.bytes_recv / 1024 / 1024)
bytes_rcvd = u"网卡接收流量: " + '{0:.2f} Mb'.format(net.bytes_sent / 1024 / 1024)
print(bytes_sent)
print(bytes_rcvd)

print('-----------------------------磁盘信息---------------------------------------')
# 磁盘信息
io = psutil.disk_partitions()
for i in io:
    o = psutil.disk_usage(i.device)
    print("总容量：" + str(int(o.total / (1024.0 * 1024.0 * 1024.0))) + "G")
    print("已用容量：" + str(int(o.used / (1024.0 * 1024.0 * 1024.0))) + "G")
    print("可用容量：" + str(int(o.free / (1024.0 * 1024.0 * 1024.0))) + "G")

print('-----------------------------内存信息-------------------------------------')
    # 内存信息
total = u"物理内存: " + str(round(psutil.virtual_memory().total / (1024.0 * 1024.0 * 1024.0), 2)) + 'G'
total_used = u"物理内存已使用: " + str(
    round(psutil.virtual_memory().used / (1024.0 * 1024.0 * 1024.0), 2)) + 'G' + '\n'
total_free = u"剩余物理内存: " + str(round(psutil.virtual_memory().free / (1024.0 * 1024.0 * 1024.0), 2)) + 'G'
memory = u"物理内存使用率: " + str(psutil.virtual_memory().percent) + '%'
print(total)
print(total_used)
print(total_free)
print(memory)

#查看内存信息,剩余内存.free  总共.total
#round()函数方法为返回浮点数x的四舍五入值。


print('-----------------------------进程信息-------------------------------------')
# 查看系统全部进程
for pnum in psutil.pids():
    p = psutil.Process(pnum)
    print(u"进程名 %-20s  内存利用率 %-18s 进程状态 %-10s 创建时间 %-10s " \
    % (p.name(), p.memory_percent(), p.status(), p.create_time()))










