using FluentSpecifications.Abstractions;
using System;
using System.Linq.Expressions;

namespace FluentSpecifications.Internal
{
    internal class ExpressionSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Condition { get; }

        public ExpressionSpecification(Expression<Func<T, bool>> condition)
        {
            Condition = condition;
        }
    }
}
