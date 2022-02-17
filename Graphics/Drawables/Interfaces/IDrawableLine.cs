using Microsoft.Maui.Graphics;
using System;

namespace BonesOfTheFallen.Graphics
{
    public interface IDrawableLine<T> : ILine<T>, IDrawable, IDrawablePoint<T> where T : INumber<T>
    {
    }
}