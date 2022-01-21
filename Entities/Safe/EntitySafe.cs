using System;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Safe implementation of entity that registers itself into World on new()
    /// </summary>
    public struct EntitySafe
    {

        internal EntitySafe(int id)
        {
            Id = id;
        }

        public int Id = 0;
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
        public static implicit operator int(EntitySafe entity)
        {
            return entity.Id;
        }

        public static explicit operator EntitySafe(int v)
        {
            return new(v);
        }
    }
}
