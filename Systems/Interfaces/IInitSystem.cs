namespace BonesOfTheFallen.Services
{
    public interface IInitSystem<T>
    {
        void Init(ref T t1Ref);
    }
}