// See https://aka.ms/new-console-template for more information

using Microsoft.Toolkit.HighPerformance.Helpers;
using System;

namespace BonesOfTheFallen.Services
{
    public record Velocity : IComponentBase<VelocityEnum>, IEquatable<Velocity>
    {
        public double X;
        public double Y;
        public double Z;

        public Velocity()
        {
        }

        public override int GetHashCode()
        {
            return HashCode<Velocity>.Combine(new[] { this });
        }
    }
}
