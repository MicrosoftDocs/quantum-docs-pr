---
title: Q# File Structure
description: Describes the structure and syntax of a Q# file.
author: gillenhaalb
ms.author: a-gibec
ms.date: 03/05/2020
ms.topic: article
uid: microsoft.quantum.guide.filestructure
no-loc: ['Q#', '$$v']
---

# Q# File Structure

A Q# file consists of a sequence of *namespace declarations*.
Each namespace declaration contains declarations for user-defined types, operations, and functions, and can contain any number of each type of declaration and in any order.
For more information on declarations within a namespace, see [user-defined types](xref:microsoft.quantum.guide.types#user-defined-types), [operations](xref:microsoft.quantum.guide.operationsfunctions#defining-new-operations), and [functions](xref:microsoft.quantum.guide.operationsfunctions#defining-new-functions).

The only text that can appear outside of a namespace declaration is comments.
In particular, documentation comments for a namespace precede the declaration. For more information, see [Documentation comments](#documentation-comments) in this article. 

## Namespace Declarations

A Q# file typically has just one namespace declaration, but could have none (and be empty or just contain comments) or could contain multiple namespaces.
Namespace declarations can not be nested.

You can declare the same namespace in multiple Q# files that are compiled together, as long as there are no type, operation, or function declarations with the same name.
In particular, it is invalid to define the same type in the same namespace in multiple files, even if the declarations are identical.

A namespace declaration consists of the keyword `namespace`, followed by the name of the namespace, and the declarations contained in the namespace enclosed in braces `{ }`.
Namespace names follow the .NET pattern of a sequence of one or more legal symbols separated by periods `.`.
For example, `MyQuantumStuff` and `Microsoft.Quantum.Intrinsic` are valid namespace names.
By convention, capitalize the symbols in a namespace name, however, this is not required.

References to types or callables declared further down in a file resolve properly; there is no need for the type, operation, or function declaration to precede a reference to it.

## Open Directives

Within a namespace block, use the `open` directive to import all types and callables declared in a certain namespace and refer to them by their unqualified name.
Such an `open` directive consists of the `open` keyword, followed by the namespace to be opened and a terminating semicolon.

> [!NOTE] 
> All `open` directives must appear before any `function`, `operation`, or `newtype` declarations in the namespace block.

Optionally, you can define a short name for the opened namespace. If a short name is defined, you must qualify all elements from that namespace by the defined short name. 
For example, given the following namespace declaration and open directives,

```qsharp
namespace NS {
    open Microsoft.Quantum.Intrinsic; // opens the namespace
    open Microsoft.Quantum.Math as Math; // defines a short name for the namespace

    // operation, function, and newtype declarations

}
```

if a declared operation uses an operation `Op` from `Microsoft.Quantum.Intrinsic`, you call it by simply using `Op`.
However, to call a certain function `Fn` from `Microsoft.Quantum.Math`, you must call it using `Math.Fn`.

The `open` directive applies to the entire namespace block within a file.
Hence, if you define an additional namespace in the same Q# file as `NS` earlier, then any operations/functions/types defined in the second namespace would not have access to anything from `Microsoft.Quantum.Intrinsic` or `Microsoft.Quantum.Math` unless you repeated the open directives therein. 

To reference a type or callable defined in another namespace that is *not* opened in the current namespace, you must reference it by its fully-qualified name.
For example, given an operation named `Op` from the `X.Y` namespace:

* You must reference it by its fully-qualified name `X.Y.Op`, unless the `X.Y` namespace has been opened earlier in the current block. 
* Even if the `X` namespace is opened, it is not possible to reference the operation as `Y.Op`.
* If you defined the short name `Z` for `X.Y` in that namespace and file, you must reference `Op` as `Z.Op`. 

It is usually better to include a namespace by using an `open` directive.
Using a fully-qualified name is required if two namespaces define constructs with the same name, and the current source uses constructs from both.

Q# follows the same rules for naming as other .NET languages.
However, Q# does not support relative references to namespaces.
For example, if the namespace `a.b` is open, a reference to an operation named `c.d` does *not* resolve to an operation with full name `a.b.c.d`.

## Formatting

Most Q# statements and directives end with a terminating semicolon, `;`.
Statements and declarations such as `for` and `operation` that end with a statement block (see the following section) do not require a terminating semicolon.
Each statement description notes whether the terminating semicolon is required.

Statements, like expressions, declarations, and directives, can be broken out across multiple lines.
Avoid putting multiple statements on a single line.

## Statement Blocks

Q# statements are grouped into statement blocks, which are contained with braces `{ }`. 
A statement block starts with an opening `{` and ends with a closing `}`.

A statement block that is lexically enclosed within another block is considered to be a sub-block of the containing block; containing and sub-blocks are also called outer and inner blocks.

## Comments

Comments begin with two forward slashes, `//`,
and continue until the end of the line.
A comment can appear anywhere in a Q# source file.

## Documentation Comments

Comments that begin with three forward slashes, `///`,
are treated specially by the compiler when they appear immediately before
a namespace, operation, specialization, function, or type definition.
In that case, the compiler treats them as documentation for the defined
callable or user-defined type, the same as other .NET languages.

Within `///` comments, text to appear as a part of API documentation is
formatted as [Markdown](https://daringfireball.net/projects/markdown/syntax),
with different parts of the documentation indicated by specially-named
headers.
In Markdown, use the `@"<ref target>"` extension to cross-reference operations, functions, and user-defined types in Q#. Replace `<ref target>` with the fully qualified name of the referenced code object.
Different documentation engines may also support additional
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

The following names are valid as documentation comment headers.

- **Summary**: A short summary of the behavior of a function or operation,
  or the purpose of a type. The first paragraph of the summary is used
  for hover information. It should be plain text.
- **Description**: A description of the behavior of a function or operation,
  or the purpose of a type. Together, the summary and description form the generated documentation file for the function, operation, or type.
  The description supports in-line LaTeX-formatted symbols and equations.
- **Input**: A description of the input tuple for an operation or function.
  Can contain additional Markdown subsections indicating each element of the input tuple.
- **Output**: A description of the tuple returned by an operation or function.
- **Type Parameters**: An empty section that contains one additional
  subsection for each generic type parameter.
- **Example**: A short example of the operation, function, or type in use.
- **Remarks**: Miscellaneous prose describing some aspect of the operation,
  function, or type.
- **See Also**: A list of fully qualified names indicating related functions,
  operations, or user-defined types.
- **References**: A list of references and citations for the documented item.

## Next steps

Learn about [Operations and Functions](xref:microsoft.quantum.guide.operationsfunctions) in Q#.