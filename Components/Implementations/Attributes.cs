using Microsoft.Toolkit.HighPerformance.Helpers;
using System;

namespace BonesOfTheFallen.Services
{
    public readonly struct AttributesModifier : IEquatable<AttributesModifier>
    {
        public AttributesModifier(AttributeEnum attributeId, int modifier)
        {
            AttributeId=attributeId;
            Modifier=modifier;
        }

        public AttributeEnum AttributeId { get; }
        public int Modifier { get; } = 0;

        public override bool Equals(object? obj)
        {
            return obj is AttributesModifier modifier&&Equals(modifier);
        }

        public bool Equals(AttributesModifier other)
        {
            return AttributeId==other.AttributeId&&
                   Modifier==other.Modifier;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AttributeId, Modifier);
        }

        public static bool operator ==(AttributesModifier left, AttributesModifier right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AttributesModifier left, AttributesModifier right)
        {
            return !(left==right);
        }
    }
    public record struct Attributes : IComponentBase<AttributeEnum>, IEquatable<Attributes>
    {
        public bool IsPayer { get; }
        public Attributes(bool isPayer = false)
        {
            IsPayer=isPayer;
        }
        public int Charisma = -1;
        public int Constitution = -1;
        public int Dexterity = -1;
        public int Expierence = -1;
        public int Health = -1;
        public int Inteligence = -1;
        public int Level = -1;
        public int Mana = -1;
        public int Strength = -1;
        public int Wisdom = -1;
        public override int GetHashCode()
        {
            return HashCode<Attributes>.Combine(new[] { this });
        }
    }
}
