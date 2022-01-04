// See https://aka.ms/new-console-template for more information

using Microsoft.Toolkit.HighPerformance;
using System;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Base of all Systems.
    /// </summary>
    public abstract record SystemBase<T, U> : ISystem<T, U> where T : struct, Enum
    {
        protected SystemBase() : base()
        {
        }

        public abstract IComponentBase<T> Component { get; }

        public abstract Ref<U> GetPropertyRef(T attributeId);
        public abstract void Process(in float time);

    }
}