import numpy as np
import cv2

def ex1():
    print("EX_1")
    arr = np.zeros(shape=(1, 10))
    print(arr)

ex1()

def ex2():
    print("EX_2")
    arr = np.zeros(shape=(1, 10))
    arr[ :, 4] = 5
    print(arr)

ex2()

def ex3():
    print("EX_3")
    arr = np.arange(10, 50)
    print(arr)

ex3()

def ex4():
    print("EX_4")
    arr = np.arange(1, 10)
    arr = arr.reshape((3, 3))
    print(arr)

ex4()

def ex5():
    print("EX_5")
    arr = np.arange(1, 10)
    arr = arr.reshape((3, 3))
    arr = np.fliplr(arr)

    print(arr)

ex5()

def ex6():
    print("EX_6")
    arr = np.arange(1, 10)
    arr = arr.reshape((3, 3))
    arr = np.flipud(arr)

    print(arr)

ex6()

def ex7():
    print("EX_7")
    arr = np.identity(3, int)
    print(arr)

ex7()

def ex8():
    print("EX_8")
    arr = np.random.random_sample((3, 3))
    print(arr)

ex8()

def ex9():
    print("EX_9")
    arr = np.random.randint(-100, 100, 10)
    average = arr.mean()

    print(arr)
    print(average)

ex9()

def ex10():
    print("EX_10")
    arr = np.ones(shape=(10, 10))
    arr[1:9, 1:9] = 0

    print(arr)

ex10()

def ex11():
    print("EX_11")

    rows = 1
    stacking = True
    arr = np.arange(1, 6)

    while stacking:
        arr2 = np.arange(1, 6)
        arr = np.vstack((arr, arr2))
        rows += 1
        if rows == 5:
            stacking = False

    print(arr)

ex11()

def ex12():
    print("EX_12")
    arr = np.random.randint(-100, 100, 9)
    arr = arr.reshape((3, 3))
    arr = np.float64(arr)

    print(arr)

ex12()

def ex13():
    print("EX_13")
    arr = np.random.randint(-100, 100, (5, 5))
    print(arr)
    av = arr.mean()
    arr = arr - av

    print(av)
    print(arr)

ex13()

def ex14():
    print("EX_14")
    arr = np.random.randint(-100, 100, (5, 5))
    arr = np.float64(arr)

    for i in range(0, 5):
        av = arr[i, :].mean()
        arr[i, :] = np.subtract(arr[i, :], av)

    print(arr)

ex14()

def ex15():
    print("EX_15")
    value = 0.5
    arr = np.random.random_sample((5, 5))

    print(arr)
    print(arr.flat[np.abs(arr - value).argmin()])

ex15()

def ex16():
    print("EX_16")
    arr = np.random.randint(0, 10, 9)
    arr = arr.reshape((3, 3))
    count = np.size(arr[arr > 5])
    print(count)

ex16()

def ex17():
    print("EX_17")
    img = np.zeros((64, 64))
    grad = np.arange(0.0, 1.0, 1.0/64.0)
    img = img + grad
    cv2.imshow("image17", img)

ex17()

def ex18():
    print("EX_18")
    img = np.zeros((64, 64))
    grad = np.arange(0.0, 1.0, 1.0/64.0)
    grad = grad.reshape((64, 1))
    img = img + grad

    cv2.imshow("image18", img)

ex18()

def ex19():
    print("EX_19")
    img = 255 * np.ones((64, 64, 3), np.uint8())
    img[:, :, 0] = 0.0

    cv2.imshow("yellow", img)

ex19()

def ex20():
    print("EX_20")
    img = 255 * np.ones((64, 64, 3), np.uint8())
    img[:32, :32, 0] = 0.0
    img[32:, 32:, 2] = 0.0

    cv2.imshow("square", img)

ex20()

def ex21():
    print("EX_21")
    img = cv2.imread("images/sonic.jpg", 1)
    img[::2, :, :] = 255/2

    cv2.imshow("horScanSonic", img)

ex21()

def ex22():
    print("EX_22")
    img = cv2.imread("images/sonic.jpg", 1)
    img[:, ::2, :] = 255/2

    cv2.imshow("verScanSonic", img)

