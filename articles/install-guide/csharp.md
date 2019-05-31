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
## Update ##
Follow these instructions to migrate your .csproj files to the newest version: 

1. Consult [Nuget.org](https://www.nuget.org/packages/Microsoft.Quantum.Development.Kit/) for the `PackageReference` number, "0.n.xxxx.yyy" for the Microsoft Quantum Development Kit package.
2. Projects need to be upgraded in order.  If you have a solution with multiple projects, update each project in the order they are referenced.
3. From a command line, run `dotnet clean` to remove all existing binaries and intermediate files.
4. In a text editor, edit the .csproj file to change the version of all the "Microsoft.Quantum" `PackageReference` to the package reference number, for example:
```xml
    <PackageReference Include="Microsoft.Quantum.Standard" Version="0.n.xxxx.yyy" />
    <PackageReference Include="Microsoft.Quantum.Development.Kit" Version="0.n.xxxx.yyy" />
```
5. From the command line, run this command: `dotnet build`  

## Usage ##

Take a look at the [quickstart guide](xref:microsoft.quantum.write-program) for information on how to write 
Q# operations and how to invoke them from C#.


