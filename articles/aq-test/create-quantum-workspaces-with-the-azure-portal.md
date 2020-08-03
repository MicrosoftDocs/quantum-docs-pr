---
title: Create quantum workspaces with the Azure portal
description: This guide will show you how to create resource groups and quantum workspaces with the Azure portal to start executing your quantum applications in Azure Quantum.
author: KittyYeungQ
ms.author: kitty
ms.date: 06/29/2020
ms.topic: article
uid: microsoft.azure.quantum.workspaces-portal
---

# Create quantum workspaces with the Azure portal

This guide will show you how to create resource groups and quantum workspaces
with the Azure portal to start executing your quantum applications in Azure
Quantum.

## Prerequisites

Azure Quantum is very similar to other Azure services. This means that to deploy
resources you need an Azure subscription in order to use the service. 

> [!NOTE]
> If you don't have an Azure subscription and you want to learn how to
> create an Azure account, check out our Microsoft Learn module [Create an Azure
> account](https://docs.microsoft.com/learn/modules/create-an-azure-account/).

## Create a quantum workspace

You first need to deploy an Azure Quantum resource into your Azure subscription.
This resource is called a quantum workspace and it's a collection of assets
associated with executing quantum or quantum inspired applications. Since this
is Private Preview the experience is currently hidden from the general public
and shown to a limited audience such as yourself. To get started go to
https://aka.ms/quantum-workspaces and follow the next steps:

1. Click **Create a resource** and then do a search for "Azure Quantum". You
   should see a tile for the **Azure Quantum (preview)** service.

   ![Tile for the Azure Quantum (preview)
   service](../media/azure-quantum-preview-tile.png)

1. Click on the tile and then click on **Create**. This will lead you to a form
   to create a Quantum Workspace.

1. Now you need to fill the details of your project:
   - **Subscription:** the subscripition you want to associate with this
     resource. 
   - **Resource group:** the resource group you want to assign this project to.
   - **Name:** the name of your quantum workspace.
   - **Region:** the region of the resource. For this private preview you should
     choose "(US) East US 2 EUAP".
   - **Storage Account**: Storage account is where your jobs and their results
     will be stored. If you don't have already an storage account you can create
     one by clicking in **Create a new storage account** and filling the small
     form. We recommend you to use the default values for this guide.

> [!NOTE] 
> A resource group is a collection of resources that share the same
> lifecycle, permissions, and policies. If you want to learn more about how
> resources groups work in Azure check out the Microsoft Learn module [Control
> and organize Azure resources with Azure Resource
> Manager](https://docs.microsoft.com/learn/modules/control-and-organize-with-azure-resource-manager/).

> [!NOTE] 
> While we are not charging for usage of Azure Quantum during the private
> preview, your jobs will be uploaded to the Azure storage account created above,
> and will be subject to storage charges.

1. After filling the information, click on the "Providers" tab to add providers
   to your workspace. A provider gives you access to a quantum service, that can
   be quantum hardware, a simulator or a quantum inspired optimization service.

   ![Providers](../media/create-providers.png)

1. After adding the providers you want to use, click on "Review + create".

1. Review the settings. You should approve the *Terms and Conditions of Use* of
   the selected providers. If everything is correct click on "Create" to create
   your quantum workspace.

   ![Review](../media/review-providers.png)

## Next steps

Now that you created a workspace, learn about the different [targets to execute
quantum algorithms in Azure
Quantum](xref:microsoft.azure.quantum.concepts.targets).