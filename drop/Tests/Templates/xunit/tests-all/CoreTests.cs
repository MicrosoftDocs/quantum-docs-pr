using System;
using System.IO;

using Microsoft.Quantum.Simulation.Common;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;
using Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators;

using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Quantum.Tests
{
    public class AssertEqualImpl<T> : Operation<(T, T), QVoid>, ICallable
    {
        public AssertEqualImpl(IOperationFactory m) : base(m)
        {
        }

        string ICallable.FullName => "AssertEqualImpl";

        public override void Init() { }

        public override Func<(T, T), QVoid> Body => (_args) =>
        {
            var (expected, actual) = _args;
            Assert.Equal(expected, actual);
            return QVoid.Instance;
        };
    }

    public class CoreTests
    {
        private readonly ITestOutputHelper output;

        public CoreTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        private static void InitSimulator(IOperationFactory sim)
        {
            if (sim is AbstractFactory<AbstractCallable> factory)
            {
                factory.Register(typeof(AssertEqual<>), typeof(AssertEqualImpl<>), typeof(ICallable));
            }

            // For Toffoli, replace H with I.
            if (sim is ToffoliSimulator toffoli)
            {
                toffoli.Register(typeof(Intrinsic.H), typeof(Intrinsic.I), typeof(IUnitary));
            }
        }

        private static void RunWithMultipleSimulators(Action<IOperationFactory> test)
        {
            var simulators = new IOperationFactory[] { new ToffoliSimulator(), new QCTraceSimulator(), new QuantumSimulator() };

            foreach (var s in simulators)
            {
                InitSimulator(s);

                test(s);

                if (s is IDisposable sim)
                {
                    sim.Dispose();
                }
            }
        }

        [Fact]
        public void DumpState()
        {
            var expectedFiles = new string[]
            {
                "dumptest-start.txt",
                "dumptest-h.txt",
                "dumptest-former.txt",
                "dumptest-later.txt",
                "dumptest-one.txt",
                "dumptest-two.txt",
                "dumptest-entangled.txt",
                "dumptest-twoQubitsEntangled.txt",
                "dumptest-end.txt",
            };

            RunWithMultipleSimulators(s =>
            {
                if (s is SimulatorBase sim)
                {
                    // OnLog defines action(s) performed when Q# test calls function Message
                    sim.OnLog += (msg) => { output.WriteLine(msg); };
                }

                foreach (var name in expectedFiles)
                {
                    if (File.Exists(name))
                    {
                        File.Delete(name);
                    }
                }

                if (File.Exists("()"))
                {
                    File.Delete("()");
                }

                SimpleDumpTest.Run(s).Wait();

                foreach (var name in expectedFiles)
                {
                    Assert.True(File.Exists(name));
                }

                Assert.False(File.Exists("()"));
            });

        }

        [Fact]
        public void BigInts()
        {
            RunWithMultipleSimulators((s) =>
            {
                BigIntTest.Run(s).Wait(); // Throws if it doesn't succeed
            });
        }
    }
}
