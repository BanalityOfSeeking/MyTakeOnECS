using System;

namespace BonesOfTheFallen.Services.Graphics.Interface;

    public interface IPoint<T> where T : INumber<T>
    {
        public T Top { get; init; }
        public T Left { get; init; }
        public T SideLength { get; init; }
        public T Radius { get; init; }
        public IPoint<T> MoveByOffset(T left, T top);
        public IPoint<T> MoveTo(IPoint<T> point);

        public ISquare<T> LengthenSide(T Expansion);
        public ISquare<T> ShrinkSide(T Contraction);

        public ICircle<T> Expand(T Expansion);
        public ICircle<T> Contract(T Contraction);


    }

