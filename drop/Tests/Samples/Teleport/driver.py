
# The first step is to import the qsharp package.
# For instructions on how to install it, see: https://docs.microsoft.com/en-us/quantum/install-guide/python
import qsharp

# All the .qs files found under the current working directory are compiled and
# available in the workspace.
# to check the operations available in the current workspace:
qsharp.get_workspace_operations()

# these operations can now be imported into Python. For example:
from Quantum.Teleport import Teleport

# once imported, an operation can be simulated:
Teleport.simulate()

# and the resources can be estimated:
Teleport.estimate_resources()

# You can use these iteratively:
for i  in range(10):
    Teleport.simulate()
    print("------------------")

# The Q# workspace is automatically reloaded when Python restarts.
# To reload Q# on demand to pick up any changes to .qs files use:
qsharp.reload()