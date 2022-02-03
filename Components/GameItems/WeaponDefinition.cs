using DotNext;
using System;

namespace BonesOfTheFallen.GameItems
{
    public record struct WeaponDefinition
    {
        public WeaponDefinition(
            Optional<Range> range,
            Optional<Range> attackDmg,
            Optional<Range> magicDmg)
        {
            Range=range;
            AttackDmg=attackDmg;
            MagicDmg=magicDmg;
        }

        // item has Range
        public Optional<Range> Range { get; }
        // increase base dmg.
        public Optional<Range> AttackDmg { get; init; }
        public Optional<Range> MagicDmg { get; init; }
    }
}