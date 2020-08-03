---
title: Azure.Quantum.Optimization
description: Reference for azure.quantum.optimization
author: KittyYeungQ
ms.author: kitty
ms.date: 06/29/2020
ms.topic: article
uid: microsoft.azure.quantum.reference.python-sdk.azure.quantum.optimization
---

# Azure.Quantum.Optimization

```py
from azure.quantum.optimization import Job
```

## Job.get_results

Retrieves the job result (the computed solution and energy). If the job has not
yet finished, blocks until it has.

## Job.has_completed

Returns a boolean indicating whether the job has finished (e.g. the job is in a
[final state](/Azure-Quantum-Overview#Job-Lifecycle)).

```py
job = workspace.get_job(jobId)
job.refresh()
print(job.has_completed())

> False
```

## Job.refresh

Refreshes the Job's details by querying the workspace.

```py
job = workspace.get_job(jobId)
job.refresh()
print(job.id)

> 5d2f9cd70f55f149e3ed3aef
```

## Job.wait_until_completed

Keeps refreshing the Job's details until it reaches a [final
state](/Azure-Quantum-Overview#Job-Lifecycle).

```py
job = workspace.get_job(jobId)
job.wait_until_completed()
print(job.has_completed())

> True
```

## Problem

```py
from azure.quantum.optimization import Problem
```

### Constructor

To create a `Problem` object, you must specify the followinbg information:

- `name`: A friendly name for your problem. No uniqueness constraints.
- [optional] `terms`: A list of `Term` objects to add to the problem.
- [optional] `problem_type`: The type of problem. Must be either
  `ProblemType.ising` or `ProblemType.pubo`

### Problem.add_term

Adds a single term to the problem. Takes a weight for the term, and the indices
of variables that appear in the term.
```py
weight = 0.13
problem.add_term(w=5, indices=[2,0])
```

### Problem.add_terms

Adds multiple terms to the problem using a list of `Terms`.

```py
problem.add_terms([
    Term(w=-9, indices=[0]),
    Term(w=-3, indices=[1,0]),
    Term(w=5, indices=[2,0]),
    Term(w=9, indices=[2,1]),
    Term(w=2, indices=[3,0]),
    Term(w=-4, indices=[3,1]),
    Term(w=4, indices=[3,2])
])
```

### Problem.serialize

Serializes a problem to a json string.

```py
problem = Problem("My Problem", [Term(w=1, indices=[0,1])])
problem.serialize()

> TODO
```

### Problem.upload

Problem data can be explicitly uploaded to an Azure storage account using its
`upload` method that receives as a parameter the `Workspace` instance:
```py
problem.upload(workspace=workspace)
```

Once a Problem is explicitly uploaded, it will not be automatically uploaded
during submission unless its terms change.

## ProblemType

```py
from azure.quantum.optimization import ProblemType
```

The `ProblemType` enum allows you to specify the type of optimization problem
you would like to solve.

### ProblemType.pubo

A polynomial unconstrained binary optimization problem (PUBO) is a problem of
the form:

$$H = \sum_{i} c_{i} x_{i} + \sum_{i,j} c_{i,j} x_{i} x_{j} + \sum_{i,j,k}
c_{i,j,k} x_{i} x_{j} x_{k} \text{ where } c_{i,j,k} \in R \text{ and }
x_{i,j,k} \in [0, 1]$$

Where *H* is the cost function, also known as the Hamiltonian. It is called
*k*-local if the maximum degree of the polynomial is *k*.

### ProblemType.ising

An Ising Model is a cost function of the form:
$$H = \sum_{i} c_{i} s_{i} + \sum_{i,j} c_{i,j} s_{i} s_{j} + \sum_{i,j,k}
c_{i,j,k} s_{i} s_{j} s_{k} \text{ where } c_{i,j,k} \in R \text{ and }
s_{i,j,k} \in [-1, 1]$$

It is called *k*-local if the maximum degree of the polynomial is *k*.