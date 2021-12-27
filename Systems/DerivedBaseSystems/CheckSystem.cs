// See https://aka.ms/new-console-template for more information

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Checks if a component meets a condition.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract record CheckSystem<T> : CheckSystem, ICheckSystem where T : unmanaged, IComponentBase
    {
        public CheckSystem(): base()
        {
            TypeMask |= WorldManager.AddMask<T>();
        }


        /// <summary>
        /// Performs Check routine on component for entity
        /// </summary>
        /// <param name="deltaTime"></param>
        /// <param name="entity"></param>
        public override void ProcessEntity(float deltaTime, int entity)
        {
            ref T t1Ref = ref StoragePool.Get<T>(entity);

            if(CheckRoutine(ref t1Ref))           
            {
                ProcessEntity(deltaTime, ref t1Ref);
            }
        }
        /// <summary>
        /// Performs action if that component meets condition,
        /// method is provided in derrived records.
        /// </summary>
        /// <param name="deltaTime"></param>
        /// <param name="t1Ref"></param>
        public abstract void ProcessEntity(float deltaTime, ref T t1Ref);
        /// <summary>
        /// Performs check on component, method is provided in derrived records.
        /// </summary>
        /// <param name="T1"></param>
        /// <returns>if condition was met true/false</returns>
        public abstract bool CheckRoutine(ref T T1);
    }
}
