using Microsoft.Quantum.Numerics.Samples;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Quantum.Tests
{
    public class NumericsTests
    {
        private readonly ITestOutputHelper output;

        public NumericsTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void CustomModAdder()
        {
            var sim = new ToffoliSimulator();
            var inputs1 = new long[] { 3, 5, 3, 4, 5 };
            var inputs2 = new long[] { 5, 4, 6, 4, 1 };
            var modulus = 7;
            int numBits = 4;

            var res = CustomModAdd.Run(sim, new QArray<long>(inputs1), new QArray<long>(inputs2), modulus, numBits).Result.ToArray();

            Assert.Equal(5, res.Length);
            Assert.Equal(1, res[0]);
            Assert.Equal(2, res[1]);
            Assert.Equal(2, res[2]);
            Assert.Equal(1, res[3]);
            Assert.Equal(6, res[4]);
        }
    }
}
