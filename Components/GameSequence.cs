using Microsoft.Toolkit.HighPerformance;
using System;
using System.Collections.Generic;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Store GameSequenceSegments, and constrain them to Numbers. <3!!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GameSequence<T, TResult>
        where T : INumber<T>
        where TResult : IParseable<TResult>
    {
        private readonly List<GameSequenceSegment<T, TResult>> GameSegments = new(100);
        public GameSequence<T, TResult> AddSegment(GameSequenceSegment<T, TResult> gameSegments)
        {
            GameSegments.Add(gameSegments);
            return this;
        }
        public void SumSegments()
        {
            if (GameSegments.Count > 1)
            {
                var input = new T[GameSegments[0].Memory.Length];
                foreach (GameSequenceSegment<T, TResult> segment in GameSegments)
                {
                    foreach (var item in segment.Memory.Span.Enumerate())
                    {
                        input[item.Index] += item.Value;
                    }
                }
                GameSegments.Clear();
                GameSegments.Add(new(input));
            }
        }
    }
}


