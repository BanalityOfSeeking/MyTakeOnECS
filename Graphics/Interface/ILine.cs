using System;

namespace BonesOfTheFallen.Services.Graphics.Interface;

    public interface ILine<T> : IPoint<T> where T : INumber<T>
    {
        public Orientation Orientation { get; }
        public IPoint<T> LineStart { get; }
    }
