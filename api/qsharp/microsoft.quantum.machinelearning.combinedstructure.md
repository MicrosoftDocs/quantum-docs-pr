---
uid: Microsoft.Quantum.MachineLearning.CombinedStructure
title: CombinedStructure function
ms.date: 11/19/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: CombinedStructure
qsharp.summary: >-
  Given one or more layers of controlled rotations, returns a single
  layer with model parameter index shifted such that distinct layers
  are parameterized by distinct model parameters.
---

# CombinedStructure function

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [Microsoft.Quantum.MachineLearning](https://nuget.org/packages/Microsoft.Quantum.MachineLearning)


Given one or more layers of controlled rotations, returns a singlelayer with model parameter index shifted such that distinct layersare parameterized by distinct model parameters.

```qsharp
function CombinedStructure (layers : Microsoft.Quantum.MachineLearning.ControlledRotation[][]) : Microsoft.Quantum.MachineLearning.ControlledRotation[]
```


## Input

### layers : [ControlledRotation](xref:Microsoft.Quantum.MachineLearning.ControlledRotation)[][]

The layers to be combined.



## Output : [ControlledRotation](xref:Microsoft.Quantum.MachineLearning.ControlledRotation)[]

A single layer of controlled rotations, representing the concatenationof all other layers.