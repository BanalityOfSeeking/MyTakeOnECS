using System;

namespace BonesOfTheFallen.Services
{
    public class SumSequenceSparseSet<T> where T : INumber<T>
    {
        private readonly int _max = 0;

        private T _n = T.Zero;

        internal GameSequence<T>[] _denseEntities = default!;     // dense array
        internal GameSequence<T>[] _sparseEntities = default!;     // sparse array

        public SumSequenceSparseSet(int max)
        {
            _denseEntities = new GameSequence<T>[max];
            _sparseEntities = new GameSequence<T>[max];
            _max = max;
        }

        public GameSequence<T> GetEntity()
        {
            int n = int.Parse((_n + T.One).ToString()!);
            if(n < _max)
            {
                return _denseEntities[n];
            }
            return default!;
        }

        public void RemoveEntity(ref T entity)
        {
            if (ContainsEntity(ref entity))
            {
                _denseEntities[int.Parse(entity.ToString()!)] = default!;
                _sparseEntities[int.Parse(entity.ToString()!)] = default!;
            }
        }

        public bool ContainsEntity(ref T entity)
        {
            int Entity = int.Parse(entity.ToString()!);
            int n = int.Parse(_n.ToString()!);
            if (Entity < 0)
                return false;
            else
                return Entity < n;
        }

        public SumSequenceSparseSet<T> Clear()
        {
            _n = T.Zero;     // simply set n to 0 to clear the set; no re-initialization is required
            return this;
        }

        public int EntityCount
        {
            get { return int.Parse(_n.ToString()!); }
        }

    }
}