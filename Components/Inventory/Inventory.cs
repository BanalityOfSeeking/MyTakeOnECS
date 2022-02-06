using BonesOfTheFallen.Services.Components.Currency;
using DotNext;
using System;

namespace BonesOfTheFallen.Services.Components.GameItems;

public record struct Inventory
{
    public IEquipedWeapon? Weapon;
    public IEquipedWeaponOrShield? WeaponOrShield;
    public Optional<int> HeadDefense;

    public Optional<int> ChestDefense;
    public Optional<int> ArmsDefense;
    public Optional<int> LegsDefense;
    public Optional<int> ShoesDefense;

    public int TotalDefense()
    {
        int ret = HeadDefense.IsNull ? 0 : HeadDefense.Value;
        ret += ArmsDefense.IsNull ? 0 : ArmsDefense.Value;
        ret += ChestDefense.IsNull ? 0 : ChestDefense.Value;
        ret += LegsDefense.IsNull ? 0 : LegsDefense.Value;
        return ret += ShoesDefense.IsNull ? 0 : ShoesDefense.Value;
    }
    private readonly CurrencyBag CoinBag = new();

}

public interface IEquipedWeaponOrShield
{
    bool IsShield { get; }
    int ShieldDefense { get; }
    int WeaponDamage { get; }
    public bool Defend();
    public bool Attack();

}

public interface IEquipedWeapon
{
    public bool Attack();
}