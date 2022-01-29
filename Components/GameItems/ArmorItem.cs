namespace BonesOfTheFallen.GameItems
{
    public readonly record struct ArmorItem
    {
        public ArmorItem(ItemDefinition definition)
        {
            ArmorId=definition.Item.GetHashCode() + definition.ItemDescription.GetHashCode() + definition.Modifiers.GetHashCode();
            Armor= definition.Modifiers.Armor.IsNull ? 0 : definition.Modifiers.Armor.Value;
            MagicDefense=definition.Modifiers.MagicDefense.IsNull ? 0 : definition.Modifiers.MagicDefense.Value;
            DamageResist=definition.Modifiers.DamageResist.IsNull ? 0 : definition.Modifiers.DamageResist.Value;
            MagicResist=definition.Modifiers.MagicResist.IsNull ? 0 : definition.Modifiers.MagicResist.Value;
        }

        public int ArmorId { get; init; }
        public int Armor { get; init; }
        public int MagicDefense { get; init; }
        public int DamageResist { get; init; }  
        public int MagicResist { get; init; }
    }
}