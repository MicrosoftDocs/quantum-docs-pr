---
title: Q# File Structure
description: Describes the structure and syntax of a Q# file.
author: gillenhaalb
ms.author: a-gibec@microsoft.com
ms.date: 03/05/2020
ms.topic: article
uid: microsoft.quantum.guide.filestructure
---

# Q# File Structure

Every Q# operation, function, and user-defined type is defined within a namespace.

A Q# file consists of a sequence of *namespace declarations*.
Each namespace declaration contains declarations for user-defined types, operations, and functions.
A namespace declaration may contain any number of each type of declaration, and in any order.
Follow these links for more details on declaring [user-defined types](xref:microsoft.quantum.guide.types#user-defined-types), [operations](xref:microsoft.quantum.guide.operationsfunctions#defining-new-operations), and [functions](xref:microsoft.quantum.guide.operationsfunctions#defining-new-functions) within a namespace.

The only text that can appear outside of a namespace declaration is comments.
In particular, documentation comments (more details below) for a namespace precede the declaration.

## Namespace Declarations

A Q# file will typically have exactly one namespace declaration, but may have none (and be empty or just contain comments) or may contain multiple namespaces.
Namespace declarations may not be nested.

The same namespace may be declared in multiple Q# files that are compiled together, as long as there are no type, operation, or function declarations with the same name.
In particular, it is invalid to define the same type in the same namespace in multiple files, even if the declarations are identical.

A namespace declaration consists of the keyword `namespace`, followed by the name of the namespace, an open brace `{`, the declarations contained in the namespace, and a close brace `}`.
Namespace names follow the .NET pattern of a sequence of one or more legal symbols separated by periods `.`.
For instance, `MyQuantumStuff` and `Microsoft.Quantum.Intrinsic` are valid namespace names.
By convention, the symbols in a namespace name are capitalized, but this is not required.

References to types or callables declared further down in a file are resolved properly; there is no need for the type, operation, or function declaration to precede a reference to it.

## Open Directives

Within a namespace block, the `open` directive may be used to import all types and callables declared in a certain namespace and refer to them by their unqualified name.
Such an `open` directive consists of the `open` keyword, followed by the namespace to be opened and a terminating semicolon.

> [!NOTE] 
> All `open` directives must appear before any `function`, `operation`, or `newtype` declarations in the namespace block.

Optionally, a short name for the opened namespace may be defined such that all elements from that namespace can (and need) to be qualified by the defined short name. 
For example, given the following namespace declaration and open directives,

```qsharp
namespace NS {
    open Microsoft.Quantum.Intrinsic; // opens the namespace
    open Microsoft.Quantum.Math as Math; // defines a short name for the namespace

    // operation, function, and newtype declarations

}
```

if an operation we declare uses an operation `Op` from `Microsoft.Quantum.Intrinsic`, we would call it by simply using `Op`.
However, if we wanted a call a certain function `Fn` from `Microsoft.Quantum.Math`, we would need to call it using `Math.Fn`.

The `open` directive applies to the entire namespace block within a file.
Hence, if we were to define an additional namespace in the same Q# file as `NS` above, then any operations/functions/types defined in the second namespace would not have access to anything from `Microsoft.Quantum.Intrinsic` or `Microsoft.Quantum.Math` unless we repeated the open directives therein. 

A type or callable defined in another namespace that is *not* opened in the current namespace must be referenced by its fully-qualified name.
For example, an operation named `Op` from the `X.Y` namespace must be referenced by its fully-qualified name `X.Y.Op`, unless the `X.Y` namespace has been opened earlier in the current block. 
As mentioned above, even if the `X` namespace has been opened, it is not possible to reference the operation as `Y.Op`.
If a short name `Z` for `X.Y` has been defined in that namespace and file, then `Op` needs to be referred to as `Z.Op`. 

It is usually better to include a namespace by using an `open` directive.
Using a fully-qualified name is required if two namespaces define constructs with the same name, and the current source uses constructs from both.

Q# follows the same rules for naming as other .NET languages.
However, Q# does not support relative references to namespaces.
That is, if the namespace `a.b` has been opened, a reference to an operation named `c.d` will *not* be resolved to an operation with full name `a.b.c.d`.

## Formatting

Most Q# statements and directives end with a terminating semicolon, `;`.
Statements and declarations such as `for` and `operation` that end with a statement block (see below) do not require a terminating semicolon.
Each statement description notes whether the terminating semicolon is required.

Statements, like expressions, declarations, and directives, may be broken out across multiple lines.
Having multiple statements on a single line should be avoided.

## Statement Blocks

Q# statements are grouped into statement blocks.
A statement block starts with an opening `{` and ends with a closing `}`.

A statement block that is lexically enclosed within another block is considered to be a sub-block of the containing block; containing and sub-blocks are also called outer and inner blocks.

## Comments

Comments begin with two forward slashes, `//`,
and continue until the end of line.
A comment may appear anywhere in a Q# source file.

## Documentation Comments

Comments that begin with three forward slashes, `///`,
are treated specially by the compiler when they appear immediately before
a namespace, operation, specialization, function, or type definition.
In that case, their contents are taken as documentation for the defined
callable or user-defined type, as for other .NET languages.

Within `///` comments, text to appear as a part of API documentation is
formatted as [Markdown](https://daringfireball.net/projects/markdown/syntax),
with different parts of the documentation being indicated by specially-named
headers.
As an extension to Markdown, cross references to operations, functions and
user-defined types in Q# can be included using the `@"<ref target>"`,
where `<ref target>` is replaced by the fully qualified name of the
code object being referenced.
Optionally, a documentation engine may also support additional
Markdown extensions.

For example:

```qsharp
/// # Summary
/// Given an operation and a target for that operation,
/// applies the given operation twice.
///
/// # Input
/// ## op
/// The operation to be applied.
/// ## target
/// The target to which the operation is to be applied.
///
/// # Type Parameters
/// ## 'T
/// The type expected by the given operation as its input.
///
/// # Example
/// ```Q#
/// // Should be equivalent to the identity.
/// ApplyTwice(H, qubit);
/// ```
///
/// # See Also
/// - Microsoft.Quantum.Intrinsic.H
operation ApplyTwice<'T>(op : ('T => Unit), target : 'T) : Unit {
    op(target);
    op(target);
}
```

The following names are recognized as documentation comment headers.

- **Summary**: A short summary of the behavior of a function or operation,
  or of the purpose of a type. The first paragraph of the summary is used
  for hover information. It should be plain text.
- **Description**: A description of the behavior of a function or operation,
  or of the purpose of a type. The summary and description are concatenated to
  form the generated documentation file for the function, operation, or type.
  The description may contain in-line LaTeX-formatted symbols and equations.
- **Input**: A description of the input tuple for an operation or function.
  May contain additional Markdown subsections indicating each individual
  element of the input tuple.
- **Output**: A description of the tuple returned by an operation or function.
- **Type Parameters**: An empty section which contains one additional
  subsection for each generic type parameter.
- **Example**: A short example of the operation, function or type in use.
- **Remarks**: Miscellaneous prose describing some aspect of the operation,
  function, or type.
- **See Also**: A list of fully qualified names indicating related functions,
  operations, or user-defined types.
- **References**: A list of references and citations for the item being
  documented.

## Next steps

Learn about [Operations and Functions](xref:microsoft.quantum.guide.operationsfunctions) in Q#.