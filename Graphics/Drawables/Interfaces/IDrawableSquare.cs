using Microsoft.Maui.Graphics;
using System;

namespace BonesOfTheFallen.Graphics
{
    public interface IDrawableSquare<T> : ISquare<T>, IDrawable, IDrawablePoint<T> where T : INumber<T>
    {
    }
}