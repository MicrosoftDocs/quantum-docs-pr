---
uid: Microsoft.Quantum.Chemistry.JordanWigner.OptimizedQubitizationOracle
title: OptimizedQubitizationOracle function
ms.date: 11/9/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Chemistry.JordanWigner
qsharp.name: OptimizedQubitizationOracle
qsharp.summary: >-
  Returns T-count optimized Qubitization operation
  and the parameters necessary to run it.
---

# OptimizedQubitizationOracle function

Namespace: [Microsoft.Quantum.Chemistry.JordanWigner](xref:Microsoft.Quantum.Chemistry.JordanWigner)

Package: [](https://nuget.org/packages/)


Returns T-count optimized Qubitization operationand the parameters necessary to run it.

```qsharp
function OptimizedQubitizationOracle (qSharpData : Microsoft.Quantum.Chemistry.JordanWigner.JordanWignerEncodingData, targetError : Double) : (Int, (Double, (Qubit[] => Unit is Adj + Ctl)))
```


## Input

### qSharpData : [JordanWignerEncodingData](xref:Microsoft.Quantum.Chemistry.JordanWigner.JordanWignerEncodingData)

Hamiltonian described by `JordanWignerEncodingData` format.


### targetError : [Double](xref:microsoft.quantum.lang-ref.double)

Error of auxillary state preparation step.



## Output : ([Int](xref:microsoft.quantum.lang-ref.int),([Double](xref:microsoft.quantum.lang-ref.double),[Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj + Ctl))

A tuple where: `Int` is the number of qubits allocated,`Double` is the one-norm of Hamiltonian coefficients, and the operationis the Quantum walk created by Qubitization.