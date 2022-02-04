namespace BonesOfTheFallen.GameItems
{
    public readonly ref struct ArmorItem
    {
        public ArmorItem(ArmorDefinition definition)
        {
            Armor= definition.PhysicalDefense.IsNull ? 0 : definition.PhysicalDefense.Value;
            MagicDefense=definition.MagicDefense.IsNull ? 0 : definition.MagicDefense.Value;
            DamageResist=definition.DamageResist.IsNull ? 0 : definition.DamageResist.Value;
            MagicResist=definition.MagicResist.IsNull ? 0 : definition.MagicResist.Value;
        }
        public int Armor { get; init; }
        public int MagicDefense { get; init; }
        public int DamageResist { get; init; }  
        public int MagicResist { get; init; }
    }
}