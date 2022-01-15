using Microsoft.Toolkit.HighPerformance.Helpers;

namespace BonesOfTheFallen.Services
{
    public sealed unsafe class SystemForUnsafe<T> where T : unmanaged
    {
        // clear disadvantage.. needs to copy out to work in parallel.
        // requires something I can pass in a ptr to memory and bounds,
        // then chunk it out for tasks to be queued.. a ref struct to handle it that with no garbage.


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
    // clear advantages:
    // Less code ~ Parallel by default
    // ** I should replace parallel and try concurrent by default. **

    // disadvantage garbage ToArray()..
    public sealed class SystemForSafe<T> where T : struct, IRefAction<T>
    {
        public SystemForSafe<T> TransitionInPlaceSafe<PStruct>(PStruct @struct) where PStruct : struct, IRefAction<T>
        {
            ParallelHelper.ForEach<T, PStruct>(ComponentCacheSafe<T>.Cache.ToArray(), @struct);
            return this;
        }
    }    
}
