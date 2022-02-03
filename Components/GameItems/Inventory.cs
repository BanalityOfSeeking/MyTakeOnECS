using DotNext;

namespace BonesOfTheFallen.GameItems
{
    public record struct Inventory
    {
        public readonly Optional<WeaponItem> Main { get; init; } = default!;
        public readonly Optional<ShieldOrWeapon> Secondary { get; init; } = default!;
        public readonly Optional<ArmorItem> HeadSlot { get; init; } = default!;
        public readonly Optional<ArmorItem> ChestSlot { get; init; } = default!;
        public readonly Optional<ArmorItem> LegSlot { get; init; } = default!;
        public readonly Optional<ArmorItem> ShoeSlot { get; init; } = default!;


        private readonly CurrencyBag CoinBag = new();

    }
}