using System;

namespace BonesOfTheFallen.Services.Graphics.Interface;

public interface IReadOnlyLine<T> :
    IAdditionOperators<ReadOnlyLine<T>, ReadOnlyLine<T>, ReadOnlyLine<T>>,
    ISubtractionOperators<ReadOnlyLine<T>, ReadOnlyLine<T>, ReadOnlyLine<T>>,
    IEqualityOperators<ReadOnlyLine<T>, ReadOnlyLine<T>>
    where T : INumber<T>, new()
{
    ReadOnlyPosition<T> Origin { get; }
    ReadOnlyPosition<T> End { get; }
}
