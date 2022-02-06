using System;

namespace BonesOfTheFallen.Services.Components.GameItems;

public readonly ref struct Weapon
{
    public Weapon(PreambleWeapon preamble, Weapons type, MagicWeaponDescription bonusType = MagicWeaponDescription.None, MagicWeaponBonus bonus = MagicWeaponBonus.Zero)
    {

        WeaponRange = type switch
        {
            Weapons.Bow => new Range(0, 6),
            Weapons.CrossBow => new Range(0, 5),
            Weapons.Dagger => new Range(0, 1),
            Weapons.Hammer => new Range(0, 3),
            Weapons.LongSword => new Range(0, 4),
            Weapons.Mace => new Range(0, 3),
            Weapons.Rod => new Range(0, 2),
            Weapons.ShortSword => new Range(0, 2),
            Weapons.Staff => new Range(0, 2),
            Weapons.Sword => new Range(0, 3),
            _ => throw new NotImplementedException(),
        };
        Damage = type switch
        {
            Weapons.Bow => new Range(3, 5),
            Weapons.CrossBow => new Range(4, 6),
            Weapons.Dagger => new Range(1, 2),
            Weapons.Hammer => new Range(2, 5),
            Weapons.LongSword => new Range(5, 8),
            Weapons.Mace => new Range(2, 5),
            Weapons.Rod => new Range(2, 3),
            Weapons.ShortSword => new Range(2, 4),
            Weapons.Staff => new Range(3, 5),
            Weapons.Sword => new Range(4, 6),
            _ => throw new NotImplementedException(),
        };
        if (preamble == PreambleWeapon.Magic)
        {
            if (bonusType == MagicWeaponDescription.Plus)
            {
                MagicDamage = new Range((int)bonus, (int)bonus);
            }
            else if (bonusType == MagicWeaponDescription.Minus)
            {
                MagicDamage = new Range(-(int)bonus, -(int)bonus);
            }
            else
            {
                MagicDamage = default!;
            }
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