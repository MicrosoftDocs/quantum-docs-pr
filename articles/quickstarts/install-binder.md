---
title: Develop with Q# and Binder
description: Learn how to create a Q# application using Binder.
author: bradben
ms.author: v-benbra
ms.date: 9/03/2020
ms.topic: quickstart
uid: microsoft.quantum.install.binder
no-loc: ['Q#', '$$v']
---
# Develop with Q# and Binder

You can use Binder to run and share your Jupyter Notebooks online.

## Use Binder with the Microsoft QDK samples

To configure Binder automatically to use the Microsoft QDK samples:

1. Open a browser and run https://aka.ms/try-qsharp.
1. On the **Quantum Development Kit Samples** landing page, click **Q# notebook** to learn how to use IQ# to write your own quantum application notebooks.

![QDK landing page](~/media/binder-install.png)

## Use Binder with your own notebooks and repository

If you already have notebooks in a GitHub repository, you can configure Binder to work with your repo:

1. Ensure that there is a file named *Dockerfile* in the root of your repository. The file must contain at least the following lines:

    ```bash
    FROM mcr.microsoft.com/quantum/iqsharp-base:0.12.20082513
    
    USER root
    COPY . ${HOME}
    RUN chown -R ${USER} ${HOME}
    
    USER ${USER}
    ```

    > [!NOTE]
    > You can verify the most current version of IQ# in the [Release Notes](xref:microsoft.quantum.relnotes).

    For more information about creating a Dockerfile, see the [Dockerfile reference](https://docs.docker.com/engine/reference/builder/).

2. Open a browser to [mybinder.org](https://mybinder.org).
3. Enter your repository name as the **GitHub URL** (for example *MyName/MyRepo*), and click **launch**.

![MyBinder form](~/media/mybinder.png)
    
## Next steps

Now that you have set up your Binder environment, you can write and run [your first quantum program](xref:microsoft.quantum.quickstarts.qrng).
