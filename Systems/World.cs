using System;
using System.Collections.Generic;
using System.Threading;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    ///  Currently for EntityUnsafe I Create an Entity and pass in the Id.
    ///  I reverse this method for Entity Safe.
    /// </summary>
    public static class World
    {
        internal static int EntityId = 0;
        public static EntityUnsafe CreateEntity()
        {
            var entity = new EntityUnsafe(EntityId);
            Interlocked.Increment(ref EntityId);
            EntityComponentlookupUnsafe.Add(entity, new Dictionary<Type, int>());

            return entity;
        }
        internal static readonly Dictionary<EntityUnsafe, Dictionary<Type, int>> EntityComponentlookupUnsafe = new();
        internal static readonly Dictionary<EntitySafe, Dictionary<Type, int>> EntityComponentlookupSafe = new();

    }
}
