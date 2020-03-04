---
title: Media Readme
description: Tips on uploading images
author: geduardo
ms.author: v-edsanc@microsoft.com
ms.date: 03/04/2020
ms.topic: readme
---

# README
**IMPORTANT**: to have the images rendering properly in dark mode you must avoid transparencies.
- For .jpg files you don't need to do anything since the file format doesn't support transparent elements.
- For .png files you must add a white background or change the value of the alpha channel to 100. The easiest way to do this in Windows is by opening the file in Paint and saving, overwritting the original file.
- For .svg files you must add a white rectangle in the lowest layer. You can do this with Inkscape:
  - Open the .svg file.
  - Select the square maker tool and draw a white rectangle on top of the original figure.
  - Select the tool "Select and transform objects" by clicking in the dark arrow or pressing F1.
  - While having the rectangle selected, click in the toolbar element "Lower selection to bottom (End)".
  - Adjust the rectangle with the mouse or the arrow keys.
