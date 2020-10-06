# Setup and workflow for Q# language topics from qsharp-language repo

This document is to define the setup and workflow for syncing the Q# language topics in the qsharp-language repo to the quantum-docs-pr repo for publishing as part of the QDK docset. 

* [Quantum-docs-pr structure](#quantum-docs-pr-structure)
* [QDK TOC structure](#qdk-toc-structure)
* [File sync process](#file-sync-structure)
* [Stub topics in quantum-docs-pr](#stub-topics-in-quantum-docs-pr)
* [Source content](#source-content)

Syntax for the Markdown *include* statement is [here](https://review.docs.microsoft.com/help/contribute/includes-best-practices?branch=master).

**Overall workflow:**

1. Source content is created in qsharp-language repo.
1. Source content files are copied to the /includes folder (and sub-folders) in quantum-docs-pr repo.
1. For each source content file, a stubbed topic file is created in quantum-docs-pr that includes metadata, H1 heading, and an `[!INCLUDE]` statement linking the related source content file. 
1. At build, the source content is pulled into the stubbed topic file and built as usual. 

## quantum-docs-pr structure 

* Under *articles*, create the folder *includes* and sub-folders to match qsharp-language structure:
    * ProgramStructure
    * Statements
    * Expression
    * TypeSystem 
* The *includes* folder is part of the *excluded* list in docfx.json.
* The `[!INCLUDE]` statement requires a relative filepath.

## QDK TOC structure

[Current User Guide](https://docs.microsoft.com/quantum/user-guide/)

* TBD - Will the new topic sub-folders replace the existing topics under *Q# language* in the User Guide? (*Types in Q#* and *Expressions*?)
* TBD - Will other topics under *Use Q#* be merged or replaced?

## File sync process

* The source files in the qsharp-language repo should be authoritative, with all copy edits and changes occurring there. No changes should be made in the /includes folder.
* TBD - Sync method. Will files be synced automatically? Is there a mechanism to force sync after edits?

## Stubbed topics in quantum-docs-pr

Stubbed topics will contain:

* Standard metadata (title, description, author, date, uid, etc.).
    * Suggestion for uid scheme: **microsoft.quantum.qsharp.**_topic_.
* Since content referenced in an `[!INCLUDE]` statement can't include an H1 heading, the stubbed topic needs to include the H1. 

Example:

> **title**: Microsoft Q# - Conditional branching <br>
**description**: Using the *if* statement in Q# for conditional branching.  <br>
...<br>
**uid**: microsoft.quantum.qsharp.conditional-branching
> ## Conditional branching

> [!INCLUDE [conditional branching] (../includes/statements/conditionalbranching.md)]

## Source topics 

Links in the source topics should be an xref to the uid of the target stubbed topic file. For example, 

*https://github.com/microsoft/qsharp-language/blob/main/Specifications/Language/3_Expressions/ConditionalExpressions.md#conditional-expressions*

would be 

*xref:microsoft.quantum.qsharp.conditional-branching*.

I can do this in the edit passes, but it will change in the source on the qsharp-language repo. Is this an issue? 