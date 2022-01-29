using DotNext;

namespace BonesOfTheFallen.GameItems
{
    public record struct ShieldOrWeapon
    {
        public readonly Optional<WeaponItem> Weapon;
        public readonly Optional<ArmorItem> Shield;

        public ShieldOrWeapon(Optional<WeaponItem> weapon, Optional<ArmorItem> shield)
        {
            Weapon=weapon;
            Shield=shield;
        }
    }
}