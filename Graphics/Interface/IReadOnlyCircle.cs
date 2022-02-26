using System;

namespace BonesOfTheFallen.Services.Graphics.Interface;

public interface IReadOnlyCircle<T> :
        IAdditionOperators<ReadOnlyCircle<T>, ReadOnlyCircle<T>, ReadOnlyCircle<T>>,
    ISubtractionOperators<ReadOnlyCircle<T>, ReadOnlyCircle<T>, ReadOnlyCircle<T>>,
    IEqualityOperators<ReadOnlyCircle<T>, ReadOnlyCircle<T>>
    where T : INumber<T>, new()
{
    ReadOnlyPosition<T> Center { get; }
    T Radius { get; }
}
