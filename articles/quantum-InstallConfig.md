---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Intent and product brand in a unique string of 43-59 chars including spaces | Microsoft Docs 
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

# Setting Up Development Environment

## Prerequisites

To use Quantum Development Kit, you need [Visual Studio](https://www.visualstudio.com/) 2017 (any edition).

## Installing Quantum Developer Kit

Download and install [Microsoft Quantum Developer Kit](https://solidrepo.blob.core.windows.net/alpha/latest/QbVSIX.vsix) Visual Studio extension. 
Note that some browsers (IE and Edge) might save this file as `QbVSIX.zip` during download, which makes it impossible to install. 
In this case, rename it back to `QbVSIX.vsix` or use a different browser (Firefox or Chrome) to open download link.

## Configuring NuGet feed

Configure Visual Studio to use QuArC alpha NuGet feed  
<https://quarcsw.pkgs.visualstudio.com/_packaging/alpha/nuget/v3/index.json>, as described
[here](https://www.visualstudio.com/en-us/docs/package/nuget/consume).

## Validating Setup

* Clone [Libraries](https://quarcsw.visualstudio.com/_git/Libraries) repository.

* Open `Libraries\QbLibs\QbLibs.sln` solution.

* Build the solution. If needed, restore NuGet packages manually first.

* To run teleport example: right click on `TeleportationExample` project, left click "Set as Startup Project", run it (Ctrl-F5). Output should look like this:

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

* To run chemistry example: right click on `H2SimulationExample` project, left click "Set as Startup Project", run it (Ctrl-F5).