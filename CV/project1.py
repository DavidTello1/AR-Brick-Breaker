import numpy as np
import cv2

def test1():
    inputImg = cv2.imread("img2.png", 0)
    target = cv2.imread("t1-img2.png", 0)

    iW, iH = inputImg.shape
    tw, th = target.shape

    #inputImg = np.float64(inputImg)
    #target = np.float64(target)

    #cv2.normalize(inputImg, inputImg)
    #cv2.normalize(target, target)

    cv2.imshow("input Image", inputImg)
    cv2.imshow("target Image", target)

    matchMap = np.float64(np.zeros(shape=(iW - tw + 1, iH - th + 1)))
    mw = iW - tw + 1
    mh = iH - th + 1

    i, j = 0, 0

    for i in range(0, mw - 1):
        for j in range(0, mh - 1):
           # aux = np.copy(target)
           # aux = np.square(target[:, :] - inputImg[i:i+tw, j:j+th])
            matchMap[i:j] = np.sum(np.square(target[:, :] - inputImg[i:i+tw, j:j+th]))

   # matchMap = cv2.normalize(matchMap, matchMap)
    cv2.imshow("MatchingMap", matchMap)

test1()

def closeWin():
    print("CLEARALL")

    key = cv2.waitKey(0)
    if key == 27: #ESC
        cv2.destroyAllWindows()

closeWin()
