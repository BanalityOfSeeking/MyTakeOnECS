// See https://aka.ms/new-console-template for more information

using Microsoft.Toolkit.HighPerformance.Helpers;
using System;

namespace BonesOfTheFallen.Services
{
    public record struct Velocity : IComponentBase<VelocityEnum>, IEquatable<Velocity>
    {
        public double X = -1;
        public double Y = -1;
        public double Z = -1;

        public Velocity()
        {
        }

        public override int GetHashCode()
        {
            return HashCode<Velocity>.Combine(new[] { this });
        }
    }
}
