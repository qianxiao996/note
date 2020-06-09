import socket

clint =socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
#clint.connect(("192.168.91.1",8899))

while True:
    data = input("请输入数据：")
    clint.sendto(data.encode("utf-8"),('192.168.91.1',8844))

