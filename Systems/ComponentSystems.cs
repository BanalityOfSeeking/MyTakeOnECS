namespace BonesOfTheFallen.Services
{
    // storage for System and Component Cache.
    public static unsafe class ComponentSystems<TValue> where TValue : unmanaged
    {
        private static readonly SystemFor<TValue> System = new();
        public static SystemFor<TValue> GetSystem() => System;
        internal static ComponentCache<TValue> CacheContainer = new();
        public static TValue* GetCache()
        {
            return ComponentCacheHelper<TValue>.CachePtr;            
        }
    }
}
