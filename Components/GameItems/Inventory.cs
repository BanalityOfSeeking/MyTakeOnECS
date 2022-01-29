using DotNext;
using System;
using System.Collections.Generic;

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

        private readonly Dictionary<ItemDefinition, int> ArmorLedger = new();
        public void ArmorGeneratorion()
        {
            for(int itt = 1; itt < (int)ItemType.Shoes + 1; itt++)
            {
                for(int itd = 1; itd < (int)ItemDescription.StuddedLeather + 1; itd++)
                {
                    ArmorLedger.Add(new ItemDefinition((ItemDescription)itd, (ItemType)itt,
                        new(
                            false,
                            // Heal
                            Range.EndAt(0),
                            // Range
                            Range.EndAt(0),
                            // Attack Damage
                            Range.EndAt(0),
                            // Magic Damage
                            Range.EndAt(0),
                            // Defense
                            itd,
                            // Magic Defense
                            itd,
                            // Damage Resistance
                            itd,
                            // Magic Resistance
                            itd)
                        )
                        // Item Count to add.
                        ,0);
                }
            }
        }
    }
}