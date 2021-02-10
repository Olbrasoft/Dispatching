using BenchmarkDotNet.Running;

namespace Olbrasoft.Dispatching.Benchmarks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //BenchmarkRunner.Run<DateTimeParserBenchmarks>();
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}