using System.Runtime.InteropServices;

namespace BonesOfTheFallen.Services
{
    [StructLayout(LayoutKind.Explicit)]
    public record Position : IComponentBase, IPosition
    {
        [FieldOffset(0)]
        internal bool HasVerticalMovement = false;
        [FieldOffset(1)]
        internal bool HasHorizontalMovement = false;
        [FieldOffset(2)]
        internal bool IsMonster = true;
        [FieldOffset(3)]
        internal double X = -1;
        [FieldOffset(4 + sizeof(double))]
        internal double Y = -1;
        [FieldOffset(5 + sizeof(double)*2)]
        internal double Z = -1;
        public ref bool HasVerticalRef { get => ref HasVerticalMovement; }
        public ref bool HasHorizontalRef { get => ref HasHorizontalMovement; }
        public ref bool Monster { get => ref IsMonster; }
        public ref double XRef { get => ref X; }
        public ref double YRef { get => ref Y; }
        public ref double ZRef { get => ref Z; }
        public Position()
        { 
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
