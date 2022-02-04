﻿namespace BonesOfTheFallen.Services.Components.GameItems;

public readonly ref struct Armor
{
    public Armor(ArmorDescription description, ArmorType type)
    {
        Defense = description switch
        {
            ArmorDescription.None => 0,
            ArmorDescription.ChainMail => 3,
            ArmorDescription.Leather => 1,
            ArmorDescription.Padded => 1,
            ArmorDescription.PaddedLeather => 2,
            ArmorDescription.PlateMail => 4,
            ArmorDescription.StuddedLeather => 3,
            _ => throw new System.NotImplementedException(),
        } + type switch
        {
            ArmorType.None => 0,
            ArmorType.Gloves => 1,
            ArmorType.Pants => 3,
            ArmorType.Robe => 2,
            ArmorType.Shield => 2,
            ArmorType.Shirt => 3,
            ArmorType.Shoes => 1,
            _ => throw new System.NotImplementedException(),
        };
        MagicDefense = Defense / 2;
        DamageResist = Defense / 10;
        MagicResist = MagicDefense / 10;
    }
    public readonly int Defense;
    public readonly int MagicDefense;
    public readonly int DamageResist;
    public readonly int MagicResist;
}
