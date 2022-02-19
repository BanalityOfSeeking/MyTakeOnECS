using BonesOfTheFallen.Services.Graphics.Interface;
using System;

namespace BonesOfTheFallen.Services.Graphics;

public record Square<T> : Point<T>, IPoint<T>, ISquare<T> where T : INumber<T>
{
    public Square(T left, T top, T sideLength) : base(left, top)
    {
        SideLength = sideLength;
    }
}


