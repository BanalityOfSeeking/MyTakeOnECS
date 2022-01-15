namespace BonesOfTheFallen.Services
{
    public static unsafe class ComponentCacheHelperUnsafe<TValue> where TValue : unmanaged
    {
        internal static TValue* CachePtr = default!;

    } 
}
