using System;
using System.Linq;
using System.Reflection;

namespace Olbrasoft.Extensions
{
    public static class TypeExtensions
    {
        public static bool ImplementsGenericInterface(this Type type, Type interfaceType)
            => type.IsGenericType(interfaceType) || type.GetTypeInfo().ImplementedInterfaces.Any(@interface => @interface.IsGenericType(interfaceType));

        public static bool IsGenericType(this Type type, Type genericType)
             => type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == genericType;
    }
}