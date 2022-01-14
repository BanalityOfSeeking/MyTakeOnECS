using System.Runtime.InteropServices;

namespace BonesOfTheFallen.Services
{
    [StructLayout(LayoutKind.Explicit)]
    public record struct Position : IComponentBase
    {
        [FieldOffset(0)]
        public bool HasVerticalMovement = false;
        [FieldOffset(1)]
        public bool HasHorizontalMovement = false;
        [FieldOffset(2)]
        public bool IsMonster = true;
        [FieldOffset(3)]
        public double X = -1;
        [FieldOffset(4 + sizeof(double))]
        public double Y = -1;
        [FieldOffset(5 + sizeof(double)*2)]
        public double Z = -1;

        public Position(
            double x = 0,
            double y = 0,
            double z = 0,
            bool hasVerticalMovement = false,
            bool hasHorizontalMovement = false,
            bool isMonster = true)
        {
            X = x;
            Y = y;
            Z = z;
            HasVerticalMovement = hasVerticalMovement;
            HasHorizontalMovement = hasHorizontalMovement;
            IsMonster = isMonster;
        }

        public static Position operator +(Position left, Position right)
        {
            left.X += right.X;
            left.Y += right.Y;
            left.Z += right.Z;
            return left;
        }
        public static bool operator <(Position left, Position right)
        {
            if (left.X < right.X
                && left.Y < right.Y)
            {
                return true;
            }
            return false;
        }
        public static bool operator >(Position left, Position right)
        {
            return right < left;
        }
    }
}
