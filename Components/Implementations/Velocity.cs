// See https://aka.ms/new-console-template for more information

using System;
using System.Numerics;

namespace BonesOfTheFallen.Services
{
    public record struct Velocity : IComponentBase, IEquatable<Velocity>
    {
        public Vector2 Value = Vector2.Zero;

        public override int GetHashCode() => HashCode.Combine(Value.GetHashCode());
    }
}
