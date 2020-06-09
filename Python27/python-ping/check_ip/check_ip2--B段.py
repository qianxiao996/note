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
            print "ip: %s is ok " % ip_str
            break
        else:
            continue

if __name__ == '__main__':
    ip_prefix= '10.85'
    for j in  xrange(0,256):
        print '\n'
        print "ping %s.%s.0..." % (ip_prefix, j)
        for i in xrange(1,256):
            ip = '%s.%s.%s' % (ip_prefix,j,i)

            threading.Thread(target = ping_ip , args = (ip , )).start()
            time.sleep(0.3)


