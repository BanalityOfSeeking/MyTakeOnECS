// See https://aka.ms/new-console-template for more information

namespace BonesOfTheFallen.Services
{
    public abstract record CrossEntitySystems<T> : SystemBase where T : unmanaged, IComponentBase
    {

        public CrossEntitySystems(int entity1, int entity2)
        {
            TypeMask |= WorldManager.AddMask<T>();
            TrackNewEntity(entity1);
            TrackNewEntity(entity2);
        }
        public override void Process(float deltaTime)
        {
            for (int i = 0; i < Entities.Length; i += 2)
            {
                var Comp1 = StoragePool.Get<T>(Entities[i]);
                var Comp2 = StoragePool.Get<T>(Entities[i + 1]);
                ProcessEntities(deltaTime, Comp1, Comp2);
            }
        }
        public abstract void ProcessEntities(float deltaTime, T t1Ref,T t2Ref);
    }

    public abstract record XSystem<T1, T2> : SystemBase
        where T1 : unmanaged, IComponentBase
        where T2 : unmanaged, IComponentBase
    {

        public XSystem(int entity1, int entity2)
        {
            TypeMask |= WorldManager.AddMask<T1>();
            TypeMask |= WorldManager.AddMask<T2>();
            TrackNewEntity(entity1);
            TrackNewEntity(entity2);
        }
        public override void Process(float deltaTime)
        {
            for (int i = 0; i < Entities.Length; i += 2)
            {
                ref var Ent1_Comp1 = ref StoragePool.Get<T1>(Entities[i]);
                ref var Ent1_Comp2 = ref StoragePool.Get<T2>(Entities[i]);
                ref var Ent2_Comp1 = ref StoragePool.Get<T1>(Entities[i + 1]);
                ref var Ent2_Comp2 = ref StoragePool.Get<T2>(Entities[i + 1]);
                ProcessEntities(deltaTime, ref Ent1_Comp1, ref Ent1_Comp2, ref Ent2_Comp1, ref Ent2_Comp2);
            }
        }
        public abstract void ProcessEntities(float deltaTime, ref T1 Ent1_t1Ref, ref T2 Ent1_t2Ref, ref T1 Ent2_t1Ref, ref T2 Ent2_t2Ref);
    }
}