namespace BonesOfTheFallen.Services
{
    // storage for System and Component Cache.
    public static unsafe class ComponentSystemsUnsafe<TValue> where TValue : unmanaged
    {
        private static readonly SystemForUnsafe<TValue> System = new();
        public static SystemForUnsafe<TValue> GetSystem() => System;
        internal static ComponentCacheUnsafe<TValue> CacheContainer = new();
        public static TValue* GetCache()
        {
            return ComponentCacheHelperUnsafe<TValue>.CachePtr;            
        }
    }
}
