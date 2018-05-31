import cv2
import numpy as np
from helper import averageNeighbour
from matplotlib import pyplot as plt

#read grayscale image
gray = cv2.imread('4.jpg',0)
#log transformation s = alpha * log(input) + beta
logTrans = 0.9 * np.log(gray) + 1
#blur
blur = cv2.bilateralFilter(np.float32(logTrans), 9, 35, 16)
#edge detection
edge = cv2.Canny(np.uint8(blur), 90, 100)
#printing result
plt.imshow(edge, cmap = 'gray', interpolation = 'bicubic')
plt.show()
