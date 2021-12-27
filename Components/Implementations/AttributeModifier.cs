using System;

namespace BonesOfTheFallen.Services
{
    public readonly struct AttributeModifier : IEquatable<AttributeModifier>
    {
        public readonly int Entity;
        public readonly AttributeEnum Attribute;
        public readonly byte Modifier;

        public AttributeModifier(int entity, AttributeEnum attribute, byte modifier)
        {
            Entity=entity;
            Attribute=attribute;
            Modifier=modifier;
        }

        public override bool Equals(object? obj)
        {
            return obj is AttributeModifier modifier&&Equals(modifier);
        }

        public bool Equals(AttributeModifier other)
        {
            return Entity==other.Entity&&
                   Attribute==other.Attribute&&
                   Modifier==other.Modifier;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Entity, Attribute, Modifier);
        }

        public static bool operator ==(AttributeModifier left, AttributeModifier right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AttributeModifier left, AttributeModifier right)
        {
            return !(left==right);
        }
    }
}
