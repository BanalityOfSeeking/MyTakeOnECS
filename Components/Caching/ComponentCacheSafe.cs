using System.Collections.Generic;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Store Component Cache and indexes for entities into cache.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class ComponentCacheSafe<T>
    {
        public static List<T> Cache { get; } = new();
        public static Dictionary<EntitySafe, int> EntityComponentIndex { get; } = new();
    }
}
