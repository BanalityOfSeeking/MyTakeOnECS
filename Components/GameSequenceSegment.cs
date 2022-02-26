using System;
using System.Buffers;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// GameSequenceSegments Purpose is to contain the next sequence 
    /// of data that changes the underlying data set.
    /// example BaseAttributes + RaceAttributes + ClassAttributes = GameArchType
    /// in other words I dont do singular modifications of the data, I only sum Sequences.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GameSequenceSegment<T, TResult> : ReadOnlySequenceSegment<T> 
        where T : INumber<T>
        where TResult : IParseable<TResult>
    {
        public GameSequenceSegment(Memory<T> memory) : base()
        {
            Memory = memory;
        }
        public GameSequenceSegment(T[] memory)
        {
            Memory = memory;
        }
        public GameSequenceSegment(Span<T> memory)
        {
            Memory = new Memory<T>(memory.ToArray());
        }
        public GameSequenceSegment(Range memory)
        {
            if (memory.End.Value is T t)
            {
                Memory = new T[] { t };
            }
        }
    }
}


