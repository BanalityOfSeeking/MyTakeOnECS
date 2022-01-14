using Microsoft.Toolkit.HighPerformance.Helpers;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BonesOfTheFallen.Services
{
    public sealed unsafe class SystemFor<T> where T : unmanaged
    {

        public SystemFor<T> TransitionInPlaceUnsafe<PStruct>(PStruct @struct) where PStruct : struct, IRefAction<T>
        {
            var cache = ComponentSystems<T>.GetCache();
            var container = ComponentSystems<T>.CacheContainer;

            T* TCache = cache;
            var TLen = 0;
            while (TLen++ < container.Count - 1)
            {
                @struct.Invoke(ref *TCache);
                TCache += TLen;
            }
            return this;
        }
    }
}
