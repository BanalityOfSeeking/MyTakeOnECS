using Microsoft.Toolkit.HighPerformance.Helpers;
using System;
using System.Runtime.InteropServices;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Unsafe system that processes components using pointers using span to capture it.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed unsafe class SystemForUnsafe<T> where T : unmanaged
    {       
        public SystemForUnsafe<T> TransitionInPlaceUnsafe<PStruct>(PStruct @struct) where PStruct : struct, IRefAction<T>
        {
            ParallelHelper.ForEach(new Memory<T>(
                new Span<T>(
                    ComponentCacheHelperUnsafe<T>.CachePtr,
                    ComponentSystemsUnsafe<T>.CacheContainer.Count * Marshal.SizeOf<T>()).ToArray())
            , @struct);
            return this;
        }
    }
}
