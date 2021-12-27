// See https://aka.ms/new-console-template for more information

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Process 1 component for entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract record GenericBaseSystems<T> : SystemBase where T : unmanaged, IComponentBase
    {
        public GenericBaseSystems() : base()
        {
            // Retrieve mask for T
            TypeMask |= WorldManager.AddMask<T>();
        }
        // called from SystemBase.Process
        // calls user supplied override for 
        // ProcessEntity that is required in a derived class
        public override void ProcessEntity(float deltaTime, int entity)
        {
            ProcessEntity(deltaTime, ref StoragePool.Get<T>(entity));
        }

        protected abstract void ProcessEntity(float deltaTime, ref T t1Ref);
    }
    // process 1 entity with 2 components
    public abstract record GenericBaseSystems<T1, T2> : SystemBase where T1 : unmanaged, IComponentBase
    where T2 : unmanaged, IComponentBase
    {
        public GenericBaseSystems() : base()
        {
            TypeMask |= WorldManager.AddMask<T1>();
            TypeMask |= WorldManager.AddMask<T2>();
        }

        public override void ProcessEntity(float deltaTime, int entity)
        {
            ProcessEntity(deltaTime,
                ref StoragePool.Get<T1>(entity),
                ref StoragePool.Get<T2>(entity)
                );
        }

        public abstract void ProcessEntity(float deltaTime, ref T1 t1Ref, ref T2 t2Ref);

    }
    public abstract record GenericBaseSystems<T1, T2, T3> : SystemBase 
        where T1 : unmanaged, IComponentBase
        where T2 : unmanaged, IComponentBase
        where T3 : unmanaged, IComponentBase
    {
        public GenericBaseSystems() : base()
        {
            TypeMask |= WorldManager.AddMask<T1>();
            TypeMask |= WorldManager.AddMask<T2>();
            TypeMask |= WorldManager.AddMask<T2>();
        }

        public override void ProcessEntity(float _, int entity)
        {
            ProcessEntity(
                ref StoragePool.Get<T1>(entity),
                ref StoragePool.Get<T2>(entity),
                ref StoragePool.Get<T3>(entity)
                );
        }

        public abstract void ProcessEntity(ref T1 t1Ref, ref T2 t2Ref, ref T3 t3Ref);

    }
}