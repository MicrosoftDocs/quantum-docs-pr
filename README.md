# Microsoft Quantum Documenation
Welcome to the official repository for the Microsoft Quantum Development Kit. 

This repository contains open-source documentation articles and automatically generated API files. There are two main folders:
- **[articles/](./articles)**: this folder contains the Markdown articles and YAML files that constitute the source of [the live version of the documentation](https://docs.microsoft.com/en-us/quantum/?view=qsharp-preview).
- **[api/](./api)**: this folder contains the automatically generated API documentation from the original QDK source code comments that constitue the source of the live version of the [API reference](https://docs.microsoft.com/en-us/qsharp/api/?view=qsharp-preview).
> :warning: If you want to modify an article of the API reference DO NOT modify the `*.yml` file in this repository. These files are automatically generated from the comments in the source code files of the repositories: [Quantum Libraries](https://github.com/microsoft/QuantumLibraries) and [Q# runtime](https://github.com/microsoft/qsharp-runtime). This means that any change made in those `*.yml` files will be override in the next build. To modify the article you should go to the original source file and apply the changes in the comments there.

## Microsoft Open Source Code of Conduct
This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
