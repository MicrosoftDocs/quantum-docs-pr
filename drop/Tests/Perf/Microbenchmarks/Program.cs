using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Microsoft.Quantum.Intrinsic;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;
using Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators;

namespace Microsoft.Quantum.Microbenchmarks
{
    public class ArrayAllocationBenchmarks
    {
        [Params(10, 100, 1_000, 10_000, 100_000)]
        public int ArraySize;

        private long[] clrArray;

        [GlobalSetup]
        public void Setup()
        {
            clrArray = new long[ArraySize];
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            clrArray = null;
        }

        [Benchmark]
        public QArray<long> CreateEmptyQArray() => QArray<long>.Create(ArraySize);

        [Benchmark]
        public QArray<long> CreateQArrayFromClrArray() => new QArray<long>(clrArray);
    }

    public class ArrayLiteralBenchmarks
    {
        [Benchmark]
        public QArray<long> CreateQArrayFromTwoItems() => new QArray<long>(1L, 2L);
    }

    public class ToffoliSimulatorBenchmarks
    {
        private ToffoliSimulator sim;
        private Allocate allocate;
        private Release deallocate;

        [GlobalSetup]
        public void Setup()
        {
            sim = new ToffoliSimulator();
            allocate = this.sim.Get<Allocate>(typeof(Allocate));
            deallocate = this.sim.Get<Release>(typeof(Release));
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            sim = null;
        }

        [Params(10, 100, 1_000, 10_000, 50_000)]
        public int ArraySize;

        [Benchmark]
        public void AllocateAndDeallocate()
        {
            var qubits = allocate.Apply(ArraySize);
            deallocate.Apply(qubits);
        }

    }

    public class TraceSimulatorBenchmarks
    {
        private QCTraceSimulator sim;
        private Allocate allocate;
        private Release deallocate;

        [GlobalSetup]
        public void Setup()
        {
            sim = new QCTraceSimulator();
            allocate = this.sim.Get<Allocate>(typeof(Allocate));
            deallocate = this.sim.Get<Release>(typeof(Release));
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            sim = null;
        }

        [Params(10, 100, 1_000, 10_000, 50_000)]
        public int ArraySize;

        [Benchmark]
        public void AllocateAndDeallocate()
        {
            var qubits = allocate.Apply(ArraySize);
            deallocate.Apply(qubits);
        }

    }

    public class Program
    {
        // Suggested command line invocation:
        // dotnet run -c Release -- --job short --join --exporters json --filter *
        public static void Main(string[] args) =>
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(
                args
            );
    }
}