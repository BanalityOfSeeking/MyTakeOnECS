using BonesOfTheFallen.GameItems;

using DotNext;

namespace BonesOfTheFallen.Services.Components.GameItems;

public record struct Inventory
{
    public readonly Optional<WeaponDefinition> Main { get; init; } = default!;
    public readonly Optional<ShieldOrWeapon> Secondary { get; init; } = default!;
    public readonly Optional<ArmorItem> HeadSlot { get; init; } = default!;
    public readonly Optional<ArmorItem> ChestSlot { get; init; } = default!;
    public readonly Optional<ArmorItem> LegSlot { get; init; } = default!;
    public readonly Optional<ArmorItem> ShoeSlot { get; init; } = default!;


    private readonly CurrencyBag CoinBag = new();

}
