using Microsoft.Toolkit.HighPerformance;
using System;
using System.Collections.Generic;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Store GameSequenceSegments, and constrain them to Numbers. <3!!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public record GameSequence<T> where T : INumber<T>
    {
        private readonly List<GameSequenceSegment<T>> GameSegments = new(100);
        public GameSequence<T> AddSegment(GameSequenceSegment<T> gameSegments)
        {
            GameSegments.Add(gameSegments);
            return this;
        }
        public void SumSegments()
        {
            if (GameSegments.Count > 1)
            {
                var input = new T[GameSegments[0].Memory.Length];
                foreach (GameSequenceSegment<T> segment in GameSegments)
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


