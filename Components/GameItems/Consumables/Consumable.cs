using DotNext;

namespace BonesOfTheFallen.Services.Components.GameItems;

public record struct Consumable
{
    public Consumable(ConsumableItem item, ConsumableEffect effect)
    {
        if (item == ConsumableItem.Health)
        {
            Health = new((int)effect);
            Mana = default!;
        }
        else
        {
            Mana = new((int)effect);
            Health = default!;
        }
    }

    public Optional<int> Health { get; init; }
    public Optional<int> Mana { get; init; }
}
