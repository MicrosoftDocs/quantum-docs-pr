---
uid: Microsoft.Quantum.Research.Chemistry.OptimizedTrotterStepOracle
title: OptimizedTrotterStepOracle function
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Research.Chemistry
qsharp.name: OptimizedTrotterStepOracle
qsharp.summary: Returns optimized Trotter step operation and the parameters necessary to run it.
---

# OptimizedTrotterStepOracle function

Namespace: [Microsoft.Quantum.Research.Chemistry](xref:Microsoft.Quantum.Research.Chemistry)

Package: [Microsoft.Quantum.Research.Chemistry](https://nuget.org/packages/Microsoft.Quantum.Research.Chemistry)


Returns optimized Trotter step operation and the parameters necessary to run it.

```qsharp
function OptimizedTrotterStepOracle (qSharpData : Microsoft.Quantum.Chemistry.JordanWigner.JordanWignerEncodingData, trotterStepSize : Double, trotterOrder : Int) : (Int, (Double, (Qubit[] => Unit is Adj + Ctl)))
```


## Input

### qSharpData : [JordanWignerEncodingData](xref:Microsoft.Quantum.Chemistry.JordanWigner.JordanWignerEncodingData)

Hamiltonian described by `JordanWignerEncodingData` format.


### trotterStepSize : [Double](xref:microsoft.quantum.user-guide.language.types)

Step size of Trotter integrator.


### trotterOrder : [Int](xref:microsoft.quantum.user-guide.language.types)

Order of Trotter integrator.



## Output : ([Int](xref:microsoft.quantum.user-guide.language.types),([Double](xref:microsoft.quantum.user-guide.language.types),[Qubit](xref:microsoft.quantum.concepts.the-qubit)[] => [Unit](xref:microsoft.quantum.user-guide.language.types)  is Adj + Ctl))

A tuple where: `Int` is the number of qubits allocated,`Double` is `1.0/trotterStepSize`, and the operationis the Trotter step.