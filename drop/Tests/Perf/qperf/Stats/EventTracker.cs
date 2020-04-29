using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace qperf.Stats
{
    public class EventTracker
    {
        public Stopwatch Watch { get; }

        public ExecutionTracker Tracker { get; }

        public string Key { get; }

        public EventTracker(ExecutionTracker tracker, string key)
        {
            this.Tracker = tracker;
            this.Key = key;

            this.Watch = Stopwatch.StartNew();
        }

        public TimeSpan End()
        {
            this.Watch.Stop();
            Tracker.Stats.AddSample(new Record(this), new double[] { this.Watch.ElapsedMilliseconds });
            return this.Watch.Elapsed;
        }
    }
}
