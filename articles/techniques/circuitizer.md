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
Install the latest version (need to specify version) of the Quantum Development Kit using [guide](https://github.com/microsoft/qsharp-runtime#installing-the-quantum-development-kit).

=>Optional
[Qpic](https://github.com/qpic/qpic#installation)

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
var qpic = new QPicCircuitizer();
var circuitizerSimulator = new CircuitizerSimulator( qpic );
var res = HelloWorld.Sample.Run(circuitizerSimulator).Result;
qpic.WriteToFile("test.qpic");
```

#### Output

The Qpic Circuitizer generates Qpic directives that can be used to generate LaTeX circuit diagrams using Qpic compiler. The example above would result in the folowing output written to `test.qpic` file.

```qpic
WIREPAD 10
q0 G H width=12 height=10
q1 G H width=12 height=10
q0 OUT 0
q1 OUT 0
```

This output generates latex diagrams in pdf with the following command. Note that `qpic` has to be installed locally for this to work.

```bash
qpic -f pdf test.qpic; open test.pdf
```

### In Jupyter notebook

```jupyter
%circuit <operation name> -type <OutputType: ascii/qpic>
```

For instance, command will draw similar ascii circuit diagram to above.

```jupyter
%circuit Sample -type ascii
```

## Limitations
-> Classically Controlled

