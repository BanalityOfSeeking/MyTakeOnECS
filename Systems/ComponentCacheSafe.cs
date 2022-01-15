using System.Collections.Generic;

namespace BonesOfTheFallen.Services
{
    public static class ComponentCacheSafe<T>
    {
        public static List<T> Cache { get; } = new();
        public static Dictionary<EntitySafe, int> EntityComponentIndex { get; } = new();
    }
}
