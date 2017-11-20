<table>
<tr><td><H1> Welcome to the Microsoft Quantum Development Kit internal preview</td><td>![Quantum](media/mobius_strip_preview.png)</td></tr>
</table>
Thank you helping us test the Microsoft Quantum Development Kit preview. Your participation will help improve Microsoft's quantum development experience.

<!---
Microsoft's Q# language brings new power and flexibility to the art of quantum computing. Q# and it's supporting compiler, libraries, simulators and Visual Studio development environment comprise a significant step toward a more industrial strength computing environment.
--->

## Feedback pipeline
Your feedback about all parts of the Quantum Development Kit is important. Please help us to address feedback quickly by putting one of the following "channels" in the subject of your email.
- Q# language
- Debugging and simulation
- Samples and Documentation
- Libraries
- Setup and Visual Studio integration
- General ideas and feature requests
 
Email the feedback to <qdkfeed@microsoft.com>

## Microsoft Quantum Development Kit components
The Quantum Development Kit preview provides a complete development and simulation environment that contains the following components.
<!--
> [!div class="mx-tdBreakAll"]
> |Component|Function|
> |-------------------------------------|-----------------------------------------|
> |Q# language <br>and compiler|Q# is a domain-specific programming language used for expressing quantum algorithms. <br>It is used for writing sub-programs that execute on an adjunct quantum processor, under the control of a classical host program and computer.|
> |Q# standard <br>library| The library contains operations and functions that support both the classical language <br>control requirement and the Q# quantum algorithms.  
> |Local quantum <br>machine simulator| A full state vector simulator optimized for accurate vector simulation and speed.|
> |Quantum computer <br>trace simulator| The trace simulator does not simulate the quantum environment like the local quantum <br>simulator. It is used to estimate the resources required to execute a quantum program and also <br>allow faster debugging of the non-Q# control code.|
> |Visual Studio <br>extension| The extension contains templates for Q# files and projects as well as syntax highlighting. <br>The extension also installs and creates automatic hooks to the compiler.
> [!div class="mx-tdBreakAll"]
--->
<table>
<tr><th>Component</th><th>Function</th></tr>
<tr><td>Q# language and compiler</td><td>Q# is a domain-specific programming language used for expressing quantum algorithms. It is used for writing sub-programs that execute on an adjunct quantum processor, under the control of a classical host program and computer.</td></tr>
<tr><td>Q# standard library</td><td>The library contains operations and functions that support both the classical language control requirement and the Q# quantum algorithms.</td></tr>
<tr><td>Local quantum machine simulator</td><td>A full state vector simulator optimized for accurate vector simulation and speed.</td></tr>
<tr><td>Quantum computer trace simulator</td><td>The trace simulator does not simulate the quantum environment like the local quantum simulator. It is used to estimate the resources required to execute a quantum program and also allow faster debugging of the non-Q# control code.</td></tr>
<tr><td>Visual Studio extension</td><td>The extension contains templates for Q# files and projects as well as syntax highlighting. The extension also installs and creates automatic hooks to the compiler.</td></tr>
</table>

## Quantum Development Kit documentation
The current documentation includes the following topics.
* [Quantum computing concepts](quantum-concepts-1-Intro.md) includes topics such the relevance of linear algebra to quantum computing, the nature and use of a qubit, how to read a quantum circuit, and more.
* [Installation and configuration](quantum-InstallConfig.md) describes how to quickly set up your quantum development environment. Your Visual Studio environment will be enhanced with a compiler for the Q# language and templates for Q# projects and files.
* [Quickstart- your first quantum program](quantum-WriteAQuantumProgram.md) walks you through how to create the Teleport application in the Visual Studio development environment. You'll learn how to define a Q# operation, call the Q# operation using C#, and how to execute your quantum algorithm.
* [Managing quantum machines and drivers](quantum-SimulatorsAndMachines.md) describes how quantum algorithms are executed, what quantum machines are available, and how to write a non-Q# driver for the quantum program.
* [Quantum development techniques](quantum-devguide-1-Intro.md) specifies the core concepts used to create quantum programs in Q#. Topics include file structures, operations and functions, working with qubits, and some advanced topics.
* [Q# standard libraries](libraries/intro.md) describes the operations and functions that support both the classical language control requirement and the Q# quantum algorithms. Topics include control flow, data structures, error correction, testing, and debugging. 
* [Q# language reference](quantum-QsharpReference.md) details the Q# language including the type model, expressions, statements, and compiler use.
* [For more information](quantum-ForMoreInfo.md) contains specially selected references to deep coverage of quantum computing topics.
* [Quantum trace simulator reference](https://review.docs.microsoft.com/en-us/dotnet/api/Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators?branch=master) contains reference material about trace simulator entities and exceptions.
* [Q# library reference](/api/overview.md) contains reference information about library entities by namespace.

<!--- * [Q# library reference](api/overview.md) --->
* [Q# library reference](/api/overview.md)
<!--- * [Q# library reference](../api/overview.md)
* [Q# library reference](../../api/overview.md)
* [Q# library reference](api/microsoft.quantum.primitive.h.yml) 
--->
* [Q# library reference](/api/microsoft.quantum.primitive.h)
<!--- * [Q# library reference](../api/microsoft.quantum.primitive.h.yml)
* [Q# library reference](../../api/microsoft.quantum.primitive.h.yml) --->

<xref: microsoft.quantum.primitive.h>
[Test](xref:uid)

<xref:microsoft.quantum.primitive.h>
[Test](xref: uid)


