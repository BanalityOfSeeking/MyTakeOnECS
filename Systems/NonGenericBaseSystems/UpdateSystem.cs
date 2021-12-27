// See https://aka.ms/new-console-template for more information

namespace BonesOfTheFallen.Services
{
    public abstract record UpdateSystem : SystemBase, IUpdateSystem
    {
        protected UpdateSystem()
        {
        }

        protected UpdateSystem(SystemBase original) : base(original)
        {
        }

        public abstract override void ProcessEntity(float deltaTime, int entity);
    }
}