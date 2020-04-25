using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Microsoft.Quantum.Samples
{
    class HelloWorldDriver
    {
        static void Main(string[] args)
        {
            var toffoli = new ToffoliSimulator();
            var result = HelloWorld.Run(toffoli, 12).Result;
            System.Console.Out.WriteLine(result);

            using (var qsim = new QuantumSimulator())
            {
                var msg = Result.One;
                var r = TeleportTest.Run(qsim, msg).Result;
                System.Console.WriteLine($"Sent: {msg}; Received: {r}");

                msg = Result.Zero;
                r = TeleportTest.Run(qsim, msg).Result;
                System.Console.WriteLine($"Sent: {msg}; Received: {r}");
            }
            System.Console.ReadKey();
        }
    }
}
