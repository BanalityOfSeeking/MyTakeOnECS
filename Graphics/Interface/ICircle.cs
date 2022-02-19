using System;

namespace BonesOfTheFallen.Services.Graphics.Interface;

public interface ICircle<T> : IPoint<T> where T : INumber<T>
{
}
