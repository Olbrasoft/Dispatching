using BenchmarkDotNet.Attributes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.Dispatching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispatching.Benchmarks;
public class Benchmarks
{
    private IMediator _mediator;
    private  AwesomeRequest _request;
    private IDispatcher _dispatcher;

    [GlobalSetup]
    public void GlobalSetup()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AwesomeRequest).Assembly));

        services.AddTransient<Olbrasoft.Dispatching.IRequestHandler<AwesomeRequest, string>, AwesomeRequestHandler>();
        // services.AddTransient<Factory>(p => p.GetService!);

        services.AddSingleton<IRequestHandlerFactory, RequestHandlerFactoryWithServiceProvider>();
       // services.AddTransient(typeof(Executor<,>), typeof(Executor<,>));

        services.AddTransient<IDispatcher, Dispatcher>();
                
        var provider = services.BuildServiceProvider();

        _mediator = provider.GetRequiredService<IMediator>();
        _dispatcher = provider.GetRequiredService<IDispatcher>();

        _request = new AwesomeRequest();
    }


    [Benchmark]
    public async Task MediatorSend()
    {
        var result = await _mediator.Send(_request);

    }

    [Benchmark]
    public async Task DispatcherDispatchAsync()
    {
        var result = await _dispatcher.DispatchAsync(_request,default);
    }


}
