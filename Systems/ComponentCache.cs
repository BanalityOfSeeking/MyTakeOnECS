using System;
using System.Runtime.InteropServices;

namespace BonesOfTheFallen.Services
{
    // Super simple pointer lookup o0
    public unsafe struct ComponentCache<TValue> : IDisposable where TValue : unmanaged
    {
        public ComponentCache()
        {
            ComponentCacheHelper<TValue>.CachePtr = (TValue*)NativeMemory.Alloc(64, (nuint)Marshal.SizeOf<TValue>());
         }
        internal int Count { get; set; } = 0;
        internal int ReallocCount { get; set; } = 0;


        public void Dispose()
        {
            NativeMemory.Free(ComponentCacheHelper<TValue>.CachePtr);
        }
    }
}
