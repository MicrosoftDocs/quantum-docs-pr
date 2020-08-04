---
title: Azure Quantum preview known issues
description: his document contains a list of known issues that we are working to address in preview.
author: geduardo
ms.author: v-edsanc@microsoft.com
ms.date: 06/25/2020
ms.topic: article
uid: microsoft.azure.quantum.known-issues
---

# Azure Quantum preview known issues

This document contains a list of known issues that we are working to address in preview.

## Manually Creating Storage Accounts

Right now you must manually create a storage account for your job input/output data (although the bash script does this for you) and pass this to the `Workspace` constructor. We are working on removing the requirement for both steps soon.

## Job Error Data Omissions

Job Error data is not always populated when a job fails.

## Jobs Marked as `Executing` while still queued

Currently, jobs will be placed in the `Executing` state when they are passed to the provider for processing. However, the provider may still have the job in a queue. In the future, jobs will show as `Executing` only when actively being executed by the provider.

In the meantime, you can determine the runtime of a job by looking at `Job.details.begin_execution_time` and `Job.details.end_execution_time`.

## List Jobs API returns all jobs

The List Jobs API currently returns all jobs and does not support pagination. This can make it very slow for workspaces with many jobs. This API will soon support pagination.

## Occasionally job management requests take a long time

Occasionally, a request to the service for a job may take a long time to complete. If you observe this behavior, we recommend a brief wait and then retry.

## Cancelling a job may throw an exception in the SDK, but cancellation succeeds

If you attempt to cancel a job in an state, you may receive a local exception in the SDK but the cancellation of the job will still be processed.