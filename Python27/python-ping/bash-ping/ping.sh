#!/bin/bash
#author: ApingLai
#www: www.ApingLAi.com
#Yes 为可以ping通
#No  为不能ping通
#设置网段
net=192.168.1
#启始IP
ip=1
while [ $ip -le 254 ]
do
    ping $net.$ip -c 2 | grep -q "ttl=" && echo "$net.$ip Yes" || echo "$net.$ip Down"
    ip=`expr $ip + 1`
done
