using System;

namespace BonesOfTheFallen.Services.Graphics.Interface;
public interface IReadOnlyPosition<T> :
        IAdditionOperators<ReadOnlyPosition<T>, ReadOnlyPosition<T>, ReadOnlyPosition<T>>,
        ISubtractionOperators<ReadOnlyPosition<T>, ReadOnlyPosition<T>, ReadOnlyPosition<T>>,
        IEqualityOperators<ReadOnlyPosition<T>, ReadOnlyPosition<T>>
    where T : INumber<T>, new()
{
    public T X { get; }

    public T Y { get; }

    public (T X, T Y) XY { get; }
}
