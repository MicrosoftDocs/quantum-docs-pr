---
title: '%connect (magic command)'
uid: microsoft.quantum.iqsharp.magic-ref.connect
ms.date: '2020-05-20'
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.AzureClient.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%connect", "Documentation": {"Summary": "Connects to an Azure workspace or displays current connection status.", "Full": null, "Description": "\r\nThis magic command allows for connecting to an Azure Quantum workspace\r\nas specified by a valid subscription ID, resource group name, workspace name,\r\nand storage account connection string.\r\n                        ", "Remarks": null, "Examples": ["\r\nPrint information about the current connection:\r\n```\r\nIn []: %connect\r\nOut[]: Connected to WORKSPACE_NAME\r\n```\r\n                            ", "\r\nConnect to an Azure Quantum workspace:\r\n```\r\nIn []: %connect subscriptionId=SUBSCRIPTION_ID\r\n                resourceGroupName=RESOURCE_GROUP_NAME\r\n                workspaceName=WORKSPACE_NAME\r\n                storageAccountConnectionString=CONNECTION_STRING\r\nOut[]: Connected to WORKSPACE_NAME\r\n```\r\n                            ", "\r\nConnect to an Azure Quantum workspace and force a credential prompt:\r\n```\r\nIn []: %connect login\r\n                subscriptionId=SUBSCRIPTION_ID\r\n                resourceGroupName=RESOURCE_GROUP_NAME\r\n                workspaceName=WORKSPACE_NAME\r\n                storageAccountConnectionString=CONNECTION_STRING\r\nOut[]: To sign in, use a web browser to open the page https://microsoft.com/devicelogin\r\n        and enter the code [login code] to authenticate.\r\n        Connected to WORKSPACE_NAME\r\n```\r\nUse the `login` option if you want to bypass any saved or cached\r\ncredentials when connecting to Azure.\r\n                            "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.AzureClient"}
-->

# `%connect`

## Summary

Connects to an Azure workspace or displays current connection status.

## Description

This magic command allows for connecting to an Azure Quantum workspace
as specified by a valid subscription ID, resource group name, workspace name,
and storage account connection string.

## Example

Print information about the current connection:
```
In []: %connect
Out[]: Connected to WORKSPACE_NAME
```

## Example

Connect to an Azure Quantum workspace:
```
In []: %connect subscriptionId=SUBSCRIPTION_ID
                resourceGroupName=RESOURCE_GROUP_NAME
                workspaceName=WORKSPACE_NAME
                storageAccountConnectionString=CONNECTION_STRING
Out[]: Connected to WORKSPACE_NAME
```

## Example

Connect to an Azure Quantum workspace and force a credential prompt:
```
In []: %connect login
                subscriptionId=SUBSCRIPTION_ID
                resourceGroupName=RESOURCE_GROUP_NAME
                workspaceName=WORKSPACE_NAME
                storageAccountConnectionString=CONNECTION_STRING
Out[]: To sign in, use a web browser to open the page https://microsoft.com/devicelogin
        and enter the code [login code] to authenticate.
        Connected to WORKSPACE_NAME
```
Use the `login` option if you want to bypass any saved or cached
credentials when connecting to Azure.
