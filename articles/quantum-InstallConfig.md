---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Setting up the Q# development environment 
description: 115-145 characters including spaces. Edit the intro para describing article intent to fit here. This abstract displays in the search result.
services: service-name-with-dashes-AZURE-ONLY 
keywords: Don’t add or edit keywords without consulting your SEO champ.
author: QuantumWriter
ms.author: MSFT-alias-person-or-DL
ms.date: 10/09/2017
ms.topic: article-type-from-white-list
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# ms.service: service-name-from-white-list
# product-name-from-white-list

# Optional fields. Don't forget to remove # if you need a field.
# ms.custom: can-be-multiple-comma-separated
# ms.devlang:devlang-from-white-list
# ms.suite: 
# ms.tgt_pltfrm:
# ms.reviewer:
# manager: MSFT-alias-manager-or-PM-counterpart
---

# Setting up the Q# development environment

This section specifies how to create a Q# development environment and validate it by running the teleport sample program.

## Checking prerequisites

If you have [Visual Studio](https://www.visualstudio.com/) 2017 installed, you're ready to install the Microsoft Quantum Developer Kit.

If you do not have Visual Studio installed, you can download Visual Studio 2017 Community Edition for free.
1. Go to the [Visual Studio download page](https://www.visualstudio.com/downloads/).
2. Click on the Visual Studio Community **Free download** button.
3. Navigate to the folder your browser uses for downloads and double click on the executable file whose name begins with **vs_community**. The file name will contain a sequence of numbers that varies.
1. _**Important!**_ When you are presented with the option to select the tools for specific workloads, check the boxes for **Universal Windows Platform development** and **.NET desktop development**
2. After selecting your workloads, click **Install** to complete the installation.

## Creating the Q# development environment 

1. Download and install [Microsoft Quantum Developer Kit](https://solidrepo.blob.core.windows.net/alpha/latest/QbVSIX.vsix) Visual Studio extension. 
Some browsers (IE and Edge) will save this file as `QbVSIX.zip` during download. In this case, rename it to `QbVSIX.vsix`.

1. If Visual Studio is open, close it.

1. Start the VSIX installer by double clicking the `QbVSIX.vsix` file and follow the prompts to install the extension.

1. Configure Visual Studio to use the QuArC beta NuGet feed. 
    - See [Consume NuGet packages in Visual Studio](https://www.visualstudio.com/en-us/docs/package/nuget/consume) for the configuration procedure. On that page, you should follow the instructions under the heading **Windows: Add the feed to your NuGet configuration**. The upper section is not required.
    - In that Windows section, the actions taken are in Visual Studio (which is not specified.)
    - You will need the quantum NuGet URL: https://quarcsw.pkgs.visualstudio.com/_packaging/alpha/nuget/v3/index.json.
    - Ignore step six: "6. If you enabled the nuget.org upstream source, uncheck the nuget.org package source."
    - Ignore the last line of the Windows section (after the image): "Then click here to continue."

## Validating your setup

1. Clone the quantum Libraries repository.
    1. Navigate to the [Libraries](https://quarcsw.visualstudio.com/_git/Libraries).
    2. Click the **Clone** button in the upper right.
    3. In the **Clone repo** pane, click **Clone in Visual Studio**.
    4. If presented with a login request, sign in using your Microsoft credentials.
    5. On the **Visual Studio Team Services** pane, click **Clone** to proceed.

2. Open the `Libraries\QbLibs\QbLibs.sln` solution. 
    - If prompted by the **Install Missing Features** pane, click **Install** to allow the installation of the necessary features. This is most often F# and tools.

3. If needed, restore NuGet packages manually as described in [NuGet package restore](https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore).

4. Validate your Q# environment by running the teleport example: 
   1. Right click on `TeleportationExample` project in the Libraries solution, and left click "Set as Startup Project".
   2. Run the solution (F5.) If teleport runs and the output is as follows, your Q# environment is ready to support your development.

```
        Round 0:        Sent True,      got True. 
        Teleportation successful!!
        Round 1:        Sent False,     got False. 
        Teleportation successful!!
        Round 2:        Sent False,     got False. 
        Teleportation successful!!
        Round 3:        Sent True,      got True. 
        Teleportation successful!!
        Round 4:        Sent True,      got True. 
        Teleportation successful!!
        Round 5:        Sent False,     got False. 
        Teleportation successful!!
        Round 6:        Sent True,      got True. 
        Teleportation successful!!
        Round 7:        Sent False,     got False. 
        Teleportation successful!!
```

