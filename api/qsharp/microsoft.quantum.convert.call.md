---
uid: Microsoft.Quantum.Convert.Call
title: Call operation
ms.date: 11/17/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Convert
qsharp.name: Call
qsharp.summary: Calls a function with a given input.
---

# Call operation

Namespace: [Microsoft.Quantum.Convert](xref:Microsoft.Quantum.Convert)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Calls a function with a given input.

```qsharp
operation Call<'Input, 'Output> (fn : ('Input -> 'Output), input : 'Input) : 'Output
```


## Description

Given a function and an input to that function, calls the functionand returns its output.

## Input

### fn : 'Input -> 'Output

A function to be called.


### input : 'Input

The input to be passed to the function.



## Output : 'Output

The result of calling `fn`.

## Type Parameters

### 'Input


### 'Output



## Remarks

This operation is mainly useful for forcing a function to be calledat a specific place within an operation, or for calling a functionwhere an operation is expected.