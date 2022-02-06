using System;
namespace BonesOfTheFallen.Services.Caching;

public ref struct CacheEntryContainer<T, U> where T : struct, Enum
{
    public CacheEntryContainer(T input)
    {
        var cache = CacheManager.GetInstance<T>();
        if (cache?[Enum.GetName(typeof(T), input)!] != null)
        {
            Modifiers = (U?)cache?[Enum.GetName(typeof(T), input)!];
        }
        else
        {
            Modifiers = default!;
        }
    }
    public U? Modifiers;
}
