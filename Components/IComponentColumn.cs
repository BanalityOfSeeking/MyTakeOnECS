using Microsoft.Toolkit.HighPerformance;

namespace BonesOfTheFallen.Services
{
    public interface IComponentColumn
    {
        int NumberOfActiveComponents { get; }
        IComponentColumn AddComponentToEntity(ref EntitySafe entity, out bool success);
        IComponentColumn AddComponentsToEntities(ref EntitySafe[] entities, out bool success);
        IComponentColumn Clear();
        IComponentColumn GetComponentForEntity<T>(ref EntitySafe entity, out T t, out bool success) where T : IComponentBase;
        void GetActiveComponents<U>(out Ref<U> @ref) where U : IComponentBase;
        IComponentColumn GetEntityComponent<T>(ref EntitySafe entity, out Ref<T> @ref) where T : IComponentBase;
        IComponentColumn RemoveEntityComponents(ref EntitySafe entity);

    }
}