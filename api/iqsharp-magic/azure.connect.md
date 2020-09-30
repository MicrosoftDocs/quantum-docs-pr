---
title: '%azure.connect (magic command)'
author: rmshaffer
uid: microsoft.quantum.iqsharp.magic-ref.azure.connect
ms.author: rmshaffer
ms.date: 09/30/2020
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.AzureClient.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%azure.connect", "Documentation": {"Summary": "Connects to an Azure Quantum workspace or displays current connection status.", "Full": null, "Description": "\r\nThis magic command allows for connecting to an Azure Quantum workspace\r\nas specified by the resource ID of the workspace or by a combination of\r\nsubscription ID, resource group name, and workspace name.\r\n\r\nIf the connection is successful, a list of the available Q# execution targets\r\nin the Azure Quantum workspace will be displayed.\r\n\r\n#### Required parameters\r\n\r\nThe Azure Quantum workspace can be identified by resource ID:\r\n\r\n- `resourceId=<string>`: The resource ID of the Azure Quantum workspace.\r\nThis can be obtained from the workspace page in the Azure portal. The `resourceId=` prefix\r\nis optional for this parameter, as long as the resource ID is valid.\r\n\r\nAlternatively, it can be identified by subscription ID, resource group name, and workspace name:\r\n\r\n- `subscription=<string>`: The Azure subscription ID for the Azure Quantum workspace.\r\n- `resourceGroup=<string>`: The Azure resource group name for the Azure Quantum workspace.\r\n- `workspace=<string>`: The name of the Azure Quantum workspace.\r\n\r\n#### Optional parameters\r\n\r\n- `refresh`: Bypasses any saved or cached credentials when connecting to Azure.\r\n- `storage=<string>`: The connection string to the Azure storage\r\naccount. Required if the specified Azure Quantum workspace was not linked to a storage\r\naccount at workspace creation time.\r\n\r\n#### Possible errors\r\n\r\n- `WorkspaceNotFound`: No Azure Quantum workspace was found that matches the specified criteria.\r\n- `AuthenticationFailed`: Failed to authenticate to the specified Azure Quantum workspace.\r\n                    ", "Remarks": null, "Examples": ["\r\nConnect to an Azure Quantum workspace using its resource ID:\r\n```\r\nIn []: %azure.connect \"/subscriptions/.../Microsoft.Quantum/Workspaces/WORKSPACE_NAME\"\r\nOut[]: Connected to Azure Quantum workspace WORKSPACE_NAME.\r\n        <list of Q# execution targets available in the Azure Quantum workspace>\r\n```\r\n                        ", "\r\nConnect to an Azure Quantum workspace using its resource ID and a storage account connection string:\r\n```\r\nIn []: %azure.connect resourceId=\"/subscriptions/.../Microsoft.Quantum/Workspaces/WORKSPACE_NAME\"\r\n                        storage=\"STORAGE_ACCOUNT_CONNECTION_STRING\"\r\nOut[]: Connected to Azure Quantum workspace WORKSPACE_NAME.\r\n        <list of Q# execution targets available in the Azure Quantum workspace>\r\n```\r\n                        ", "\r\nConnect to an Azure Quantum workspace using individual subscription ID, resource group name, and workspace name parameters:\r\n```\r\nIn []: %azure.connect subscription=\"SUBSCRIPTION_ID\"\r\n                        resourceGroup=\"RESOURCE_GROUP_NAME\"\r\n                        workspace=\"WORKSPACE_NAME\"\r\n                        storage=\"STORAGE_ACCOUNT_CONNECTION_STRING\"\r\nOut[]: Connected to Azure Quantum workspace WORKSPACE_NAME.\r\n        <list of Q# execution targets available in the Azure Quantum workspace>\r\n```\r\n                        ", "\r\nConnect to an Azure Quantum workspace and force a credential prompt using\r\nthe `refresh` option:\r\n```\r\nIn []: %azure.connect refresh \"/subscriptions/.../Microsoft.Quantum/Workspaces/WORKSPACE_NAME\"\r\nOut[]: To sign in, use a web browser to open the page https://microsoft.com/devicelogin\r\n        and enter the code [login code] to authenticate.\r\n        Connected to Azure Quantum workspace WORKSPACE_NAME.\r\n        <list of Q# execution targets available in the Azure Quantum workspace>\r\n```\r\n                        ", "\r\nPrint information about the currently-connected Azure Quantum workspace:\r\n```\r\nIn []: %azure.connect\r\nOut[]: Connected to Azure Quantum workspace WORKSPACE_NAME.\r\n        <list of Q# execution targets available in the Azure Quantum workspace>\r\n```\r\n                        "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.AzureClient"}
-->

