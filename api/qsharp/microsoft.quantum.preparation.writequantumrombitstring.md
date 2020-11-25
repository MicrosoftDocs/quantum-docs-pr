---
uid: Microsoft.Quantum.Preparation.WriteQuantumROMBitString
title: WriteQuantumROMBitString operation
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: WriteQuantumROMBitString
qsharp.summary: ''
---

# WriteQuantumROMBitString operation

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)




```qsharp
operation WriteQuantumROMBitString (idx : Int, keepCoeff : Int[], altIndex : Int[], data : Bool[][], keepCoeffRegister : Microsoft.Quantum.Arithmetic.LittleEndian, altIndexRegister : Microsoft.Quantum.Arithmetic.LittleEndian, dataRegister : Qubit[], altDataRegister : Qubit[]) : Unit is Adj + Ctl
```


## Input

### idx : [Int](xref:microsoft.quantum.user-guide.language.types)




### keepCoeff : [Int](xref:microsoft.quantum.user-guide.language.types)[]




### altIndex : [Int](xref:microsoft.quantum.user-guide.language.types)[]




### data : [Bool](xref:microsoft.quantum.user-guide.language.types)[][]




### keepCoeffRegister : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)




### altIndexRegister : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)




### dataRegister : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[]




### altDataRegister : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[]





## Output : [Unit](xref:microsoft.quantum.user-guide.language.types)

