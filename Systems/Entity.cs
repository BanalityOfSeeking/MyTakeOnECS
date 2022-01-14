namespace BonesOfTheFallen.Services
{
    public struct Entity
    {

        internal int HashCode = 0;

        public override bool Equals(object? obj)
        {
            return obj is Entity entity&&
                   HashCode==entity.HashCode;
        }

        public override int GetHashCode()
        {
            return HashCode;
        }

        public static bool operator ==(Entity left, Entity right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left==right);
        }
    }
}
