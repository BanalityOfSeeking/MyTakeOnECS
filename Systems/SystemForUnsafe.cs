using Microsoft.Toolkit.HighPerformance.Helpers;
using System;
using System.Threading;
namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Unsafe system that processes components using pointers using span to capture it.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed unsafe class SystemForUnsafe<T> : IThreadPoolWorkItem where T : unmanaged, IRefAction<T>
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }

        public SystemForUnsafe<T> TransitionInPlaceUnsafe<PStruct>(PStruct @struct) where PStruct : unmanaged, IRefAction<T>
        {
            ParallelHelper.ForEach(new Memory<T>(
                new Span<T>(ComponentCacheHelperUnsafe<T>.CachePtr, 
                            World.ComponentSystemsUnsafe<T>.CacheContainer.Count)
                        .ToArray()), @struct);
            return this;
        }
    }
}
