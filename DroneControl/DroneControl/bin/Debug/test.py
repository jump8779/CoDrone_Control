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

class statData(Structure):
    _pack_ = 1
    _fields_ = [
        ("battery_p",c_short),
        ("temp",c_short),
        ("pressure",c_short)
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
        ("sequence", c_int)
    ]

drone = CoDrone()
IsConnected = False
senD = sendData()
seqD = sequData()

try:
    ser_socket = socket(AF_INET, SOCK_STREAM)
    ser_socket.bind(('',8080))
    ser_socket.listen(1)

    cliSock, addr = ser_socket.accept()
    IsConnected = True
    print("Connect Success..")
except Exception as ex:
    print("Error:",ex)

def sequenceMove(st):
    if st == 0:
        pass
    elif st == 10001:
        drone.takeoff()
        drone.hover(3)
        drone.fly_sequence(Sequence.SQUARE)
        drone.land()
    elif st == 10002:
        drone.takeoff()
        drone.hover(3)
        drone.fly_sequence(Sequence.SPIRAL)
        drone.land()
    elif st == 10003:
        drone.takeoff()
        drone.hover(3)
        drone.fly_sequence(Sequence.TRIANGLE)
        drone.land()
    elif st == 10004:
        drone.takeoff()
        drone.hover(3)
        drone.fly_sequence(Sequence.HOP)
        drone.land()
    elif st == 10005:
        drone.takeoff()
        drone.hover(3)
        drone.fly_sequence(Sequence.SWAY)
        drone.land()
    elif st == 10006:
        drone.takeoff()
        drone.hover(3)
        drone.fly_sequence(Sequence.ZIGZAG)
        drone.land()
    elif st == 20001:
        drone.takeoff()
        drone.hover(3)

        drone.set_roll(50)
        drone.move(1)
        drone.set_roll(0)
        drone.set_pitch(50)
        drone.move(1)
        drone.set_pitch(0)
        drone.set_roll(-50)
        drone.move(1)
        drone.set_roll(0)
        drone.set_pitch(50)
        drone.move(1)
        drone.set_pitch(0)
        drone.set_roll(50)
        drone.move(1)
        drone.set_pitch(-100)
        drone.set_roll(-50)
        drone.move(1)

        drone.land()
    elif st == 20002:
        drone.takeoff()
        drone.hover(3)

        drone.set_yaw(-60)
        drone.set_roll(70)
        drone.move(4)

        drone.land()
    elif st == 20003:
        drone.takeoff()
        drone.hover(3)

        for i in [0, 3]:
            drone.set_yaw(-90)
            drone.move(1)
            drone.set_yaw(0)
            drone.set_pitch(50)
            drone.move(1)
            drone.set_pitch(0)
            drone.rotate180()
            drone.set_pitch(50)
            drone.move(1)
            drone.set_pitch(0)
            if i != 2:
                drone.set_yaw(-90)
                drone.move(1)
                drone.set_yaw(0)
                drone.set_pitch(40)
                drone.move(1)
                drone.set_pitch(0)

def recvD():
    nstat = 0
    ostat = 0

    if IsConnected:
        while drone.isConnected():
            cliSock.recv_into(seqD)
            nstat = seqD.sequence
            if ostat != nstat:
                print(seqD.sequence)
                sequenceMove(nstat)
            ostat = nstat

def sendD():
    if IsConnected:
        while drone.isConnected():
            senD.statD.battery_p = drone.get_battery_percentage()
            senD.statD.temp = drone.get_drone_temp()
            senD.statD.pressure = drone.get_pressure()
            senD.attiD.attROLL = drone.get_gyro_angles().ROLL
            senD.attiD.attPITCH = drone.get_gyro_angles().PITCH
            senD.attiD.attYAW = drone.get_gyro_angles().YAW
            senD.moveD.getR = drone.get_roll()
            senD.moveD.getP = drone.get_pitch()
            senD.moveD.getY = drone.get_yaw()
            senD.moveD.getT = drone.get_throttle()
            print("ROLL:{0} PITCH:{1} YAW:{2} THROTTLE:{3}".format(senD.moveD.getR, senD.moveD.getP,
            senD.moveD.getY, senD.moveD.getT))

            cliSock.send(senD)

if __name__ == '__main__':
    drone.pair()
    t1 = Thread(target=recvD, daemon=True)
    t2 = Thread(target=sendD, daemon=True)
    t1.start()
    t2.start()
    t1.join()
    t2.join()
    drone.disconnect()