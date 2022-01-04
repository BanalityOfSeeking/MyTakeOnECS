using Microsoft.Toolkit.HighPerformance.Helpers;
using System;

namespace BonesOfTheFallen.Services
{
    public record Position : IComponentBase<PositionEnum>, IEquatable<Position>
    {
        public double X;
        public double Y;
        public double Z;

        public Position()
        {
        }

        public override int GetHashCode()
        {
            return HashCode<Position>.Combine(new[] { this });
        }

    }
}
