import cv2
import numpy as np
from helper import averageNeighbour
from matplotlib import pyplot as plt


def logtrans(img, a, b):
	averageOut = averageNeighbour(img)
	logAverage = np.log(averageOut)
	out = a * logAverage + b * (np.log(img) - logAverage)
	return out

def logtrans1(img, a, b):
	out = a * np.log(img) + b
	return out

def bila(img):
	return cv2.bilateralFilter(img, 5, 35, 16)

def canny(img):
	return cv2.Canny(np.uint8(img), 90, 100)

def morph(img):
	return cv2.morphologyEx(img, cv2.MORPH_CLOSE, kernel, iterations = 1)

def integral():
	return
def matshow(img):
	plt.imshow(img, cmap = 'gray', interpolation = 'bicubic')
	plt.show()
	return 

org = cv2.imread('2.jpg',-1)
#static variation
alpha = 0.9
beta = 1.1
kernel = np.ones((3,3), np.uint8)

#convert input image into grayscale
gray = cv2.imread('1.jpg',0)
gray32 = np.float32(gray)
#perform log transformation on grayscale image
logout = logtrans(gray32,alpha, beta)
logT = np.float32(logout)
logTF = np.exp(logT)
#perform bilateral filter
blur = bila(logTF)
#perform edge detection
edges = canny(blur)
print(edges)
final = morph(edges)

#cv2.imshow('edges', edges)
matshow(gray)
matshow(logT)
matshow(blur)
matshow(edges)
matshow(final)

#cv2.imshow('Final',final)
#cv2.imshow('blur',blur)
#cv2.imshow("Gray", gray)
#cv2.imshow('Origin',org)
#cv2.imshow('log transformation',np.exp(logout).astype(int))
print('========')
print(logout.shape)
cv2.waitKey(0)
cv2.destroyAllWindows()


# print(gray[100,100])
# print(org[100,100])
# print(gray.item(100,100))
# print(gray.shape)
# print(gray.size)









