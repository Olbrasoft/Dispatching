using Olbrasoft.Dispatching.Common;
using System;

namespace Olbrasoft.Dispatching.Dynamic
{
    public static class FactoryExtensions
    {
        public static IRequestHandler CreateHandler(this Factory factory, Type type) => (IRequestHandler)factory(type);
    }
}