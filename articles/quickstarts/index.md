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

<table>
    <tr>
        <th width=10%>&nbsp;</th>
        <th>&nbsp;</th>
        <th align="center" width=18%><img src="~/media/vs_code.png" alt="VS Code" width="50"/><br><b>VS Code<br>(2019 or later)</b></th>
        <th align="center" width=18%><img src="~/media/vs_studio.png" alt="Visual Studio" width="50"/><br><b>Visual Studio<br>(2019 or later)</b></th>
        <th align="center" width=18%><img src="~/media/jupyter-wht.png" alt="jupyter install" width="65"/><br><b>Jupyter Notebooks</b></th>
        <th align="center" width=18%><img src="~/media/blank.png" alt="blank spacer" width="65"/><br><b>Command line</b></th>
    </tr>
    <tr>
        <th>&nbsp;</th>
        <td align="left"><b>OS support:</b></td>
        <td align="center">Windows, macOS, Linux</td>
        <td align="center">Windows only</td>
        <td align="center">Windows, macOS, Linux</td>
        <td align="center">Windows, macOS, Linux</td>
    </tr>
    <tr>
        <td align="right"><img src="~/media/quantum-wht.png" alt="QDK" width="60"/></td>
        <td align="left"><b>Q# standalone</b></td>
        <td align="center"><a href="xref:microsoft.quantum.install.standalone">Install</a></td>
        <td align="center"><a href="xref:microsoft.quantum.install.standalone">Install</a></td>
        <td align="center"><a href="xref:microsoft.quantum.install.jupyter">Install</a></td>
        <td align="center"><a href="xref:microsoft.quantum.install.standalone">Install</a></td>
    </tr>
    <tr>
        <td align="right"><img src="~/media/python.png" alt="python install" width="50"/></td>
        <td align="left"><b>Q# and Python</b></td>
        <td align="center"><a href="xref:microsoft.quantum.install.python">Install</a></td>
        <td align="center"><a href="xref:microsoft.quantum.install.python">Install</a></td>
        <td align="center"><a href="xref:microsoft.quantum.install.python">Install</a></td>
        <td align="center"><a href="xref:microsoft.quantum.install.python">Install</a></td>
    </tr>
    <tr>
        <td align="right"><img src="~/media/dot_net.png" alt="dotnet install" width="50"/></td>
        <td align="left"><b>Q# and .NET (C#, F#)</b></td> 
        <td align="center"><a href="xref:microsoft.quantum.install.cs">Install</a></td>
        <td align="center"><a href="xref:microsoft.quantum.install.cs">Install</a></td>
        <td align="center">&#10006;</td>
        <td align="center"><a href="xref:microsoft.quantum.install.cs">Install</a></td>
   </tr>
</table>

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
