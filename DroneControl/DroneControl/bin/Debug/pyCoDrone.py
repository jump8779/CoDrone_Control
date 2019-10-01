from CoDrone.codrone import *
from CoDrone.protocol import *
from CoDrone.system import *
from tkinter import *
from threading import *

drone = CoDrone()

Flag = True

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
      self.battery_per = 0
      self.temp = 0
      self.press = 0
      self.attitude_R = 0
      self.attitude_P = 0
      self.attitude_Y = 0
      self.angle_R = 0
      self.angle_P = 0
      self.angle_Y = 0
      self.acc_X = 0
      self.acc_Y = 0
      self.acc_Z = 0

      frameSta = Frame(self)
      frameSta.pack(fill=X, anchor=W)

      #Battery

      lblBatt = Label(frameSta, text="Battery", width=10)
      lblBatt.pack(side=LEFT, padx=4, pady=8)

      self.lblBattP = Label(frameSta, text="{0}%  |".format(self.battery_per))
      self.lblBattP.pack(side=LEFT, padx=4, pady=8)

      #temperature

      lblTemp = Label(frameSta, text="Temperature", width=10)
      lblTemp.pack(side=LEFT, padx=4, pady=8)

      self.lblTempC = Label(frameSta, text="{0}C  |".format(self.temp))
      self.lblTempC.pack(side=LEFT, padx=4, pady=8)

      #pressure

      lblPres = Label(frameSta, text="Pressure", width=10)
      lblPres.pack(side=LEFT, padx=4, pady=8)

      self.lblPresP = Label(frameSta, text="{0}".format(self.press))
      self.lblPresP.pack(side=LEFT, padx=4, pady=8)

      #Attitude
      frameAtt = Frame(self)
      frameAtt.pack(side=LEFT)

      lblAtti = Label(frameAtt, text="Attitude", width=10)
      lblAtti.pack(padx=8, pady=8)

      self.texAtti = Text(frameAtt, height=30, width=30)
      self.texAtti.insert(1.0, "ROLL:{0} PITCH:{1} YAW:{2}\n".format(self.attitude_R, self.attitude_P, self.attitude_Y))
      self.texAtti.pack(pady=10, padx=10)
      
      #angle
      frameAng = Frame(self)
      frameAng.pack(side=LEFT)

      lblAng = Label(frameAng, text="Angle", width=10)
      lblAng.pack(padx=8, pady=8)

      self.texAng = Text(frameAng, height=30, width=30)
      self.texAng.insert(1.0, "ROLL:{0} PITCH:{1} YAW:{2}\n".format(self.angle_R, self.angle_P, self.angle_Y))
      self.texAng.pack(pady=10, padx=10)

      #accel
      frameAcc = Frame(self)
      frameAcc.pack(side=LEFT)

      lblAcc = Label(frameAcc, text="Accel", width=10)
      lblAcc.pack(padx=8, pady=8)

      self.texAcc = Text(frameAcc, height=30, width=30)
      self.texAcc.insert(1.0, "X:{0} Y:{1} Z:{2}\n".format(self.acc_X, self.acc_Y, self.acc_Z))
      self.texAcc.pack(pady=10, padx=10)

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

   def droneStat(self):
      if drone.isConnected():
         self.temp = drone.get_drone_temp()
         self.press = drone.get_pressure()
         self.battery_per = drone.get_battery_percentage()
      self.after(1000, self.droneStat)

   def droneAtti(self):
      if drone.isConnected():
         self.attitude_R = drone._data.attitude.ROLL
         self.attitude_P = drone._data.attitude.PITCH
         self.attitude_Y = drone._data.attitude.YAW
      self.after(1000, self.droneAtti)

   def droneAngl(self):
      if drone.isConnected():
         self.angle_R = drone._data.gyro.ROLL
         self.angle_P = drone._data.gyro.PITCH
         self.angle_Y = drone._data.gyro.YAW
      self.after(1000, self.droneAngl)

   def droneAcce(self):
      if drone.isConnected():
         self.acc_X = drone._data.accel.X
         self.acc_Y = drone._data.accel.Y
         self.acc_Z = drone._data.accel.Z
      self.after(1000, self.droneAcce)

   def update_text(self):
      self.upBattP = "{0}%  |".format(self.battery_per)
      self.upTempC = "{0}C  |".format(self.temp)
      self.upPresP = "{0}".format(self.press)
      self.lblBattP.configure(text=self.upBattP)
      self.lblTempC.configure(text=self.upTempC)
      self.lblPresP.configure(text=self.upPresP)
      self.texAtti.insert(1.0, "ROLL:{0} PITCH:{1} YAW:{2}\n".format(self.attitude_R, self.attitude_P, self.attitude_Y))
      self.texAng.insert(1.0, "ROLL:{0} PITCH:{1} YAW:{2}\n".format(self.angle_R, self.angle_P, self.angle_Y))
      self.texAcc.insert(1.0, "X:{0} Y:{1} Z:{2}\n".format(self.acc_X, self.acc_Y, self.acc_Z))

      self.after(1000, self.update_text)


def main():
   root = Tk()
   root.geometry("1000x450+100+100")
   root = MyFrame(root)
   root.droneStat()
   root.droneAtti()
   root.droneAngl()
   root.droneAcce()
   root.update_text()
   root.mainloop()

if __name__ == '__main__':
   main()