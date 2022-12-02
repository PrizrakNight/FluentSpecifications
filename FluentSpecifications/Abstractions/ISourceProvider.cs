using System.Collections.Generic;
using System.Linq;

namespace FluentSpecifications.Abstractions
{
    public interface ISourceProvider<T>
    {
        bool IsInMemory { get; }

        bool TryGetEnumerable(out IEnumerable<T>? source);
        bool TryGetQueryable(out IQueryable<T>? source);
    }
}
