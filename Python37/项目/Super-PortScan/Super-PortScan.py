#!/usr/bin/env python
# -*- coding: utf-8 -*-
from socket import *
import threading      #导入线程相关模块
import queue,os
import argparse
from color import *
#得到-d中的ip列表
def get_ip_d_list(ip):
    ip_list=[]
    if '/24' in ip:
        ip = ip.replace('/24','')
        for i in range(1,255):
            ip_list.append(ip[:ip.rfind('.')]+'.'+str(i))
    elif '-' in ip:
        ip_start = ip.split('.')[-1].split('-')[0]
        ip_end = ip.split('.')[-1].split('-')[1]
        if int(ip_start)>int(ip_end):
            numff =ip_start
            ip_start= ip_end
            ip_end = numff
        for i in range(int(ip_start), int(ip_end)+1):
            ip_list.append(ip[:ip.rfind('.')] + '.' + str(i))
    else:
        ip_list = ip.split()
    # 列表去重
    all_list = []
    for i in ip_list:
        if i not in all_list:
            all_list.append(i)
    return list(filter(None, ip_list))  # 去除 none 和 空字符
#得到文件中的ip列表
def get_ip_f_list(file):
    all_list =[]
    if os.path.exists(file):
        try:
            file = open(file,'r',encoding= 'utf-8')
            for line in file:
                all_list =all_list+ get_ip_d_list(line)
            file.close()
            all_list2 = []
            for i in all_list:
                if i not in all_list2:
                    all_list2.append(i)
            return list(filter(None, all_list2))  # 去除 none 和 空字符
        except:
            printRed('Error:文件读取错误！')
    else:
        printRed('Error:文件不存在')
        exit()
#得到端口列表
def get_port_list(port):
    port_list=[]
    if ',' in port:
        port_list = port.split(',')
        for i in port_list:
            if '-' in i :
                port_list.remove(i)
                port_start = i.split('-')[0]
                port_end = i.split('-')[1]
                if int(port_start) > int(port_end):
                    numff = port_start
                    port_start = port_end
                    port_end = numff
                for i in range(int(port_start), int(port_end) + 1):
                    port_list.append(str(i))
    elif '-' in port :
        port_start = port.split('-')[0]
        port_end = port.split('-')[1]
        if int(port_start)>int(port_end):
            numff =port_start
            port_start= port_end
            port_end = numff
        for i in range(int(port_start), int(port_end)+1):
            port_list.append(str(i))
    else:
        port_list = port.split()
    # print(port_list)
    try:
        port_list = list(map(int, port_list))
        all_list = []
        for i in port_list:
            if i not in all_list and int(i) < 65535:
                all_list.append(i)
        # print(port_list)
        return list(filter(None, all_list)) #去除 none 和 空字符
    except:
        printRed("Error:Port is Error!")
        exit()
    # return list(filter(None, port_list)) #去除 none 和 空字符
def portScanner(portQueue,timeout):
    while True:
        if portQueue.empty():  # 队列空就结束
            break
        ip_port = portQueue.get()  # 从队列中取出
        host = ip_port.split(':')[0]
        port = ip_port.split(':')[1]
        # print(host,port)
        try:
            tcp = socket(AF_INET, SOCK_STREAM)
            tcp.settimeout(timeout)  # 如果设置太小，检测不精确，设置太大，检测太慢
            result = tcp.connect_ex((host, int(port)))  # 效率比connect高，成功时返回0，失败时返回错误码
            try:
                server = tcp.recv(1024).decode('utf-8').strip()
            except:
                server = 'unknow'
            if result == 0:
                host =  host.ljust(12, ' ')
                printGreen(('[-] '+'%s\t%s\t')%(host.ljust(15, ' '),port.ljust(6, ' '))+('opened'.ljust(6, ' '))+('\t\t%s') % ( server.ljust(20, ' ')))
            if result != 0 and flag:
                printDarkGray(('[-] '+'%s\t%s\t')%(host.ljust(15, ' '),port.ljust(6, ' '))+('close'.ljust(6, ' '))+('\t\t%s') % ( server.ljust(20, ' ')))
        except:
            pass
            # exit()
        finally:
            tcp.close()
    #创建线程
