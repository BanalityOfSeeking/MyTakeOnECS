using System;

namespace BonesOfTheFallen.Services
{
    public interface IMemorySparseSet
    {
        int EntityCount { get; }

        MemorySparseSet Clear();
        bool ContainsEntity(ref EntitySafe entity);
        Span<EntitySafe> GetEntities();
        Span<EntitySafe> ProvideEntities(ref int[] entities);
        Span<EntitySafe> ProvideEntities(ref Span<int> entities);
        void RemoveEntity(ref EntitySafe entity);
    }
}