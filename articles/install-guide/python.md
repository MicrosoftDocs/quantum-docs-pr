---
title: Using the Quantum Development Kit with Python
author: cgranade
uid: microsoft.quantum.install.python
ms.author: christopher.granade@microsoft.com
ms.date: 2/25/2019
ms.topic: article
---

# Using the Quantum Development Kit with Python #

The `qsharp` package for Python provides interoperability with the Quantum Development Kit and with the Q# language, making it easy to simulate Q# operations and functions from within Python.

In this article, we detail the steps required to use the Quantum Development Kit from within your Python environment.

## Installation ##

To get started with the `qsharp` package, you'll need a few prerequisites:

- .NET Core SDK 2.1.3 or later,
- Python 3.6 or later,
- Jupyter, and
- The IQ# kernel for Jupyter.

To install the .NET Core SDK, please follow the [Hello World tutorial](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro) provided with .NET Core.

To install Python and Jupyter, we recommend using the Anaconda distribution of Python.
Please see https://www.anaconda.com/distribution/ for more details.
On other distributions of Python, the Jupyter platform can be installed using `pip install jupyter`.

Finally, the IQ# kernel for Jupyter can be installed using the `dotnet` command line tool:

```bash
dotnet tool install -g Microsoft.Quantum.IQSharp
dotnet iqsharp install
```

## Usage ##

Create one or more files with a `.qs` extension with the quantum operations you want to execute.
The `qsharp` package automatically detects and tries to compile all the files under the current directory that have the  `.qs` extension.

To call a Q# operation from Python, first import `qsharp`:
```python
>>> import qsharp
```

After this, Q# namespaces can be imported as Python packages, for example:
```python
>>> from Microsoft.Quantum.Python import HelloQ, HelloAgain
```

Once imported, to simulate a Q# operation invoke it's `simulate` method:
```python
>>> HelloQ.simulate()
```

If the Q# operation expects parameters, include them as keyword arguments to the `simulate` method:
```python
>>> HelloAgain.simulate(count=3, name="Alice")
```

If the Q# operation returns a value, the corresponding value is returned from the `simulate` method.
```python
>>> r = HelloAgain.simulate(count=3, name="Alice")
>>> print("HelloAgain result: ", r)
```

On top of simulation, you can also do quantum resources estimation including the count of primitive operations used by the algorithm and the number of required qubits.
For this, invoke the `estimate` method on the operation:
```python
>>> r = HelloAgain.trace(count=5, name="Counting")
```

### Calling the Q# Compiler from Python ###

You can now also compile Q# operations on the fly from Python
and simulate them.
To create an operation on the fly, the `qsharp` module exports a `compile` method that accepts a string containing Q# source as a parameter:

```python
>>> hello = qsharp.compile("""
...     operation HelloQ() : Result {
...         Message($"Hello from quantum world!");
...         return Zero;
...     }
... """)
```

If successful, `compile` returns a Q# operation that can now be simulated or traced:
```python
>>> r = hello.simulate()
```

You may call `compile` multiple times, and may refer to operations previously defined in other snippets.
Calling `compile` using a previous snippet_id updates the corresponding definition.

### Loading NuGet Packages at Runtime ###

Additional Q# libraries can be referenced at runtime by using the `qsharp.packages` object.
For instance, to download and use the Q# functionality offered by the [quantum chemistry library](xref:microsoft.quantum.chemistry.concepts.intro):

```python
>>> qsharp.packages.add("Microsoft.Quantum.Chemistry")
```

To obtain a list of packages that are currently available, iterate over the `qsharp.packages` object:

```python
>>> print(list(qsharp.packages))
```

### Viewing Q# API Documentation from Python ###

The built-in function `help` can be used to access API documentation for Q# functions and operations as well:

```python
>>> from Microsoft.Quantum.Primitive import X
>>> help(X)
```
