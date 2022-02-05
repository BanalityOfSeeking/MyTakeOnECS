using BonesOfTheFallen.Services.Components.Currency;
using DotNext;
using System;

namespace BonesOfTheFallen.Services.Components.GameItems;

public record struct Inventory
{
    public Optional<Range> MainRange;
    public Optional<Range> MainDamage;
    public Optional<Range> MainMagicDamage;
    public Optional<Range> SecondaryRange;
    public Optional<Range> SecondaryDamage;
    public Optional<Range> SecondaryMagicDamage;
    public Optional<int> HeadDefense;
    public Optional<int> HeadMagicDefense;
    public Optional<int> HeadDamageResist;
    public Optional<int> HeadMagicResist;
    public Optional<int> ChestDefense;
    public Optional<int> ChestMagicDefense;
    public Optional<int> ChestDamageResist;
    public Optional<int> ChestMagicResist;
    public Optional<int> ArmsDefense;
    public Optional<int> ArmsMagicDefense;
    public Optional<int> ArmsDamageResist;
    public Optional<int> ArmsMagicResist;
    public Optional<int> LegsDefense;
    public Optional<int> LegsMagicDefense;
    public Optional<int> LegsDamageResist;
    public Optional<int> LegsMagicResist;
    public Optional<int> ShoesDefense;
    public Optional<int> ShoesMagicDefense;
    public Optional<int> ShoesDamageResist;
    public Optional<int> ShoesMagicResist;

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
