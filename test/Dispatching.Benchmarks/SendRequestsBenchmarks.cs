using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

using LightInject;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Dispatching.DI.Microsoft.Common;
using System.Threading.Tasks;
using Grace.DependencyInjection;
using Grace.DependencyInjection.Extensions;
using Singularity;

namespace Olbrasoft.Dispatching.Benchmarks
{
    internal class SingularityServiceProviderFactory : IServiceProviderFactory<Container>
    {
        public Container CreateBuilder(IServiceCollection services)
        {
            var container = new Container(cb =>
            {
                cb.RegisterServiceProvider();
                cb.RegisterServices(services);
            });

            return container;
        }

        public IServiceProvider CreateServiceProvider(Container container)
        {
            return container.GetInstance<IServiceProvider>();
        }
    }

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class SendRequestsBenchmarks
    {
        private static readonly IServiceCollection _services = new ServiceCollection();
        private static IDispatcher _dispatcherWithExecutor;
        private IDispatcher _dynamicDispatcher;
        private IMediator _mediator;

        private static IServiceContainer _lightInjectContainer;
        private static IContainer _singularityContainer;
        private static IInjectionScope _graceContainer;
        private static SimpleInjector.Container _simpleInjector;

        private IDispatcher _lightInjectDispatcherWithExecutor;
        private IDispatcher _LightInjectDispatcherDynamic;

        private IDispatcher _singularityDispatcher;
        private IDispatcher _singularityDynamicDispatcher;

        private IDispatcher _graceDispatcher;

        private IDispatcher _graceDynamicDispatcher;

        private IDispatcher _simpleDispatcher;
        private IDispatcher _simpleDynamicDispatcher;

        [GlobalSetup]
        public void Setup()
        {
            var container = new DependencyInjectionContainer();

            //_lightInjectContainer.ScopeManagerProvider = new PerLogicalCallContextScopeManagerProvider();
            _services.AddScoped(typeof(Executor<,>), typeof(Executor<,>));

            _lightInjectContainer = new ServiceContainer();
            _lightInjectContainer.RegisterScoped(typeof(Executor<,>), typeof(Executor<,>));
            _lightInjectContainer.RegisterScoped<IRequestHandler<AwesomeRequest, object>, AwesomeRequestHandler>();
            _lightInjectContainer.RegisterScoped<Factory>(p => p.GetInstance);

            _simpleInjector = new SimpleInjector.Container();

            _simpleInjector.Register(typeof(Executor<,>), typeof(Executor<,>));
            _simpleInjector.Register<IRequestHandler<AwesomeRequest, object>, AwesomeRequestHandler>();
            _simpleInjector.Register<Factory>(() => _simpleInjector.GetInstance);

            _simpleDispatcher = new Dispatcher(_simpleInjector.GetInstance<Factory>());

            _simpleDynamicDispatcher = new DynamicDispatcher(_simpleInjector.GetInstance<Factory>());

            _services.AddRequestHandlers(new[] { typeof(Program).Assembly });

            _services.AddScoped<Factory>(p => p.GetService);


            _services.AddMediatR(typeof(Program));
            
            //_services.AddScoped<MediatR.IRequestHandler<AwesomeRequest, object>, AwesomeRequestHandler>();

            //_services.AddScoped<IMediator, Mediator>();


            //_singularityContainer =  new Container(builder =>
            //{
            //    builder.Register(typeof(Executor<,>), typeof(Executor<,>));
            //    builder.Register<Abstractions.IRequestHandler<AwesomeRequest, object>, AwesomeRequestHandler>();
            //    builder.Register<Factory>(c=>c.Inject(_singularityContainer.GetInstance));
            //});

            _singularityContainer = new SingularityServiceProviderFactory().CreateBuilder(_services);

            _graceContainer = new Grace.DependencyInjection.DependencyInjectionContainer();
            _graceContainer.Configure(c =>
            {
                c.Export(typeof(Executor<,>)).As(typeof(Executor<,>));
                c.Export<AwesomeRequestHandler>().As<IRequestHandler<AwesomeRequest, object>>();
                c.ExportFunc<Factory>(p => p.GetService);
            });

            var fac = _graceContainer.Locate<Factory>();

            var graceFactory = _graceContainer.Locate<Factory>();
            if (graceFactory == null) throw new ArgumentNullException();

            _graceDispatcher = new Dispatcher(graceFactory);
            _graceDynamicDispatcher = new DynamicDispatcher(graceFactory);

            var provider = _services.BuildServiceProvider();

            var factory = provider.GetService<Factory>();

            Factory f;

            using (var scope = _lightInjectContainer.BeginScope())
            {
                f = scope.GetInstance<Factory>();
            }

            var singularityFactory = _singularityContainer.GetInstance<Factory>();

            _lightInjectDispatcherWithExecutor = new Dispatcher(f);
            _LightInjectDispatcherDynamic = new DynamicDispatcher(f);

            _singularityDispatcher = new Dispatcher(singularityFactory);
            _singularityDynamicDispatcher = new DynamicDispatcher(singularityFactory);

            _dispatcherWithExecutor = new Dispatcher(factory);

            _dynamicDispatcher = new DynamicDispatcher(factory);

            _mediator = provider.GetService<IMediator>();
        }

        [Benchmark]
        public async Task DispatcherWithExecutorDispatchAsync()
        {
            var request = new AwesomeRequest();

            var response = await _dispatcherWithExecutor.DispatchAsync(request, default);
        }

        //[Benchmark]
        //public async Task SimpleDispatcherWithExecutorDispatchAsync()
        //{
        //    var request = new AwesomeRequest();

        //    var response = await _simpleDispatcher.DispatchAsync(request, default);
        //}

        //[Benchmark]
        //public async Task SimpleDynamicDispatcherWithExecutorDispatchAsync()
        //{
        //    var request = new AwesomeRequest();

        //    var response = await _simpleDynamicDispatcher.DispatchAsync(request, default);
        //}

        //[Benchmark(Baseline = true)]
        //public async Task GraceDispatcherWithExecutorDispatchAsync()
        //{
        //    var request = new AwesomeRequest();

        //    var response = await _graceDispatcher.DispatchAsync(request, default);
        //}

        //[Benchmark]
        //public async Task GraceDynamicDispatcherDispatchAsync()
        //{
        //    var request = new AwesomeRequest();

        //    var response = await _graceDynamicDispatcher.DispatchAsync(request, default);
        //}

        //[Benchmark]
        //public async Task LightInjectDispatcherWithExecutorDispatchAsync()
        //{
        //    var request = new AwesomeRequest();

        //    var response = await _lightInjectDispatcherWithExecutor.DispatchAsync(request, default);
        //}

        //[Benchmark]
        //public async Task SingularityDispatcherDispatchAsync()
        //{
        //    var request = new AwesomeRequest();

        //    var response = await _singularityDispatcher.DispatchAsync(request, default);
        //}

        //[Benchmark]
        //public async Task SingularityDynamicDispatcherDispatchAsync()
        //{
        //    var request = new AwesomeRequest();

        //    var response = await _singularityDynamicDispatcher.DispatchAsync(request, default);
        //}

        [Benchmark]
        public async Task DynamicDispatcherDispatchAsync()
        {
            var request = new AwesomeRequest();

            var response = await _dynamicDispatcher.DispatchAsync(request, default);
        }

        //[Benchmark]
        //public async Task MediatrSendAsync()
        //{
        //    var request = new AwesomeRequest();

        //    var response = await _mediator.Send(request, default);
        //}

        //[Benchmark]
        //public async Task LightInjectDispatcherDynamicDispatchAsync()
        //{
        //    var request = new AwesomeRequest();

        //    var response = await _LightInjectDispatcherDynamic.DispatchAsync(request, default);
        //}
    }
}