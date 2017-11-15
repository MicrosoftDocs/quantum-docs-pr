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

Confirm that you have [Visual Studio](https://www.visualstudio.com/) 2017 installed.

## Creating the Q# development environment 

1. Download and install [Microsoft Quantum Developer Kit](https://solidrepo.blob.core.windows.net/alpha/latest/QbVSIX.vsix) Visual Studio extension. 
Some browsers (IE and Edge) will save this file as `QbVSIX.zip` during download. In this case, rename it back to `QbVSIX.vsix`.

1. Start the VSIX installer by double clicking the `QbVSIX.vsix` file and follow the prompts to install the extension.

1. Configure Visual Studio to use the [QuArC beta NuGet](https://quarcsw.pkgs.visualstudio.com/_packaging/alpha/nuget/v3/index.json) feed, as described
in [Consume NuGet packages in Visual Studio](https://www.visualstudio.com/en-us/docs/package/nuget/consume).

## Validating your setup

1. Clone the [Libraries](https://quarcsw.visualstudio.com/_git/Libraries) repository.

2. Open `Libraries\QbLibs\QbLibs.sln` solution.

3. If needed, restore NuGet packages manually as described in [NuGet package restore](https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore).

4. Validate your Q# environment by running the teleport example: 
   1. Right click on `TeleportationExample` project in the Libraries solution, and left click "Set as Startup Project".
   2. Run the solution (Ctrl-F5.) If teleport runs and the output is as follows, your Q# environment is ready to support your development.
<!---
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
--->

```
        Round 0:        Sent True,      got True. Teleportation successful!!
        Round 1:        Sent False,     got False. Teleportation successful!!
        Round 2:        Sent False,     got False. Teleportation successful!!
        Round 3:        Sent True,      got True. Teleportation successful!!
        Round 4:        Sent True,      got True. Teleportation successful!!
        Round 5:        Sent False,     got False. Teleportation successful!!
        Round 6:        Sent True,      got True. Teleportation successful!!
        Round 7:        Sent False,     got False. Teleportation successful!!
```

