using Microsoft.Toolkit.HighPerformance.Helpers;
using System;

namespace BonesOfTheFallen.Services
{
    public record Position : IComponentBase<PositionEnum>, IEquatable<Position>
    {
        public double X = -1;
        public double Y = -1;
        public double Z = -1;

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
    }
}
