using Olbrasoft.Dispatching;
using System;

namespace Olbrasoft.Extensions.Dispatching
{
    public static class FactoryExtensions
    {
        public static IRequestHandler CreateHandler(this Factory factory, Type type) => (IRequestHandler)factory(type);
    }
}