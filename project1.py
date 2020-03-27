import numpy as np
import cv2

def test1():
    
    inputImg = cv2.imread("img2.png", 0)
    target = cv2.imread("t1-img2.png", 0)

    iW, iH = inputImg.shape
    tw, th = target.shape

    matchMap = np.float64(np.zeros((iW - tw + 1, iH - th + 1)) 
    cv2.imshow('MatchingMap', matchMap)
    
test1()

def closeWin():
    print("CLEARALL")

    key = cv2.waitKey(0)
    if key == 27: #ESC
        cv2.destroyAllWindows()

closeWin()
