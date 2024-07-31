using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.Emit;

namespace Olbrasoft.Dispatching.Benchmarks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var config = ManualConfig.Create(DefaultConfig.Instance);

            config.AddJob(Job.Default.WithToolchain(InProcessEmitToolchain.Instance));
                          
            BenchmarkRunner.Run<SendRequestsBenchmarks>(config);
        }
    }
}