# `%azure.connect`

## Summary

Connects to an Azure Quantum workspace or displays current connection status.

## Description

This magic command allows for connecting to an Azure Quantum workspace
as specified by the resource ID of the workspace or by a combination of
subscription ID, resource group name, and workspace name.

If the connection is successful, a list of the available Q# execution targets
in the Azure Quantum workspace will be displayed.

#### Required parameters

The Azure Quantum workspace can be identified by resource ID:

- `resourceId=<string>`: The resource ID of the Azure Quantum workspace.
This can be obtained from the workspace page in the Azure portal. The `resourceId=` prefix
is optional for this parameter, as long as the resource ID is valid.

Alternatively, it can be identified by subscription ID, resource group name, and workspace name:

- `subscription=<string>`: The Azure subscription ID for the Azure Quantum workspace.
- `resourceGroup=<string>`: The Azure resource group name for the Azure Quantum workspace.
- `workspace=<string>`: The name of the Azure Quantum workspace.

#### Optional parameters

- `refresh`: Bypasses any saved or cached credentials when connecting to Azure.
- `storage=<string>`: The connection string to the Azure storage
account. Required if the specified Azure Quantum workspace was not linked to a storage
account at workspace creation time.

#### Possible errors

- `WorkspaceNotFound`: No Azure Quantum workspace was found that matches the specified criteria.
- `AuthenticationFailed`: Failed to authenticate to the specified Azure Quantum workspace.

## Example

Connect to an Azure Quantum workspace using its resource ID:
```
In []: %azure.connect "/subscriptions/.../Microsoft.Quantum/Workspaces/WORKSPACE_NAME"
Out[]: Connected to Azure Quantum workspace WORKSPACE_NAME.
        <list of Q# execution targets available in the Azure Quantum workspace>
```

## Example

Connect to an Azure Quantum workspace using its resource ID and a storage account connection string:
```
In []: %azure.connect resourceId="/subscriptions/.../Microsoft.Quantum/Workspaces/WORKSPACE_NAME"
                        storage="STORAGE_ACCOUNT_CONNECTION_STRING"
Out[]: Connected to Azure Quantum workspace WORKSPACE_NAME.
        <list of Q# execution targets available in the Azure Quantum workspace>
```

## Example

Connect to an Azure Quantum workspace using individual subscription ID, resource group name, and workspace name parameters:
```
In []: %azure.connect subscription="SUBSCRIPTION_ID"
                        resourceGroup="RESOURCE_GROUP_NAME"
                        workspace="WORKSPACE_NAME"
                        storage="STORAGE_ACCOUNT_CONNECTION_STRING"
Out[]: Connected to Azure Quantum workspace WORKSPACE_NAME.
        <list of Q# execution targets available in the Azure Quantum workspace>
```

## Example

Connect to an Azure Quantum workspace and force a credential prompt using
the `refresh` option:
```
In []: %azure.connect refresh "/subscriptions/.../Microsoft.Quantum/Workspaces/WORKSPACE_NAME"
Out[]: To sign in, use a web browser to open the page https://microsoft.com/devicelogin
        and enter the code [login code] to authenticate.
        Connected to Azure Quantum workspace WORKSPACE_NAME.
        <list of Q# execution targets available in the Azure Quantum workspace>
```

## Example

Print information about the currently-connected Azure Quantum workspace:
```
In []: %azure.connect
Out[]: Connected to Azure Quantum workspace WORKSPACE_NAME.
        <list of Q# execution targets available in the Azure Quantum workspace>
```
