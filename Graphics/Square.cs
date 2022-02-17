﻿using System;

namespace BonesOfTheFallen.Graphics
{
    public record Square<T> : Point<T>, IPoint<T>, ISquare<T> where T : INumber<T>
    {
        public Square(T top, T left, T sideLength) : base(top, left)
        {
            SideLength = sideLength;
        }
        public T SideLength { get; }
    }
}


