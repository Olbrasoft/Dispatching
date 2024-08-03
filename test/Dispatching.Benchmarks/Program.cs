using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.Emit;

namespace Olbrasoft.Dispatching.Benchmarks
{
    internal class Program
    {
#pragma warning disable IDE0060 // Remove unused parameter
        private static void Main(string[] args)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            var config = ManualConfig.Create(DefaultConfig.Instance);

            config.AddJob(Job.Default.WithToolchain(InProcessEmitToolchain.Instance));
                          
            BenchmarkRunner.Run<SendRequestsBenchmarks>(config);
        }
    }
}