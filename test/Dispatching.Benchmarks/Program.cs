// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;

namespace Dispatching.Benchmarks;
public class Program
{
    public static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
}