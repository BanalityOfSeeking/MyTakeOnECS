using BonesOfTheFallen.Services.Graphics.Interface;
using Microsoft.Maui.Graphics;
using System;

namespace BonesOfTheFallen.Services.Graphics.Drawables.Interfaces;

public interface IDrawablePoint<T> : IReadOnlyPosition<T>, IDrawable where T : INumber<T>, new()
{
}
