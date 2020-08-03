---
title: Azure Quantum common issues
description: List of common issues of the Azure Quantum service.
author: geduardo
ms.author: v-edsanc@microsoft.com
ms.date: 06/25/2020
ms.topic: article
uid: microsoft.azure.quantum.common-issues
---
# Azure Quantum common issues

When submitting jobs for the first time to Azure Quantum, you may run into common issues

## Submitting jobs

### ERROR: Operation returned an invalid status code 'Unauthorized'

Steps to resolve this issue:

1.https://portal.azure.com and authenticate
2.Click Subscriptions and select your subscription
3.Click Access control (IAM)
4.Under 'Check access', enter your email address and select the account
5.Notice that an 'Owner' or 'Contributor' role is missing
6.Click on ‘Role assignments’ tab
7.Select Role > 'Owner' (or 'Contributor'), enter your email address and select your account
8.Click Save
9.You should see your account set with the 'Owner' (or 'Contributor') role
10.Create your Quantum workspace again and submit a job against this new Quantum workspace

## Creating workspace

### ERROR: The resource type could not be found in the namespace 'Microsoft.Quantum' for api version '2019-11-04-preview'

Documentation under construction for this issue.