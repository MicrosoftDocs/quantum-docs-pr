---
uid: Microsoft.Quantum.Convert.FunctionAsOperation
title: FunctionAsOperation function
ms.date: 11/6/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Convert
qsharp.name: FunctionAsOperation
qsharp.summary: Converts functions to operations.
---

# FunctionAsOperation function

Namespace: [Microsoft.Quantum.Convert](xref:Microsoft.Quantum.Convert)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Converts functions to operations.

```qsharp
function FunctionAsOperation<'Input, 'Output> (fn : ('Input -> 'Output)) : ('Input => 'Output)
```


## Description

Given a function, returns an operation which calls that function,and which does nothing else.

## Input

### fn : 'Input -> 'Output

A function to be converted to an operation.



## Output : 'Input => 'Output 

An operation `op` such that `op(input)` is identical to `fn(input)`for all `input`.

## Type Parameters

### 'Input

Input type of the function to be converted.
### 'Output

Output type of the function to be converted.

## Remarks

This is mainly useful for passing functions to functions or operationswhich expect an operation as input.