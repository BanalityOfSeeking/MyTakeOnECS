using Microsoft.Maui.Graphics;
using System;

namespace BonesOfTheFallen.Services.Graphics.Interface;
public interface IReShapeable<T, TResult> : IDrawable where T : INumber<T>
    where TResult : IParseable<TResult>
{
    public PathF Path { get; }
    public new void Draw(ICanvas canvas, RectangleF rectangle);

}
