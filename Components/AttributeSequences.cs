using System;

namespace BonesOfTheFallen.Services
{
    public ref struct ArmorSequences<T, TResult> 
        where T : INumber<T>
        where TResult : IParseable<TResult>
    {
        internal GameSequenceSegment<T, TResult> DamageResistChance = new(Range.EndAt(20));
        internal GameSequenceSegment<T, TResult> Defense = new(Range.EndAt(100));
        internal GameSequenceSegment<T, TResult> MagicDefense = new(Range.EndAt(50));
        internal GameSequenceSegment<T, TResult> MagicResistPercent = new(Range.EndAt(10));

        public ArmorSequences()
        {
        }
    }
    public ref struct AttributeSequences<T, TResult> 
        where T : INumber<T>
        where TResult : IParseable<TResult>
    { 
        internal GameSequenceSegment<T, TResult> Charisma = new(Range.EndAt(25));
        internal GameSequenceSegment<T, TResult> Constitution = new(Range.EndAt(25));
        internal GameSequenceSegment<T, TResult> Dexterity = new(Range.EndAt(25));
        internal GameSequenceSegment<T, TResult> Intelligence = new(Range.EndAt(25));
        internal GameSequenceSegment<T, TResult> Strength = new(Range.EndAt(25));
        internal GameSequenceSegment<T, TResult> Wisdom = new(Range.EndAt(25));

        public AttributeSequences()
        {
        }
    }
}


