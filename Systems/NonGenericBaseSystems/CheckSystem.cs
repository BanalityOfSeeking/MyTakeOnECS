// See https://aka.ms/new-console-template for more information

namespace BonesOfTheFallen.Services
{
    public abstract record CheckSystem : SystemBase, ICheckSystem
    {
        protected CheckSystem()
        {
        }

        protected CheckSystem(SystemBase original) : base(original)
        {
        }

        public abstract override void ProcessEntity(float deltaTime, int entity);
    }
}