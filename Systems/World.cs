using System;
using System.Collections.Generic;
using System.Threading;

namespace BonesOfTheFallen.Services
{
    /// Create entities using World
    public static class World
    {
        internal static int EntityId = 0;
        public static Entity CreateEntity()
        {
            var entity = new Entity();
            Interlocked.Increment(ref EntityId);
            Interlocked.Exchange(ref entity.HashCode, EntityId.GetHashCode());
            // auto adds to component pairs and initializes list of Types for this entity
            EntityComponentlookup.Add(entity, new Dictionary<Type, int>());

            return entity;
        }
        internal static readonly Dictionary<Entity, Dictionary<Type, int>> EntityComponentlookup = new();

    }
}
