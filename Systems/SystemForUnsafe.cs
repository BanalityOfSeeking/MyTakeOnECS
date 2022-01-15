using Microsoft.Toolkit.HighPerformance.Helpers;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Unsafe system that processes components using pointers
    /// Not implemented in parallel 
    /// yet due to copy memory to array, pass that array to parallelhelper, 
    /// that copy gets changes then i have to copy them back to the pointer..
    /// I dont like that, so I will have to think of a better way.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed unsafe class SystemForUnsafe<T> where T : unmanaged
    {
        // clear disadvantage.. needs to copy out to work in parallel.
        // requires something I can pass in a ptr to memory and bounds,
        // then chunk it out for tasks to be queued..
        // a ref struct to handle it that with no garbage.

        public SystemForUnsafe<T> TransitionInPlaceUnsafe<PStruct>(PStruct @struct) where PStruct : struct, IRefAction<T>
        {
            var cache = ComponentSystemsUnsafe<T>.GetCache();
            var container = ComponentSystemsUnsafe<T>.CacheContainer;

            T* TCache = cache;
            var TLen = 0;
            while (TLen < container.Count)
            {
                @struct.Invoke(ref *(TCache + TLen));
                TLen++;
            }
            return this;
        }
    }
}
