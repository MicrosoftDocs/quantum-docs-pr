---
title: Setting up the Q# development environment 
author: QuantumWriter
ms.author: Alan.Geller@microsoft.com 
ms.date: 12/11/2017
ms.topic: article
uid: microsoft.quantum.install
---

# Getting Started with the Quantum Development Kit

The Quantum Development Kit can be used on a variety of platforms (Windows, Linux, Mac) and with a variety of development environments (Visual Studio, Visual Studio Code, or the command line).  Additionally, Q# quantum programs are executed on one of many target machines provided by the Quantum Development Kit (e.g., full-state simulator, trace simulator or resource estimator).  These target machines can be invoked from any .NET host language, or from Python. Here is a guide to configuring the Quantum Development Kit for each platform and host language in the manner most natural for that platform and host language.   

The Quantum Development Kit can be used either with the Visual Studio 2017 integrated development environment, or a development editor such as Visual Studio Code.
Alternatively, the Quantum Development Kit can be used with the [command line directly](xref:microsoft.quantum.install.cmd-line).  A separate section gives additional information on how to integrate with [Python](xref:microsoft.quantum.install.python).

<table>
<tr>
<td>
[<img src="../media/install-guide-select-vs-2017.png" width="90%">](xref:microsoft.quantum.install.vs-2017)
<div class="nextstepaction">
[Install on Visual Studio 2017 (Windows 10)](xref:microsoft.quantum.install.vs-2017)
</div>
</td>

<td>
[<img src="../media/install-guide-select-vs-code.png" width="90%">](xref:microsoft.quantum.install.vs-code)
<div class="nextstepaction">
[Install on Visual Studio Code (Windows 10, macOS, or Linux)](xref:microsoft.quantum.install.vs-code)
</div>
</td>
</tr>
</table>

> [!NOTE]
> The Quantum Development Kit requires a 64-bit installation of Windows 10, macOS, or Linux.
> Microsoft's quantum simulator, installed with the Quantum Development Kit, utilizes Advance Vector Extensions (AVX), and thus can run significantly more efficiently on an AVX-enabled CPU.
> The Quantum Development Kit will still run on non–AVX enabled CPUs, but may not be as efficient.
> Intel processors shipped in Q1 2011 (Sandy Bridge) or later support AVX.

