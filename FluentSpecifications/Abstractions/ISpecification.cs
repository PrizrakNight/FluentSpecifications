using System;
using System.Linq.Expressions;

namespace FluentSpecifications.Abstractions
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Condition { get; }
    }
}
