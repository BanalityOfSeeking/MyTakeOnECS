using System;
using System.Collections.Generic;
using System.Threading;

namespace BonesOfTheFallen.Services
{
    // reverse logic and safe.
    public struct EntitySafe
    {

        public EntitySafe()
        {
            World.EntityComponentlookupSafe.Add(this, new Dictionary<Type, int>());
        }

        internal int Id = Interlocked.Increment(ref World.EntityId);

        public override bool Equals(object? obj)
        {
            return obj is EntitySafe entity&&
                   Id==entity.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public static bool operator ==(EntitySafe left, EntitySafe right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(EntitySafe left, EntitySafe right)
        {
            return !(left==right);
        }
    }
}
