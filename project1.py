import numpy as np
import cv2

def test1():
    
    inputImg = cv2.imread("img2.png", 1)
    target = cv2.imread("t1-img2.png", 1)

    cv2.imshow('InputImage', inputImg)
    cv2.imshow('TargetImage', target)


    matchMap = cv2.matchTemplate(inputImg, target, 1)

    cv2.imshow('MatchingTemplate', matchMap)

test1()

def closeWin():
    print("CLEARALL")

    key = cv2.waitKey(0)
    if key == 27: #ESC
        cv2.destroyAllWindows()

closeWin()
