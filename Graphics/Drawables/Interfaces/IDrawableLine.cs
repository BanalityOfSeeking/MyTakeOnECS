using BonesOfTheFallen.Services.Graphics.Interface;
using Microsoft.Maui.Graphics;
using System;

namespace BonesOfTheFallen.Services.Graphics.Drawables.Interfaces;

    public interface IDrawableLine<T> : IReadOnlyLine<T>, IDrawable 
        where T : INumber<T>, new()
    {
    }
