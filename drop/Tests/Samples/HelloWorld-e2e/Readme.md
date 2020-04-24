## End-to-end Example

This is a step-by-step instruction on how to create a simple Q# operation from scratch and execute it from C# code. 

This scenario requires Visual Studio 2017; earlier versions of Visual Studio are not supported. Current VSIX has been tested with VS version 15.3.3, earlier versions might not be compatible.

1. Download and install the VisualStudio extension from [here](https://solidrepo.blob.core.windows.net/alpha/latest/QsharpVSIX.vsix). 
   Note that some browsers (IE and Microsoft Edge) might rename this file to `QsharpVSIX.zip` during download, which makes it impossible to install. Rename it back to `QsharpVSIX.vsix` or use a different browser to open download link.
1. [Configure VisualStudio](https://www.visualstudio.com/en-us/docs/package/nuget/consume) to use Solid's alpha feed: <https://quarcsw.pkgs.visualstudio.com/_packaging/alpha/nuget/v3/index.json>.
1. Create new Q# project: in **File** menu, select **New -> Project**, and find **Q# Application** in the list of Visual C# projects. This will create a project with a `.qs` file for Q# code and a `.cs` file for C# driver code.
1. If needed, create a new Q# file in your project: right-click on the project, select **Add -> New Item**, and find **Q# File** in the list of Visual C# Items. This will create a new `.qs` file. Alternatively, you can add an existing file or create it as an arbitrary text item as long as the extension of the result is `.qs`.
   During build a `.g.cs` file will be generated with the code behind for each `.qs` file.
1. In your C# driver code, follow the sequence shown in `HelloWorldDriver.cs`:
    - create a simulator (in this example `QuantumSimulator`)
    - run your Q# operation on this simulator and get the result
    - build and run the project
```
    using (var qsim = new QuantumSimulator()) {
        var result = HelloWorld.Run(qsim, 12).Result;
        System.Console.Out.WriteLine(result);
    }
```

Syntax highlighting is installed automatically during the first launch of Visual Studio after VSIX installation. Alternatively, see [syntax installer instructions](../../src/extensions/SyntaxHighlightInstaller/README.md).
