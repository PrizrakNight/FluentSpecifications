using FluentSpecifications.Abstractions;
using System;
using System.Linq.Expressions;

namespace FluentSpecifications.Internal
{
    internal class DefaultSpecificationBuilder<T> : ISpecificationBuilder<T>
    {
        public ISourceProvider<T> SourceProvider { get; }

        private ISpecificationExpressionBrowser<T>? _browser;

        private Expression<Func<T, bool>>? _specExpression;

        public DefaultSpecificationBuilder(ISourceProvider<T> sourceProvider)
        {
            SourceProvider = sourceProvider ?? throw new ArgumentNullException(nameof(sourceProvider));
        }

        public ISpecificationBuilder<T> UseSpecification(ISpecification<T> specification)
        {
            if (specification == null)
                throw new ArgumentNullException(nameof(specification));

            _specExpression = specification.Condition;

            return this;
        }

        public ISpecificationBuilder<T> UseSpecification<TSpec>(Action<TSpec>? configure = null)
            where TSpec : ISpecification<T>, new()
        {
            var spec = new TSpec();

            configure?.Invoke(spec);

            _specExpression = spec.Condition;

            return this;
        }

        public ISpecificationBuilder<T> And<TSpec>(Action<TSpec>? configure = null)
            where TSpec : ISpecification<T>, new()
        {
            if (_specExpression == null)
                throw GetBuilderException();

            var spec = new TSpec();

            configure?.Invoke(spec);

            var parameter = Expression.Parameter(typeof(T), "x");
            var left = Expression.Invoke(_specExpression, parameter);
            var right = Expression.Invoke(spec.Condition, parameter);
            var binaryExpression = Expression.AndAlso(left, right);

            _specExpression = Expression.Lambda<Func<T, bool>>(binaryExpression, parameter);

            return this;
        }

        public ISpecificationBuilder<T> And(ISpecification<T> specification)
        {
            if (_specExpression == null)
                throw GetBuilderException();

            var parameter = Expression.Parameter(typeof(T), "x");
            var left = Expression.Invoke(_specExpression, parameter);
            var right = Expression.Invoke(specification.Condition, parameter);
            var binaryExpression = Expression.AndAlso(left, right);

            _specExpression = Expression.Lambda<Func<T, bool>>(binaryExpression, parameter);

            return this;
        }

        public ISpecificationBuilder<T> Or<TSpec>(Action<TSpec>? configure = null)
            where TSpec : ISpecification<T>, new()
        {
            if (_specExpression == null)
                throw GetBuilderException();

            var spec = new TSpec();

            configure?.Invoke(spec);

            var parameter = Expression.Parameter(typeof(T), "x");
            var left = Expression.Invoke(_specExpression, parameter);
            var right = Expression.Invoke(spec.Condition, parameter);
            var binaryExpression = Expression.Or(left, right);

            _specExpression = Expression.Lambda<Func<T, bool>>(binaryExpression, parameter);

            return this;
        }

        public ISpecificationBuilder<T> Or<TSpec>(ISpecification<T> specification)
        {
            if (_specExpression == null)
                throw GetBuilderException();

            var parameter = Expression.Parameter(typeof(T), "x");
            var left = Expression.Invoke(_specExpression, parameter);
            var right = Expression.Invoke(specification.Condition, parameter);
            var binaryExpression = Expression.Or(left, right);

            _specExpression = Expression.Lambda<Func<T, bool>>(binaryExpression, parameter);

            return this;
        }

        public ISpecification<T> BuildSpecification()
        {
            if (_specExpression == null)
                throw GetBuilderException();

            _browser?.Browse(_specExpression);

            return new ExpressionSpecification<T>(_specExpression);
        }

        public Expression<Func<T, bool>> BuildExpression()
        {
            if (_specExpression == null)
                throw GetBuilderException();

            _browser?.Browse(_specExpression);

            return _specExpression;
        }

        private static Exception GetBuilderException()
        {
            return new InvalidOperationException("Builder does not contain specifications");
        }

        public ISpecificationBuilder<T> UseExpressionBrowser<TBrowser>(Action<TBrowser>? configure = null)
            where TBrowser : ISpecificationExpressionBrowser<T>, new()
        {
            var browser = new TBrowser();

            configure?.Invoke(browser);

            _browser = browser;

            return this;
        }

        public ISpecificationBuilder<T> UseExpressionBrowser<TBrowser>(Func<TBrowser> resolver)
            where TBrowser : ISpecificationExpressionBrowser<T>
        {
            _browser = resolver.Invoke();

            return this;
        }

        public ISpecificationBuilder<T> UseExpressionBrowser(ISpecificationExpressionBrowser<T> browser)
        {
            _browser = browser;

            return this;
        }
    }
}
