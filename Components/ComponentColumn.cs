using System.Runtime.CompilerServices;
using Microsoft.Toolkit.HighPerformance;
using System;

namespace BonesOfTheFallen.Services
{
    public class ComponentColumn<T> : IComponentColumn where T : IComponentBase
    {
        // Max number of components
        internal int Max = 0;
        
        public int NumberOfActiveComponents { get; private set; } = 0;
        // storage
        public IComponentBase[] AllocatedComponents = default!;
        public ComponentColumn(int _max)
        {
            Max = _max;
            AllocatedComponents = new IComponentBase[Max];
        }
        // use activator to create type using paramterless constructor!!!!
        private static T GetTypedItem() => Activator.CreateInstance<T>();
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IComponentColumn AddComponentsToEntities(ref EntitySafe[] entities, out bool success)
        {
            if (NumberOfActiveComponents + entities.Length < Max)
            {
                for (int i = 0; i < entities.Length; i++)
                {
                    T item = GetTypedItem();
                    AllocatedComponents[entities[i]] = item;
                    NumberOfActiveComponents++;
                }
                success = true;
                return this;
            }
            success = false;
            return this;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IComponentColumn AddComponentToEntity(ref EntitySafe entity, out bool succeess)
        {
            if (NumberOfActiveComponents + 1 < Max)
            {
                AllocatedComponents[entity] = GetTypedItem();
                NumberOfActiveComponents++;
                succeess = true;
                return this;
            }
            succeess = false;
            return this;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IComponentColumn GetComponentForEntity<U>(ref EntitySafe entity, out U t, out bool success) where U : IComponentBase
        {
            if (AllocatedComponents[entity] is U ts)
            {
                t = ts;
                success = false;
                return this;
            }
            else
            {
                // return component
                t = (U)AllocatedComponents[entity];
                success = true;
                return this;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IComponentColumn RemoveEntityComponents(ref EntitySafe entity)
        {
            AllocatedComponents![entity] = default!; // remove the array
            return this;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IComponentColumn Clear()
        {
            AllocatedComponents = new IComponentBase[Max];
            return this;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe IComponentColumn GetEntityComponent<U>(ref EntitySafe entity, out Ref<U> @ref) where U : IComponentBase
        {
            @ref = new Ref<U>(Unsafe.AsPointer(ref AllocatedComponents![entity]));
            return this;
        }
        public T define = default!;
        private int ActiveCalls = -1;
        public unsafe void GetActiveComponents<U>(out Ref<U> @ref) where U : IComponentBase
        {
            ActiveCalls = ActiveCalls + 1 <= NumberOfActiveComponents ? ActiveCalls + 1 : -1;
            if (ActiveCalls!= -1)
            {
                @ref = new Ref<U>(ref Unsafe.AsRef<U>(Unsafe.AsPointer(ref AllocatedComponents[ActiveCalls])));
            }
            else
            {
                @ref = default!;
            }
        }
    }
}