ex22()

def ex23():
    print("EX_23")
    img = cv2.imread("images/sonic.jpg", 1)

    img2 = np.float64(img)
    cv2.imshow("float", img2)

    cv2.normalize(img2, img)
    cv2.imshow("normalized", img)

    img = img / img.max()
    img = img * 0.5

    cv2.imshow("darkSonic", img)

ex23()

#start test numpy part 2
print("EXERCISES PART 2")

def ex_1():
    print("EX_1")
    img = cv2.imread("images/lena_noise.jpg", 1)

    ishape = 'Shape: ' + "{}".format(img.shape)
    itype = 'Type: ' + "{}".format(img.dtype)
    idim = 'Dimensions: ' + "{}".format(img.shape[2])

    black = (0, 0, 0)
    fontscale = 0.5
    thickness = 1

    img = cv2.putText(img, ishape, (5, 20), cv2.FONT_HERSHEY_SIMPLEX, fontscale, black, thickness, cv2.LINE_AA)
    img = cv2.putText(img, itype, (5, 40), cv2.FONT_HERSHEY_SIMPLEX, fontscale, black, thickness, cv2.LINE_AA)
    img = cv2.putText(img, idim, (5, 60), cv2.FONT_HERSHEY_SIMPLEX, fontscale, black, thickness, cv2.LINE_AA)

    cv2.imshow("TEXT", img)

ex_1()

def ex_2():
    print("EX_2")
    img = cv2.imread("images/lena_noise.jpg", 1)

    img = np.float64(img)
    img = img / img.max()

    cv2.imshow("Floating IMG", img)

ex_2()

def ex_3():
    print("EX_3")
    img = cv2.imread("images/rice.jpg", 0)
    (thresh, img) = cv2.threshold(img, 128, 255, cv2.THRESH_BINARY | cv2.THRESH_OTSU)

    cv2.imshow('Binary Img', img)

ex_3()

def ex_4():
    print("EX_4")
    img = cv2.imread("images/lena_noise.jpg", 1)
    img2 = np.copy(img) * 0
    rows, cols = img.shape[:2]

    kernX = cv2.getGaussianKernel(cols, 90)
    kernY = cv2.getGaussianKernel(rows, 90)
    kern = kernY*kernX.T
    vignMask = kern/kern.max()
    img2[:, :, 0] = img[:, :, 0] * vignMask
    img2[:, :, 1] = img[:, :, 1] * vignMask
    img2[:, :, 2] = img[:, :, 2] * vignMask

    cv2.imshow("Vignette", img2)

ex_4()

def ex_5():
    print("EX_5")
    img = cv2.imread("images/sonic.jpg", 1)
    img = ~img

    cv2.imshow('Negative img', img)

ex_5()

def ex_6():
    print("EX_6")
    img = cv2.imread("images/sonic.jpg", 1)

    img[:, :, 1] = img[:, :, 1]/2
    img[:, :, 2] = img[:, :, 2]/2

    cv2.imshow('BlueTint Img', img)

ex_6()

def ex_7():
    print("EX_7")
    img = cv2.imread("images/sonic.jpg", 1)

    #Both two options works
    final_img = cv2.addWeighted(img, 2.0, img, 0, 0)
    #final_img = cv2.convertScaleAbs(img, alpha=1.35, beta=0.0)

    cv2.imshow('contrast', final_img)

ex_7()

def bi_fi():
    print("Bilateral Filter")
    img = cv2.imread("images/lena_noise.jpg", 1)

    final_img = cv2.bilateralFilter(img, 10, 100, 100)

    cv2.imshow('bilateral', final_img)

bi_fi()

def edge():
    print("Edge Detection")
    img = cv2.imread("images/sonic.jpg", 1)
    edges = cv2.Canny(img, 195, 200)

    cv2.imshow('Edge Detection', edges)

edge()

def closeWin():
    print("CLEARALL")

    key = cv2.waitKey(0)
    if key == 27: #ESC
        cv2.destroyAllWindows()

closeWin()
