using Microsoft.Maui.Graphics;
using System;

namespace BonesOfTheFallen.Graphics
{
    public interface IDrawablePoint<T> : IPoint<T>, IDrawable where T : INumber<T>
    {
    }
}