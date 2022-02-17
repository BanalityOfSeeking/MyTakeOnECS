using Microsoft.Maui.Graphics;
using System;

namespace BonesOfTheFallen.Graphics
{
    public interface IDrawableCircle<T> : ICircle<T>, IDrawable, IDrawablePoint<T> where T : INumber<T> 
    {
    }
}