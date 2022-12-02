using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FluentSpecifications.Tests.DatabaseTests
{
    internal class ExpressionToSqlBrowser<T> : ISpecificationExpressionBrowser<T>
        where T : class
    {
        private readonly DbSet<T> _set;

        public ExpressionToSqlBrowser()
        {
            _set = AssemblyInitializer.DbContext.Set<T>();
        }

        public void Browse(Expression<Func<T, bool>> expression)
        {
            var sql = _set
                .Where(expression)
                .ToQueryString();

            Console.WriteLine(sql);
        }
    }
}
