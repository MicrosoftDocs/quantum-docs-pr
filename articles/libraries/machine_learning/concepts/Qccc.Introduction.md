
# Framework and goals
Quantum encoding and processing of information is a powerful alternative to traditional predictive data analysis (that uses tools such as support vector machines, neural nets, decision trees etc.) Quantum classifiers, in particular, encode data in quantum registers that are concise relative to the number of features, systematically employ quantum entanglement as computational resource and employ quantum measurement for class inference. Circuit centric quantum classifier is a relatively simple quantum solution that combines data encoding with a rapidly entangling/disentangling quantum circuit followed by measurement to infer class labels of data samples. The goal is to ensure classical characterization and storage of subject circuits, as well as hybrid quantum/classical training of the circuit parameters even for extremely large feature spaces.

# Classifier architecture
Classification is a supervised machine learning task, where the goal is to infer class labels $\{y_1,y_2,\ldots,y_d\}$ of certain data samples. The `training data set` is a collection of samples $\mathcal{D}=\{(x,y)}$ with known pre-assigned labels. Here $x$ is a data sample and $y$ is its known label called `training label`.
Somewhat similar to traditional methods, quantum classification consists of three steps: data encoding, preparing of a classifier state, taking a measurement. Due to probabilistic nature of the measurement, these three steps must be repeated multiple times. The measurement may be viewed as a quantum equivalent of some non-linear activation.
Both the encoding and the computing of the classifier state are done by means of `quantum circuits`. While the encoding circuit is usually data-driven and parameter-free, the classifier circuit contains a sufficient set of learnable parameters. In the proposed solution the classifier circuit is composed of single-qubit rotations and two-qubit controlled rotations. The learnable parameters here are the rotation angles. The rotation and controlled rotation gates are known to be `universal` for quantum computation, which means that any unitary weight matrix can be decomposed into a long enough circuit consisting of such gates. Our architecture explores relatively shallow circuits, which therefore must be `rapidly entangling` in order to capture all the correlations between the data features at all ranges. An example of the most useful rapidly entangling circuit component is shown on FIG 1. Even though this circuit consists of only $3\,n+1$ gates, the unitary weight matrix that it computes ensures significant cross-talk between $2^n$ features.
 

## FIG. 1
![Rapidly entangling quantum circuit on 5 qubits (with two cyclic layers).](./5qubitCircuit.png)

The circuit consists of 6 single-qubit gates $(G_1,\ldots,G_5; G_{16})$ and 10 two-qubits gates $(G_6,\ldots,G_{15})$. Assuming that each of the gates is defined with one learnable parameter we have 16 learnable parameters, while the dimension of the 5-qubit Hilbert space is 32. Such circuit geometry can be easily generalized to any $n$-qubit register, when $n$ is odd, yielding circuits with $3\, n+1$ parameters for $2^n$-dimensional feature space.

# Classifier training as a supervised learning task
Training of a classifier model involves finding optimal values of its operational parameters, such that they maximize the average likelihood of inferring the correct training labels across the training samples.
Here  we concern ourselves with two level classification only, i.e. the case of $d=2$ and only two classes with the labels $y_1,y_2$. \footnote{A principled way of generalizing our methods to arbitrary number of classes is to replace qubits with q-dits, i.e. quantum units with $d$ basis states, end the two-way measurement with $d$-way measurement.}

## Likelihood as the training goal
Given a learnable quantum circuit $U(\theta)$, where $\theta$ is a vector of parameters, and denoting the final measurement by $M$, the average likelihood of the correct label inference is
$$\mathcal{L}(\theta)=\frac{1}{|\mathcal{D}|} \left( \sum{(x,y_1)\in\mathcal{D}} P(M=y_1|U(\theta) x) + \sum{(x,y_2)\in\mathcal{D}} P(M=y_2|U(\theta) x)\right)$$
where $P(M=y|z)$ is the probability of measuring $y$ in quantum state $z$.
 Here it suffices to understand that the likelihood function $\mathcal{L}(\theta)$ is smooth in $\theta$ and its derivative in any $\theta_j$ can be computed by essentially the same quantum protocol as used for computing the likelihood function itself. This allows for optimizing the $\mathcal{L}(\theta)$ by gradient descent.

## Classifier bias and training score
Given some intermediate (or final) values of the parameters in $\theta$, we need to identify a single real value $b$ know as `classifier bias` to do the inference. The label inference rule works as follows:
	A sample $x$ is assigned label $y_2$ if and only if
$$ P(M=y_2|U(\theta) x) + b > 0.5 $$  (RULE1)
(otherwise it is assigned label $y_1$)
Clearly $b$ must be in the interval $(-0.5,+0.5)$ to be meaningful.
A training case $(x,y) \in \mathcal{D}$ is considered a `misclassification` given the bias $b$ if the label inferred for $x$ as per RULE1 is actually different from $y$. The overall number of misclassifications is the `training score` of the classifier given the bias $b$. The `optimal` classifier bias $b$ minimizes the training score.
It is easy to see that, given the precomputed probability estimates $\{ P(M=y_2|U(\theta) x) | (x,*)\in\mathcal{D}$, the optimal classifier bias can be found by binary search in interval $(-0.5,+0.5)$ by making at most $\log_2(|\mathcal{D}|)$ steps.