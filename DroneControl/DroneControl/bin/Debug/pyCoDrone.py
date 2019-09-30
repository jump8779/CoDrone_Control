from CoDrone.codrone import *
from CoDrone.protocol import *
from CoDrone.system import *
from tkinter import *
from threading import *

drone = CoDrone()

Flag = True
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

def droneStat():
   global temp
   global press
   global battery_per
   while(drone.isConnected()):
      temp = drone.get_drone_temp()
      press = drone.get_pressure()
      battery_per = drone.get_battery_percentage()

def droneAtti():
   global attitude_R 
   global attitude_P 
   global attitude_Y
   while(drone.isConnected()):
      attitude_R = drone._data.attitude.ROLL
      attitude_P = drone._data.attitude.PITCH
      attitude_Y = drone._data.attitude.YAW

def droneAngl():
   global angle_R 
   global angle_P 
   global angle_Y 
   while(drone.isConnected()):
      angle_R = drone._data.gyro.ROLL
      angle_P = drone._data.gyro.PITCH
      angle_Y = drone._data.gyro.YAW

def droneAcce():
   global acc_X 
   global acc_Y 
   global acc_Z 
   while(drone.isConnected()):
      acc_X = drone._data.accel.X
      acc_Y = drone._data.accel.Y
      acc_Z = drone._data.accel.Z

def connect():
   drone.pair()
   drone.takeoff()
   drone.hover()

def disconnect():
   if drone.isConnected():
      drone.land()
      drone.disconnect()

def setPlot():
   global Flag
   if Flag:
      drone.set_plot_sensor(PlotType.gyro)
      Flag = False
   else:
      pass

def drawPlot():
   if not Flag:
      drone.draw_plot_sensor()
      Flag = True
   else:
      pass

def moveFront():
   if drone.isConnected():
      drone.set_pitch(10)
      drone.move(1)

def moveBack():
   if drone.isConnected():
      drone.set_pitch(-10)
      drone.move(1)

def moveLeft():
   if drone.isConnected():
      drone.set_roll(-10)
      drone.move(1)

def moveRight():
   if drone.isConnected():
      drone.set_roll(10)
      drone.move(1)

def KeyPress(event):
   pass

# GUI Design

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

      texAtti = Text(frameAtt, height=30, width=30, state=DISABLED)
      texAtti.insert(1.0, "ROLL:{0} PITCH:{1} YAW:{2}\n".format(attitude_R, attitude_P, attitude_Y))
      texAtti.pack(pady=10, padx=10)
      
      #angle
      frameAng = Frame(self)
      frameAng.pack(side=LEFT)

      lblAng = Label(frameAng, text="Angle", width=10)
      lblAng.pack(padx=8, pady=8)

      texAng = Text(frameAng, height=30, width=30, state=DISABLED)
      texAtti.insert(1.0, "ROLL:{0} PITCH:{1} YAW:{2}\n".format(angle_R, angle_P, angle_Y))
      texAng.pack(pady=10, padx=10)

      #accel
      frameAcc = Frame(self)
      frameAcc.pack(side=LEFT)

      lblAcc = Label(frameAcc, text="Accel", width=10)
      lblAcc.pack(padx=8, pady=8)

      texAcc = Text(frameAcc, height=30, width=30, state=DISABLED)
      texAcc.insert(1.0, "X:{0} Y:{1} Z:{2}\n".format(acc_X, acc_Y, acc_Z))
      texAcc.pack(pady=10, padx=10)

      #plot_Check
      framePlo = Frame(self)
      framePlo.pack(anchor=W)

      check_S = Checkbutton(framePlo, text="SET PLOT", command=setPlot)
      check_S.pack()

      check_D = Checkbutton(framePlo, text="DRAW PLOT", command=drawPlot)
      check_D.pack()

      #Connect_B
      frameCon = Frame(self)
      frameCon.pack()

      button_sta = Button(frameCon, text="Start", command=connect)
      button_sta.pack()

      button_sto = Button(frameCon, text="Stop", command=disconnect)
      button_sto.pack()

      #button_moving
      #UP
      frameUP = Frame(self)
      frameUP.pack(fill=BOTH, ipady=60)

      button_UP = Button(frameUP, width=5, height=2, text="↑", command=moveFront)
      button_UP.pack(side=BOTTOM, pady=10)

      #LEFT
      frameLE = Frame(self)
      frameLE.pack(fill=BOTH, side=LEFT, expand=1)

      button_LEFT = Button(frameLE, width=5, height=2, text="←", command=moveLeft)
      button_LEFT.pack(anchor=NE)

      #BOTTOM
      frameBO = Frame(self)
      frameBO.pack(fill=BOTH, side=LEFT, expand=1)

      button_BOTTOM = Button(frameBO, width=5, height=2, text="↓", command=moveBack)
      button_BOTTOM.pack()

      #RIGHT
      frameRI = Frame(self)
      frameRI.pack(fill=BOTH, side=RIGHT, expand=1)

      button_RIGHT = Button(frameRI, width=5, height=2, text="→", command=moveRight)
      button_RIGHT.pack(anchor=NW)

      def update_text(self):
         if texAtti.see(100.0):
            texAtti.delete(99.0,100.0)
            texAng.delete(99.0,100.0)
            texAcc.delete(99.0,100.0)
         self.update()
         self.after(1000, self.update_text)


def main():
   t1 = Thread(target=droneStat)
   t2 = Thread(target=droneAtti)
   t3 = Thread(target=droneAngl)
   t4 = Thread(target=droneAcce)
   t1.daemon = True
   t2.daemon = True
   t3.daemon = True
   t4.daemon = True
   t1.start()
   t2.start()
   t3.start()
   t4.start()

   root = Tk()
   root.geometry("1000x450+100+100")
   MyFrame(root)
   root.mainloop()

if __name__ == '__main__':
   main()