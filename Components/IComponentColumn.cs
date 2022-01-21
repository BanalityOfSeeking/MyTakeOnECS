using Microsoft.Toolkit.HighPerformance;
using System.Buffers;

namespace BonesOfTheFallen.Services
{
    public interface IComponentColumn
    {
        int NumberOfActiveComponents { get; }
        IComponentColumn AddComponent(ref EntitySafe entity, out bool success);
        IComponentColumn AddComponents(ref EntitySafe[] entities, out bool success);
        IComponentColumn Clear();
        IComponentColumn GetComponent<T>(ref EntitySafe entity, out T t, out bool success) where T : struct, IComponentBase;
        ReadOnlySequence<IComponentBase> GetActiveComponents();
        IComponentColumn GetEntityComponent<T>(ref EntitySafe entity, out Ref<T> @ref) where T : struct, IComponentBase;
        IComponentColumn RemoveEntityComponents(ref EntitySafe entity);

    }
}