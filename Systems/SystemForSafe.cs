using Microsoft.Toolkit.HighPerformance.Helpers;

namespace BonesOfTheFallen.Services
{
    // clear advantages:
    // Less code ~ Parallel by default
    // ** I should replace parallel and try concurrent by default. **

    public sealed class SystemForSafe<T> where T : struct, IRefAction<T>
    {
        public SystemForSafe<T> TransitionInPlaceSafe<PStruct>(PStruct @struct) where PStruct : struct, IRefAction<T>
        {
            ParallelHelper.ForEach<T, PStruct>(ComponentCacheSafe<T>.Cache.ToArray(), @struct);
            return this;
        }
    }
}
