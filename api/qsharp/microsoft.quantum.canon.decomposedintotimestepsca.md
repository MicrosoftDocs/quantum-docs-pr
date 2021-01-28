---
uid: Microsoft.Quantum.Canon.DecomposedIntoTimeStepsCA
title: DecomposedIntoTimeStepsCA function
ms.date: 1/28/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: DecomposedIntoTimeStepsCA
qsharp.summary: >-
  Returns an operation implementing the Trotter–Suzuki integrator for
  a given operation.
---

# DecomposedIntoTimeStepsCA function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns an operation implementing the Trotter–Suzuki integrator fora given operation.

```qsharp
function DecomposedIntoTimeStepsCA<'T> ((nSteps : Int, op : ((Int, Double, 'T) => Unit is Adj + Ctl)), trotterOrder : Int) : ((Double, 'T) => Unit is Adj + Ctl)
```


## Input

### nSteps : [Int](xref:microsoft.quantum.lang-ref.int)

The number of operations to be decomposed into time steps.


### op : ([Int](xref:microsoft.quantum.lang-ref.int),[Double](xref:microsoft.quantum.lang-ref.double),'T) => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl

An operation which accepts an index input (type `Int`) and a timeinput (type `Double`) for decomposition.


### trotterOrder : [Int](xref:microsoft.quantum.lang-ref.int)

Selects the order of the Trotter–Suzuki integrator to be used.Order 1 and even orders 2, 4, 6,... are currently supported.



## Output : ([Double](xref:microsoft.quantum.lang-ref.double),'T) => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl

Returns a unitary implementing the Trotter–Suzuki integrator, wherethe first parameter `Double` is the integration step size, and thesecond parameter is the target acted upon.

## Type Parameters

### 'T

The type which each time step should act upon; typically, either`Qubit[]` or `Qubit`.

## Remarks

When called with `order` equal to `1`, this function returns an operationthat can be simulated by the lowest-order Trotter–Suzuki integrator$$\begin{align}S_1(\lambda) = \prod_{j = 1}^{m} e^{H_j \lambda},\end{align}$$where we have followed the notation of[quant-ph/0508139](https://arxiv.org/abs/quant-ph/0508139)and let $\lambda$ be the evolution time (represented by the first inputof the returned operation), and have let $\{H_j\}_{j = 1}^{m}$ be theset of (skew-Hermitian) dynamical generators being integrated such that`op(j, lambda, _)` is simulated by the unitary operator$e^{H_j \lambda}$.Similarly, an `order` of `2` returns the second-order symmetricTrotter–Suzuki integrator$$\begin{align}S_2(\lambda) = \prod_{j = 1}^{m} e^{H_k \lambda / 2}\prod_{j' = m}^{1} e^{H_{j'} \lambda / 2}.\end{align}$$Higher even values of `order` are implemented using the recursiveconstruction of [quant-ph/0508139](https://arxiv.org/abs/quant-ph/0508139).

## References

- [ *D. W. Berry, G. Ahokas, R. Cleve, B. C. Sanders* ](https://arxiv.org/abs/quant-ph/0508139)