---
marp: true
footer: "Created by fls2134"
paginate: true
theme: gaia
style: |
  section { background: rgb(241, 237, 234); }
  p { font-size: 24px; }
  li { font-size: 18pt; }
  h1 { font-size: 28pt; }
  h2 { font-size: 24pt; font-weight: normal; }
  h3 { font-size: 23pt; }
  h4 { font-size: 22pt; }
  h5 { font-size: 20pt; }
  h6 { font-size: 18pt; }
  table { font-size: 20px; }
---

# 6주차: Computer Vision

## ✨ 이미지 밝기 조절

### Goal
- `cv.convertScaleAbs()`로 이미지 밝기 조절하는 방법 학습
- `cv.createTrackbar()`, `cv.getTrackbarPos()`로 실시간 밝기 조절

---

## 💻 Code Demo

```python
import cv2 as cv
import numpy as np

def nothing(x):
    pass

img = cv.imread('lena.jpg')
img = cv.resize(img, (500, 500))
if img is None:
    raise FileNotFoundError('lena.jpg 파일을 찾을 수 없습니다.')

cv.namedWindow('Brightness Adjust')
cv.createTrackbar('Beta', 'Brightness Adjust', 100, 200, nothing)

while True:
    beta = cv.getTrackbarPos('Beta', 'Brightness Adjust') - 100
    adjusted = cv.convertScaleAbs(img, alpha=1.0, beta=beta)
    cv.imshow('Brightness Adjust', adjusted)
    if cv.waitKey(1) & 0xFF == 27:
        break

cv.destroyAllWindows()
