using BonesOfTheFallen.Services.Graphics.Interface;
using System;

namespace BonesOfTheFallen.Services.Graphics;

public record Circle<T> : Point<T>, IPoint<T>, ICircle<T> where T : INumber<T>
{
    public Circle(T radius, IPoint<T> center) : base(center.Top, center.Left)
    {
        Radius = radius;
    }

    public T Radius { get; init; }
    internal static T Zero { get => default!; }
    public ICircle<T> Expand(T Expansion) => this with { Radius = Radius + Expansion };
    public ICircle<T> Contract(T Contraction) => Radius - Contraction > Circle<T>.Zero ? this with { Radius = Radius - Contraction } : this;
}

