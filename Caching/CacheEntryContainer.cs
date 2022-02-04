using System;
namespace BonesOfTheFallen.Services.Caching;

public ref struct CacheEntryContainer<T, U> where T : struct
{
    public CacheEntryContainer(in T input)
    {
        var cache = CacheManager.GetInstance<T>();
        if (cache?.Get(nameof(T)) != null)
        {
            Modifiers = (U?)cache?[Enum.GetName(typeof(T), input)!]!;
        }
        else
        {
            Modifiers = default!;
        }
    }
    public U? Modifiers;
}
