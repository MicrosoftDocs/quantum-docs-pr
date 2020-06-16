# Articles

In this directory you can find the articles for the documentation of the Quantum
Development Kit. This directory contains:

- **Articles directories**: contain the articles for each section of
  the documentation. In these directories you can find the following contents:
  
  - Every directory contains a `toc.yml` file to display the content of the directory
    in the main Table Of Contents (TOC).
  - Markdown articles that contain the documentation content. These articles
    should follow the guidelines of the [Microsoft Docs contributor
    guide](https://docs.microsoft.com/en-us/contribute/).
  - Articles sub-directories. These
    sub-directories should also contain their own `toc.yml` file.

> :pencil: Although it's possible to refer the `*.md` files directly in the parent
> `TOC.yml` file, to keep things ordered we only refer them from the `toc.yml`
> of their current directory.

- **Main table of contents (TOC) `TOC.yml` file**: in this file the sections of
  the website TOC are listed together with the reference to the main `toc.yml`
  file of the directory of each section.
- **`index.yml`** YAML with the configuration of the landing page of the documentation.
- **`\media`**: A directory to store all the images used in the documentation. It
  contains a `\media\src` subdirectory to store source files of the images.
- **License files**: files containing legal licenses
- **Technical files**: files containing macros and metadata.

## Guidelines

Some general guidelines about the organization of this directory
for contributors:

- Every directory or sub-directory should contain its own `toc.yml` file in
  which are referred the same-level articles or the `toc.yml` files of its child directories.
- The organization of the directories of the repository should be as close as possible to the
  organization of the table of contents of the documentation website.
- All the images should be stored in `articles\media` and not in the articles
  folder.
- The titles of the articles, the names in the TOC and the *uid* of the metadata
  should be as close as possible among them and represent clearly the H1 header
  of the Markdown document.

## Adding images

To have the images rendering properly in dark mode you must avoid transparencies.
- For `*.jpg` files you don't need to do anything since the file format doesn't support transparent elements.
- For `*.png` files you must add a white background or change the value of the alpha channel to 100. The easiest way to do this in Windows is by opening the file in Paint and saving, overwriting the original file.
- For `*.svg` files you must add a white rectangle in the lowest layer. You can do this with Inkscape:
  - Open the `*.svg` file.
  - Select the square maker tool and draw a white rectangle on top of the original figure.
  - Select the tool "Select and transform objects" by clicking in the dark arrow or pressing F1.
  - While having the rectangle selected, click in the toolbar element "Lower selection to bottom (End)".
  - Adjust the rectangle with the mouse or the arrow keys.
