---
title: Getting Started with C# and Q#
uid: microsoft.quantum.install.csharp
author: anpaz-msft
ms.author: anpaz@microsoft.com
ms.date: 3/27/19
ms.topic: article
---

# Getting Started with C# and the Quantum Development Kit #  

C# is supported natively in the Quantum Development Kit making it easy to call Q# operations from C#.


## Pre-requisites ##

To write C# programs, download and install the **.NET Core SDK** 2.1 or later from the [.NET downloads page](https://www.microsoft.com/net/download).


## Installation ##

To download the latest templates for creating new C# projects and libraries that invoke Q# operations, execute this from a command line:
```Bash
dotnet new -i Microsoft.Quantum.ProjectTemplates
```

To verify everything is correctly installed, create and run a new program using the following from a command line:
```Bash
dotnet new console -lang Q# -o myApp
cd MyApp
dotnet run
```

If everything works ok, you will see a "Hello quantum world!" message, for example:
```Prompt
C:\>dotnet new console -lang Q# -o myApp
The template "Console Application" was created successfully.

C:\>cd myApp

C:\Repos\myApp>dotnet run
Hello quantum world!
```


## Usage ##

Take a look at the [quickstart guide](xref:microsoft.quantum.write-program) for information on how to write 
Q# operations and how to invoke them from C#.


