---
uid: Microsoft.Quantum.Characterization.ApplyHadamardTestOnSingleRegister
title: ApplyHadamardTestOnSingleRegister operation
ms.date: 11/13/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Characterization
qsharp.name: ApplyHadamardTestOnSingleRegister
qsharp.summary: ''
---

# ApplyHadamardTestOnSingleRegister operation

Namespace: [Microsoft.Quantum.Characterization](xref:Microsoft.Quantum.Characterization)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)




```qsharp
operation ApplyHadamardTestOnSingleRegister (phaseShift : Bool, commonPreparation : (Qubit[] => Unit is Adj), preparation1 : (Qubit[] => Unit is Adj + Ctl), preparation2 : (Qubit[] => Unit is Adj + Ctl), register : Qubit[]) : Unit is Adj
```


## Input

### phaseShift : [Bool](xref:microsoft.quantum.lang-ref.bool)




### commonPreparation : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj




### preparation1 : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl




### preparation2 : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl




### register : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]





## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

