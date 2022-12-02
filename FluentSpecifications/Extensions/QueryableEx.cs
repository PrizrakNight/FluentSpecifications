using FluentSpecifications.Abstractions;
using FluentSpecifications.Internal;
using System.Linq;

namespace FluentSpecifications.Extensions
{
    public static class QueryableEx
    {
        public static ISpecificationBuilder<T> AsSpecBuilder<T>(this IQueryable<T> source)
        {
            var sourceProvider = new DefaultSourceProvider<T>(source);
            var specBuilder = new DefaultSpecificationBuilder<T>(sourceProvider);

            return specBuilder;
        }
    }
}
