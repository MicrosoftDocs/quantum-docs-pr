using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.QCTraceSimulatorRuntime;
using Microsoft.Quantum.Simulation.Simulators;
using qperf.Stats;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace qperf
{

    public class ExecutionTracker
    {
        private Stack<EventTracker> _events = new Stack<EventTracker>();

        public SingleExecutionInfo Info { get; }

        public EventTracker MainEvent { get; }

        public long EventsTotal { get; private set; }

        public StatisticsCollector<Record> Stats;


        private ExecutionTracker(RunInfo run, Type quantumMachine, Type gate)
        {
            this.Stats = new StatisticsCollector<Record>(new string[] { "TotalTime" }, new IDoubleStatistic[] { new MomentsStatistic(), new MinMaxStatistic() });
            this.Info = new SingleExecutionInfo(run, quantumMachine, gate);
            this.MainEvent = EventStart("TotalExecution");
        }

        public static ExecutionTracker Run(RunInfo run, Type quantumMachine, Type gate)
        {
            Console.WriteLine($"##[info] Starting run of gate {gate} on machine {quantumMachine}");

            var tracker = new ExecutionTracker(run, quantumMachine, gate);

            IOperationFactory machine = null;

            tracker.Track("QuantumMachineInit", () =>
            {
                machine = CreateQuantumMachine(quantumMachine);
            });

            RunTopLevelGate(machine, gate);

            tracker.Track("QuantumMachineDispose", () =>
            {
                (machine as IDisposable)?.Dispose();
            });

            tracker.End();

            return tracker;
        }

        private void OnOperationStart(string opName, OperationFunctor variant, object args)
        {
            var key = opName + ":" + variant;
            _events.Push(EventStart(key));
        }

        private void OnOperationEnd(string opName, OperationFunctor variant, object args)
        {
            var evt = _events.Pop();
            evt.End();
        }

        public static IOperationFactory CreateQuantumMachine(Type machineType)
        {
            return Activator.CreateInstance(machineType) as IOperationFactory;
        }

        public static void RunTopLevelGate(IOperationFactory qsim, Type gate)
        {
            var run = qsim.GetType()
                .GetMethod("Run");

            var result = run
                .MakeGenericMethod(gate, typeof(QVoid), typeof(QVoid))
                .Invoke(qsim, new object[] { QVoid.Instance }) as Task<QVoid>;

            result.Wait();
        }

        public TimeSpan End()
        {
            Trace.Assert(_events.Count == 0, "Event queue is not empty. Some operations are still running?!");
            return this.MainEvent.End();
        }

        public void Track(string eventName, Action action)
        {
            var evt = this.EventStart(eventName);
            action();
            evt.End();
        }

        public EventTracker EventStart(string key)
        {
            EventsTotal++;

            return new EventTracker(this, key);
        }
    }
}
