namespace BonesOfTheFallen.Services
{
    public interface IVelocitySystem
    {
        bool Equals(object? obj);
        bool Equals(SystemBase? other);
        bool Equals(VelocitySystem? other);
        int GetHashCode();
        void Process(in float time);
        string ToString();
    }
}