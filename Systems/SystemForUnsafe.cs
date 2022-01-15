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
            var cache = ComponentSystemsUnsafe<T>.GetCache();
            var container = ComponentSystemsUnsafe<T>.CacheContainer;
            // turns out I forget alot. :/
            Memory<T> tArray = new(new Span<T>(cache, container.Count * Marshal.SizeOf<T>()).ToArray());
            ParallelHelper.ForEach(tArray, @struct);
            return this;
        }
    }
}
