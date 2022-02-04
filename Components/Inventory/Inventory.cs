using BonesOfTheFallen.Services.Components.Currency;
using DotNext;

namespace BonesOfTheFallen.Services.Components.GameItems;

public record struct Inventory
{
    public readonly Optional<WeaponDefinition> Main { get; init; } = default!;
    public readonly Optional<ShieldOrWeapon> Secondary { get; init; } = default!;
    public readonly Optional<Armor> HeadSlot { get; init; } = default!;
    public readonly Optional<Armor> ChestSlot { get; init; } = default!;
    public readonly Optional<Armor> LegSlot { get; init; } = default!;
    public readonly Optional<Armor> ShoeSlot { get; init; } = default!;


    private readonly CurrencyBag CoinBag = new();

}
