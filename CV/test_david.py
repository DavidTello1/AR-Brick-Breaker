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

    #Downscaling images

    downscale = 60
    iw = int(W * downscale / 100)
    ih = int(H * downscale / 100)
    rescale_input = (iw, ih)
    resized_Igray = np.zeros((iw, ih))
    cv2.resize(input_gray, rescale_input, resized_Igray, interpolation=cv2.INTER_AREA)

    tw = int(w * downscale / 100)
    th = int(h * downscale / 100)
    rescale_target = (tw, th)
    resized_Tgray = np.zeros((tw, th))
    cv2.resize(target_gray, rescale_target, resized_Tgray, interpolation=cv2.INTER_AREA)

    #---------------------------------------------------------------------------#
#     temp_found = None
#     for scale in np.linspace(0.2, 1.0, 20)[::-1]:
#         #resize the image and store the ratio
#         resized_img = imutils.resize(gray_image, width = int(gray_image.shape[1] * scale))
#         ratio = gray_image.shape[1] / float(resized_img.shape[1])
#         if resized_img.shape[0] < height or resized_img.shape[1] < width:
#             break
#         #Convert to edged image for checking
#         #e = cv2.Canny(resized_img, 10, 25)
#         match = cv2.matchTemplate(e, template, cv2.TM_CCOEFF)
#     (_, val_max, _, loc_max) = cv2.minMaxLoc(match)
#    if temp_found is None or val_max>temp_found[0]:
#       temp_found = (val_max, loc_max, ratio)
# #Get information from temp_found to compute x,y coordinate
#     (_, loc_max, r) = temp_found
#     (x_start, y_start) = (int(loc_max[0]), int(loc_max[1]))
#     (x_end, y_end) = (int((loc_max[0] + width)), int((loc_max[1] + height)))
# #Draw rectangle around the template
#     cv2.rectangle(main_image, (x_start, y_start), (x_end, y_end), (153, 22, 0), 5)

    
    #---------------------------------------------------------------------------#

    # Create empty Matching Map
    matchMap = np.zeros(shape=(W-w+1, H-h+1), dtype=float)

    for x in range(0, W-w+1):
        for y in range(0, H-h+1):
            # sum of squared diferences
            matchMap[x][y] = np.sum(np.square(resized_Tgray[:, :] - resized_Igray[x:x+tw, y:y+th]))

    matchMap = matchMap / matchMap.max()
    loc = np.where(matchMap < Threshold)

    if loc:
        for pt in zip(*loc[::-1]):
            Found = int(True)
            cv2.rectangle(Input, pt, (pt[0] + w, pt[1] + h), (0, 255, 0), 1)

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
