---
title: Opening pull requests | Microsoft Docs
description: Opening pull requests
author: cgranade
ms.author: chgranad
ms.date: 10/12/2018
ms.topic: article
uid: microsoft.quantum.contributing.pulls
---

# Opening Pull Requests #

All of the documentation for the Quantum Development Kit is managed using the Git version control system through the use of several repositories hosted on GitHub.
Using Git and GitHub together makes it easy to collaborate widely on the Quantum Development Kit.
In particular, any Git repository can be cloned or forked to make a completely independent copy of that repository.
This allows you to work on your contribution with the tools and at a pace that you prefer.

When you're ready, you can send us a request to include your contribution into our repos, using GitHub's _pull request_ functionality.
The page for each pull request includes details of all the changes that make your contribution, a list of comments on your contribution, and a set of review tools that other members of the community can use to provide feedback and advice.

> [!NOTE]
> While a full tutorial on Git is beyond the scope of this guide, we can suggest the following links for more resources on learning Git:
>
> - [Learn Git](https://www.atlassian.com/git): A set of Git tutorials from Atlassian.
> - [GitHub Learning Lab](https://lab.github.com/): A set of online courses for using Git, GitHub, and related technologies.
> - [Visualizing Git](https://git-school.github.io/visualizing-git/): An interactive tool for visualizing how Git commands change the state of a repository.
> - [Version Control with Git (EPQIS 2016)](https://nbviewer.jupyter.org/github/QuinnPhys/PythonWorkshop-science/blob/master/lecture-1-scicomp-tools-part1.ipynb#Version-Control-with-Git-(50-Minutes)): A Git tutorial oriented towards scientific computing.
> - [Learn Git Branching](https://learngitbranching.js.org/): An interactive set of branching and rebasing puzzles to help learn new Git features.

## What is a Pull Request? ##

Having said the above, it's helpful to take a few moments to say what a pull request **is**.
When working with Git, any changes are represented as _commits_ that describe how those changes are related to the state of the repository before those changes.
We'll often draw diagrams in which commits are drawn as circles with arrows from previous commits.

**TODO: example**

Suppose you have started a contribution in a _branch_ called `feature`.
Then your fork of **Microsoft/Quantum** might look something like this:

![](~/media/git-workflow-step0.png)

If you make your changes in your local repository, you can _pull_ changes from another repository into yours to catch up to any changes that happened upstream.

![](~/media/git-workflow-step1.png)

Pull requests work the same way, but in reverse: when you open a pull request, you ask for the upstream repository to pull your contribution in.

![](~/media/git-workflow-step2.png)

When you open a pull request to one of our repositories, GitHub will offer an opportunity for others in the community to see a summary of your changes, to comment on them, and to make suggestions for how to help make an even better contribution.

![](~/media/pull-request-header.png)

Using this process helps us 


**TODO: describe lightweight (web-based) for small changes, links to GitHub Flow for more extensive work.**

**TODO: PR ettiquette, reviews, etc.**

## Next steps ##

Congratulations on using Git to help out the Quantum Development Kit community!
To learn more about how to contribute code, please continue with the following guide.

<div class="nextstepaction">
[Learn how to contribute code](xref:microsoft.quantum.contributing.code)
</div>
