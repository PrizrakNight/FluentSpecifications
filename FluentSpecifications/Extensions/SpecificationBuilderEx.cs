using FluentSpecifications.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FluentSpecifications.Extensions
{
    public static class SpecificationBuilderEx
    {
        public static IEnumerable<T> AsEnumerable<T>(this ISpecificationBuilder<T> builder)
        {
            if (builder.SourceProvider.TryGetEnumerable(out var enumerable))
            {
                return enumerable.Where(builder.BuildExpression().Compile());
            }

            if (builder.SourceProvider.TryGetQueryable(out var queryable))
            {
                return queryable
                    .Where(builder.BuildExpression())
                    .AsEnumerable();
            }

            throw GetSourceProviderException();
        }

        public static IList<T> ToList<T>(this ISpecificationBuilder<T> builder)
        {
            if (builder.SourceProvider.TryGetEnumerable(out var enumerable))
            {
                return enumerable
                    .Where(builder.BuildExpression().Compile())
                    .ToList();
            }

            if (builder.SourceProvider.TryGetQueryable(out var queryable))
            {
                return queryable
                    .Where(builder.BuildExpression())
                    .ToList();
            }

            throw GetSourceProviderException();
        }

        public static T[] ToArray<T>(this ISpecificationBuilder<T> builder)
        {
            if (builder.SourceProvider.TryGetEnumerable(out var enumerable))
            {
                return enumerable
                    .Where(builder.BuildExpression().Compile())
                    .ToArray();
            }

            if (builder.SourceProvider.TryGetQueryable(out var queryable))
            {
                return queryable
                    .Where(builder.BuildExpression())
                    .ToArray();
            }

            throw GetSourceProviderException();
        }

        public static IReadOnlyCollection<T> ToReadOnlyCollection<T>(this ISpecificationBuilder<T> builder)
        {
            if (builder.SourceProvider.TryGetEnumerable(out var enumerable))
            {
                var filtered = enumerable
                    .Where(builder.BuildExpression().Compile())
                    .ToArray();

                return new ReadOnlyCollection<T>(filtered);
            }

            if (builder.SourceProvider.TryGetQueryable(out var queryable))
            {
                var filtered = queryable
                    .Where(builder.BuildExpression())
                    .ToArray();

                return new ReadOnlyCollection<T>(filtered);
            }

            throw GetSourceProviderException();
        }

        public static HashSet<T> ToHashSet<T>(this ISpecificationBuilder<T> builder)
        {
            if (builder.SourceProvider.TryGetEnumerable(out var enumerable))
            {
                return enumerable
                    .Where(builder.BuildExpression().Compile())
                    .ToHashSet();
            }

            if (builder.SourceProvider.TryGetQueryable(out var queryable))
            {
                return queryable
                    .Where(builder.BuildExpression())
                    .ToHashSet();
            }

            throw GetSourceProviderException();
        }

        public static T First<T>(this ISpecificationBuilder<T> builder)
        {
            if (builder.SourceProvider.TryGetEnumerable(out var enumerable))
            {
                return enumerable.First(builder.BuildExpression().Compile());
            }

            if (builder.SourceProvider.TryGetQueryable(out var queryable))
            {
                return queryable.First(builder.BuildExpression());
            }

            throw GetSourceProviderException();
        }

        public static T FirstOrDefault<T>(this ISpecificationBuilder<T> builder)
        {
            if (builder.SourceProvider.TryGetEnumerable(out var enumerable))
            {
                return enumerable.FirstOrDefault(builder.BuildExpression().Compile());
            }

            if (builder.SourceProvider.TryGetQueryable(out var queryable))
            {
                return queryable.FirstOrDefault(builder.BuildExpression());
            }

            throw GetSourceProviderException();
        }

        private static Exception GetSourceProviderException()
        {
            return new InvalidOperationException("SourceProvider was unable to provide a data source to which specifications should apply");
        }
    }
}
