// See https://aka.ms/new-console-template for more information

namespace BonesOfTheFallen.Services
{
    public interface ICheckSystem : IGameSystem
    {
        public void ProcessEntity(float deltaTime, int entity);
    }
}