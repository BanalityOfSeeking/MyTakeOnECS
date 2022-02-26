using System;

namespace BonesOfTheFallen.Services.Graphics.Interface;

public class ReShapeable<T, TResult> where T : INumber<T>
    where TResult : IParseable<TResult>
{
    private SumSequenceSparseSet<T,TResult> Points = new(1000);

}
