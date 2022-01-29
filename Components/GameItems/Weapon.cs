using System;

namespace BonesOfTheFallen.GameItems
{
    public record struct WeaponItem
    {
        public WeaponItem(ItemDefinition definition)
        {
            WeaponId=definition.Item.GetHashCode() + definition.ItemDescription.GetHashCode() + definition.Modifiers.GetHashCode();
            Range=definition.Modifiers.Range.IsNull ? Range.EndAt(0) : definition.Modifiers.Range.Value;
            Damage=definition.Modifiers.AttackDmg.IsNull ? Range.EndAt(0) : definition.Modifiers.AttackDmg.Value;
            MagicDamage= definition.Modifiers.MagicDmg.IsNull ? Range.EndAt(0) : definition.Modifiers.MagicDmg.Value;
        }

        public int WeaponId {get; init;}
        public Range Range { get; init; }
        public Range Damage { get; init; }
        public Range MagicDamage { get; init; }
    }
}