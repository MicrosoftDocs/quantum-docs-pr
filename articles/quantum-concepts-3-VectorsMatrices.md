---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Intent and product brand in a unique string of 43-59 chars including spaces | Microsoft Docs 
description: 115-145 characters including spaces. Edit the intro para describing article intent to fit here. This abstract displays in the search result.
services: service-name-with-dashes-AZURE-ONLY 
keywords: Don’t add or edit keywords without consulting your SEO champ.
author: QuantumWriter
ms.author: MSFT-alias-person-or-DL
ms.date: 10/09/2017
ms.topic: article-type-from-white-list
uid: microsoft.quantum.concepts.vecmat
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# ms.service: service-name-from-white-list
# product-name-from-white-list

# Optional fields. Don't forget to remove # if you need a field.
# ms.custom: can-be-multiple-comma-separated
# ms.devlang:devlang-from-white-list
# ms.suite: 
# ms.tgt_pltfrm:
# ms.reviewer:
# manager: MSFT-alias-manager-or-PM-counterpart
---

# Vectors and Matrices

Some familiarity with vectors and matrices is essential to understand quantum computing. We provide a brief introduction below and interested readers are recommended to read a standard reference on linear algebra such as [Strang, G. (1993). Introduction to linear algebra (Vol. 3). Wellesley, MA: Wellesley-Cambridge Press] or an online reference such as http://joshua.smcvt.edu/linearalgebra/.

A column vector (or simply vector) $v$ of dimension (or size) $n$ is a collection of $n$ complex numbers $(v_1,v_2,\ldots,v_n)$ arranged as a column:

$$v =\begin{bmatrix}
v_1\\\\
v_2\\\\
\vdots\\\\
v_n
\end{bmatrix}.$$

The norm of a vector $v$ is defined as $\sqrt{\sum_i |v_i|^2}$. A vector is said to be of unit norm (or alternatively it is called a unit vector) if its norm is $1$. The adjoint of a vector $v$ is denoted $v^\dagger$ and is defined to be the following row vector

$$\begin{bmatrix}v_1 \\\\ \vdots \\\\ v_n \end{bmatrix}^\dagger = \begin{bmatrix}v_1^* & \cdots & v_n^* \end{bmatrix}.$$

The most common way to multiply two vectors together is through the inner product, also known as a dot product.  The inner product gives the projection of one vector onto another and is invaluable in describing how to express one vector as a sum of other simpler vectors.  The inner product between $u$ and $v$, denoted $\left\langle u, v\right\rangle$ is defined as

$$
\langle u, v\rangle = u^\dagger v=u_1^{*} v_1 + \cdots + u_n^{*} v_n.
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

A matrix of size $m \times n$ is a collection of $mn$ complex numbers arranged in $m$ rows and $n$ columns as shown below:

$$M = 
\begin{bmatrix}
M_{11} ~~ M_{12} ~~ \cdots ~~ M_{1n}\\\\
M_{21} ~~ M_{22} ~~ \cdots ~~ M_{2n}\\\\
\ddots\\\\
M_{m1} ~~ M_{m2} ~~ \cdots ~~ M_{mn}\\\\
\end{bmatrix}$$

Note that a vector of dimension $n$ is simply a matrix of size $n \times 1$. Just like with vectors, we can multiply a matrix with a number $c$ to obtain a new matrix where every entry is multiplied with $c$, and we can add two matrices of the same size to produce a new matrix whose entries are the sum of the respective entries of the two matrices. 

## Matrix multiplication and tensor products

We can also multiply two matrices $M$ of dimension $m\times n$ and $N$ of dimension $n \times p$ to get a new matrix $P$ of dimension $m \times p$ as follows:

$$
\begin{bmatrix}
	M_{11} ~~ M_{12} ~~ \cdots ~~ M_{1n}\\\\
	M_{21} ~~ M_{22} ~~ \cdots ~~ M_{2n}\\\\
	\ddots\\\\
	M_{m1} ~~ M_{m2} ~~ \cdots ~~ M_{mn}\\\\
\end{bmatrix}\times
\begin{bmatrix}
N_{11} ~~ N_{12} ~~ \cdots ~~ N_{1p}\\\\
N_{21} ~~ N_{22} ~~ \cdots ~~ N_{2p}\\\\
\ddots\\\\
N_{n1} ~~ N_{n2} ~~ \cdots ~~ N_{np}\\\\
\end{bmatrix} =
\begin{bmatrix}
P_{11} ~~ P_{12} ~~ \cdots ~~ P_{1p}\\\\
P_{21} ~~ P_{22} ~~ \cdots ~~ P_{2p}\\\\
\ddots\\\\
P_{m1} ~~ P_{m2} ~~ \cdots ~~ P_{mp}\\\\
\end{bmatrix},
$$

where the entry $P_{ik} = \sum_j M_{ij}N_{jk}$. For example, the entry $P_{11}$ is the inner product of the first row of $M$ with the first column of $N$. Note that since a vector is simply a special case of a matrix, this definition extends to matrix--vector multiplication. 

