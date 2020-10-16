---
title: Setting up the Microsoft Quantum Development Kit (QDK)
description: Learn how to set up the Microsoft Quantum Development Kit for different environments.
author: bradben
ms.author: v-benbra
ms.date: 5/8/2020
ms.topic: article
ms.custom: how-to
uid: microsoft.quantum.install
no-loc: ['Q#', '$$v']
---

# Setting up the Microsoft Quantum Development Kit (QDK)

Learn how to set up the Microsoft Quantum Development Kit (QDK) for your environment, so that you can get started with quantum programming. The QDK consists of:

- The Q# programming language
- A set of libraries that abstract complex functionality in Q#
- APIs for Python and .NET languages (C#, F#, and VB.NET) for running quantum programs written in Q#
- Tools to facilitate your development

Q# programs can run as standalone applications using Visual Studio Code or Visual Studio, through Jupyter Notebooks with the IQ# Jupyter kernel, or paired with a host program written in Python or a .NET language (C#, F#). You can also run Q# programs online using [Codespaces](https://online.visualstudio.com/), [MyBinder.org](https://mybinder.org/), or [Docker](#use-the-qdk-with-docker). 

## Options for setting up the QDK

You can use the QDK in three ways:

- [Install the QDK locally](#install-the-qdk-locally)
- [Use the QDK online](#use-the-qdk-online)
- [Use a QDK Docker image](#use-the-qdk-with-docker)

## Install the QDK locally

You can develop Q# code in most of your favorites IDEs, as well as integrate Q# with other languages such as Python and .NET (C#, F#).

|&nbsp; | **VS Code<br>(2019 or later)**| **Visual Studio<br>(2019 or later)** | **Jupyter Notebooks** | **Command line**|
|:-----|:-----:|:-----:|:-----:|:-----:|
|**OS** |Windows, macOS, Linux |Windows only |Windows, macOS, Linux |Windows, macOS, Linux |
|<br>**Q# standalone** |<br>[Install](xref:microsoft.quantum.install.standalone) |<br> [Install](xref:microsoft.quantum.install.standalone)  |<br> [Install](xref:microsoft.quantum.install.jupyter) |<br>[Install](xref:microsoft.quantum.install.standalone)|
|**Q#  and Python** |[Install](xref:microsoft.quantum.install.python) |[Install](xref:microsoft.quantum.install.python) |[Install](xref:microsoft.quantum.install.jupyter) |[Install](xref:microsoft.quantum.install.python) |
|**Q# and .NET (C#, F#)**|[Install](xref:microsoft.quantum.install.cs) |[Install](xref:microsoft.quantum.install.cs)|&#10006; |[Install](xref:microsoft.quantum.install.cs) |

## Use the QDK Online

You can also develop Q# code without installing anything locally with these options:

|Resource|Advantages|Limitations|
|---|---|---|
|[**Visual Studio Codespaces**](xref:microsoft.quantum.install.standalone)|A rich online development environment  |Requires an Azure subscription and plan |
|[**Binder**](xref:microsoft.quantum.install.binder) | Free online notebook experience |No persistence |

## Use the QDK with Docker

You can use our QDK Docker image in your local Docker installation or in the cloud via any service that supports Docker images, such as ACI.

You can download the IQ# Docker image from https://github.com/microsoft/iqsharp/#using-iq-as-a-container. 

You can also use Docker with a Visual Studio Code Remote Development Container to quickly define development environments. For more information about VS Code Development Containers, see https://github.com/microsoft/Quantum/tree/master/.devcontainer.

## Next steps

The workflows for each of these setups are described and compared at [Ways to run a Q# program](xref:microsoft.quantum.guide.host-programs).
