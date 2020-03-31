# Microsoft Quantum Documenation
Welcome to the official documentation repository for the Microsoft Quantum Development Kit.


This repository contains open-source documentation articles and automatically generated API files.  There are two main folders:
- **[articles/](./articles)** contains the Markdown articles and YAML files that constitute the source of the [QDK documentation](https://docs.microsoft.com/quantum/?view=qsharp-preview).
- **[api/](./api)** contains the *automatically generated* API documentation that serves as the source for the [Q# API reference](https://docs.microsoft.com/en-us/qsharp/api/?view=qsharp-preview).

> :warning: If you want to modify an article of the API reference, **DO NOT** modify the `*.yml` file in this repository, as any changes would be automatically overwritten in the next build. These files are automatically generated from the comments in the language source code files, which are located in the repositories [Quantum Libraries](https://github.com/microsoft/QuantumLibraries) and [Q# runtime](https://github.com/microsoft/qsharp-runtime). To modify the article you should locate the original source file, apply the changes in the comments there, and submit the pull request to its respective repository.
> For more details, please see the [documentation section of the contribution guide](https://docs.microsoft.com/quantum/contributing/docs).

> :pencil: If your changes are only editorial, without association to the API, this is the right place to do it. You can directly edit 
> the `*.md` and `*.yml` files here.
## Getting started
If you are new to the QDK documentation and want to learn how to contribute you can follow our [Contributors Guide](https://docs.microsoft.com/quantum/contributing/?view=qsharp-preview).

## Microsoft Open Source Code of Conduct
This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
