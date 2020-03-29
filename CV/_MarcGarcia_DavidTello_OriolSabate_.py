import numpy as np
import cv2

def TemplateMathing(Input, Target, Threshold):
    Found = int(False)
    # Input image GrayScale
    input_gray = cv2.cvtColor(Input, cv2.COLOR_BGR2GRAY)
    W, H = input_gray.shape

    # Target image GrayScale
    target_gray = cv2.cvtColor(Target, cv2.COLOR_BGR2GRAY)
    w, h = target_gray.shape

    # Create empty Matching Map
    matchMap = np.zeros(shape=(W-w+1, H-h+1), dtype=float)

    # Computing Matching Map
    for x in range(0, W-w+1):
        for y in range(0, H-h+1):
            # sum of squared diferences
            matchMap[x, y] = np.sum(np.square(target_gray[:, :] - input_gray[x:x+w, y:y+h]))

    matchMap = matchMap / matchMap.max()
    # Locating target
    loc = np.where(matchMap < Threshold)

    if loc:
        for pt in zip(*loc[::-1]):
            Found = int(True)
            # Drawing the rectangle
            cv2.rectangle(Input, pt, (pt[0] + w, pt[1] + h), (0, 255, 0), 2)

    return matchMap, Found

# Load Input and Target Images
input_path = input("Enter image path:")
target_path = input("Enter target path:")

img_input = cv2.imread(input_path, 1)
img_target = cv2.imread(target_path, 1)

# Define Threshold
input_thresh = input("Enter threshold:")
threshold = float(input_thresh)

found = int(False)
# Execute Template Matching algorithm
matching_map, found = TemplateMathing(img_input, img_target, threshold)

# Create result image
font = cv2.FONT_HERSHEY_SIMPLEX

# Check if target is found and print the proper output
if found == 1:
    img_found = np.zeros((40, 245, 3), np.uint8)
    cv2.putText(img_found, "TARGET FOUND", (5, 30), font, 1, (0, 255, 0), 2)
if found == 0:
    img_found = np.zeros((40, 320, 3), np.uint8)
    cv2.putText(img_found, "TARGET NOT FOUND", (5, 30), font, 1, (0, 0, 255), 2)

# Show Images
cv2.imshow("Input Image", img_input)
cv2.imshow("Target Image", img_target)
cv2.imshow("MatchingMap", matching_map)
cv2.imshow("Result", img_found)

def closeWin():
    key = cv2.waitKey(0)
    if key == 27: #ESC
        print("CLEAR ALL")
        cv2.destroyAllWindows()

closeWin()
