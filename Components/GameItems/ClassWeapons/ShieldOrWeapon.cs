using BonesOfTheFallen.GameItems;

namespace BonesOfTheFallen.Services.Components.GameItems;

public ref struct ShieldOrWeapon
{
    public readonly Weapon Weapon;
    public readonly ArmorItem Shield;

    public ShieldOrWeapon(Weapon weapon, ArmorItem shield)
    {
        Weapon=weapon;
        Shield=shield;
    }
}