All the matrices we consider will either be square matrices, where the number of rows and columns are equal, or vectors, which corresponds to only $1$ column. One special square matrix is the identity matrix, denoted $\mathbb{1}$, which has all its diagonal elements equal to $1$ and the remaining elements equal to $0$:

$$\mathbb{1}=\begin{bmatrix}
1 ~~ 0 ~~ \cdots ~~ 0\\\\
0 ~~ 1 ~~ \cdots ~~ 0\\\\
~~ \ddots\\\\
0 ~~ 0 ~~ \cdots ~~ 1\\\\
\end{bmatrix}.$$

For a square matrix $A$, we say a matrix $B$ is its inverse if $AB = \mathbb{1}$. The inverse of a matrix need not exist, but when it exists it is unique and we denote it $A^{-1}$. 

For any matrix $M$, the adjoint or conjugate transpose of $M$, is a matrix $N$ such that $N_{ij} = M^*_{ji}$. The adjoint of $M$ is usually denoted $M^\dagger$. We say a matrix $U$ is unitary if $UU^\dagger = \mathbb{1}$ or equivalently, $U^{-1} = U^\dagger$.  Perhaps the most important property of unitary matrices is that they preserve the norm of a vector.  This happens because 

$$\langle v,v \rangle=v^\dagger v = v^\dagger U^{-1} U v = \langle U v, U v\rangle$$.  

A matrix $M$ is said to be Hermitian if $M=M^\dagger$.

Finally, the tensor product (or Kronecker product) of two matrices $M$ of size $m\times n$ and $N$ of size $p \times q$ is a larger matrix $P=M\otimes N$ of size $mp \times nq$, and is obtained from $M$ and $N$ as follows:

$$
	M \otimes N =
	\begin{bmatrix}
		M_{11} ~~ \cdots ~~ M_{1n} \\\\
		\ddots\\\\
		M_{m1}  ~~ \cdots ~~ M_{mn}\\\\
	\end{bmatrix}\times
	\begin{bmatrix}
		N_{11}  ~~ \cdots ~~ N_{1q}\\\\
		\ddots\\\\
		N_{p1} ~~ \cdots ~~ N_{pq}\\\\
	\end{bmatrix}
	=
	\begin{bmatrix}
		M_{11} \begin{bmatrix} N_{11}  ~~ \cdots ~~ N_{1q}\\\\ \ddots\\\\ N_{p1} ~~ \cdots ~~ N_{pq}\\\\ \end{bmatrix}~~ \cdots ~~ 
		M_{1n} \begin{bmatrix} N_{11}  ~~ \cdots ~~ N_{1q}\\\\ \ddots\\\\ N_{p1} ~~ \cdots ~~ N_{pq}\\\\ \end{bmatrix}\\\\
		\ddots\\\\
		M_{m1} \begin{bmatrix} N_{11}  ~~ \cdots ~~ N_{1q}\\\\ \ddots\\\\ N_{p1} ~~ \cdots ~~ N_{pq}\\\\ \end{bmatrix}~~ \cdots ~~ 
		M_{mn} \begin{bmatrix} N_{11}  ~~ \cdots ~~ N_{1q}\\\\ \ddots\\\\ N_{p1} ~~ \cdots ~~ N_{pq}\\\\ \end{bmatrix}\\\\
	\end{bmatrix}.
$$

This is better demonstrated using some examples:

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

A final notation surrounding tensor products that is useful is that, for any vector $v$ or matrix $M$, $v^{\otimes n}$ or $M^{\otimes n}$ is short hand for an $n$--fold repeated tensor product.  For example

$$
\begin{bmatrix} 1 \\\\ 0 \end{bmatrix}^{\otimes 1} = \begin{bmatrix} 1 \\\\ 0 \end{bmatrix}\qquad \begin{bmatrix} 1 \\\\ 0 \end{bmatrix}^{\otimes 2} = \begin{bmatrix} 1 \\\\ 0 \\\\0 \\\\0 \end{bmatrix}\qquad X^{\otimes 2}= \begin{bmatrix} 0 &0&0&1 \\\\ 0 &0&1&0 \\\\ 0 &1&0&0\\\\ 1 &0&0&0\end{bmatrix}.
$$

## Eigenvalues and Eigenvectors

Let $M$ be a square matrix and $v$ be a vector that is not the all zeros vector (i.e., the vector with all entries equal to $0$).
Then we say $v$ is an eigenvector of  $M$ if $Mv = cv$ for some number $c$. We say $c$ is the eigenvalue corresponding to the eigenvector $v$. In general a matrix $M$ may transform a vector into any other vector, but an eigenvector is special because it is left unchanged except for being multiplied by a number. Note that if $v$ is an eigenvector with eigenvalue $c$, then $av$ is also an eigenvector (for any nonzero $a$) with the same eigenvlue. 

For example, for the identity matrix, every vector $v$ is an eigenvector with eigenvalue $1$. As another example, consider a diagonal matrix $D$ which only has nonzero entries on the diagonal:

