---

---

# Testing no-loc tag

### "\sqrt{2}" resolves correctly in VS code, but displays the no-loc tag

:::no-loc text="$\sqrt{2}$":::

:::no-loc text="$\\sqrt{2}$"::: (with extra backslash)

### Matrices and formulas work in VS code, but including \sqrt{x} displays the no-loc tag

:::no-loc text="$\\begin{bmatrix}1 \\\\  0 \end{bmatrix}\otimes \cdots \otimes\begin{bmatrix}1 \\\\  0 \end{bmatrix}$":::  (formula with no sqrt, double slash)

:::no-loc text="$\\begin{bmatrix}1 \\\\  0 \end{bmatrix}\otimes \cdots \otimes\begin{bmatrix}1 \\\\  0 \end{bmatrix} + \sqrt{2}$"::: (formula with sqrt, double slash)

#### Double slashes on different components that work in VS code

:::no-loc text="text only $\ test":::

:::no-loc text="$\\otimes \\cdots \\otimes$":::

:::no-loc text="$\\ket{0}$":::

:::no-loc text="$\\braket{0 | 1} = \\braket{1 | 0} =0$":::

:::no-loc text="$\\ket{\\psi} = {\frac{3}{5}} \\ket{1} + {\\frac{4}{5}} \\ket{0}$":::

:::no-loc text="$H^{\\otimes n} \\ket{0} = \\frac{1}{2^{n/2}} \\sum_{j=0}^{2^n-1} \\ket{j} = \\ket{+}^{\\otimes n}$":::

:::no-loc text="$\\psi^\\dagger \\otimes \\phi^\\dagger=(\\psi\\otimes \\phi)^\\dagger$":::

:::no-loc text="$P(\\text{first qubit = 1})= \\bra{\\psi}\\left(\\ket{1}\\bra{1}\\otimes \\boldone^{\\otimes n-1}\\right) \\ket{\\psi}$":::

:::no-loc text="$\\alpha : \\\{0, 1\\\}^n \\times \\\{0, 1\\\}^m \\to \\mathbb{C}$":::

#### Double $$ for centering formula 

$$\begin{bmatrix}1 \\\\  0 \end{bmatrix}$$  (without no-loc tag)

:::no-loc text="$$\begin{bmatrix}1 \\\\  0 \end{bmatrix}$$"::: (with no-loc tag, single slash)

:::no-loc text="$$\\begin{bmatrix}1 \\\\\  0 \\end{bmatrix}$$"::: (with no-loc tag, double slash)
