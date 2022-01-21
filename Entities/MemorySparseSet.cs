using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using Microsoft.Toolkit.HighPerformance;

namespace BonesOfTheFallen.Services
{
    public class MemorySparseSet : IDisposable, IMemorySparseSet
    {
        private int _max = 0;

        private int _n = 0;
        internal Memory<int> _denseEntities = new(stackalloc int[100].ToArray());      // dense array
        private MemoryHandle denseHandle = default!;

        internal Memory<int> _sparseEntities = new(stackalloc int[100].ToArray());     // sparse array
        private MemoryHandle sparseHandle = default!;

        public MemorySparseSet(int max)
        {
            denseHandle = _denseEntities.Pin();
            sparseHandle = _sparseEntities.Pin();
            _max = max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<EntitySafe> ProvideEntities(ref int[] entities)
        {
            if (entities.Length < 100)
            {
                for (int i = 0; i < entities.Length; i++)
                {
                    ref var de = ref _denseEntities.Span[_n + i];     // insert new value in the dense array...
                    de = _n +i;
                    ref var se = ref _sparseEntities.Span[_n +i];
                    se = _n +i;     // ...and link it to the sparse array
                }
                _n += entities.Length;
                return SpanExtensions.Cast<int, EntitySafe>(_denseEntities.Span[..entities.Length]);
            }
            return default!;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<EntitySafe> GetEntities()
        {

            if (_n < 100)
            {
                return _denseEntities.Span.Cast<int, EntitySafe>();
            }
            return default!;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RemoveEntity(ref EntitySafe entity)
        {
            if (ContainsEntity(ref entity))
            {
                _denseEntities.Span![_sparseEntities.Span![entity]] = _denseEntities.Span![_n - 1];
                _sparseEntities.Span![_denseEntities!.Span[_n - 1]] = _sparseEntities!.Span[entity];
                _n--;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ContainsEntity(ref EntitySafe entity)
        {
            if (entity >= _n || entity < 0)
                return false;
            else
                return _sparseEntities!.Span[entity] > _n && _denseEntities!.Span[_sparseEntities!.Span[entity]] == entity;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MemorySparseSet Clear()
        {
            _n = 0;     // simply set n to 0 to clear the set; no re-initialization is required
            return this;
        }


        void IDisposable.Dispose()
        {
            ((IDisposable)denseHandle).Dispose();
            ((IDisposable)sparseHandle).Dispose();
        }

        public Span<EntitySafe> ProvideEntities(ref Span<int> entities)
        {
            if (_n + entities.Length < _max)
            {
                for (int i = 0; i < entities.Length; i++)
                {
                    ref var de = ref _denseEntities.Span[_n + i];     // insert new value in the dense array...
                    de = _n +i;
                    ref var se = ref _sparseEntities.Span[_n +i];
                    se = _n +i;     // ...and link it to the sparse array
                }
                _n += entities.Length;
                return SpanExtensions.Cast<int, EntitySafe>(_denseEntities.Span[..entities.Length]);
            }
            return default!;
        }

        public int EntityCount
        {
            get { return _n; }
        }

    }
}