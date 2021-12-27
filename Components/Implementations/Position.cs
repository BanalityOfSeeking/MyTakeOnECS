// See https://aka.ms/new-console-template for more information

using System;
using System.Numerics;

namespace BonesOfTheFallen.Services
{
    public record struct Position : IComponentBase, IEquatable<Position>
    {
        public Vector2 Value;

        public override int GetHashCode() => HashCode.Combine(Value.GetHashCode());
    }
}
