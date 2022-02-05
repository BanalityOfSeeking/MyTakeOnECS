using System;

namespace BonesOfTheFallen.Services.Components.GameItems;

public readonly ref struct Weapon
{
    public Weapon(PreambleWeapon preamble, WeaponType type, MagicWeaponDescription bonusType, MagicWeaponBonus bonus)
    {

        WeaponRange = type switch
        {
            WeaponType.Bow => new Range(0, 6),
            WeaponType.CrossBow => new Range(0, 5),
            WeaponType.Dagger => new Range(0, 1),
            WeaponType.Hammer => new Range(0, 3),
            WeaponType.LongSword => new Range(0, 4),
            WeaponType.Mace => new Range(0, 3),
            WeaponType.Rod => new Range(0, 2),
            WeaponType.ShortSword => new Range(0, 2),
            WeaponType.Staff => new Range(0, 2),
            WeaponType.Sword => new Range(0, 3),
            _ => throw new NotImplementedException(),
        };
        Damage = type switch
        {
            WeaponType.Bow => new Range(3, 5),
            WeaponType.CrossBow => new Range(4, 6),
            WeaponType.Dagger => new Range(1, 2),
            WeaponType.Hammer => new Range(2, 5),
            WeaponType.LongSword => new Range(5, 8),
            WeaponType.Mace => new Range(2, 5),
            WeaponType.Rod => new Range(2, 3),
            WeaponType.ShortSword => new Range(2, 4),
            WeaponType.Staff => new Range(3, 5),
            WeaponType.Sword => new Range(4, 6),
            _ => throw new NotImplementedException(),
        };
        if (preamble == PreambleWeapon.Magic)
        {
            MagicDamage = new Range((int)bonus, (int)bonus);
        }
        else
        {
            MagicDamage = default!;
        }
    }
    public readonly Range WeaponRange;
    public readonly Range Damage;
    public readonly Range MagicDamage;
}