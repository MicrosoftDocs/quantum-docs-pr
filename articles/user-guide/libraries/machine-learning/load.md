---
title: Loading classical data
description: Learn how to load your own dataset to train a classifier model with the Microsoft Quantum Development Kit (QDK).
author: geduardo
ms.author: v-edsanc@microsoft.com
ms.date: 02/16/2020
ms.topic: article
uid: microsoft.quantum.libraries.machine-learning.load
no-loc: ['Q#', '$$v']
---

# Load and classify your own datasets

In this short tutorial, we are going to learn how to load your own dataset to train a classifier model with the Quantum Development Kit (QDK).

We highly recommend the use of a standardized serialization format such as [JSON files](https://en.wikipedia.org/wiki/JSON) to store your data.
Such formats offer high compatibility with different frameworks like Python and the .NET ecosystem.
In particular, we recommend using our template for loading the data, so that you can copy-paste the code directly from the samples.

## Template for loading your datasets

Suppose we have a training dataset $(x, y)$ of size $N=2$ where each instance $x_i$ of $x$ has three features: $x_{i1}$, $x_{i2}$ and $x_{i3}$.
The validation dataset has the same structure.
These datsets can be represented by a `data.json` file similar to the following:

```json
{
    "TrainingData": {
        "Features": [
            [
                x_11,
                x_12,
                x_13
            ],
            [
                x_21,
                x_22,
                x_23
            ]
        ],
        "Labels": [
            y_1,
            y_2
        ]
    },
    "ValidationData": {
        "Features": [
            [
                xv_11,
                xv_12,
                xv_13
            ],
            [
                xv_11,
                xv_12,
                xv_13
            ]
        ],
        "Labels": [
            yv_1,
            yv_2
        ]
    }
}
```

### Example using the template

Suppose we have a small dataset with the heights and weights of different cats and dogs. This dataset is very small to train a model but will be enough to show the process of loading a dataset.

| Height (m) | Weight (kg) | Animal |
|-----------|------------|--------|
| 0.54      | 30         | Dog    |
| 0.30      | 8          | Cat    |
| 0.91      | 44         | Dog    |
| 0.86      | 31          | Dog    |
| 0.32      | 5         | Cat    |
| 0.25      | 4          | Cat    |

The process is:

- First we need to separate the dataset into training and validation. In this case we can just take the first three samples for training and the rest of samples for validation. In general it is a good practice to sample randomly the training and validation dataset to avoid unwanted biases in the training data.
- Secondly, we need to assign a numeric label to each class. Note that, for the moment, the QML library only admits binary classification problems. So we will assign the label 0 to the class `Dog` and the number 1 to the class `Cat`.
- Finally, we fill the template using the data from our dataset. Note that for big datasets you should build a small script to automatically generate the template from your specific dataset. This script will depend on the original format of your dataset.

For our dataset the `data.json` file is:

```json
{
    "TrainingData": {
        "Features": [
            [
                0.54,
                30
            ],
            [
                0.30,
                8
            ],
            [
                0.91,
                44
            ]
        ],
        "Labels": [
            0,
            1,
            0
        ]
    },
    "ValidationData": {
        "Features": [
            [
                0.86,
                31
            ],
            [
                0.32,
                5
            ]
            [
                0.25,
                4
            ]
        ],
        "Labels": [
            0,
            1,
            1
        ]
    }
}

```

## Loading the data

Once you have your data serialized as a JSON file, you can load it in using JSON libraries provided with your host language of choice.

### [Python](#tab/tabid-python)

Python provides the [built-in `json` package](https://docs.python.org/3.7/library/json.html) for working with JSON-serialized data:

:::code language="python" source="~/quantum/samples/machine-learning/half-moons/host.py" range="4-5,20-22":::

### [C#](#tab/tabid-csharp)

The .NET Core platform provides the [`System.Text.Json` package](https://www.nuget.org/packages/System.Text.Json) for working with JSON-serialized data:

:::code language="csharp" source="~/quantum/samples/machine-learning/half-moons/Host.cs" range="10,64-82":::

***

## Next steps

Now you are ready to start running your own experiments with your own datasets. Try different classifiers and dataset and contribute to the community sharing your results!
