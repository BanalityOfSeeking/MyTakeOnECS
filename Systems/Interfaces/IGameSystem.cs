// See https://aka.ms/new-console-template for more information

namespace BonesOfTheFallen.Services
{
    public interface IGameSystem
    {
        int GetHashCode();
        int GetTypeMask();
        void Process(float deltaTime);
        void TrackNewEntity(int entity);
    }
}