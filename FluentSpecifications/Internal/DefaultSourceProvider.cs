using FluentSpecifications.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentSpecifications.Internal
{
    internal class DefaultSourceProvider<T> : ISourceProvider<T>
    {
        public bool IsInMemory { get; }

        private readonly IEnumerable<T>? _enumerableSource;
        private readonly IQueryable<T>? _queryableSource;

        public DefaultSourceProvider(IEnumerable<T> enumerableSource)
        {
            if (enumerableSource == null)
                throw new ArgumentNullException(nameof(enumerableSource));

            IsInMemory = true;

            _enumerableSource = enumerableSource;
        }

        public DefaultSourceProvider(IQueryable<T> queryableSource)
        {
            if (queryableSource == null)
                throw new ArgumentNullException(nameof(queryableSource));

            IsInMemory = false;

            _queryableSource = queryableSource;
        }

        public bool TryGetEnumerable(out IEnumerable<T>? source)
        {
            source = _enumerableSource;

            if (_enumerableSource == null)
                return false;

            return true;
        }

        public bool TryGetQueryable(out IQueryable<T>? source)
        {
            source = _queryableSource;

            if (_queryableSource == null)
                return false;

            return true;
        }
    }
}
