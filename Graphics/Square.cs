using System;

namespace BonesOfTheFallen.Graphics
{
    public record Square<T> : Point<T>, ISquare<T> where T : INumber<T>
    {
        public Square(T top, T left, T sideLength) : base(top, left)
        {
            SideLength = sideLength;
        }
        public T SideLength { get; }
        public Line<T>[] LineSquare
        {
            get => new Line<T>[]
            {
                new(new Point<T>(Top, Left), SideLength, Orientation.Horizontal),
                new(new Point<T>(Top + SideLength, Left), SideLength, Orientation.Vertical),
                new(new Point<T>(Top + SideLength, Left + SideLength), SideLength, Orientation.Horizontal),
                new(new Point<T>(Top, Left + SideLength), SideLength, Orientation.Vertical)
            };
        }
    }
}


