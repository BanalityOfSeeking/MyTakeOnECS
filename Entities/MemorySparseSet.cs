using System;

namespace BonesOfTheFallen.Services
{
    public struct MemorySparseSet : IMemorySparseSet
    {
        private readonly int _max = 0;

        private int _n = 0;
        
        internal EntitySafe[] _denseEntities = default!;     // dense array
        internal int[] _sparseEntities = default!;     // sparse array

        public MemorySparseSet(int max)
        {
            _denseEntities = new EntitySafe[max];
            _sparseEntities = new int[max];
            _max = max;
        }

        public Span<EntitySafe> ProvideEntities(ref int requestCount)
        {
            if (_n + requestCount < _max)
            {
                for (; _n < _max; _n++)
                {
                    _denseEntities[_n] = (EntitySafe)_n;
                    _sparseEntities[_n] = _n;       // ...and link it to the sparse array
                };
                return _denseEntities[.._n];
            }
            return default!;
        }
        public Span<EntitySafe> ProvideEntities(ref Span<EntitySafe> entities)
        {
            if (_n + entities.Length < _max)
            {
                for (int i = 0; _n < _max; _n++)
                {
                    _denseEntities[_n] = entities[i];
                    _sparseEntities[_n] = _n;     // ...and link it to the sparse array
                    i++;
                }
                return _denseEntities[.._n];
            }
            return default!;
        }

        public Span<EntitySafe> GetEntities()
        {
            return _denseEntities;
        }

        public void RemoveEntity(ref EntitySafe entity)
        {
            if (ContainsEntity(ref entity))
            {
                _denseEntities![_sparseEntities![entity]] = _denseEntities![_n - 1];
                _sparseEntities![_denseEntities![_n - 1]] = _sparseEntities![entity];
                _n--;
            }
        }

        public bool ContainsEntity(ref EntitySafe entity)
        {
            if (entity >= _n || entity < 0)
                return false;
            else
                return _sparseEntities![entity] > _n && _denseEntities![_sparseEntities![entity]] == entity;
        }

        public MemorySparseSet Clear()
        {
            _n = 0;     // simply set n to 0 to clear the set; no re-initialization is required
            return this;
        }

        public int EntityCount
        {
            get { return _n; }
        }

    }
}