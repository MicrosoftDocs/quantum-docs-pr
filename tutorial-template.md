---
title: Markdown template for quantum tutorials
description: Template and guidance for writing tutorials for the Microsoft Quantum Development Kit documentation. 
author: bradben
ms.author: bradben
ms.date: 04/01/2020
ms.topic: article
uid: microsoft.quantum.tutorial-template

# title: <title should express the intent of the article. Google displays the title on the search results page, best to keep length to 60-65 characters including spaces. For example "Tutorial: Write and simulate qubit-level programs in Q#">
# description: <Description of the tutorial for SEO - this text also appears on the search results page> 
# author: <GitHub handle>
# ms.author: <ms alias>
# ms.date: 04/01/2020
# ms.topic: tutorial
# uid: microsoft.quantum.tutorial.<unique name for tutorial>

# For future contributors, describe the customer intent of the tutorial
# Customer intent: As a <type of user>, I want to <what?> so that <why>.
---

<!-- General guidelines

    * DO:
        * Comment your code generously
        * Include a "Clean Up" section before the Summary section if an environment or configuration needs to be reset
    * DO NOT: 
        * Include links to other content (such as our doc set or APIs) in the procedures. Explain everything that the user needs to know to do the task. This helps keep them focused and on task. EXCEPTION for the Prerequisites section for links to installation, configuration, etc.
        * Include a 'More Info', 'Resources', or 'See Also' section
    * AVOID:
        * Notes, Tips, and Important boxes. Users find them distracting and generally skip over them. 
        * Excessive bulleted or numbered lists. Use only as needed for clarity. 

-->

# Tutorial: <state what the tutorial accomplishes> 
 <!-- (example) "Tutorial: Write and simulate qubit-level programs in Q#". This should reflect the title in the metadata but doesn't need to match exactly-->

 <!-- 
    * Provide a high-level abstract of the tutorial: what the user will do, accomplish, and learn. "In this tutorial you will do..." 

    * Provide a bullet list of what is covered, based on the H2 procedure steps. Use the 'checklist' class to display green checkmarks (for this checklist only)
-->

> [!div class="checklist"]
> * Procedure-1
> * Procedure-2
> * Procedure-3

## Prerequisites
 <!-- 
 Provide as necessary:
     * Software versions of installations
     * Previous tutorials or knowledge
     * Preparations such as creating a host project (this can be a link to How to Create a Q# Project)
-->

## Procedure_1 (Write the Q# code)
<!-- "This procedure walks you through writing the code to..."  -->

<!-- Include:
    * A short sentence or two describing what happens in this section
    * List and link the steps performed in this section
    * [optional] Display the finished and commented Q# code block. It can be beneficial to see the big picture first. 
-->

### Step_1 
<!-- Step names should describe an action, for example, "Add the Quantum.Operations namespace definition", "Measure the qubits and store the results">
<!-- Include
    * Brief description of what this step does
    * Individual steps as needed
    * Explain what this step accomplishes, what commands were used
    * Other pertinent notes or comments
-->
### Step_2

### Step_3

## Procedure_2 (Write the host code and run the program)
<!-- "This procedure walks you through running the code to..."  -->

<!-- Include:
    * A short sentence or two describing what happens in this section
    * (If more than 2 or 3 steps) List and link the steps performed in this section
    * A tabbed structure with code examples for the Python (if supported for the scenario), C# for VS, and C# for VS Code hosts'
-->
### Step_1
<!-- Include (as needed)
    * Brief description of what this step does
    * Individual steps as needed
    * Explain what this step accomplishes, what commands were used
    * Other pertinent notes or comments
-->
### Step_2

## Procedure_3 (Analyze results)
<!-- "This procedure analyzes the output of the scenario..."  -->

<!-- Display the results and explain how they relate to the code and concept 

     Create output results for each of the host code examples used in Procedure 2.

-->
## Summary
<!-- Review the scenario and highlight:
    * Key learning takeaways
    * Other possible applications of this knowledge
    * New concepts and commands introduced
-->

## Next Steps
<!-- Include one link only to:
    * The next logical tutorial in the series, or
    * The continuation or variations on this tutorial (see below)
    * Another related task that the user can do
-->

<!-- As applicable, add a second tutorial to take advantage of the working environment the user just built to demonstrate variations of the scenario and to expand and reinforce learning, ie., "What if the input to X was negative?", "Replace <that code> with <this code> and compare the results" 

    * Indicate that this is a continuation of the previous tutorial
    * Procedures may be streamlined, for example to Proc_Apply_Variations, and Proc_View_New_Results
    -->