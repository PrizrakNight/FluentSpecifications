using System;
using System.Linq.Expressions;

namespace FluentSpecifications.Abstractions
{
    public interface ISpecificationExpressionBrowser<T>
    {
        void Browse(Expression<Func<T, bool>> expression);
    }
}