def createThread(num,portQueue,timeout):
    for i in range(num):
        i= threading.Thread(target=portScanner, args=(portQueue,timeout))
        threads.append(i)
def  scan(ip_list,port_list,threadNum):
    # ip_list=['192.168.1.1','192.168.1.2']
    # port_list = [80, 25, 110]
    portQueue = queue.Queue()  # 待检测端口队列，会在《Python常用操作》一文中更新用法
    for ip in ip_list:
        for i in port_list:
            portQueue.put(ip+':'+str(i))
    createThread(threadNum, portQueue,timeout)
    printYellow('[*] The Scan is Start')
    printSkyBlue('[*] '+'Host'.ljust(15,' ')+'\t'+'Port'.ljust(6,' ')+'\t'+'Status'.ljust(6,' ')+'\t\t'+'Server'.ljust(20,' '))
    for t in threads:#启动线程
        t.start()
    for t in threads:#阻塞线程，等待线程结束
        t.join()
    printYellow('[*] The Scan is complete!')
if __name__ == '__main__':
    printDarkSkyBlue('''
   _____                         _____           _    _____   
  / ____|                       |  __ \         | |  / ____|                
 | (___  _   _ _ __   ___ _ __  | |__) |__  _ __| |_| (___   ___ __ _ _ __  
  \___ \| | | | '_ \ / _ \ '__| |  ___/ _ \| '__| __|\___ \ / __/ _` | '_ \ 
  ____) | |_| | |_) |  __/ |    | |  | (_) | |  | |_ ____) | (_| (_| | | | |
 |_____/ \__,_| .__/ \___|_|    |_|   \___/|_|   \__|_____/ \___\__,_|_| |_|
             | |                                                           
             |_|                                       
                       github: https://github.com/qianxiao996/Super-PortScan''')
    threads = []#线程列表
    flag = 0  # 是否显示过程
    all_port_list = [22, 23,80,110, 443, 445, 1521, 3306,3389, 6379, 7001, 8000, 8001, 8080, 9000,27017]
    parser = argparse.ArgumentParser(usage='\n\tpython3 Super-PortScan.py -i 192.168.1.1 -p 80\n\tpython3 Super-PortScan.py -f ip.txt -p 80')
    group = parser.add_mutually_exclusive_group()
    group.add_argument("-i", "--ip" ,help="输入一个或一段ip，例如：192.168.1.1、192.168.1.1/24、192.168.1.1-99")
    group.add_argument("-f", "--file",help="从文件加载ip列表")
    parser.add_argument("-p", "--port", help="定义扫描的端口，例如:80、80，8080、80-8000")
    parser.add_argument("-ts",help="设置超时时间，默认0.5s")
    parser.add_argument("-v", action="store_true",help="显示所有扫描结果")
    parser.add_argument("-t", "--threads", help="定义扫描的线程，默认为30")
    args = parser.parse_args()
    if args.v:
        flag=1
    if args.ts:
        timeout=int(args.ts)
    else:
        timeout=0.5
    if args.ip:
        if  args.port :
            port_list = get_port_list(args.port)
        if not args.port:
            port_list = all_port_list
        ip_list =  get_ip_d_list(args.ip)
        if args.threads:
            scan(ip_list,port_list,int(args.threads))
        else:
            scan(ip_list,port_list,30)
        # for i in ip_list:
        #     scan(i, port_list, threadNum)
    if args.file:
        if  args.port :
            port_list = get_port_list(args.port)
        if not args.port:
            port_list = all_port_list
        ip_list =  get_ip_f_list(args.file)
        if args.threads:
            scan(ip_list,port_list,int(args.threads))
        else:
            scan(ip_list, port_list, 30)

