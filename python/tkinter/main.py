from tkinter import *
import math
# create a window
root = Tk()
# the title of the window
root.title('Drawing charts in tkinter')
# window width
width = 1020
# window height
height = 620
# window size
root.geometry(str(width) + 'x' + str(height))
# the field for drawing (canvas)
canvas = Canvas(root, width=width, height=height, bg='#fff')
# cell size in pixels
k = 50
# vertical grid lines
for y in range(int(width / k)):
	d = k * y
	canvas.create_line(10 + d, height-10, 10+d, 10, width=1, fill='#808080')
# horizontal grid lines
for x in range(int(height / k)):
	d = k * x
	canvas.create_line(10, 10+d, width-10, 10+d, width=1, fill='#808080')
# y axis
canvas.create_line(10, 10, 10, height-10, width=1, arrow=FIRST, fill='#000')
# x axis
canvas.create_line(0, int(height/2), width-10, int(height/2), width=1, arrow=LAST, fill='#000')
#the y-offset
dy = int(height/2)
#array of points
xy = []
#fill the array
for x in range(1000):
	#function value
	y = 200*math.sin(0.0209*x + 10)
	xy.append(x)
	xy.append(y+dy)
#drawing a graph by aray
sin_line = canvas.create_line(xy, fill='blue')
# canvas dysplay
canvas.pack()
# window display
root.mainloop()