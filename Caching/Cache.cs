
using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace BonesOfTheFallen.Services.Caching;
internal class Cache<T> : MemoryCache
{
    public static Cache<T> GetInstance()
    {
        return new Cache<T>(nameof(T));
    }
    public override DefaultCacheCapabilities DefaultCacheCapabilities => base.DefaultCacheCapabilities;

    public override string Name => base.Name;

    public override object this[string key] { get => base[key]; set => base[key]=value; }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string? ToString()
    {
        return base.ToString();
    }

    public override bool Add(string key, object value, DateTimeOffset absoluteExpiration, string? regionName = null)
    {
        return base.Add(key, value, absoluteExpiration, regionName);
    }

    public override bool Add(string key, object value, CacheItemPolicy policy, string? regionName = null)
    {
        return base.Add(key, value, policy, regionName);
    }

    public override IDictionary<string, object> GetValues(string regionName, params string[] keys)
    {
        return base.GetValues(regionName, keys);
    }

    public override CacheEntryChangeMonitor CreateCacheEntryChangeMonitor(IEnumerable<string> keys, string? regionName = null)
    {
        return base.CreateCacheEntryChangeMonitor(keys, regionName);
    }

    protected override IEnumerator<KeyValuePair<string, object>> GetEnumerator()
    {
        return base.GetEnumerator();
    }

    public override bool Contains(string key, string? regionName = null)
    {
        return base.Contains(key, regionName);
    }

    public override bool Add(CacheItem item, CacheItemPolicy policy)
    {
        return base.Add(item, policy);
    }

    public override object AddOrGetExisting(string key, object value, DateTimeOffset absoluteExpiration, string? regionName = null)
    {
        return base.AddOrGetExisting(key, value, absoluteExpiration, regionName);
    }

    public override CacheItem AddOrGetExisting(CacheItem item, CacheItemPolicy policy)
    {
        return base.AddOrGetExisting(item, policy);
    }

    public override object AddOrGetExisting(string key, object value, CacheItemPolicy policy, string? regionName = null)
    {
        return base.AddOrGetExisting(key, value, policy, regionName);
    }

    public override object Get(string key, string? regionName = null)
    {
        return base.Get(key, regionName);
    }

    public override CacheItem GetCacheItem(string key, string? regionName = null)
    {
        return base.GetCacheItem(key, regionName);
    }

    public override void Set(string key, object value, DateTimeOffset absoluteExpiration, string? regionName = null)
    {
        base.Set(key, value, absoluteExpiration, regionName);
    }

    public override void Set(CacheItem item, CacheItemPolicy policy)
    {
        base.Set(item, policy);
    }

    public override void Set(string key, object value, CacheItemPolicy policy, string? regionName = null)
    {
        base.Set(key, value, policy, regionName);
    }

    public override object Remove(string key, string? regionName = null)
    {
        return base.Remove(key, regionName);
    }

    public override long GetCount(string? regionName = null)
    {
        return base.GetCount(regionName);
    }

    public override IDictionary<string, object> GetValues(IEnumerable<string> keys, string? regionName = null)
    {
        return base.GetValues(keys, regionName);
    }

    private Cache(string name) : base(name)
    {
    }
}
        
    
