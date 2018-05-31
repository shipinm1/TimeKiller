import numpy as np
from scipy import ndimage

def averageNeighbour(img):
    #kernel = np.array([0,1,0],[1,0,1],[0,1,0])
    out = ndimage.generic_filter(img, np.nanmean, size = 3, mode = 'constant', cval = np.NaN)
    #print(out)
    #print(kernel.sum())
    return out

    