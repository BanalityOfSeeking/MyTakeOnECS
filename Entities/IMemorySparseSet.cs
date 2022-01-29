using System;

namespace BonesOfTheFallen.Services
{
    public interface IMemorySparseSet
    {
        int EntityCount { get; }

        MemorySparseSet Clear();
        bool ContainsEntity(ref EntitySafe entity);
        Span<EntitySafe> GetEntities();
        Span<EntitySafe> ProvideEntities(ref int requestCount);
        Span<EntitySafe> ProvideEntities(ref Span<EntitySafe> entities);
        void RemoveEntity(ref EntitySafe entity);
    }
}