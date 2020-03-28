import numpy as np
import cv2

def test1():
    inputImg = cv2.imread("img2.png", 1)
   # inputImgGray = cv2.cvtColor(inputImg, cv2.COLOR_BGR2GRAY)
   # iW, iH = inputImgGray.shape

    target = cv2.imread("t1-img2.png", 1)
    #targetGray = cv2.cvtColor(target, cv2.COLOR_BGR2GRAY)
    #tw, th = targetGray.shape

    # cv2.normalize(inputImg, inputImg, alpha=0, beta=1, norm_type=cv2.NORM_MINMAX, dtype=cv2.CV_32F)
    # cv2.normalize(target, target, alpha=0, beta=1, norm_type=cv2.NORM_MINMAX, dtype=cv2.CV_32F)

    # mw, mh = iW - tw + 1, iH - th + 1
    # matchMap = np.zeros(shape=(mw, mh), dtype=float)
    matchMap = cv2.matchTemplate(inputImg, target, 1)

    # for i in range(0, mw):
    #     for j in range(0, mh):
    #         aux = np.zeros(shape=(tw, th), dtype=float)
    #         aux = np.square(targetGray[:, :] - inputImgGray[i:i+tw, j:j+th])
    #         matchMap[i:j] = np.sum(aux, None, dtype=float)

    #cv2.normalize(matchMap, matchMap)

    cv2.imshow("input Image", inputImg)
    cv2.imshow("target Image", target)
    cv2.imshow("MatchingMap", matchMap)

test1()

def closeWin():
    print("CLEARALL")
    key = cv2.waitKey(0)
    if key == 27: #ESC
        cv2.destroyAllWindows()

closeWin()
