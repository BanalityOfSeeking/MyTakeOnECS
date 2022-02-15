using System;

namespace BonesOfTheFallen.Graphics
{
    public interface ILine<T> : IPoint<T> where T : INumber<T>
    {
        public IPoint<T> LineStart { get => new Point<T>(Top, Left); }
        public Point<T> LineEnd { get; }
    }
}