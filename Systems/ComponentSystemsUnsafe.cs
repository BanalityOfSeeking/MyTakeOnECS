namespace BonesOfTheFallen.Services
{
    /// <summary>
    ///   System and Component Cache access class.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public static unsafe class ComponentSystemsUnsafe<TValue> where TValue : unmanaged
    {
        private static readonly SystemForUnsafe<TValue> System = new();
        public static SystemForUnsafe<TValue> GetSystem() => System;
        internal static ComponentCacheUnsafe<TValue> CacheContainer = new();
    }
}
