import CoDrone
from CoDrone.protocol import *

drone = CoDrone.CoDrone()

def dronestate():
   _stData = []
   _stData.append(drone.get_drone_temp)
   _stData.append(drone.get_pressure)
   _stData.append(drone.get_battery_percentage)
   return _stData

def thgyro():
   _attData = []
   _attData.append(drone._data.attitude.ROLL)
   _attData.append(drone._data.attitude.PITCH)
   _attData.append(drone._data.attitude.YAW)
   return _attData

def connect(port="None", droneN="None"):
   if not port == "None" or not droneN == "None":
      drone.pair(droneN, port)
   else:
      drone.pair()

def disconnect():
   drone.disconnect()

def moving():
   drone.takeoff()
   drone.hover(3)
   drone.set_pitch(50)
   drone.move(1)
   drone.land()