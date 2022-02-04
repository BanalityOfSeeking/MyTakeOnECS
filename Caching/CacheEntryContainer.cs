using System;
using System.Runtime.Caching;
namespace BonesOfTheFallen.Services.Caching;

public ref struct CacheEntryContainer<T, U> where T : struct
{
    public CacheEntryContainer(in T input)
    {
        if (CacheManager.GetInstance<T>().TryGetValue(typeof(T), out ObjectCache? cache))
        {
            Modifiers = (U)cache[Enum.GetName(typeof(T), input)];
        }
        else
        {
            Modifiers = default!;
        }
    }
    public U Modifiers;
}
