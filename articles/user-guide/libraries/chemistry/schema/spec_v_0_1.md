---
title: Broombridge Schema Specification (ver 0.1)
description: Details the specifications for the Broombridge quantum chemistry schema v0.1 for the Microsoft quantum chemistry library. 
author: cgranade
ms.author: chgranad
ms.date: 10/17/2018
ms.topic: conceptual
uid: microsoft.quantum.libraries.chemistry.schema.spec_v_0_1
no-loc: ['Q#', '$$v']
---

# Broombridge Specification v0.1 #

The key words "MUST", "MUST NOT", "REQUIRED", "SHALL", "SHALL NOT", "SHOULD", "SHOULD NOT", "RECOMMENDED",  "MAY", and "OPTIONAL" in this document are to be interpreted as described in [RFC 2119](https://tools.ietf.org/html/rfc2119).

Any sidebar with the headings "NOTE," "INFORMATION," or "WARNING" is informative.

## Introduction ##

This section is informative.

Broombridge documents are intended to communicate instances of simulation problems in quantum chemistry for processing using quantum simulation and programming toolchains.

## Serialization ##

This section is normative.

A Broombridge document MUST be serialized as a [YAML 1.2 document](http://yaml.org/spec/) representing a JSON object as described in [RFC 4627](https://tools.ietf.org/html/rfc4627) section 2.2.
The object serialized to YAML MUST have a property `"$schema"` whose value is `"https://raw.githubusercontent.com/Microsoft/Quantum/master/Chemistry/Schema/qchem-0.1.schema.json"`, and MUST be valid according to the JSON Schema draft-06 specifications [[1](https://tools.ietf.org/html/draft-wright-json-schema-01), [2](https://tools.ietf.org/html/draft-wright-json-schema-validation-01)].

For the remainder of this specification, "the Broombridge object" will refer to the JSON object deserialized from a Broombridge YAML document.

Unless otherwise explicitly noted, objects MUST NOT have additional properties beyond those specified explicitly in this document.

## Additional Definitions ##

This section is normative.

### Quantity Objects ###

This section is normative.

A _quantity object_ is a JSON object, and MUST have a property `units` whose value is one of the allowed values listed in Table 1.

A quantity object is a _simple quantity object_ if it has a single property `value` in addition to its `units` property.
The value of the `value` property MUST be a number.

A quantity object is a _bounded quantity object_ if it has the properties `lower` and `upper` in addition to its `units` property.
The values of the `lower` and `upper` properties MUST be numbers.
A bounded quantity object MAY have a property `value` whose value is a number.

A quantity object is a _sparse array quantity object_ if it has the property `format` and a property `values` in addition to its `units` property.
The value of `format` MUST be the string `sparse`.
The value of the `values` property MUST be an array.
Each element of `values` MUST be an array representing the indices and value of the sparse array quantity.

The indices for each element of a sparse array quantity object MUST be unique across the entire sparse array quantity object.
If an index is present with a value of `0`, a parser MUST treat the sparse array quantity object identically to a sparse array quantity object in which that index is not present at all.


A quantity object MUST either be

- a simple quantity object,
- a bounded quantity object, or
- a sparse array quantity object.


### Examples ###

This section is informative.

A simple quantity representing $1.9844146837\,\mathrm{Ha}$:

```yaml
coulomb_repulsion:
    value: 1.9844146837
    units: hartree
```

A bounded quantity representing a uniform distribution over the interval $[-7, -6]\,\mathrm{Ha}$:

```yaml
fci_energy:
    upper: -6
    lower: -7
    units: hartree
```

The following is a sparse array quantity with an element `[1, 2]` equal to `hello` and an element `[3, 4]` equal to `world`:

```yaml
sparse_example:
    format: sparse
    units: hartree
    values:
    - [1, 2, "hello"]
    - [3, 4, "world"]
```

## Format Section ##

This section is normative.

The Broombridge object MUST have a property `format` whose value is a JSON object with one property called `version`.
The `version` property MUST have the value `"0.1"`.

### Example ###

This section is informative.

```yaml
format:                        # required
    version: "0.1"             # must match exactly
```

## Integral Sets Section ##

This section is normative.

The Broombridge object MUST have a property `integral_sets` whose value is a JSON array.
Each item in the value of the `integral_sets` property MUST be a JSON object describing one set of integrals, as described in the remainder of this section.
In the remainder of this section, the term "integral set object" will refer to an item in the value of the `integral_sets` property of the Broombridge object.

Each integral set object MUST have a property `metadata` whose value is a JSON object.
The value of `metadata` MAY be the empty JSON object (that is, `{}`), or MAY contain additional properties defined by the implementor.

### Hamiltonian Section ###

#### Overview ####

This section is informative.

The `hamiltonian` property of each integral set object describes the Hamiltonian for a particular quantum chemistry problem by listing out its one- and two-body terms as sparse arrays of real numbers.
The Hamiltonian operators described by each integral set object take the form

$$
H = \sum\_\{i,j\}\sum\_{\sigma\in\\{\uparrow,\downarrow\\}} h\_\{ij\} a^\{\dagger\}\_{i,\sigma} a\_{j,\sigma} + \frac{1}{2}\sum\_\{i,j,k,l\}\sum\_{\sigma,\rho\in\\{\uparrow,\downarrow\\}} h\_{ijkl} a^\dagger\_{i,\sigma} a^\dagger\_{k,\rho} a\_{l,\rho} a\_{j,\sigma},
$$

here $h_{ijkl}= (ij|kl)$ in Mulliken convention.

For clarity, the one-electron term is

$$
h_{ij} = \int {\mathrm d}x \psi^*\_i(x) \left(\frac{1}{2}\nabla^2 + \sum\_{A}\frac{Z\_A}{|x-x\_A|}  \right) \psi\_j(x),
$$

and the two-electron term is

$$
h\_\{ijkl\} = \iint \{\mathrm d\}x^2 \psi^\{\*\}\_i(x\_1)\psi\_j(x\_1) \frac\{1\}\{\|x\_1 -x\_2\|\}\psi\_k^\{\*\}(x\_2) \psi\_l(x\_2).
$$

As noted in our description of the [`basis_set` property](#basis-set-object) of each element of the `integral_sets` property, we further explicitly assume that the basis functions used are real-valued.
This allows us to use the following symmetries between the terms to compress the representation of the Hamiltonian.

$$
h_{ijkl} = h_{ijlk}=h_{jikl}=h_{jilk}=h_{klij}=h_{klji}=h_{lkij}=h_{lkji}.
$$


#### Contents ####

This section is normative.

Each integral set MUST have a property `hamiltonian` whose value is a JSON object.
The value of the `hamiltonian` property is known as a Hamiltonian object, and MUST have the properties `one_electron_integrals` and `two_electron_integrals` as described in the remainder of this section.
A Hamiltonian object MAY also have a property `particle_hole_representation`.
If present, the value of `particle_hole_representation` MUST follow the format described in the remainder of this section.

##### One-Electron Integrals Object #####

This section is normative.

The `one_electron_integrals` property of the Hamiltonian object MUST be a sparse array quantity whose indices are two integers and whose values are numbers.
Every term MUST have indices `[i, j]` where `i >= j`.

> [NOTE]
> This reflects the symmetry that $h_{ij} = h_{ji}$ which is a consequence of the fact that the Hamiltonian is Hermitian.


###### Example ######

This section is informative.

The following sparse array quantity represents the Hamiltonian
$$
H = \left(-5.0  (a^\{\dagger\}\_{1,\uparrow} a\_{1,\uparrow}+a^\{\dagger\}\_{1,\downarrow} a\_{1,\downarrow})+ 0.17 (a^\{\dagger\}\_{2,\uparrow} a\_{1,\uparrow}+ a^\{\dagger\}\_{1,\uparrow} a\_{2,\uparrow}+a^\{\dagger\}\_{2,\downarrow} a\_{1,\downarrow}+ a^\{\dagger\}\_{1,\downarrow} a\_{2,\downarrow})\right)\\,\mathrm{Ha}.
$$

```yaml
one_electron_integrals:     # required
    units: hartree          # required
    format: sparse          # required
    values:                 # required
        # i j f(i,j)
        - [1, 1, -5.0]
        - [2, 1,  0.17]
```
> [!NOTE]
> Broombridge uses 1-based indexing.


##### Two-Electron Integrals Object #####

This section is normative.

The `two_electron_integrals` property of the Hamiltonian object MUST be a sparse array quantity with one additional property called `index_convention`.
Each element of the value of `two_electron_integrals` MUST have four indices.

Each `two_electron_integrals` property MUST have a `index_convention` property.
The value of the `index_convention` property MUST be one of the allowed values listed in Table 1.
If the value of `index_convention` is `mulliken`, then for each element of the `two_electron_integrals` sparse array quantity, a parser loading a Broombridge document MUST instantiate a Hamiltonian term equal to the two-electron operator $h_{i, j, k, l} a^\dagger_i a^\dagger_j a_k a_l$, where $i$, $j$, $k$, and $l$ MUST be integers in the inclusive range from 1 to the number of electrons specified by the `n_electrons` property of the integral set object, and where $h_{i, j, k, l}$ is the element `[i, j, k, l, h(i, j, k, l)]` of the sparse array quantity.

###### Symmetries ######

This section is normative.

If the `index_convention` property of a `two_electron_integrals` object is equal to `mulliken`, then if an element with indices `[i, j, k, l]` is present, the following indices MUST NOT be present unless they are equal to `[i, j, k, l]`:

- `[i, j, l, k]`
- `[j, i, k, l]`
- `[j, i, l, k]`
- `[k, l, i, j]`
- `[k, l, j, i]`
- `[l, k, j, i]`

> [!NOTE]
> Because the `index_convention` property is a sparse quantity object, no indices may be repeated on different elements.
> In particular, if an element with indices `[i, j, k, l]` is present, no other element may have those indices.


<!-- h_{ijkl} = h_{ijlk}=h_{jikl}=h_{jilk}=h_{klij}=h_{klji}=h_{lkji}. -->

###### Example #######

This section is informative.

The following object specifies the Hamiltonian

$$
H = \frac12 \sum\_{\sigma,\rho\in\\{\uparrow,\downarrow\\}}\Biggr(
1.6 a^{\dagger}\_{1,\sigma} a^{\dagger}\_{1,\rho} a\_{1,\rho} a\_{1,\sigma}- 0.1 a^{\dagger}\_{6,\sigma} a^{\dagger}\_{1,\rho} a\_{3,\rho} a\_{2,\sigma}- 0.1 a^{\dagger}\_{6,\sigma} a^{\dagger}\_{1,\rho} a\_{2,\rho} a\_{3,\sigma}- 0.1 a^{\dagger}\_{1,\sigma} a^{\dagger}\_{6,\rho} a\_{3,\rho} a\_{2,\sigma}- 0.1 a^{\dagger}\_{1,\sigma} a^{\dagger}\_{6,\rho} a\_{2,\rho} a\_{3,\sigma}
$$
$$- 0.1 a^{\dagger}\_{3,\sigma} a^{\dagger}\_{2,\rho} a\_{6,\rho} a\_{1,\sigma}- 0.1 a^{\dagger}\_{3,\sigma} a^{\dagger}\_{2,\rho} a\_{1,\rho} a\_{6,\sigma}- 0.1 a^{\dagger}\_{2,\sigma} a^{\dagger}\_{3,\rho} a\_{6,\rho} a\_{1,\sigma}- 0.1 a^{\dagger}\_{2,\sigma} a^{\dagger}\_{3,\rho} a\_{1,\rho} a\_{6,\sigma}\Biggr)\\,\textrm{Ha}.
$$

```yaml
two_electron_integrals:
    index_convention: mulliken
    units: hartree
    format: sparse
    values:
        - [1, 1, 1, 1,  1.6]
        - [6, 1, 3, 2, -0.1]
```

##### Particle–Hole Representation Object #####

This section is normative.

The particle–hole representation object specifies that the integrals stored are defined with respect to particle hole representation wherein the creation and annihilation operators describe excitations away from the reference state used, such as a Hartree–Fock state.
The object is OPTIONAL.
If the object is not specified then the Hamiltonian is to be interpreted as not given in particle-hole representation.
If present, the value of `particle_hole_representation` MUST be a sparse array quantity object whose indices are four integers, and whose values are a number and a string.
The string portion of the value of each element MUST contain only the characters `'+'` and `'-'` which specifies whether a given factor in the term is a creation or annihilation operator in the particle–hole representation.  For example `"-+++"` coresponds to a hole being created at site $i$ and particles being created at sites $j,k$ and $l$.

> [!NOTE]
> As the value of the `particle_hole_representation` is a sparse array quantity object, the `unit` and `format` properties must be specified.
> Acceptable units include are listed in Table 1.
> The `format` property is required, and indicates whether the Hamiltonian coefficients are specified as a dense or sparse array.
> In the current version, only sparse arrays are supported, with interpretation that all unspecified elements are $0$, but future versions may add support for additional values of the `format` property.

### Initial State Section ###

The initial_state_suggestion object specifies initial quantum states of interest to the specified Hamiltonian. This object must be an array of JSON `state` objects.

#### State object ####

Each states represents a superposition of occupied orbitals. Each state object MUST have a `label` property containing a string. Each state object MUST have a `superposition` property containing an array of basis states and their unnormalized amplitudes.

For example, the initial states
$$
\ket{G0}=\ket{G1}=\ket{G2}=(a^{\dagger}\_{1,\uparrow}a^{\dagger}\_{2,\uparrow}a^{\dagger}\_{2,\downarrow})\ket{0}
$$
$$
\ket{E}=\frac{0.1 (a^{\dagger}\_{1,\uparrow}a^{\dagger}\_{2,\uparrow}a^{\dagger}\_{2,\downarrow})+0.2 (a^{\dagger}\_{1,\uparrow}a^{\dagger}\_{3,\uparrow}a^{\dagger}\_{2,\downarrow})}{\sqrt{|0.1|^2+|0.2|^2}}\ket{0}
$$
are represented by
```yaml
initial_state_suggestions: # optional. If not provided, spin-orbitals will be filled to minimize one-body diagonal term energies.
    - state:
        label: "|G0>"
        superposition:
            - [1.0, "(1a)+","(2a)+","(2b)+","|vacuum>"]
    - state:
        label: "|G1>"
        superposition:
            - [-1.0, "(2a)+","(1a)+","(2b)+","|vacuum>"]
    - state:
        label: "|G2>"
        superposition:
            - [1.0, "(3a)","(1a)+","(2a)+","(3a)+","(2b)+","|vacuum>"]
    - state:
        label: "|E>"
        superposition:
            - [0.1, "(1a)+","(2a)+","(2b)+","|vacuum>"]
            - [0.2, "(1a)+","(3a)+","(2b)+","|vacuum>"]
```

#### Basis Set Object ####

This section is normative.

Each integral set object MAY have a `basis_set` property.
If present, the value of the `basis_set` property MUST be an object with two properties, `type` and `name`.

The basis functions identified by the value of the `basis_set` property MUST be real-valued.

> [!NOTE]
> The assumption that all basis functions are real-valued may be relaxed in future versions of this specification.

## Tables and Lists ##

### Table 1. Allowed Physical Units ###

This section is normative.

Any string specifying a unit MUST be one of the following:

- `hartree`
- `ev`

Parsers and producers MUST treat the following simple quantity objects as equivalent:

```yaml
- {"units": "hartree", "value": 1}
- {"units": "ev", "value": 27.2113831301723}
```

### Table 2. Allowed Index Conventions ###

This section is normative.

Any string specifying an index convention MUST be one of the following:

- `mulliken`

This section is informative.

Additional index conventions may be introduced in future versions of this specification.

#### Interpretation of Index Conventions ####

This section is informative.
