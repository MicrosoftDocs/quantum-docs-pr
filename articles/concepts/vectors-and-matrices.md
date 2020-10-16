---
title: Vectors and matrices in quantum computing
description: Learn the basics of how to work with vectors and matrices.
author: QuantumWriter
uid: microsoft.quantum.concepts.vectors
ms.author: v-benbra
ms.date: 12/11/2017
ms.topic: article
no-loc: ['Q#', '$$v', '$$', "$$", '$', "$", $, $$, '\cdots', 'bmatrix', '\ddots', '\equiv', '\sum', '\begin', '\end', '\sqrt', '\otimes', '{', '}', '\text', '\phi', '\kappa', '\psi', '\alpha', '\beta', '\gamma', '\delta', '\omega', '\bra', '\ket', '\boldone', '\\\\', '\\', '=', '\frac', '\text', '\mapsto', '\dagger', '\to', '\begin{cases}', '\end{cases}', '\operatorname', '\braket', '\id', '\expect', '\defeq', '\variance', '\dd', '&', '\begin{align}', '\end{align}', '\Lambda', '\lambda', '\Omega', '\mathrm', '\left', '\right', '\qquad', '\times', '\big', '\langle', '\rangle', '\bigg', '\Big', '|', '\mathbb', '\vec', '\in', '\texttt', '\ne', '<', '>', '\leq', '\geq', '~~', '~', '\begin{bmatrix}', '\end{bmatrix}', '\_']
---

# Vectors and Matrices

