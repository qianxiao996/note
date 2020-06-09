#!/usr/bin/python3


from xml.dom.minidom import parse

# 读取文件
dom = parse("00000001_MySQL数据库扫描_127.0.0.1_2020-06-08_163334.xml")
# 获取文档元素对象
data = dom.documentElement
# 获取 SCANDATA

all_list = []
single_list = []
for stu in data.getElementsByTagName('SCANDATA')[0].getElementsByTagName("HOST"):
   #获得标签属性值
   IP = stu.getAttribute("IP")
   single_list.append(IP)

   # 获取标签中内容
   PORT = stu.getElementsByTagName('PORT')[0].firstChild.data
   DBTYPE = stu.getElementsByTagName('DBTYPE')[0].firstChild.data
   single_list.append(PORT)
   single_list.append(DBTYPE)
   #获得标签对之间的数据

   for i in stu.getElementsByTagName('DATA')[0].getElementsByTagName('VULNERABLITY'):
      NAME = i.getElementsByTagName('NAME')[0].firstChild.data
      CNVD= i.getElementsByTagName('NO')[0].getAttribute("CNVD")
      CVE = i.getElementsByTagName('NO')[0].getAttribute("CVE")
      MS = i.getElementsByTagName('NO')[0].getAttribute("MS")
      OTHER = i.getElementsByTagName('NO')[0].getAttribute("OTHER")
      VULTYPE = i.getElementsByTagName('VULTYPE')[0].firstChild.data
      RISK =  i.getElementsByTagName('RISK')[0].firstChild.data
      SYNOPSIS  = i.getElementsByTagName('SYNOPSIS')[0].firstChild.data
      DESCRIPTION = i.getElementsByTagName('DESCRIPTION')[0].firstChild.data
      SOLUTION = i.getElementsByTagName('SOLUTION')[0].firstChild.data
      single_list.append([NAME,CNVD,CVE,MS,OTHER,VULTYPE,RISK,SYNOPSIS,DESCRIPTION,SOLUTION])
   all_list.append(single_list)
   print(single_list)
   single_list = []

# print(all_list)