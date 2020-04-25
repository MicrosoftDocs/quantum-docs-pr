
This is a basic project to help debug Q# simulation.

It requires that:
* the environment has been initialized (`bootstrap.cmd`)
* that the Q# compiler is built (`dotnet build src\QsCompiler.sln`)


To debug the native simulator set  
`Microsoft.Quantum.Simulator.Runtime` as the start up project, and
configuring it to launch `C:\Program Files\dotnet\dotnet.exe DebugSimulation.dll`
from `Tests\DebugSimulation\bin\Debug\netcoreapp2.0` as the working folder.

