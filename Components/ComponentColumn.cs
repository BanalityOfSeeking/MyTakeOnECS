using System.Runtime.CompilerServices;
using Microsoft.Toolkit.HighPerformance;
using System;
using System.Buffers;

namespace BonesOfTheFallen.Services
{
    public class ComponentColumn<T> : IComponentColumn where T : struct, IComponentBase
    {
        internal int Max = 0;
        public int NumberOfActiveComponents { get; private set; } = 0;
        public IComponentBase[] AllocatedComponents = default!;
        public ComponentColumn(int _max)
        {
            Max = _max;
            AllocatedComponents = new IComponentBase[Max];
        }
        private static T GetTypedItem() => Activator.CreateInstance<T>();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IComponentColumn AddComponents(ref EntitySafe[] entities, out bool success)
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
        public IComponentColumn AddComponent(ref EntitySafe entity, out bool succeess)
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
        public IComponentColumn GetComponent<U>(ref EntitySafe entity, out U t, out bool success) where U : struct, IComponentBase
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
        public unsafe IComponentColumn GetEntityComponent<U>(ref EntitySafe entity, out Ref<U> @ref) where U : struct, IComponentBase
        {
            @ref = new Ref<U>(Unsafe.AsPointer(ref AllocatedComponents![entity]));
            return this;
        }

        public ReadOnlySequence<IComponentBase> GetActiveComponents()
        {
            return new ReadOnlySequence<IComponentBase>(AllocatedComponents, 0, NumberOfActiveComponents);
        }
    }
}