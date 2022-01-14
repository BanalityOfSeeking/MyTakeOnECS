namespace BonesOfTheFallen.Services
{
    public unsafe static class ComponentCacheHelper<TValue> where TValue : unmanaged
    {
        internal static TValue* CachePtr = default!;

    } 
}
