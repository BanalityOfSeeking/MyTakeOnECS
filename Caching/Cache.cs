
using BonesOfTheFallen.Services.Components.Interfaces;
using Microsoft.Toolkit.HighPerformance;
using System;

namespace BonesOfTheFallen.Services.Caching;
internal static class Cached2D
{

    private static readonly Memory2D<IComponentBase> Cache2D = new(new IComponentBase[100000], 10000, 10);

    internal static Memory<IComponentBase>? GetEntityComponents(EntitySafe Entity)
    {
       if(Cache2D.Slice(Entity.Id, 0, 1, 10).TryGetMemory(out Memory<IComponentBase> memory))
        {
            return memory;
        }
       return null;
    }

    internal static bool SetEntityComponents(EntitySafe entity, Memory<IComponentBase> memory)
    {
        if (memory.IsEmpty || memory.Length > Cache2D.Width)
        {
            return false;
        }
        try
        {
            memory.Span.CopyTo(Cache2D.Span.GetRowSpan(entity));
            return true;
        }
        catch (Exception)
        {

            return false;
        }

    }
}
        
    
