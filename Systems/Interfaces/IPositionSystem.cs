namespace BonesOfTheFallen.Services
{
    public interface IPositionSystem
    {
        IComponentBase<PositionEnum> Component { get; }

        bool Equals(object? obj);
        bool Equals(PositionSystem? other);
        bool Equals(SystemBase? other);
        int GetHashCode();
        void Process(in float time);
        void ProcessModifier(Position item);
        string ToString();
    }
}