$$
\begin{equation}
	\begin{bmatrix}
		d_1 & 0 & 0 \\\\ 0 & d_2 & 0 \\\\ 0 & 0 & d_3
	\end{bmatrix}.
\end{equation}
$$

The vectors 

$$\begin{bmatrix}1 \\\\ 0 \\\\ 0 \end{bmatrix}, \begin{bmatrix}0 \\\\ 1 \\\\ 0\end{bmatrix} and \begin{bmatrix}0 \\\\ 0 \\\\ 1\end{bmatrix}$$

are eigenvectors of this matrix with eigenvalues  $d_1$, $d_2$, and $d_3$ respectively. If $d_1$, $d_2$, and $d_3$ are distinct numbers, then these vectors (and their multiples) are the only eigenvectors of the matrix $D$. In general, for a diagonal matrix it is easy to read off the eigenvalues and eigenvectors. The eigenvalues are all the numbers appearing on the diagonal, and their respective eigenvectors are the unit vectors with one entry equal to $1$ and the remaining entries equal to $0$.

Note in the above example that the eigenvectors of $D$ formed a basis for $3$-dimensional vectors. A basis is a set of vectors such that any vector can be written as a linear combination of them. More explicitly, $v_1$, $v_2$, and $v_3$ form a basis if any vector $v$ can be written as $v=a_1 v_1 + a_2 v_2 + a_3 v_3$ for some numbers $a_1$, $a_2$, and $a_3$. 

For Hermitian and unitary matrices, which are  essentially the only matrices encountered in quantum computing, we have a general result known as the spectral theorem, which asserts the following: For any Hermitian or unitary matrix $M$, there exists a unitary $U$ such that $M=U^\dagger D U$ for some diagonal matrix $D$. Furthermore, the diagonal entries of $D$ will be the eigenvalues of $M$. We already know how to compute the eigenvalues and eigenvectors of a diagonal matrix $D$. Using this theorem we know that if $v$ is an eigenvector of $D$ with eigenvalue $c$, i.e., $Dv = cv$, then $U^\dagger v$ will be an eigenvector of $M$ with eigenvalue $c$. This is because 

$$M(U^\dagger v) = U^\dagger D U  (U^\dagger v) =U^\dagger D (U  U^\dagger) v = U^\dagger D v = c U^\dagger v.$$

## Matrix Exponentials
A matrix exponential can also be defined in exact analogy to the exponential function.  The matrix exponential of a matrix $A$ can be expressed as

$$
e^A=\mathbb{1} + A + \frac{A^2}{2!}+\frac{A^3}{3!}+\cdots.
$$
This is important to us because quantum mechanical time evolution is described by a unitary matrix of the form $e^{iB}$ for Hermitian matrix $B$.  For this reason, performing matrix exponentials is a fundamental part of quantum computing and as such Q# has intrinsic routines for describing these operations.
There are many ways in practice to compute a matrix exponential on a classical computer, and in general numerically approximating such an exponential it is fraught with peril.  See [Cleve Moler and Charles Van Loan. "Nineteen dubious ways to compute the exponential of a matrix." SIAM review 20.4 (1978): 801-836] for more information about the challenges involved.  

The easiest way to understand how to compute the exponential of a matrix is through the eigenvalues and eigenvectors of that matrix.  Specifically, the spectral theorem discussed above says that for every Hermitian or unitary matrix $A$ there exists a unitary matrix $U$ and a diagonal matrix $D$ such that $A=U^\dagger D U$.  Because of the properties of unitarity we have that $A^2 = U^\dagger D^2 U$ and similarly for any power $p$ $A^p = U^\dagger D^p U$.  If we substitute this into the operator definition of the operator exponential we obtain

$$
e^A= U^\dagger \left(\mathbb{1} +D +\frac{D^2}{2!}+\cdots \right)U= U^\dagger \begin{bmatrix}\exp(D_{11}) & 0 &\cdots &0\\\\ 0 & \exp(D_{22})&\cdots& 0\\\\ \vdots &\vdots &\ddots &\vdots\\\\ 0&0&\cdots&\exp(D_{NN}) \end{bmatrix} U.
$$
In other words, if you transform to the eigenbasis of the matrix $A$ then computing the matrix exponential is equivalent to computing the ordinary exponential of the eigenvalues of the matrix.  As many of the operations in quantum computing involve performing matrix exponentials, this trick of transforming into the eigenbasis of a matrix to simplify performing the operator exponential appears frequently and is the basis behind many quantum algorithms such as Trotter–Suzuki based quantum simulation methods.

Another useful property is if $B$ is both unitary and Hermitian, ie $B^2=\mathbb{1}$, then it can be seen by applying this rule to the above expansion of the operator exponential and grouping the $\mathbb{1}$ and the $B$ terms that for any real valued $x$
$$e^{iBx}=\cos(x)\mathbb{1} + iB\sin(x).$$
This trick is especially useful because it allows us to reason about the actions that matrix exponentials have, even if the dimension of $B$ is exponentially large, for the special case when $B$ is both unitary and Hermitian. 