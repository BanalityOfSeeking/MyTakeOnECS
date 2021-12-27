// See https://aka.ms/new-console-template for more information

namespace BonesOfTheFallen.Services
{
    public abstract record CheckSystem<T> : CheckSystem, ICheckSystem where T : unmanaged, IComponentBase
    {
        public CheckSystem(): base()
        {
            // Retrieve mask for T
            TypeMask |= WorldManager.AddMask<T>();
        }
        protected abstract bool CheckRoutine(ref T T1);

        public override void ProcessEntity(float deltaTime, int entity)
        {
            ref T t1Ref = ref StoragePool.Get<T>(entity);

            if(CheckRoutine(ref t1Ref))           
            {
                ProcessEntity(deltaTime, ref t1Ref);
            }
        }

        public abstract void ProcessEntity(float deltaTime, ref T t1Ref);
    }
}
