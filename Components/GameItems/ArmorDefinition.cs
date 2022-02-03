using DotNext;

namespace BonesOfTheFallen.GameItems
{
    public record struct ArmorDefinition
    {
        public ArmorDefinition(
            Optional<int> defense,
            Optional<int> damageResist,
            Optional<int> magicDefense,
            Optional<int> magicResist)
        {

            PhysicalDefense=defense;
            MagicDefense=magicDefense;
            DamageResist=damageResist;
            MagicResist=magicResist;
        }

        // decrease damage taken
        public Optional<int> PhysicalDefense { get; init; }
        public Optional<int> MagicDefense { get; init; }
        // increase ability to resist damage.
        public Optional<int> DamageResist { get; init; }
        public Optional<int> MagicResist { get; init; }

    }
}