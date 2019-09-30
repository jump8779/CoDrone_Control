from CoDrone.codrone import *
from CoDrone.protocol import *
from CoDrone.system import *
from tkinter import *
from threading import *

drone = CoDrone()

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

# GUI Design

battery_per = 0
temp = 0
press = 0
attitude_R = 0
attitude_P = 0
attitude_Y = 0
angle_R = 0
angle_P = 0
angle_Y = 0
acc_X = 0
acc_Y = 0
acc_Z = 0

def battery_p():
   i = 0
   global battery_per

   while(i<100):
      battery_per = i
      i += 1

class MyFrame(Frame):
   def __init__(self, master):
      Frame.__init__(self, master)

      self.master = master
      self.master.title("Drone_Co")
      self.pack(fill=BOTH, expand=True)

      frameSta = Frame(self)
      frameSta.pack(fill=X, anchor=W)

      #Battery

      lblBatt = Label(frameSta, text="Battery", width=10)
      lblBatt.pack(side=LEFT, padx=4, pady=8)

      lblBattP = Label(frameSta, text="{0}%  |".format(battery_per))
      lblBattP.pack(side=LEFT, padx=4, pady=8)

      #temperature

      lblTemp = Label(frameSta, text="Temperature", width=10)
      lblTemp.pack(side=LEFT, padx=4, pady=8)

      lblTempC = Label(frameSta, text="{0}C  |".format(temp))
      lblTempC.pack(side=LEFT, padx=4, pady=8)

      #pressure

      lblPres = Label(frameSta, text="Pressure", width=10)
      lblPres.pack(side=LEFT, padx=4, pady=8)

      lblPresP = Label(frameSta, text="{0}".format(press))
      lblPresP.pack(side=LEFT, padx=4, pady=8)

      #Attitude
      frameAtt = Frame(self)
      frameAtt.pack(side=LEFT)

      lblAtti = Label(frameAtt, text="Attitude", width=10)
      lblAtti.pack(padx=8, pady=8)

      texAtti = Text(frameAtt, height=30, width=30)
      texAtti.pack(pady=10, padx=10)

      #angle
      frameAng = Frame(self)
      frameAng.pack(side=LEFT)

      lblAng = Label(frameAng, text="Angle", width=10)
      lblAng.pack(padx=8, pady=8)

      texAng = Text(frameAng, height=30, width=30)
      texAng.pack(pady=10, padx=10)

      #accel
      frameAcc = Frame(self)
      frameAcc.pack(side=LEFT)

      lblAcc = Label(frameAcc, text="Accel", width=10)
      lblAcc.pack(padx=8, pady=8)

      texAcc = Text(frameAcc, height=30, width=30)
      texAcc.pack(pady=10, padx=10)

      #plot_Check
      framePlo = Frame(self)
      framePlo.pack(anchor=W)

      check_P = Checkbutton(framePlo, text="SET PLOT")
      check_P.pack()

      #button_moving
      #UP
      frameUP = Frame(self)
      frameUP.pack(fill=BOTH, ipady=60)

      button_UP = Button(frameUP, width=5, height=2, text="↑")
      button_UP.pack(side=BOTTOM, pady=10)

      #LEFT
      frameLE = Frame(self)
      frameLE.pack(fill=BOTH, side=LEFT, expand=1)

      button_LEFT = Button(frameLE, width=5, height=2, text="←")
      button_LEFT.pack(anchor=NE)

      #BOTTOM
      frameBO = Frame(self)
      frameBO.pack(fill=BOTH, side=LEFT, expand=1)

      button_BOTTOM = Button(frameBO, width=5, height=2, text="↓")
      button_BOTTOM.pack()

      #RIGHT
      frameRI = Frame(self)
      frameRI.pack(fill=BOTH, side=RIGHT, expand=1)

      button_RIGHT = Button(frameRI, width=5, height=2, text="→")
      button_RIGHT.pack(anchor=NW)


def main():
   t1 = Thread(target=battery_p)
   t1.daemon = True
   t1.start()
   root = Tk()
   root.geometry("1000x450+100+100")
   MyFrame(root)
   root.mainloop()

if __name__ == '__main__':
   main()