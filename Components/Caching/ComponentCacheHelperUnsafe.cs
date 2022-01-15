namespace BonesOfTheFallen.Services
{

    /// <summary>
    /// Store Pointer for the Given type cache.
    /// ** I want to eventualy turn ppointers to a "sparse set architecture" using pointers..
    /// that is a far way off..
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public static unsafe class ComponentCacheHelperUnsafe<TValue> where TValue : unmanaged
    {
        internal static TValue* CachePtr = default!;

    }
}
