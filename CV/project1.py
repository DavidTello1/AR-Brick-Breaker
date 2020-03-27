import numpy as np
import cv2

def test1():
    inputImg = cv2.imread("img2.png", 0)
    target = cv2.imread("t1-img2.png", 0)

    iW, iH = inputImg.shape
    tw, th = target.shape

    cv2.imshow("input Image", inputImg)
    cv2.imshow("target Image", target)
    
    matchMap = np.float64(np.zeros((iW - tw + 1, iH - th + 1)))
    mw, mh = matchMap.shape

    i, j = 0, 0

    for i in range(0, mw):
        for j in range(0, mh):
            aux = np.zeros((tw - 1, th - 1))
            aux = np.square(target[:, :] - inputImg[i:i+mw, j:j+mh])
            matchMap[i:j] = np.sum(aux)

    cv2.imshow("MatchingMap", matchMap)

test1()

def closeWin():
    print("CLEARALL")

    key = cv2.waitKey(0)
    if key == 27: #ESC
        cv2.destroyAllWindows()

closeWin()
