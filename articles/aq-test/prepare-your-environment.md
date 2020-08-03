---
title: Prepare your environment to use Azure Quantum
description: This document provides the information about how to install the necessary tools on your computer to submit Q# programs to Azure Quantum from the command line.
author: KittyYeungQ
ms.author: kitty
ms.date: 06/29/2020
ms.topic: article
uid: microsoft.azure.quantum.setup.cli
---

# Prepare your environment to use Azure Quantum

In this guide you will find the information about how to install the necessary
tools on your computer to submit Q# programs to Azure Quantum from the command
line.

## Prerequistites

- The [Quantum Development
  Kit](https://docs.microsoft.com/quantum/install-guide/standalone).
- Latest version of the [Azure
  CLI](https://docs.microsoft.com/cli/azure/install-azure-cli?view=azure-cli-latest),
  (version 2.5.0 or higher).

## Installation

Install the extension using the following command:

```bash
    az extension add --source https://msquantumpublic.blob.core.windows.net/az-quantum-cli/quantum-latest-py3-none-any.whl
```

## Update the extension

If you need to update the `quantum` extension for the Azure CLI:

1. Remove the existing version:

    ```bash
    az extension remove -n quantum
    ```

1. Follow the installation guide above.

## Set the prerelease feed (for private review only)

Notice the Q# samples in this repository require access to pre-release packages
available in the [public Microsoft Quantum pre-release
feed](https://dev.azure.com/ms-quantum-public/Microsoft%20Quantum%20(public)/_packaging?_a=feed&feed=alpha).
To enable this access you will need to copy the
[NuGet.config](~/samples/qsharp/NuGet.Config) file from our samples to the
folder (or one of its parents) where your Q# project is located.

## Next steps

Now that you have installed the tools to use Azure Quantum, learn how to [submit
jobs to Azure Quantum](xref:microsoft.azure.quantum.submit-jobs.azcli).
