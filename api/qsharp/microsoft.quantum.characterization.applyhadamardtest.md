---
uid: Microsoft.Quantum.Characterization.ApplyHadamardTest
title: ApplyHadamardTest operation
ms.date: 11/18/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Characterization
qsharp.name: ApplyHadamardTest
qsharp.summary: ''
---

# ApplyHadamardTest operation

Namespace: [Microsoft.Quantum.Characterization](xref:Microsoft.Quantum.Characterization)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)




```qsharp
operation ApplyHadamardTest (phaseShift : Bool, commonPreparation : (Qubit[] => Unit is Adj), preparation1 : (Qubit[] => Unit is Adj + Ctl), preparation2 : (Qubit[] => Unit is Adj + Ctl), control : Qubit, target : Qubit[]) : Unit is Adj
```


## Input

### phaseShift : [Bool](xref:microsoft.quantum.lang-ref.bool)




### commonPreparation : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj




### preparation1 : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl




### preparation2 : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl




### control : [Qubit](xref:microsoft.quantum.lang-ref.qubit)




### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]





## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

