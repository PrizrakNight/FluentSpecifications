using FluentSpecifications.Abstractions;
using FluentSpecifications.Internal;
using System;
using System.Collections.Generic;

namespace FluentSpecifications.Extensions
{
    public static class EnumerableEx
    {
        public static ISpecificationBuilder<T> AsSpecBuilder<T>(this IEnumerable<T> source,
            Action<ISpecificationBuilder<T>>? configure = null)
        {
            var sourceProvider = new DefaultSourceProvider<T>(source);
            var specBuilder = new DefaultSpecificationBuilder<T>(sourceProvider);

            configure?.Invoke(specBuilder);

            return specBuilder;
        }
    }
}
