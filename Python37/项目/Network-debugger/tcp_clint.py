import socket

#创建socket
clint = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
clint.connect(("192.168.91.1",8844))


while True:
    #data = input("请输入给服务器发送的数据：")
    #clint.sendall(data.encode('utf-8'))
    info = clint.recv(1024)
    print("服务器接收到的数据为：",info.decode('utf-8'))




