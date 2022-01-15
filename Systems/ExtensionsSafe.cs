namespace BonesOfTheFallen.Services
{
    public static class ExtensionsSafe
    {
        public static void AddComponentSafe<T>(this EntitySafe entity, T component)
        {
            ComponentCacheSafe<T>.Cache.Add(component);
            ComponentCacheSafe<T>.EntityComponentIndex.Add(entity, ComponentCacheSafe<T>.Cache.Count -1);
        }
        public static T GetComponentSafe<T>(this EntitySafe entity)
        {
            return ComponentCacheSafe<T>.Cache[ComponentCacheSafe<T>.EntityComponentIndex[entity]];
        }
    }
}
