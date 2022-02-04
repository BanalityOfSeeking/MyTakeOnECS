using BonesOfTheFallen.Classes;
using System;
using System.Collections.Concurrent;
using System.Runtime.Caching;

namespace BonesOfTheFallen.Services.Caching;

public static class Caches
{
    private static readonly ObjectCache RaceCache = new MemoryCache("Race");
    private static readonly ObjectCache ClassCache = new MemoryCache("Class");
    private static readonly ObjectCache PlayableCache = new MemoryCache("Playable");
    public static readonly ConcurrentDictionary<Type, ObjectCache> CacheLookup = new();

    static Caches()
    {
        CacheLookup.TryAdd(typeof(Race), RaceCache);
        CacheLookup.TryAdd(typeof(GameClass), ClassCache);
        CacheLookup.TryAdd(typeof(PlayableObject), PlayableCache);
    }
    public static ObjectCache GetCache(CacheEntries cache)
    {
        return cache switch
        {
            CacheEntries.Race => RaceCache,
            CacheEntries.Classes => ClassCache,
            CacheEntries.Playables => PlayableCache,
            _ => throw new NotImplementedException(),
        };
    }
}
