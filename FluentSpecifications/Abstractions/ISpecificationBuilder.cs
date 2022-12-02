using System;
using System.Linq.Expressions;

namespace FluentSpecifications.Abstractions
{
    public interface ISpecificationBuilder<T>
    {
        ISourceProvider<T> SourceProvider { get; }

        ISpecificationBuilder<T> UseExpressionBrowser<TBrowser>(Action<TBrowser>? configure = null)
            where TBrowser : ISpecificationExpressionBrowser<T>, new();

        ISpecificationBuilder<T> UseExpressionBrowser<TBrowser>(Func<TBrowser> resolver)
            where TBrowser : ISpecificationExpressionBrowser<T>;

        ISpecificationBuilder<T> UseExpressionBrowser(ISpecificationExpressionBrowser<T> browser);

        ISpecificationBuilder<T> UseSpecification(ISpecification<T> specification);

        ISpecificationBuilder<T> UseSpecification<TSpec>(Action<TSpec>? configure = null)
            where TSpec : ISpecification<T>, new();

        ISpecificationBuilder<T> And<TSpec>(Action<TSpec>? configure = null)
            where TSpec : ISpecification<T>, new();

        ISpecificationBuilder<T> And(ISpecification<T> specification);

        ISpecificationBuilder<T> Or<TSpec>(Action<TSpec>? configure = null)
            where TSpec : ISpecification<T>, new();

        ISpecificationBuilder<T> Or<TSpec>(ISpecification<T> specification);

        ISpecification<T> BuildSpecification();

        Expression<Func<T, bool>> BuildExpression();
    }
}
