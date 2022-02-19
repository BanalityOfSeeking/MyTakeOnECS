using BonesOfTheFallen.Services.Graphics.Interface;
using System;

namespace BonesOfTheFallen.Services.Graphics;

public record Circle<T> : Point<T>, IPoint<T>, ICircle<T> where T : INumber<T>
{
    public Circle(T radius, IPoint<T> center) : base(center.Left, center.Top)
    {
        Radius = radius;
    }
}

