#!/usr/bin/env/python
#_*_coding:utf-8_*_
#PythonVersion:python2.7
#filename:IPscanner.py

import os
import sys
import time
import threading

reload(sys)
sys.setdefaultencoding("utf-8")

# 获取脚本运行的系统
def get_system():
    if os.name == 'nt':
        return 'n'
    else:
        return 'c'

def ping_ip(ip_str):
    shell = ['ping','-{op}'.format(op=get_system()),'1',ip_str]
    output = os.popen(' '.join(shell)).readlines()

    for line in list(output):
        if not line:
            continue
        if str(line).upper().find('TTL') >= 0:
            print ip_str.replace(" ","")
            break

def find_ip(ip_prefix):
    for i in xrange(1,256):
        ip = '%s.%s' % (ip_prefix,i)
        threading.Thread(target = ping_ip , args = (ip , )).start()
        time.sleep(0.3)

if __name__ == '__main__':
    cmd = sys.argv[1:]
    args = ''.join(cmd)
    print "IP is OK:"

    ip_prefix = '.'.join(args.split('.')[:-1])
    find_ip(ip_prefix)
