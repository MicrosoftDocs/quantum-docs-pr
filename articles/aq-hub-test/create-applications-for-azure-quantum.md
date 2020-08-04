---
title: Create applications for Azure Quantum
description: Explanation of how to create applications for the different targets of Azure-Quantum
author: KittyYeungQ
ms.author: kitty
ms.date: 06/29/2020
ms.topic: article
uid: microsoft.azure.quantum.create-applications
---

# Create and run Q# applications in Azure Quantum

This guide will outline of the process to create a Q# application
and run it on the different targets available in Azure Quantum.

## Different types of targets in Azure Quantum

Azure Quantum is a platform that offers different quantum solutions such as
different hardware devices and different quantum simulators. 
For the moment, each of these devices has its own limitations and requirements 
for the programs to run. The Quantum Development Kit and Azure Quantum take care 
of everything in the background so that your Q# code can run seamlessly on all 
targets of Azure Quantum.

However, quantum computers are still devices under development and not all of
them have yet the ability to run every Q# code. So you will need to keep some
restrictions in mind when developing for different targets. For the moment, we
classify targets in three different profiles:

- **Full:** this profile has the ability to execute any Q# program within the
  limits of memory for simulated QPUs or the number of qubits of the physical
  quantum hardware.
- **No Control Flow:** this profile can execute any Q# program that doesn't
  require the use of the results from qubit measurements to control the
  execution flow. Within a Q# program targeted for this kind of QPU, values of
  type `Result` do not support equality comparison.
- **Basic Measurement Feedback:** this profile has limited ability to use the
  results from qubit measurements to control the execution. Within a Q# program
  targeted for this kind of QPU, values of type `Result` can only be compared as
  part of conditions within if-statements in operations. The corresponding
  conditional blocks may not contain return- or set-statements.

In this guide you will learn to create applications for each of these
target profiles and submit them to run on Azure Quantum hardware.

## Create and run applications for Full profile targets

Full profile targets are able to run any Q# program, so you can
program without functionality restrictions. Azure Quantum does not provide yet
any target with this profile, but you can try locally any Q# program using the
[full state simulator of the Quantum Development
Kit](xref:microsoft.quantum.machines.full-state-simulator) and the
[resources estimator](https://docs.microsoft.com/quantum/user-guide/machines/resources-estimator?view=qsharp-preview). 

If you need help setting up your environment to run Q# programs locally, you can
start by our article on [Getting started with the Quantum Development
Kit](xref:microsoft.quantum.welcome).

You can also explore different Q# code samples to be run locally with the
[Quantum Development
Kit](https://docs.microsoft.com/samples/browse/?languages=qsharp&view=qsharp-preview).

## Create and run applications for No Control Flow profile targets

No Control Flow profile targets can run a wide variety of Q# applications, with
the constraint that they can't use results from qubit measurements to control
the execution flow. More specifically, values of type `Result` do not support
equality comparison.

For example, this operation can NOT be run on a No Control Flow target:

```qsharp
    operation SetQubitState(desired : Result, q : Qubit) : Result {
        if (desired != M(q)) {
            X(q);
        }
    }
```

It can't be run because it evaluates a comparison between two results (`desired != M(q)`)
to control the execution flow with an `if` statement.

> [!NOTE]
> Currently, for the targets of this profile there exists an additional
> limitation: *you can't apply operations on qubits that have been measured even
> if you don't use the results to control the execution flow.* This limitation is
> not intrinsic of this profile but circumstantial to the situation of Limited
> Preview.

Presently, the list of No Control Flow targets for Azure Quantum is:

- **Provider:** IonQ
    - IonQ simulator (`ìonq.simulator`)
    - IonQ QPU: (`ionq.qpu`)

### Create applications for IonQ targets

To create an application to be run in IonQ targets follow the next guide:

#### Prerequisites

- Install the [Quantum Development Kit](xref:microsoft.quantum.install.standalone).
- Install the [Azure CLI](https://docs.microsoft.com/cli/azure/install-azure-cli?view=azure-cli-latest).
- Install the [necessary utilities to use Azure Quantum](./prepare-your-environment.md), this includes the `quantum` extension for the Azure CLI.
- A quantum workspace with IonQ listed as a provider. To create one, follow the
  guide [Create an Azure Quantum
  workspace](Create-quantum-workspaces-with-the-Azure-portal.md).

#### Guide

1. [Create a Q# application using the Q# project template.](https://docs.microsoft.com/quantum/quickstarts/install-command-line?tabs=tabid-vscode#develop-with-q)
1. Open the `*.csproj` file in a text editor (e.g. VS Code) and edit the file to:
    - Make sure the project points to the latest Quantum Development Kit
      version. You can check the latest version in the official [QDK Release Notes](xref:microsoft.quantum.relnotes).
    - Add a line specifying the execution target:
      `<ExecutionTarget>ionq.qpu</ExecutionTarget>` for the IonQ QPU and
      `<ExecutionTarget>ionq.simulator</ExecutionTarget>` for the IonQ
      simulator.
  
   It should look something like this:
  
    ```xlm
    <Project Sdk="Microsoft.Quantum.Sdk/X.XX.XXXXXXXX">
    
      <PropertyGroup>
        <OutputType>Exe</OutputType>
        <TargetFramework>netcoreapp3.1</TargetFramework>
        <ExecutionTarget>ionq.qpu</ExecutionTarget>
      </PropertyGroup>
    
    </Project>
    ```
   where `X.XX.XXXXXXXX` is a place holder for the number of the latest version.
1. Write your Q# program, reminding that you cannot compare measurement results
 to control the execution flow. 
1. Build and run your program locally using the Quantum Development Kit local
   targets. This will let you know if your Q# application can be run in IonQ's
   targets by checking the fulfillement of the No Control Flow restrictions and calculating the
   needed resources.
   - You can run locally your Q# program using the QDK full state simulator by
     using the command `dotnet run`. Since you selected the `ExecutionTarget` in
     the `*.csproj` file the console output will warn you if you created a file
     not compatible with the No Control Flow profile.
   - You can use the
     [`ResourcesEstimator`](https://docs.microsoft.com/quantum/user-guide/machines/resources-estimator?view=qsharp-preview)
     to estimate what resources your Q# program needs to be run. You can
     invoke the resource estimator with the command: `dotnet run --simulator
     ResourcesEstimator`.
1. Once you have your Q# program ready, you can submit the job to Azure Quantum
   using the command: `az quantum job submit --target-id ionq.qpu` (or
   `ionq.simulator` if you want to use the simulator instead).

You can find more information on how to submit jobs to Azure Quantum in our
guide [Submit jobs to Azure Quantum using the Azure CLI](xref:microsoft.azure.quantum.submit-jobs.azcli).

## Create and run applications for Basic Measurement Feedback targets

Basic Measurement Feedback profile targets can run a wide variety of Q#
applications, with the constraint that the  values of type `Result` can only be
compared as part of conditions within if-statements in operations. The
corresponding conditional blocks may not contain return- or set-statements. This
supposes an improvement over No Control Flow profiles, but still is subject to
some limitations.

For the moment, Azure Quantum doesn't host yet any target with this profile,
but some targets will become available soon during the Limited Review.

## Next steps

Now that you know how to create Q# applications to Azure quantum you can try to run the
[different samples we have available](https://github.com/MicrosoftDocs/quantum-docs-private/tree/feature/onboarding-azure-quantum/azure-quantum/samples) or try to submit your own
projects.