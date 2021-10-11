using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Dispatching.Abstractions;
using Olbrasoft.Dispatching.DI.Microsoft.Common;
using Olbrasoft.Dispatching.Dynamic;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class SendRequestsBenchmarks
    {
        private static readonly IServiceCollection _services = new ServiceCollection();
        private IDispatcher _dispatcherWithExecutor;
        private IDispatcher _dynamicDispatcher;
        private IMediator _mediator;

        [GlobalSetup]
        public void Setup()
        {
            _services.AddScoped(typeof(Executor<,>), typeof(Executor<,>));

            _services.AddRequestHandlers(new[] { typeof(Program).Assembly });
            _services.AddScoped<Factory>(p => p.GetService);
            _services.AddMediatR(typeof(Program));

            var provider = _services.BuildServiceProvider();

            var factory = provider.GetService<Factory>();

            _dispatcherWithExecutor = new Dispatcher(factory);

            _dynamicDispatcher = new DynamicDispatcher(factory);

            _mediator = provider.GetService<IMediator>();
        }

        [Benchmark(Baseline = true)]
        public async Task DispatcherWithExecutorDispatchAsync()
        {
            var request = new AwesomeRequest();

            var response = await _dispatcherWithExecutor.DispatchAsync(request, default);
        }

        [Benchmark]
        public async Task DynamicDispatcherDispatchAsync()
        {
            var request = new AwesomeRequest();

            var response = await _dynamicDispatcher.DispatchAsync(request, default);
        }

        [Benchmark]
        public async Task MediatrSendAsync()
        {
            var request = new AwesomeRequest();

            var response = await _mediator.Send(request, default);
        }
    }
}