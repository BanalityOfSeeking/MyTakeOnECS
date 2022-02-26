using BonesOfTheFallen.Services.Graphics.Interface;
using Microsoft.Maui.Graphics;
using System;

namespace BonesOfTheFallen.Services.Graphics.Drawables.Interfaces;

public interface IDrawableSquare<T> : IReadOnlyRectangle<T>, IDrawable, IDrawablePoint<T> where T : INumber<T>, new()
{
}
