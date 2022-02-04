using BonesOfTheFallen.GameItems;

namespace BonesOfTheFallen.Services.Components.GameItems;

public ref struct ShieldOrWeapon
{
    public readonly WeaponItem Weapon;
    public readonly ArmorItem Shield;

    public ShieldOrWeapon(WeaponItem weapon, ArmorItem shield)
    {
        Weapon=weapon;
        Shield=shield;
    }
}
