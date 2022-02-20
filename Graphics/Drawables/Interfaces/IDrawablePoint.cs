using BonesOfTheFallen.Services.Graphics.Interface;
using Microsoft.Maui.Graphics;
using System;

namespace BonesOfTheFallen.Services.Graphics.Drawables.Interfaces;

public interface IDrawablePoint<T> : IPoint<T>, IDrawable where T : INumber<T>
    {
    }
public interface IMainDrawable : IDrawablePoint<float>
{
}
public record MainDrawable : DrawablePoint, IPoint<float>, IDrawablePoint<float>, IMainDrawable
{
    public MainDrawable(float left, float top) : base(left, top)
    {
    }

    public MainDrawable(DrawablePoint original) : base(original)
    {
    }

    public MainDrawable(Point<float> original) : base(original)
    {
    }
}
public interface ISubDrawable : IDrawablePoint<float>
{
}
public record SubDrawable : DrawablePoint, IPoint<float>, IDrawablePoint<float>, ISubDrawable
{
    public SubDrawable(float left, float top) : base(left, top)
    {
    }

    public SubDrawable(DrawablePoint original) : base(original)
    {
    }

    public SubDrawable(Point<float> original) : base(original)
    {
    }
}