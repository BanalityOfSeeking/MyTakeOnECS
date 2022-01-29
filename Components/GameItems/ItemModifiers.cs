using DotNext;
using System;

namespace BonesOfTheFallen.GameItems
{
    public record struct ItemModifiers
    {
        public bool Consumable = false;

        public ItemModifiers(
            bool consumable,
            Optional<Range> heal,
            Optional<Range> range,
            Optional<Range> attackDmg,
            Optional<Range> magicDmg,
            Optional<int> defense,
            Optional<int> magicDefense,
            Optional<int> damageResist,
            Optional<int> magicResist)
        {
            Consumable=consumable;
            Heal=heal;
            Range=range;
            AttackDmg=attackDmg;
            MagicDmg=magicDmg;
            Armor=defense;
            MagicDefense=magicDefense;
            DamageResist=damageResist;
            MagicResist=magicResist;
        }

        // item heals.
        public Optional<Range> Heal { get; init; }
        // item has Range
        public Optional<Range> Range { get;}
        // increase base dmg.
        public Optional<Range> AttackDmg { get; init; } 
        public Optional<Range> MagicDmg { get; init; }
        // decrease damage taken
        public Optional<int> Armor { get; init; }
        public Optional<int> MagicDefense { get; init; }
        // increase ability to resist damage.
        public Optional<int> DamageResist { get; init; }
        public Optional<int> MagicResist { get; init; }

    }
}