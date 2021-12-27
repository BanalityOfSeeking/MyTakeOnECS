// See https://aka.ms/new-console-template for more information

namespace BonesOfTheFallen.Services
{
    public abstract record UpdateSystem<T> : UpdateSystem where T : unmanaged, IComponentBase
    {
        public UpdateSystem() : base()
        {
            // Retrieve mask
            TypeMask = WorldManager.AddMask<T>();   
        }
        public override void ProcessEntity(float deltaTime, int entity)
        {
            ProcessEntity(deltaTime, ref StoragePool.Get<T>(entity));
        }
        public abstract void ProcessEntity(float deltaTime, ref T entity);
    }
}