---
title: '%azure.connect (magic command)'
uid: microsoft.quantum.iqsharp.magic-ref.azure.connect
ms.date: '2020-06-23'
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.AzureClient.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%azure.connect", "Documentation": {"Summary": "Connects to an Azure Quantum workspace or displays current connection status.", "Full": null, "Description": "\r\nThis magic command allows for connecting to an Azure Quantum workspace\r\nas specified by the resource ID of the workspace or by a combination of\r\nsubscription ID, resource group name, and workspace name.\r\n\r\nIf the connection is successful, a list of the available Q# execution targets\r\nin the Azure Quantum workspace will be displayed.\r\n                        ", "Remarks": null, "Examples": ["\r\nConnect to an Azure Quantum workspace using its resource ID:\r\n```\r\nIn []: %azure.connect resourceId=\"/subscriptions/f846b2bd-d0e2-4a1d-8141-4c6944a9d387/resourceGroups/RESOURCE_GROUP_NAME/providers/Microsoft.Quantum/Workspaces/WORKSPACE_NAME\"\r\nOut[]: Connected to Azure Quantum workspace WORKSPACE_NAME.\r\n       <list of Q# execution targets available in the Azure Quantum workspace>\r\n```\r\n                            ", "\r\nConnect to an Azure Quantum workspace using its resource ID and a storage account connection string,\r\nwhich is required for workspaces that do not have a linked storage account:\r\n```\r\nIn []: %azure.connect resourceId=\"/subscriptions/f846b2bd-d0e2-4a1d-8141-4c6944a9d387/resourceGroups/RESOURCE_GROUP_NAME/providers/Microsoft.Quantum/Workspaces/WORKSPACE_NAME\"\r\n                      storage=\"STORAGE_ACCOUNT_CONNECTION_STRING\"\r\nOut[]: Connected to Azure Quantum workspace WORKSPACE_NAME.\r\n       <list of Q# execution targets available in the Azure Quantum workspace>\r\n```\r\n                            ", "\r\nConnect to an Azure Quantum workspace using individual parameters:\r\n```\r\nIn []: %azure.connect subscription=\"SUBSCRIPTION_ID\"\r\n                      resourceGroup=\"RESOURCE_GROUP_NAME\"\r\n                      workspace=\"WORKSPACE_NAME\"\r\n                      storage=\"STORAGE_ACCOUNT_CONNECTION_STRING\"\r\nOut[]: Connected to Azure Quantum workspace WORKSPACE_NAME.\r\n       <list of Q# execution targets available in the Azure Quantum workspace>\r\n```\r\nThe `storage` parameter is necessary only if the\r\nspecified Azure Quantum workspace was not linked to a storage account at creation time.\r\n                            ", "\r\nConnect to an Azure Quantum workspace and force a credential prompt using\r\nthe `refresh` option:\r\n```\r\nIn []: %azure.connect refresh resourceId=\"/subscriptions/f846b2bd-d0e2-4a1d-8141-4c6944a9d387/resourceGroups/RESOURCE_GROUP_NAME/providers/Microsoft.Quantum/Workspaces/WORKSPACE_NAME\"\r\nOut[]: To sign in, use a web browser to open the page https://microsoft.com/devicelogin\r\n        and enter the code [login code] to authenticate.\r\n       Connected to Azure Quantum workspace WORKSPACE_NAME.\r\n       <list of Q# execution targets available in the Azure Quantum workspace>\r\n```\r\nThe `refresh` option bypasses any saved or cached\r\ncredentials when connecting to Azure.\r\n                            ", "\r\nPrint information about the current connection:\r\n```\r\nIn []: %azure.connect\r\nOut[]: Connected to Azure Quantum workspace WORKSPACE_NAME.\r\n       <list of Q# execution targets available in the Azure Quantum workspace>\r\n```\r\n                            "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.AzureClient"}
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

## Example

Connect to an Azure Quantum workspace using its resource ID:
```
In []: %azure.connect resourceId="/subscriptions/f846b2bd-d0e2-4a1d-8141-4c6944a9d387/resourceGroups/RESOURCE_GROUP_NAME/providers/Microsoft.Quantum/Workspaces/WORKSPACE_NAME"
Out[]: Connected to Azure Quantum workspace WORKSPACE_NAME.
       <list of Q# execution targets available in the Azure Quantum workspace>
```

## Example

Connect to an Azure Quantum workspace using its resource ID and a storage account connection string,
which is required for workspaces that do not have a linked storage account:
```
In []: %azure.connect resourceId="/subscriptions/f846b2bd-d0e2-4a1d-8141-4c6944a9d387/resourceGroups/RESOURCE_GROUP_NAME/providers/Microsoft.Quantum/Workspaces/WORKSPACE_NAME"
                      storage="STORAGE_ACCOUNT_CONNECTION_STRING"
Out[]: Connected to Azure Quantum workspace WORKSPACE_NAME.
       <list of Q# execution targets available in the Azure Quantum workspace>
```

## Example

Connect to an Azure Quantum workspace using individual parameters:
```
In []: %azure.connect subscription="SUBSCRIPTION_ID"
                      resourceGroup="RESOURCE_GROUP_NAME"
                      workspace="WORKSPACE_NAME"
                      storage="STORAGE_ACCOUNT_CONNECTION_STRING"
Out[]: Connected to Azure Quantum workspace WORKSPACE_NAME.
       <list of Q# execution targets available in the Azure Quantum workspace>
```
The `storage` parameter is necessary only if the
specified Azure Quantum workspace was not linked to a storage account at creation time.

## Example

Connect to an Azure Quantum workspace and force a credential prompt using
the `refresh` option:
```
In []: %azure.connect refresh resourceId="/subscriptions/f846b2bd-d0e2-4a1d-8141-4c6944a9d387/resourceGroups/RESOURCE_GROUP_NAME/providers/Microsoft.Quantum/Workspaces/WORKSPACE_NAME"
Out[]: To sign in, use a web browser to open the page https://microsoft.com/devicelogin
        and enter the code [login code] to authenticate.
       Connected to Azure Quantum workspace WORKSPACE_NAME.
       <list of Q# execution targets available in the Azure Quantum workspace>
```
The `refresh` option bypasses any saved or cached
credentials when connecting to Azure.

## Example

Print information about the current connection:
```
In []: %azure.connect
Out[]: Connected to Azure Quantum workspace WORKSPACE_NAME.
       <list of Q# execution targets available in the Azure Quantum workspace>
```
