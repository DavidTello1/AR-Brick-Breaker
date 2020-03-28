import numpy as np
import cv2

def TemplateMathing(Input, Target, threshold):
   
    input_gray = cv2.cvtColor(Input, cv2.COLOR_BGR2GRAY)
    W, H = input_gray.shape

    target_gray = cv2.cvtColor(Target, cv2.COLOR_BGR2GRAY)
    w, h = target_gray.shape

    matchMap = np.ones(shape=(W-w+1, H-h+1), dtype=float)
    matchMap = cv2.matchTemplate(Input, Target, 1)

    for x in range(0, W-w+1):
        for y in range(0, H-h+1):
            for i in range(0, w+1):
                for j in range(0,h+1):
                    matchMap[x][y] += (target_gray[i][j] - input_gray[x+i][j+y])**2
                    if (matchMap[x][y] < threshold):
                        cv2.rectangle(Input, (x,y), (x+w, y+h), (255,0,255))

# Load Input and Target Images
img_input = cv2.imread("img2.png", 1)
img_target = cv2.imread("t1-img2.png", 1)

# Define Threshold
threshold = 0.1

# Create result image
img_found = np.zeros((40,245,3), np.uint8)
font = cv2.FONT_HERSHEY_SIMPLEX
cv2.putText(img_found, "TARGET FOUND", (5,30), font, 1, (0,255,0), 2)

# Execute Template Matching algorithm
TemplateMathing(img_input, img_target, threshold)

# Show Images
cv2.imshow("Input Image", inputImg)
cv2.imshow("Target Image", target)
cv2.imshow("MatchingMap", matchMap)
cv2 imshow("Result", img_found)

def closeWin():
    print("CLEAR ALL")
    key = cv2.waitKey(0)
    if key == 27: #ESC
        cv2.destroyAllWindows()

closeWin()