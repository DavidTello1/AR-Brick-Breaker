import numpy as np
import cv2

def TemplateMathing(Input, Target, Threshold):
    # Input image GrayScale
    input_gray = cv2.cvtColor(Input, cv2.COLOR_BGR2GRAY)
    W, H = input_gray.shape

    # Target image GrayScale
    target_gray = cv2.cvtColor(Target, cv2.COLOR_BGR2GRAY)
    w, h = target_gray.shape

    # Create empty Matching Map
    matchMap = np.zeros(shape=(W-w+1, H-h+1), dtype=float)

    # sum of squared diferences
    matchMap[0:W-w+1][0:H-h+1] += (target_gray[0:w+1][0:h+1] - input_gray[(0:W-w+1) + (0:w+1)][(0:H-h+1) + (0:h+1)])**2

    # if (matchMap[0:W-w+1][0:H-h+1] < Threshold): # check if pixel is below threshold
    #     cv2.rectangle(Input, (x, y), (x+w, y+h), (0, 255, 0)) # draw rectangle on top of input image

    return matchMap

# Load Input and Target Images
img_input = cv2.imread("img2.png", 1)
img_target = cv2.imread("t1-img2.png", 1)

# Define Threshold
threshold = 0.1

# Create result image
img_found = np.zeros((40, 245, 3), np.uint8)
font = cv2.FONT_HERSHEY_SIMPLEX
cv2.putText(img_found, "TARGET FOUND", (5, 30), font, 1, (0, 255, 0), 2)

# Execute Template Matching algorithm
mathing_map = TemplateMathing(img_input, img_target, threshold)

# Show Images
cv2.imshow("Input Image", img_input)
cv2.imshow("Target Image", img_target)
cv2.imshow("MatchingMap", mathing_map)
cv2.imshow("Result", img_found)

def closeWin():
    print("CLEAR ALL")
    key = cv2.waitKey(0)
    if key == 27: #ESC
        cv2.destroyAllWindows()

closeWin()