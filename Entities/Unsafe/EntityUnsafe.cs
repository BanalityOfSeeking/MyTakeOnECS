using System;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Unsafe entity gets assigned from World.CreateEntity()
    /// </summary>
    public struct EntityUnsafe
    {

        internal int Id = 0;
        internal int ComponentCount = 0;
        public EntityUnsafe(int id)
        {
            Id=id;
        }

        public override bool Equals(object? obj)
        {
            return obj is EntityUnsafe entity&&
                   Id==entity.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public static bool operator ==(EntityUnsafe left, EntityUnsafe right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(EntityUnsafe left, EntityUnsafe right)
        {
            return !(left==right);
        }
        public static implicit operator int(EntityUnsafe entity)
        {
            return entity.Id;
        }
    }
}
