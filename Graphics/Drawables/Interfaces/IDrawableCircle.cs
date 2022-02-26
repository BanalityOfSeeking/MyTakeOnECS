using BonesOfTheFallen.Services.Graphics.Interface;
using Microsoft.Maui.Graphics;
using System;

namespace BonesOfTheFallen.Services.Graphics.Drawables.Interfaces;

public interface IDrawableCircle<T, TResult> : IReadOnlyCircle<T>, IDrawable
    where T : INumber<T>, new()
{
}
