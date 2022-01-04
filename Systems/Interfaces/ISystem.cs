using System;

namespace BonesOfTheFallen.Services
{
    public interface ISystem<T> where T : struct, Enum
    {
        // component modification
        public IComponentBase<T> Component { get; }

        public void Process(in float time);
    }
}