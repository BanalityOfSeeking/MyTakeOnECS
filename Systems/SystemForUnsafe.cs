using Microsoft.Toolkit.HighPerformance.Helpers;
using System;
using System.Runtime.InteropServices;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Unsafe system that processes components using pointers
    /// Not implemented in parallel 
    /// yet due to copy memory to array, pass that array to parallelhelper, 
    /// that copy gets changes then i have to copy them back to the pointer..

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
