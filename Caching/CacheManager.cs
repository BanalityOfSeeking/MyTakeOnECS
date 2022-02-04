
using System;
using System.Collections.Concurrent;
using System.Runtime.Caching;

namespace BonesOfTheFallen.Services.Caching;

internal static class CacheManager
{
    public static Cache<T>? GetInstance<T>() => LookupOrNew<T>();
    private static readonly ConcurrentDictionary<Type, MemoryCache> CacheLookup = new();
    private static Cache<T>? LookupOrNew<T>()
    {
        if(CacheLookup.TryGetValue(typeof(T), out MemoryCache? cache))
        {
            return (Cache<T>)cache;
        }
        else
        {
            CacheLookup.TryAdd(typeof(T), Cache<T>.GetInstance());
            return (Cache<T>)CacheLookup[typeof(T)];
        }
    }
}
        
    
