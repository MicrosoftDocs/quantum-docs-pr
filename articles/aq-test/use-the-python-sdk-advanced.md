---
title: Advanced usage of the Python SDK for Quantum Inspired Optimization
description: This document provides an overview of some advanced usage patterns for the Python SDK for Quantum Inspired Optimization.
author: KittyYeungQ
ms.author: kitty
ms.date: 06/29/2020
ms.topic: article
uid: microsoft.azure.quantum.qio.python-sdk.advanced
---

# Advanced usage of the Python SDK for Quantum Inspired Optimization

This document provides an overview of some advanced usage patterns for the
Python SDK for Quantum Inspired Optimization.

## Asynchronous problem solving

In the [basic usage example](xref:microsoft.azure.quantum.qio.python-sdk) a problem
was created, submitted to Azure Quantum, and solved synchronously. This is
convenient for certain environments, but unsuitable for others where there's a
need to either submit a problem and check on it later, or submit many problems
and compare the results.

### Submit the problem

To submit a problem asynchronously, use the `submit` method on the `solver`:

```py
solver = ParallelTempering(workspace, timeout=100, seed=11)
job = solver.submit(problem)
print(job.id)

> ea81bb40-682f-11ea-8271-c49dede60d7c
```

### Refresh job status

After submitting, you can check on the status of the job by calling the
`refresh` method. Each time `refresh` is called the job metadata gets refreshed.

```py
job.refresh()
print(job.details.status)

> Succeeded
```

### Get the job output

Once the job is in a [final state](/Azure-Quantum-Overview#Job-Lifecycle) such
as `Succeeded` you may download the job output using `get_results`:

```py
jobId = "ea81bb40-682f-11ea-8271-c49dede60d7c"
job = workspace.get_job(jobId)
result = job.get_results()
print(result)

> {'energy': -32.0, 'solution': [1, 1, -1, 1]}
```

## Reusing problem definitions

Sometimes it is more efficient to upload a problem definition once and find its
solution using different algorithms (solvers) or with different parameters. You
can upload a problem definition using the `upload` method, which returns a URL,
then provide this URL to a solver's `submit` or `optimize` methods:

```py
url = problem.upload(workspace)
job = solver.submit(url)
print(job.id)

> 9228ea88-6832-11ea-8271-c49dede60d7c
```

## Job Management

The `Workspace` provides methods for managing jobs:

- `Problem` (for Quantum-Inspired Problems), or `QsharpOperation` (for Quantum
    Hardware or Simulators).
- **get_job**: returns the `Job` metadata and results for a specific job
    (based on job `id`)
- **list_jobs**: returns a list of all jobs in the workspace
- **cancel_job**: cancels a specific job

See [Job Cancellation](/Azure-Quantum-Overview#Job-Cancellation) for more
information on how cancellation requests are processed.

You can use the `list_jobs` method to get a list of all jobs in the workspace:

```py
jobs = [job.id for job in workspace.list_jobs()]
print(jobs)

> ['5d2f9cd70f55f149e3ed3aef', '23as12fs5d2f9cd70f55f', '1644428ea8507edb7361']
```

This shows how to submit a job asynchronously and call `get_job` to get the
metadata (and results) for a previously submitted job, by `id`: 

```py
from azure.quantum.optimization import Problem, ProblemType, Term, ParallelTempering, SimulatedAnnealing

problem = Problem(name="MyOptimizationJob", problem_type=ProblemType.ising)
problem.add_term(w=-9, indices=[0])
problem.add_term(w=-3, indices=[1,0])
problem.add_term(w=5, indices=[2,0])

solver = SimulatedAnnealing(workspace)
job = solver.submit(problem)
print(job.id)

> 5d2f9cd70f55f149e3ed3aef

job = workspace.get_job(job.id)
results = job.get_results()
print(results)

> {'energy': -17.0, 'solution': [1, 1, -1]}
```

## Methods for supplying problem terms

There are three ways to supply terms for a
[`Problem`](/Reference/Python-SDK/Azure.Quantum.Optimization): in the
constructor, individually, and as a list of `Term` objects.

### In the constructor

You can supply an array of `Term` objects in the constructor of a `Problem`:

```py
terms = [
    Term(w=-9, indices=[0]),
    Term(w=-3, indices=[1,0]),
    Term(w=5, indices=[2,0])
]

problem = Problem(name="My Difficult Problem", terms=terms)
```

### Individually

You can supply each term individually by calling the `add_term` method on the
`Problem`.

```py
problem = Problem(name="My Difficult Problem", problem_type=ProblemType.ising)
problem.add_term(w=-9, indices=[0])
problem.add_term(w=-3, indices=[1,0])
problem.add_term(w=5, indices=[2,0])
```

### A list of terms

You can also supply a list of `Term` objects:

```py
problem = Problem(name="My Difficult Problem")
terms = [
    Term(w=-9, indices=[0]),
    Term(w=-3, indices=[1,0]),
    Term(w=5, indices=[2,0]),
    Term(w=9, indices=[2,1]),
    Term(w=2, indices=[3,0]),
    Term(w=-4, indices=[3,1]),
    Term(w=4, indices=[3,2])
]

problem.add_terms(terms=terms)
```

## Using a Service Principal to Authenticate

Sometimes it is unsuitable to use interactive authentication or to authenticate
as a user account. These cases may arrive when you want to submit jobs from a
web service or other worker role or automated system. In this cases you
typically want to authenticate using a [Service
Principal](https://docs.microsoft.com/azure/active-directory/develop/app-objects-and-service-principals).

### Prerequisite: Create a service principal and application secret

In order to authenticate as a service principal you must first [create a service
principal](https://docs.microsoft.com/azure/active-directory/develop/howto-create-service-principal-portal).

Steps to create a service principal, assign access, and generate a credential:

1. [Create an Azure AAD application](https://docs.microsoft.com/azure/active-directory/develop/howto-create-service-principal-portal):

    > You do not need to set a redirect URI
    1. Once created, write down the `Application (client) ID` and the `Directory
       (tenant) ID`

1. [Create a
   credential](https://docs.microsoft.com/azure/active-directory/develop/howto-create-service-principal-portal#create-a-new-application-secret)
   to login as the application
    1. In the settings for your application, select "Certificates & secrets"
    1. Under Client Secrets, select "Create New Secret"
    1. Provide a description and duration, then select Add
    1. Copy the value of the secret to a safe place immediately - you won't be
       able to see it again!

1. Give your service principal permissions to access your workspace:
    1. Open the Azure Portal
    1. In the search bar, enter the name of the resource group you created your
       workspace in. Select the resource group when it comes up in the results.
    1. On the resource group overview, select "Access control (IAM)".
    1. Click "Add Role Assignment"
    1. Search for and select the service principal
    1. Assign either the Contributor or Owner role

### Authenticate as the service principal

**Step 1**: Install the `azure-common` python package:

```bash
pip3 install azure-common
```

**Step 2**: Before you call `workspace.login()`, instantiate your service
principal and provide it to the workspace:

```python
from azure.common.credentials import ServicePrincipalCredentials
workspace.credentials = ServicePrincipalCredentials(
    tenant    = "", # From service principal creation, your Directory (tenant) ID
    client_id = "", # From service principal creation, your Application (client) ID
    secret    = "", # From service principal creation, your secret
    resource  = "https://private-preview.quantum.microsoft.com" # Do not change! This is the resource you want to authenticate against - the Azure Quantum service
)
```

That's it! Make sure you call `workspace.login()` after setting up the service
principal and you should be able to create jobs as usual.