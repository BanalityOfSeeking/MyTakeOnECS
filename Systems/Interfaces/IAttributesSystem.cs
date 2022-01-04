using Microsoft.Toolkit.HighPerformance;

namespace BonesOfTheFallen.Services
{
    public interface IAttributesSystem
    {
        IComponentBase<AttributeEnum> Component { get; }

        bool Equals(AttributesSystem? other);
        bool Equals(object? obj);
        bool Equals(SystemBase? other);
        int GetHashCode();
        Ref<int> GetPropertyRef(AttributeEnum attributeId);
        void Process(in float time);
        string ToString();
    }
}