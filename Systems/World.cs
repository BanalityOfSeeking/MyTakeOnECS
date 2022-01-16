using Microsoft.Toolkit.HighPerformance.Helpers;
using System.Threading;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    ///  Currently for EntityUnsafe's id is created in World and passed in the constructor.
    ///  I reverse this methodology for Entity Safe.
    /// </summary>
    /// Only integration point for unsafe and safe implementations.
    /// Idea: thread each implementaion, and benchmark, 
    /// and search for area(s) where each implemation can be improved.
    public static class World
    {
        internal static int EntitySafeId = 0;

        internal static int EntityUnsafeId = 0;
        
        public static readonly EntitySafeSparseSet EntityComponentManagerSafe = new(1024);

        public static readonly EntityUnsafeSparseSet EntityComponentManagerUnsafe = new(1024);

        public static class ComponentSystemsSafe<T> where T : struct, IRefAction<T>
        {

            private static readonly SystemForSafe<T> SystemSafe = new();
            public static SystemForSafe<T> GetSystem() => SystemSafe;
        }
        public static unsafe class ComponentSystemsUnsafe<TValue> where TValue : unmanaged
        {
            private static readonly SystemForUnsafe<TValue> System = new();
            public static SystemForUnsafe<TValue> GetSystem() => System;

            internal static ComponentCacheUnsafe<TValue> CacheContainer = new();
        }
    }
}
