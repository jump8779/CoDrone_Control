from CoDrone.codrone import *
from CoDrone.protocol import *
from CoDrone.system import *
from ctypes import *
from socket import *
from threading import *

# receive data
# 전후좌우 이동
# 상하 이동
# 패턴비행

# send data
# 베터리
# 온도
# 기압
# angle/angular-speed/accelerometer

drone = CoDrone()
IsConnected = False
stat = 00

class statData(Structure):
    _pack_ = 1
    _fields_ = [
        ("battery_p",c_short),
        ("temp",c_short),
        ("pressure",c_int)
    ]

class attiData(Structure):
    _pack_ = 1
    _fields_ = [
        ("attROLL",c_short),
        ("attPITCH",c_short),
        ("attYAW",c_short)
    ]

class moveData(Structure):
    _pack_ = 1
    _fields_ = [
        ("getR",c_short),
        ("getP",c_short),
        ("getY",c_short),
        ("getT",c_short)
    ]

class sendData(Structure):
    _pack_ = 1
    _fields_ = [
        ("statD",statData),
        ("attiD",attiData),
        ("moveD",moveData)
    ]

class sequData(Structure):
    _pack_ = 1
    _fields_ = [
        ("sequence",c_int)
    ]

try:
    ser_socket = socket(AF_INET, SOCK_STREAM)
    ser_socket.bind(('',8080))
    ser_socket.listen(1)

    cliSock, addr = ser_socket.accept()
    IsConnected = True
except Exception as ex:
    print("Error:",ex)

def recvD():
    seqD = sequData()

    print("Connect Success..")

    while IsConnected:
        seqD = cliSock.recv(sizeof(sequData))

def sendD():
    pass

def main():
    t1 = Thread(target=recvD, daemon=True)
    t2 = Thread(target=sendD, daemon=True)
    t1.start()
    t2.start()