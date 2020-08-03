---
title: Submit jobs to Azure Quantum with Python
description: This document provides a basic guide to submit and run Q# applications in Azure Quantum using Q# Jupyter Notebooks.
author: KittyYeungQ
ms.author: kitty
ms.date: 06/29/2020
ms.topic: article
uid: microsoft.azure.quantum.submit-jobs.python
---

# Submit jobs to Azure Quantum with Python

This document provides a basic guide to submit and run Q# applications in Azure
Quantum using Q# Jupyter Notebooks.

## Prerequisites

- You need to have an Azure Quantum workspace in your subscription. To create
  one, follow the guide [Create an Azure Quantum
  workspace](xref:microsoft.azure.quantum.workspaces-portal).

## Installation

Follow these steps to install Jupyter Notebook and the current version of the
IQ# kernel, which powers the Q# Jupyter Notebook and Python experiences.

1. Install [Miniconda](https://docs.conda.io/en/latest/miniconda.html) or
   [Anaconda](https://www.anaconda.com/products/individual#Downloads).
1. Open an Anaconda Prompt.
   - Or, if you prefer to use PowerShell or pwsh: open a shell, run `conda init
     powershell`, then close and re-open the shell.
1. Create and activate a new conda environment named `qsharp-env` with the
   required packages (including Jupyter Notebook and IQ#) by running the
   following commands:

    ```
    conda create -n qsharp-env -c quantum-engineering qsharp notebook

    conda activate qsharp-env
    ```

1. Run `python -c "import qsharp"` from the same terminal to verify your
   installation and populate your local package cache with all required QDK
   components.

Now you're set up to use Python and Q# integration to execute
quantum programs on Azure Quantum.

**NOTE:** You'll want to have the resource ID of your Azure Quantum workspace
handy, as you'll need it for the steps below. You can copy/paste this from the
top-right corner of your Quantum Workspace page in Azure Portal.

## Quantum Execution with Q# and Python

1. The Python environment in the conda environment you created above already
   includes the `qsharp` Python package. Make sure you are running your Python
   script from a terminal where this conda environment is activated.

1. If you've never used Q# with Python, read this first: [Create your first Q#
   program with
   Python](https://docs.microsoft.com/quantum/quickstarts/install-python?tabs=tabid-conda#write-your-first-q-program).

1. Write your Q# operations in a `*.qs` file. When running `import qsharp` in
   Python, the IQ# kernel will automatically detect any .qs files in the same
   folder, compile them, and report any errors. If compilation is successful,
   those Q# operations will become available for use directly from within
   Python.
    - For example, the contents of your .qs file could look something like this:

        ```qsharp
        namespace Test {
            open Microsoft.Quantum.Intrinsic;
            open Microsoft.Quantum.Measurement;

            operation GenerateRandomBits(n : Int) : Result[] {
                using (qubits = Qubit[n])  {
                    ApplyToEach(H, qubits);
                    return MultiM(qubits);
                }
            }
        }
        ```

1. Create a Python script in the same folder as your `*.qs` file. Azure Quantum
   functionality is available by running `import qsharp.azure` and then calling
   the Python commands to interact with Azure Quantum. Here you can find the
   [complete list of Python
   commands](https://docs.microsoft.com/python/qsharp/qsharp.azure).
   You'll use the resource ID of your Azure Quantum workspace in order to
   connect. For example, your Python script could look like this:

    ```py
    import qsharp
    import qsharp.azure
    from Test import GenerateRandomBit

    qsharp.azure.connect(resourceId="/subscriptions/.../Microsoft.Quantum/Workspaces/WORKSPACE_NAME")
    qsharp.azure.target("ionq.simulator")
    result = qsharp.azure.execute(GenerateRandomBits, n=3, shots=1000, jobName="Generate three random bits")
    print(result)
    ```

    where `GenerateRandomBits` is the Q# operation in a namespace `Test` that is
    defined in your `*.qs` file, `n=3` is the parameter to be passed to
    that operation, `shots=1000` (optional) specifies the number of repetitions
    to perform, and `jobName="Generate three random bits"` (optional) is a custom
    job name to identify the job in the Azure Quantum workspace.

1. Execute your Python script by running `python test.py`, where `test.py` is
   the name of your Python file. If successful, you should see your job results
   printed to the terminal. For example:

   ```output
   {'[0,0,0]': 0.125, '[1,0,0]': 0.125, '[0,1,0]': 0.125, '[1,1,0]': 0.125, '[0,0,1]': 0.125, '[1,0,1]': 0.125, '[0,1,1]': 0.125, '[1,1,1]': 0.125}
   ```

1. To view the details of all jobs in your Azure Quantum workspace, run `qsharp.azure.jobs()`:

   ```dotnetcli
   >>> qsharp.azure.jobs()
   [{'id': 'f4781db6-c41b-4402-8d7c-5cfce7f3cde4', 'name': 'GenerateRandomNumber 3 qubits', 'status': 'Succeeded', 'provider': 'ionq', 'target': 'ionq.simulator', 'creation_time': '2020-07-17T21:45:43.4405253Z', 'begin_execution_time': '2020-07-17T21:45:54.09Z', 'end_execution_time': '2020-07-17T21:45:54.101Z'}, {'id': '1b03cc74-b5d5-4ffa-81db-465f08ae6cd0', 'name': 'GenerateRandomBit', 'status': 'Succeeded', 'provider': 'ionq', 'target': 'ionq.simulator', 'creation_time': '2020-07-21T19:44:17.1065156Z', 'begin_execution_time': '2020-07-21T19:44:25.85Z', 'end_execution_time': '2020-07-21T19:44:25.858Z'}]
   ```

1. To view the detailed status of a particular job, pass the job ID to `qsharp.azure.status()` or `qsharp.azure.output()`, e.g.:

   ```dotnetcli
   >>> qsharp.azure.status('1b03cc74-b5d5-4ffa-81db-465f08ae6cd0')
   {'id': '1b03cc74-b5d5-4ffa-81db-465f08ae6cd0', 'name': 'GenerateRandomBit', 'status': 'Succeeded', 'provider': 'ionq', 'target': 'ionq.simulator', 
   'creation_time': '2020-07-21T19:44:17.1065156Z', 'begin_execution_time': '2020-07-21T19:44:25.85Z', 'end_execution_time': '2020-07-21T19:44:25.858Z'}

   >>> qsharp.azure.output('1b03cc74-b5d5-4ffa-81db-465f08ae6cd0')
   {'0': 0.5, '1': 0.5}
   ```

## Next steps

Now that you know how to submit jobs to Azure Quantum you can try to run the
[different samples we have available](https://github.com/MicrosoftDocs/quantum-docs-private/tree/feature/onboarding-azure-quantum/azure-quantum/samples) or try to submit your own
projects.
