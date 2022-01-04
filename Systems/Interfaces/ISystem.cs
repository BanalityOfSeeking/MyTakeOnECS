using Microsoft.Toolkit.HighPerformance;
using System;

namespace BonesOfTheFallen.Services
{
    public interface ISystem<T, baseEnumType> where T : struct, Enum
    {
        // component modification
        public IComponentBase<T> Component { get; }

        Ref<baseEnumType> GetPropertyRef(T attributeId);
        public void Process(in float time);
    }
}