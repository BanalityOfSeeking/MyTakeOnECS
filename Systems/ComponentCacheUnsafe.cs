using System;
using System.Runtime.InteropServices;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Store the count and reallocation count as well 
    /// and allocates from native memory.
    /// The actual pointer is stored in a separate static class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public unsafe struct ComponentCacheUnsafe<T> : IDisposable where T : unmanaged
    {
        public ComponentCacheUnsafe()
        {
            ComponentCacheHelperUnsafe<T>.CachePtr = (T*)NativeMemory.Alloc(64, (nuint)Marshal.SizeOf<T>());
         }
        internal int Count { get; set; } = 0;
        internal int ReallocCount { get; set; } = 0;


        public void Dispose()
        {
            NativeMemory.Free(ComponentCacheHelperUnsafe<T>.CachePtr);
        }
    }
}
