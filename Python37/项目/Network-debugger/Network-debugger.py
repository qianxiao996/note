from PyQt5 import  QtGui, QtWidgets
from PyQt5.QtWidgets import QMessageBox
from main import Ui_MainWindow
import socket,threading,re,sys
class MainWindows(QtWidgets.QMainWindow,Ui_MainWindow): #主窗口
    def __init__(self,parent=None):
        super(MainWindows,self).__init__(parent)
        self.Ui = Ui_MainWindow()
        self.Ui.setupUi(self)
        self.setWindowIcon(QtGui.QIcon('./logo.png'))
        self.setFixedSize(self.width(), self.height()) #设置宽高不可变
        self.Ui.open.clicked.connect(self.opensocket)  #开启监听
        self.Ui.send.clicked.connect(self.senddata)  # 发送数据
        self.Ui.connect.clicked.connect(self.tcp_connect)  # 发送数据
        self.Ui.close.clicked.connect(self.close_socket)  # 关闭
        self.Ui.ltest.clicked.connect(self.check_port)  # 端口占用
        self.Ui.rtest.clicked.connect(self.check_connect)  # 测试连接
        self.socket = socket
        self.Ui.radio_tcp.setChecked(True)
        self.flag=0

    def check_port(self):
        ip = self.get_ip('lip')
        port = self.get_port('lport')
        if not (ip and port):
            return 0
        s = socket.socket()
        try:
            s.settimeout(100)
            s.connect((ip, port))
            s.shutdown(1)
            QMessageBox.information(self, 'Faile', '该端口已被占用！')
        except socket.error as e:
            QMessageBox.information(self, 'Success', '该端口可以使用！')
    def check_connect(self):
        ip = self.get_ip('rip')
        port = self.get_port('rport')
        if not (ip and port):
            return 0
        s = socket.socket()
        try:
            s.settimeout(100)
            s.connect((ip, port))
            s.shutdown(1)
            QMessageBox.information(self, 'Success', '远程主机可以连接！')
        except socket.error as e:
            QMessageBox.information(self, 'Faile', '连接失败！')



    def close_socket(self):
        try:
            self.flag = 0
            self.socket.close()
            self.statusBar().showMessage("连接已关闭!")  # 状态栏显示信息
            self.Ui.debugger.appendPlainText('连接已关闭!')

        except:
            pass


    def receive_data(self):
        self.flag=1
        # try:
        while self.flag:
            data = self.socket.recv(1024)
            if not data:
                self.Ui.Receive_data.appendPlainText('失去连接！')
                self.statusBar().showMessage('失去连接！')  # 状态栏显示信息
                self.flag=0
                break
            self.Ui.Receive_data.appendPlainText(data.decode("utf-8"))
        # except:
        #     pass


    def opensocket(self):
        try:
            ip = self.get_ip('lip')
            port=self.get_port('lport')
            if not (ip and port):
                return 0
            if self.Ui.radio_tcp.isChecked():
                s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
                s.bind((ip, port))
                s.listen(20)
                timeout = 10
                socket.setdefaulttimeout(timeout)
                self.statusBar().showMessage('TCP服务端监听监听成功，等待连接！')  # 状态栏显示信息
                self.Ui.debugger.appendPlainText('TCP服务端监听监听成功，等待连接！')
                thread = threading.Thread(target=self.tcp_open, args=(s,))
                thread.setDaemon(True)  # 设置为后台线程，这里默认是False，设置为True之后则主线程不用等待子线程
                thread.start()
            if self.Ui.radio_udp.isChecked():
                s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
                s.bind((ip, port))  # 绑定服务器的ip和端口
                self.statusBar().showMessage('UDP服务端监听运行中！')  # 状态栏显示信息
                self.Ui.debugger.appendPlainText('UDP服务端监听运行中！')
                self.socket = s
                thread = threading.Thread(target=self.receive_data, args=())
                thread.setDaemon(True)  # 设置为后台线程，这里默认是False，设置为True之后则主线程不用等待子线程
                thread.start()

        except Exception as  e:
            self.Ui.debugger.appendPlainText(str(e))

    def tcp_open(self,s):
        sock, addr = s.accept()
        self.statusBar().showMessage("TCP客户端已连接!")  # 状态栏显示信息
        self.Ui.debugger.appendPlainText('TCP客户端已连接！')
        self.socket =sock
        self.receive_data()
        # print(self.socket)
    def tcp_connect(self):
        ip = self.get_ip('rip')
        port = self.get_port('rport')
        if not (ip and port):
            return 0
        if self.Ui.radio_tcp.isChecked():
            try:
                clint = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
                clint.connect((ip, port))
                self.Ui.debugger.appendPlainText('已连接TCP服务端，请发送数据！')
                self.statusBar().showMessage("已连接TCP服务端！")  # 状态栏显示信息
                self.socket = clint
                self.flag=1
                thread = threading.Thread(target=self.receive_data, args=())
                thread.setDaemon(True)  # 设置为后台线程，这里默认是False，设置为True之后则主线程不用等待子线程
                thread.start()
            except Exception as  e:
                self.Ui.debugger.appendPlainText(str(e))



        if self.Ui.radio_udp.isChecked():
            self.Ui.debugger.appendPlainText('UDP无需连接远端，直接发送数据即可！')
    def senddata(self):
        if self.Ui.radio_tcp.isChecked():
            if not self.flag:
                self.Ui.debugger.appendPlainText('没有正在运行的服务！')
                return 0
            data = self.Ui.send_data.toPlainText()
            print(data)
            self.Ui.debugger.appendPlainText('TCP服务器正在发送数据...')
            data = bytes(data,encoding='utf-8')
            self.socket.sendall(data)
            self.Ui.debugger.appendPlainText('发送成功！！')
            # sock.close()
        if self.Ui.radio_udp.isChecked():
            ip = self.get_ip('rip')
            port = self.get_port('rport')
            if not (ip and port):
                return 0
            udp_send = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
            # 发送数据 字节
            data = self.Ui.send_data.toPlainText()
            data = bytes(data, encoding='utf-8')
            self.Ui.debugger.appendPlainText('UDP服务器正在发送数据...')
            udp_send.sendto(data, (ip,port))
            self.Ui.debugger.appendPlainText('发送成功！！')
    def get_ip(self,type):
        if type =='lip':
            ip = self.Ui.lip.text()
        if type == 'rip':
            ip = self.Ui.rip.text()
        if ip =='':
            self.Ui.debugger.appendPlainText('IP地址不能为空！')
            return 0
        if not re.match(r"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$", ip):
            self.Ui.debugger.appendPlainText('请输入正确的IP地址！')
            return 0
        return ip
    def get_port(self,type):
        if type == 'lport':
            port = self.Ui.lport.text()
        if type == 'rport':
            port = self.Ui.rport.text()
        if port=='':
            self.Ui.debugger.appendPlainText('端口不能为空！')
            return 0
        if not re.match(r"^(6553[0-5]|655[0-2][0-9]|65[0-4][0-9]{2}|6[0-4][0-9]{3}|[1-5][0-9]{4}|[1-9][0-9]{1,3}|[0-9])$",port):
            self.Ui.debugger.appendPlainText('请输入正确的端口！')
            return 0
        return int(port)











if __name__ == "__main__":
    app = QtWidgets.QApplication(sys.argv)
    window = MainWindows()
    window.show()
    sys.exit(app.exec_())
