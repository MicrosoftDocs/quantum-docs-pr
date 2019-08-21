---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Quantum Development Kit Q# Circuitizer | Microsoft Docs 
description: How to generate quantum circuits that represent simple Q# operations.
author: anpaz-msft
ms.author: anpaz@microsoft.com 
ms.date: 8/16/2019
ms.topic: article
uid: microsoft.quantum.machines.circuitizer
---

# Quantum Circuits from Q#

Simple quantum algorithms can have a visual representation using a quantum circuit.
The circuit diagram can be generated using the Q# circuitizer.
The Q# circuitizer supports generation of Unicode and [Qpic](https://github.com/qpic/qpic) representation of the circuit.

## Installation


## Usage

### In code
Run your q# program on the CircuitizerSimulator.

For instance, given the following q# operation.
```qs
operation Sample() : Unit {
    using( (q1, q2) = (Qubit(),Qubit()))
    {
        H(q1);
        H(q2);
    }
}
```
It can run on the CircuitizerSimulator with either the Ascii or Qpic circuitizer

#### Ascii
```cs
var circuitizer = new AsciiCircuitizer();
var circuitizerSimulator = new CircuitizerSimulator(circuitizer);
var res = HelloWorld.Sample.Run(circuitizerSimulator1).Result;
Console.WriteLine(circuitizer.ToString());
```

#### Output
       ┌─────┐
|0>────┤  H  ├───────────<0|
       └─────┘              
              ┌─────┐       
|0>───────────┤  H  ├────<0|
              └─────┘       

#### Qpic
```cs
var circuitizer = new QPicCircuitizer();
var circuitizerSimulator = new CircuitizerSimulator(circuitizer);
var res = HelloWorld.Sample.Run(circuitizerSimulator1).Result;
Console.WriteLine(circuitizer.ToString());
```

#### Output


### In Jupyter notebook


## Limitations
-> Classically Controlled