Some familiarity with vectors and matrices is essential to understand quantum computing. We provide a brief introduction below and interested readers are recommended to read a standard reference on linear algebra such as *Strang, G. (1993). Introduction to linear algebra (Vol. 3). Wellesley, MA: Wellesley-Cambridge Press* or an online reference such as [Linear Algebra](http://joshua.smcvt.edu/linearalgebra/).

A column vector (or simply [*vector*](https://en.wikipedia.org/wiki/Vector_(mathematics_and_physics))) $v$ of dimension (or size) $n$ is a collection of $n$ complex numbers $(v_1,v_2,\ldots,v_n)$ arranged as a column:

$$v =\begin{bmatrix}
v_1\\\\
v_2\\\\
\vdots\\\\
v_n
\end{bmatrix}$$

The norm of a vector $v$ is defined as $\sqrt{\sum\_i |v\_i|^2}$. A vector is said to be of unit norm (or alternatively it is called a [*unit vector*](https://en.wikipedia.org/wiki/Unit_vector)) if its norm is $1$. The [*adjoint of a vector*](https://en.wikipedia.org/wiki/Adjoint_matrix) $v$ is denoted $v^\dagger$ and is defined to be the following row vector where $\*$ denotes the complex conjugate,

$$\begin{bmatrix}v_1 \\\\ \vdots \\\\ v_n \end{bmatrix}^\dagger = \begin{bmatrix}v_1^* & \cdots & v_n^* \end{bmatrix}$$

The most common way to multiply two vectors together is through the [*inner product*](https://en.wikipedia.org/wiki/Inner_product_space), also known as a dot product.  The inner product gives the projection of one vector onto another and is invaluable in describing how to express one vector as a sum of other simpler vectors.  The inner product between $u$ and $v$, denoted $\left\langle u, v\right\rangle$ is defined as

$$
\langle u, v\rangle = u^\dagger v=u\_1^{\*} v_1 + \cdots + u\_n^{\*} v\_n.
$$

This notation also allows the norm of a vector $v$ to be written as $\sqrt{\langle v, v\rangle}$.

We can multiply a vector with a number $c$ to form a new vector whose entries are multiplied by $c$. We can also add two vectors $u$ and $v$ to form a new vector whose entries are the sum of the entries of $u$ and $v$. These operations are depicted below:

$$\mathrm{If}~u =\begin{bmatrix}
u_1\\\\
u_2\\\\
\vdots\\\\
u_n
\end{bmatrix}~\mathrm{and}~
v =\begin{bmatrix}
	v_1\\\\
	v_2\\\\
	\vdots\\\\
	v_n
\end{bmatrix},~\mathrm{then}~
au+bv =\begin{bmatrix}
au_1+bv_1\\\\
au_2+bv_2\\\\
\vdots\\\\
au_n+bv_n
\end{bmatrix}.
$$

A [*matrix*](https://en.wikipedia.org/wiki/Matrix_(mathematics)) of size $m \times n$ is a collection of $mn$ complex numbers arranged in $m$ rows and $n$ columns as shown below:

$$M = 
\begin{bmatrix}
M_{11} ~~ M_{12} ~~ \cdots ~~ M_{1n}\\\\
M_{21} ~~ M_{22} ~~ \cdots ~~ M_{2n}\\\\
\ddots\\\\
M_{m1} ~~ M_{m2} ~~ \cdots ~~ M_{mn}\\\\
\end{bmatrix}.$$

Note that a vector of dimension $n$ is simply a matrix of size $n \times 1$. As with vectors, we can multiply a matrix with a number $c$ to obtain a new matrix where every entry is multiplied with $c$, and we can add two matrices of the same size to produce a new matrix whose entries are the sum of the respective entries of the two matrices. 

## Matrix Multiplication and Tensor Products

We can also multiply two matrices $M$ of dimension $m\times n$ and $N$ of dimension $n \times p$ to get a new matrix $P$ of dimension $m \times p$ as follows:

\begin{align}
&\begin{bmatrix}
	M_{11} ~~ M_{12} ~~ \cdots ~~ M_{1n}\\\\
	M_{21} ~~ M_{22} ~~ \cdots ~~ M_{2n}\\\\
	\ddots\\\\
	M_{m1} ~~ M_{m2} ~~ \cdots ~~ M_{mn}
\end{bmatrix}
\begin{bmatrix}
N_{11} ~~ N_{12} ~~ \cdots ~~ N_{1p}\\\\
N_{21} ~~ N_{22} ~~ \cdots ~~ N_{2p}\\\\
\ddots\\\\
N_{n1} ~~ N_{n2} ~~ \cdots ~~ N_{np}
\end{bmatrix}=\begin{bmatrix}
P_{11} ~~ P_{12} ~~ \cdots ~~ P_{1p}\\\\
P_{21} ~~ P_{22} ~~ \cdots ~~ P_{2p}\\\\
\ddots\\\\
P_{m1} ~~ P_{m2} ~~ \cdots ~~ P_{mp}
\end{bmatrix}
\end{align}

where the entries of $P$ are $P_{ik} = \sum_j M_{ij}N_{jk}$. For example, the entry $P_{11}$ is the inner product of the first row of $M$ with the first column of $N$. Note that since a vector is simply a special case of a matrix, this definition extends to matrix-vector multiplication. 

All the matrices we consider will either be square matrices, where the number of rows and columns are equal, or vectors, which corresponds to only $1$ column. One special square matrix is the [*identity matrix*](https://en.wikipedia.org/wiki/Identity_matrix), denoted $\boldone$, which has all its diagonal elements equal to $1$ and the remaining elements equal to $0$:

$$\boldone=\begin{bmatrix}
1 ~~ 0 ~~ \cdots ~~ 0\\\\
0 ~~ 1 ~~ \cdots ~~ 0\\\\
~~ \ddots\\\\
0 ~~ 0 ~~ \cdots ~~ 1
\end{bmatrix}.$$

For a square matrix $A$, we say a matrix $B$ is its [*inverse*](https://en.wikipedia.org/wiki/Invertible_matrix) if $AB = BA = \boldone$. The inverse of a matrix need not exist, but when it exists it is unique and we denote it $A^{-1}$. 

For any matrix $M$, the adjoint or conjugate transpose of $M$ is a matrix $N$ such that $N_{ij} = M_{ji}^\*$. The adjoint of $M$ is usually denoted $M^\dagger$. We say a matrix $U$ is [*unitary*](https://en.wikipedia.org/wiki/Unitary_matrix) if $UU^\dagger = U^\dagger U = \boldone$ or equivalently, $U^{-1} = U^\dagger$.  Perhaps the most important property of unitary matrices is that they preserve the norm of a vector.  This happens because 

$$\langle v,v \rangle=v^\dagger v = v^\dagger U^{-1} U v = v^\dagger U^\dagger U v = \langle U v, U v\rangle.$$  

A matrix $M$ is said to be [*Hermitian*](https://en.wikipedia.org/wiki/Hermitian_matrix) if $M=M^\dagger$.

Finally, the [*tensor product*](https://en.wikipedia.org/wiki/Tensor_product) (or Kronecker product) of two matrices $M$ of size $m\times n$ and $N$ of size $p \times q$ is a larger matrix $P=M\otimes N$ of size $mp \times nq$, and is obtained from $M$ and $N$ as follows:

\begin{align}
	M \otimes N &=
	\begin{bmatrix}
		M_{11} ~~ \cdots ~~ M_{1n} \\\\
		\ddots\\\\
		M_{m1}  ~~ \cdots ~~ M_{mn}
	\end{bmatrix}
	\otimes
	\begin{bmatrix}
		N_{11}  ~~ \cdots ~~ N_{1q}\\\\
		\ddots\\\\
		N_{p1} ~~ \cdots ~~ N_{pq}
	\end{bmatrix}\\\\
	&=
	\begin{bmatrix}
		M_{11} \begin{bmatrix} N_{11}  ~~ \cdots ~~ N_{1q}\\\\ \ddots\\\\ N_{p1} ~~ \cdots ~~ N_{pq} \end{bmatrix}~~ \cdots ~~ 
		M_{1n} \begin{bmatrix} N_{11}  ~~ \cdots ~~ N_{1q}\\\\ \ddots\\\\ N_{p1} ~~ \cdots ~~ N_{pq} \end{bmatrix}\\\\
		\ddots\\\\
		M_{m1} \begin{bmatrix} N_{11}  ~~ \cdots ~~ N_{1q}\\\\ \ddots\\\\ N_{p1} ~~ \cdots ~~ N_{pq} \end{bmatrix}~~ \cdots ~~ 
		M_{mn} \begin{bmatrix} N_{11}  ~~ \cdots ~~ N_{1q}\\\\ \ddots\\\\ N_{p1} ~~ \cdots ~~ N_{pq} \end{bmatrix}
	\end{bmatrix}.
\end{align}

This is better demonstrated with some examples:

$$
	\begin{bmatrix}
		a \\\\ b  \end{bmatrix} \otimes \begin{bmatrix} c \\\\ d \\\\ e
	\end{bmatrix} =
	\begin{bmatrix}
		a \begin{bmatrix} c \\\\ d \\\\ e \end{bmatrix}
		\\\\[1.5em]
		b \begin{bmatrix} c \\\\ d \\\\ e\end{bmatrix}
	\end{bmatrix}
	= \begin{bmatrix} a c \\\\ a d \\\\ a e \\\\ b c \\\\ b d \\\\ be\end{bmatrix}
$$

and

$$
	\begin{bmatrix}
		a\ b \\\\ c\ d
	\end{bmatrix}
	\otimes 
	\begin{bmatrix}
		e\ f\\\\g\ h
	\end{bmatrix}
	 =
	\begin{bmatrix}
	a\begin{bmatrix}
	e\ f\\\\ g\ h
	\end{bmatrix}
	b\begin{bmatrix}
	e\ f\\\\ g\ h
	\end{bmatrix}
	\\\\[1em]
	c\begin{bmatrix}
	e\ f\\\\ g\ h
	\end{bmatrix}
	d\begin{bmatrix}
	e\ f\\\\ g\ h
	\end{bmatrix}
	\end{bmatrix}
	=
	\begin{bmatrix}
	ae\ af\ be\ bf \\\\
	ag\ ah\ bg\ bh \\\\
	ce\ cf\ de\ df \\\\
	cg\ ch\ dg\ dh
	\end{bmatrix}.
$$

A final useful notational convention surrounding tensor products is that, for any vector $v$ or matrix $M$, $v^{\otimes n}$ or $M^{\otimes n}$ is short hand for an $n$-fold repeated tensor product.  For example:

\begin{align}
&\begin{bmatrix} 1 \\\\ 0 \end{bmatrix}^{\otimes 1} = \begin{bmatrix} 1 \\\\ 0 \end{bmatrix}, \qquad\begin{bmatrix} 1 \\\\ 0 \end{bmatrix}^{\otimes 2} = \begin{bmatrix} 1 \\\\ 0 \\\\0 \\\\0 \end{bmatrix}, \qquad\begin{bmatrix} 1 \\\\ -1 \end{bmatrix}^{\otimes 2} = \begin{bmatrix} 1 \\\\ -1 \\\\-1 \\\\1 \end{bmatrix},
\\\\
  &\begin{bmatrix}	0 & 1 \\\\ 1& 0 	\end{bmatrix}^{\otimes 1}= \begin{bmatrix}	0& 1 \\\\ 1& 0 	\end{bmatrix},	\qquad\begin{bmatrix}	0 & 1 \\\\ 1& 0 	\end{bmatrix}^{\otimes 2}= \begin{bmatrix} 0 &0&0&1 \\\\ 0 &0&1&0 \\\\ 0 &1&0&0\\\\ 1 &0&0&0\end{bmatrix}.
\end{align}
