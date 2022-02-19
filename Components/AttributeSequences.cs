using System;

namespace BonesOfTheFallen.Services
{
    public ref struct ArmorSequences<T> where T : INumber<T>
    {
        internal GameSequenceSegment<T> DamageResistChance = new(Range.EndAt(20));
        internal GameSequenceSegment<T> Defense = new(Range.EndAt(100));
        internal GameSequenceSegment<T> MagicDefense = new(Range.EndAt(50));
        internal GameSequenceSegment<T> MagicResistPercent = new(Range.EndAt(10));

        public ArmorSequences()
        {
        }
    }
    public ref struct AttributeSequences<T> where T : INumber<T>
    { 
        internal GameSequenceSegment<T> Charisma = new(Range.EndAt(25));
        internal GameSequenceSegment<T> Constitution = new(Range.EndAt(25));
        internal GameSequenceSegment<T> Dexterity = new(Range.EndAt(25));
        internal GameSequenceSegment<T> Intelligence = new(Range.EndAt(25));
        internal GameSequenceSegment<T> Strength = new(Range.EndAt(25));
        internal GameSequenceSegment<T> Wisdom = new(Range.EndAt(25));

        public AttributeSequences()
        {
        }
    }
}


