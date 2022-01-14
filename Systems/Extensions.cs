using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BonesOfTheFallen.Services
{
    public static class Extensions
    {



        /// <summary>
        /// Adds component to entity component lookups, writes cache, etc..
        /// basically just checking everything is in order and perform the right operation for the situation.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="entity"></param>
        /// <param name="input"></param>
        /// <exception cref="Exception"></exception>
        public static unsafe void AddComponent<TValue>(this Entity entity, TValue input) where TValue : unmanaged
        {
            // get dictionary to prevent constant repeated calls..
            var ecl = World.EntityComponentlookup;
            if (ecl.ContainsKey(entity))
            {
                Dictionary<Type, int> lookup = ecl[entity];
                if (!lookup.ContainsKey(typeof(TValue)))
                {
                    lookup.Add(typeof(TValue), ComponentSystems<TValue>.CacheContainer.WriteCache(input));
                }
                else
                {
                    throw new Exception("Component already exists");
                }
            }
            else
            {
                TValue* tcp = ComponentCacheHelper<TValue>.CachePtr;
            }
        }
        /// <summary>
        /// Gets a component that is associated with an entity.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="entity"></param>
        /// <param name="component"></param>
        /// <returns></returns>
        public static unsafe bool GetComponent<TValue>(this Entity entity, out TValue component) where TValue : unmanaged
        {
            var ecl = World.EntityComponentlookup;
            if (ecl.ContainsKey(entity))
            {
                if (ecl[entity].ContainsKey(typeof(TValue)))
                {
#if DEBUG // check key
                    var key = ecl[entity][typeof(TValue)];
#endif
                    var cache = ComponentCacheHelper<TValue>.CachePtr;
                    component =  *(cache + ecl[entity][typeof(TValue)]);
                    return true;
                }
            }
            component = default;
            return false;
        }
        /// <summary>
        /// Writes to a pointer, ensures no stack buffer overflow (0xc0000409)
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="cache"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static unsafe int WriteCache<TValue>(this ref ComponentCache<TValue> cache, TValue input) where TValue : unmanaged
        {
            var container = ComponentSystems<TValue>.CacheContainer;
            // if cach count less than 64 use write to it, they are preallocated.
            if (cache.Count < (cache.ReallocCount > 0 ? cache.ReallocCount : 1) * 64)
            {
                *(ComponentCacheHelper<TValue>.CachePtr + cache.Count) = input;
                cache.Count++;
                return cache.Count - 1;
            }
            // count is higher..
            else
            {
                // check reallocation count is 0, if so double the size of buffer.
                if (cache.ReallocCount == 0)
                {
                    ComponentCacheHelper<TValue>.CachePtr = (TValue*)NativeMemory.Realloc(ComponentCacheHelper<TValue>.CachePtr, (nuint)(Marshal.SizeOf<TValue>() * 128));

                }
                // more than 0
                else
                {
                    // sizeof struct * realloccount (2,4,6,8 etc) * 128 first pass 256, next 512, etc..
                    ComponentCacheHelper<TValue>.CachePtr = (TValue*)NativeMemory.Realloc(ComponentCacheHelper<TValue>.CachePtr, (nuint)(Marshal.SizeOf<TValue>() * cache.ReallocCount * 128));
                }
            }
            // finish up.
            *(ComponentCacheHelper<TValue>.CachePtr + container.Count) = input;
            cache.ReallocCount += 2;
            cache.Count++;
            return cache.Count -1;
        }
    }
}
