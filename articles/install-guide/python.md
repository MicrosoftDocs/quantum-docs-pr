---
title: Getting Started with Python and Q#
author: cpalmer
uid: microsoft.quantum.install.python
ms.author: cpalmer@microsoft.com
ms.date: 2/25/19
ms.topic: article
---

# Getting Started with Python and the Quantum Development Kit #  

The [qsharp package for Python](https://pypi.org/project/qsharp/) provides interoperability with the Quantum Development Kit and with the Q# language, making it easy to simulate Q# operations and functions from within Python.

## Pre-requisites ##

To get started with the `qsharp` package, you'll need the following prerequisites:
- **.NET Core 2.2 or later**,
- **Python 3.6 or later**,

To install the latest version of [.NET Core SDK](https://dotnet.microsoft.com/),  
follow the instructions from the [.NET downloads page](https://www.microsoft.com/net/download).
  
To install Python, we recommend using the Anaconda distribution of Python.
Please see https://www.anaconda.com/distribution/ for more details.


## Installation ##

Install `qsharp` using `pip`:

```
pip install qsharp --upgrade
```

You will also need to explicitly install the `iqsharp` kernel using these commands:

```
dotnet tool install -g Microsoft.Quantum.IQSharp
dotnet iqsharp install
```

To verify IQ# was correctly installed, from the command line type: `dotnet iqsharp --version`. You should see the IQ# version reported on the output, for example:
```
C:\>dotnet iqsharp --version
Language kernel: 0.5.1903.2501
Jupyter core: 1.1.12077.0
```

## Usage ##

The `qsharp` package finds all the files under the current working folder with a `.qs` extension
and compiles them. 

To get started, create a new `Quantum.qs` file with the following content:

```qsharp
namespace Microsoft.Samples 
{
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Canon;

    operation HelloQ() : Result
    {
        Message($"Hello from quantum world!"); 
        return Zero;
    }
}
```


> [!NOTE]
> All `.qs` files under the current working folder need to correctly compile
> before any of the operations can be used from Python.


To call the `HelloQ` Q# operation from Python, first import the `qsharp` module:
```python
import qsharp
```

After this, Q# namespaces can be imported as Python packages, for example:
```python
from Microsoft.Samples import HelloQ
```

### Simulation ###

Once imported, to simulate a Q# operation invoke it's `simulate` method:
If the Q# operation returns a value, the corresponding value is returned from the `simulate` method.
If the method uses `Message` the messages will be displayed on the console, for example:

```python
>>> HelloQ.simulate()
Hello from quantum world!
0
```

A `.qs` file may contain multiple operations, for example we could add the following code to `Quantum.qs`:

```qsharp
    /// # Summary: 
    ///     A more sophisticated operation that shows how to 
    ///     specify parameters, instantiate qubits, and return values.
    operation HelloAgain(count: Int, name: String) : Result[]
    {
        Message($"Hello {name} again!"); 

        mutable r = new Result[count];
        using (q = Qubit()) {
            for (i in 1..count) {
                ApplyIf(X, i == 2, q);
                set r w/= (i - 1) <- M(q);
                Reset(q);
            }
        }

        return r;
    }
```

File changes are automatically picked up when the Python environment is restarted. To pick up
the changes immediately without having to restart Python, you can invoke `reload` method:

```python
>>> qsharp.reload()
>>> from Microsoft.Samples import HelloAgain
```

If the Q# operation expects parameters, include them as named parameters to the `simulate` method:
```python
>>> HelloAgain.simulate(count=3, name="old friend")
Hello "old friend" again!
[0, 1, 0]
```

### Resources Estimation ###

On top of simulation, you can also do quantum resources estimation including 
the count of primitive operations used by the algorithm and the number of required qubits.
For this, invoke the `estimate_resources` method on the operation which returns a dictionary
with the list of estimated resources:
```python          
>>> HelloAgain.estimate_resources(count=3, name="resources")
Hello "resources" again!
{'CNOT': 0, 'QubitClifford': 1, 'R': 0, 'Measure': 6, 'T': 0, 'Depth': 0, 'Width': 1, 'BorrowedWidth': 0}
```

The list of metrics and their description can be found in the [resources estimator documentation](xref:microsoft.quantum.machines.resources-estimator).

### Quantum Libraries ###

All `.qs` files can automatically use all [standard operations](xref:microsoft.quantum.libraries.standard.intro) 
defined in the Quantum Development Kit. 
To import operations defined in other libraries, their corresponding nuget package needs to be added first.
In particular, to use the operations from the [chemistry library](xref:microsoft.quantum.chemistry.concepts.intro)
you need to add the [Microsoft.Quantum.Chemistry](https://www.nuget.org/packages/Microsoft.Quantum.Chemistry/) package to `qsharp`.

```python
>>>import qsharp
>>> qsharp.packages.add("Microsoft.Quantum.Chemistry")
```

If your `.qs` uses operations from the chemistry library, qsharp will need to be reloaded to pick
up the new references:

```python
>>> qsharp.reload()
>>> from Microsoft.Samples import HelloAgain
```


