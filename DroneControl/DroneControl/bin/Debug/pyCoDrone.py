import CoDrone
from CoDrone.protocol import *
import threading
import time

drone = CoDrone.CoDrone()

def thgyro():
   R = 0
   P = 0
   while(1):
      R += drone._data.attitude.ROLL
      P += drone._data.attitude.PITCH
      print("ROLL:", drone._data.attitude.ROLL)
      print("PITCH:", drone._data.attitude.PITCH)
      print("YAW:", drone._data.attitude.YAW)
      time.sleep(1)
   print("R:", R)
   print("P:", P)

def main():
   t1 = threading.Thread(target=thgyro)
   t1.daemon = True
   drone.pair()
   battery = drone.get_battery_percentage()
   print("battery:", battery)
   drone.takeoff()
   t1.start()
   drone.hover(3)
   drone.set_pitch(100)
   drone.move(5)
   drone.land()
   drone.disconnect()

if __name__ == '__main__':
   main()