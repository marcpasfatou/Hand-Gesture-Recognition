# Hand-Gesture-Recognition
A very simple project which detects hand and number of digits with fingers. The goal was to familiarize myself with C sharp and openCV.

![overview](https://raw.githubusercontent.com/marcpasfatou/Hand-Gesture-Recognition/master/overview.png)

First, we segment the hand using a skin tone detection algorithm. I used the ratio between the Red, green, and blue value to determine if a pixel was skin or not.


![segmentation](https://raw.githubusercontent.com/marcpasfatou/Hand-Gesture-Recognition/master/segmentation.png)

I assumed the biggest continuous area was the hand. A bounding box is generated using the blob detection form OpenCV.

![blob](https://raw.githubusercontent.com/marcpasfatou/Hand-Gesture-Recognition/master/blob.png)

Finally, by using crops and intensity value, I get a pretty accurate detection of fingers.

![hist](https://raw.githubusercontent.com/marcpasfatou/Hand-Gesture-Recognition/master/hist.png)
