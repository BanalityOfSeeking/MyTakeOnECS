﻿using System;

namespace BonesOfTheFallen.Services.Components.GameItems;

public readonly ref struct Weapon
{
    public Weapon(WeaponDefinition definition)
    {

        Range=definition.Range.IsNull ? Range.EndAt(0) : definition.Range.Value;
        Damage=definition.AttackDmg.IsNull ? Range.EndAt(0) : definition.AttackDmg.Value;
        MagicDamage= definition.MagicDmg.IsNull ? Range.EndAt(0) : definition.MagicDmg.Value;
    }

    public Range Range { get; init; }
    public Range Damage { get; init; }
    public Range MagicDamage { get; init; }
}
