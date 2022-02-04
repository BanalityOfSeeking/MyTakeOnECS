using System;

namespace BonesOfTheFallen.Services.Components.GameItems;

public readonly struct Weapon
{
    public Weapon(WeaponDescription description, WeaponType type)
    {

    }
    public readonly Range Range;
    public readonly Range Damage;
    public readonly Range MagicDamage;
}
