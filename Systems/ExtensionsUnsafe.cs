using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Extensions class for EntityUnsafe and writing to the cache pointer.
    /// its faster, but error prone currently.
    /// </summary>
    public static class ExtensionsUnsafe
    {
        /// <summary>
        /// Adds component to entity component lookups, writes cache, etc..
        /// basically just checking everything is in order and perform the right operation for the situation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="input"></param>
        /// <exception cref="Exception"></exception>
        public static unsafe void AddComponentUnsafe<T>(this EntityUnsafe entity, T input) where T : unmanaged
        {
            // get dictionary to prevent constant repeated calls..
            var ecl = World.EntityComponentlookupUnsafe;
            if (ecl.ContainsKey(entity))
            {
                Dictionary<Type, int> lookup = ecl[entity];
                if (!lookup.ContainsKey(typeof(T)))
                {
                    lookup.Add(typeof(T), ComponentSystemsUnsafe<T>.CacheContainer.WriteCacheUnsafe(input));
                }
                else
                {
                    throw new Exception("Component already exists");
                }
            }
            else
            {
                T* tcp = ComponentCacheHelperUnsafe<T>.CachePtr;
            }
        }
        /// <summary>
        /// Gets a component that is associated with an entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="component"></param>
        /// <returns></returns>
        public static unsafe bool GetComponent<T>(this EntityUnsafe entity, out T component) where T : unmanaged
        {
            var ecl = World.EntityComponentlookupUnsafe;
            if (ecl.ContainsKey(entity))
            {
                if (ecl[entity].ContainsKey(typeof(T)))
                {
#if DEBUG // check key
                    var key = ecl[entity][typeof(T)];
#endif
                    var cache = ComponentCacheHelperUnsafe<T>.CachePtr;
                    component =  *(cache + ecl[entity][typeof(T)]);
                    return true;
                }
            }
            component = default;
            return false;
        }
        /// <summary>
        /// Writes to a pointer, ensures no stack buffer overflow (0xc0000409)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static unsafe int WriteCacheUnsafe<T>(this ref ComponentCacheUnsafe<T> cache, T input) where T : unmanaged
        {
            var container = ComponentSystemsUnsafe<T>.CacheContainer;
            // if cache count less than 64 use write to it, they are preallocated.
            if (cache.Count < (cache.ReallocCount > 0 ? cache.ReallocCount : 1) * 64)
            {
                *(ComponentCacheHelperUnsafe<T>.CachePtr + cache.Count) = input;
                cache.Count++;
                return cache.Count - 1;
            }
            // count is higher..
            else
            {
                // check reallocation count is 0, if so double the size of buffer.
                if (cache.ReallocCount == 0)
                {
                    ComponentCacheHelperUnsafe<T>.CachePtr = (T*)NativeMemory.Realloc(ComponentCacheHelperUnsafe<T>.CachePtr, (nuint)(Marshal.SizeOf<T>() * 128));

                }
                // more than 0
                else
                {
                    // sizeof struct * realloccount (2,4,6,8 etc) * 128 first pass 256, next 512, etc..
                    ComponentCacheHelperUnsafe<T>.CachePtr = (T*)NativeMemory.Realloc(ComponentCacheHelperUnsafe<T>.CachePtr, (nuint)(Marshal.SizeOf<T>() * cache.ReallocCount * 128));
                }
            }
            // finish up.
            *(ComponentCacheHelperUnsafe<T>.CachePtr + container.Count) = input;
            cache.ReallocCount += 2;
            cache.Count++;
            return cache.Count -1;
        }
    }
}
