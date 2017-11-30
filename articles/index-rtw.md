---
uid: microsoft.quantum.index
---
<img src="media/mobius_strip_preview.png" style="float: right;" title="Quantum" alt="Quantum">
# Welcome to the Microsoft Quantum Development Kit preview #

Thank you for visiting Microsoft's Quantum Development Kit preview page. The development kit contains the tools you need to build your own quantum computing programs and experiments. Assuming some experience with Visual Studio, beginners can write their first quantum program, and experienced researchers can be developing new quantum algorithms in less than 90 minutes.

To jump right in, start with [Installation and validation](quantum-InstallConfig.md) to create and validate your development environment, and then use [Quickstart - your first computer program](quantum-WriteAQuantumProgram.md) to learn about the structure of a Q# project and how to write a quantum teleport application.

If you'd like more general information about Microsoft's quantum computing initiatives, see [Microsoft Quantum](https://www.microsoft.com/en-us/quantum/).

<!---
Computers as we've known them for decades can no longer solve the complex problems we are faced with. Computing power has been rapidly increasing over decades, but that trend is slowing. Even Gordon Moore, who described [Moore's Law](https://www.merriam-webster.com/dictionary/Moore's%20law), said in [2015](https://spectrum.ieee.org/computing/hardware/gordon-moore-the-man-whose-name-means-progress) that he sees silicon technology becoming saturated in the next decade.  
--->

## Feedback pipeline
Your feedback about all parts of the Quantum Development Kit is important. We ask you to provide feedback by going to [Microsoft Quantum - Feedback](https://quantum.uservoice.com/). Sign in and enter your feedback in one of the following forums. 

You will need a [Windows Live account](https://signup.live.com/) to provide feedback.

- Q# language
- Debugging and simulation
- Samples and Documentation
- Libraries
- Setup and Visual Studio integration
- General ideas and feature requests
 
## Microsoft Quantum Development Kit components
The Quantum Development Kit preview provides a complete development and simulation environment that contains the following components.
<table>
<tr><th>Component</th><th>Function</th></tr>
<tr><td>Q# language and compiler</td><td>Q# is a domain-specific programming language used for expressing quantum algorithms. It is used for writing sub-programs that execute on an adjunct quantum processor under the control of a classical host program and computer.</td></tr>
<tr><td>Q# standard library</td><td>The library contains operations and functions that support both the classical language control requirement and the Q# quantum algorithms.</td></tr>
<tr><td>Local quantum machine simulator</td><td>A full state vector simulator optimized for accurate vector simulation and speed.</td></tr>
<tr><td>Quantum computer trace simulator</td><td>The trace simulator does not simulate the quantum environment like the local quantum simulator. It is used to estimate the resources required to execute a quantum program and also allow faster debugging of the non-Q# control code.</td></tr>
<tr><td>Visual Studio extension</td><td>The extension contains templates for Q# files and projects as well as syntax highlighting. The extension also installs and creates automatic hooks to the compiler.</td></tr>
</table>

## Quantum Development Kit documentation
The current documentation includes the following topics.
* [Microsoft Quantum Development kit release notes](quantum-121117-Preview-RelNotes.md)
* [Quantum computing concepts](quantum-concepts-1-Intro.md) includes topics such the relevance of linear algebra to quantum computing, the nature and use of a qubit, how to read a quantum circuit, and more.
* [Installation and configuration](quantum-InstallConfig.md) describes how to quickly set up your quantum development environment. Your Visual Studio environment will be enhanced with a compiler for the Q# language and templates for Q# projects and files.
* [Quickstart- your first quantum program](quantum-WriteAQuantumProgram.md) walks you through how to create the Teleport application in the Visual Studio development environment. You'll learn how to define a Q# operation, call the Q# operation using C#, and how to execute your quantum algorithm.
* [Managing quantum machines and drivers](quantum-SimulatorsAndMachines.md) describes how quantum algorithms are executed, what quantum machines are available, and how to write a non-Q# driver for the quantum program.
* [Quantum development techniques](quantum-devguide-1-Intro.md) specifies the core concepts used to create quantum programs in Q#. Topics include file structures, operations and functions, working with qubits, and some advanced topics.
* [Q# standard libraries](libraries/intro.md) describes the operations and functions that support both the classical language control requirement and the Q# quantum algorithms. Topics include control flow, data structures, error correction, testing, and debugging. 
* [Q# language reference](quantum-QR-Intro.md) details the Q# language including the type model, expressions, statements, and compiler use.
* [For more information](quantum-ForMoreInfo.md) contains specially selected references to deep coverage of quantum computing topics.
* [Quantum trace simulator reference](https://review.docs.microsoft.com/en-us/dotnet/api/Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators?branch=master) contains reference material about trace simulator entities and exceptions.
* [C# components reference](https://review.docs.microsoft.com/en-us/dotnet/api/Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators?branch=master) contains reference information about the C# entities used in control code and simulation handling.
* [Q# library reference](../api/index.md) contains reference information about library entities by namespace.


