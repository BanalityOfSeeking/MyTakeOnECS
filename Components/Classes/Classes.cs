namespace BonesOfTheFallen.Classes
{
    public record struct Fighter
    {
        public readonly GameClass FighterModifiers = new(new AttributeModifiers(-2, 4, -2, 0, 50, -2, 0, 25, 2, -2));
    }
    public record Mage
    {
        public readonly GameClass MageAttributes = new(new AttributeModifiers(-1, -2, -2, 0, 25, 2, 0, 50, -2, 3));
    }
    public record Cleric
    {
        public readonly GameClass ClericAttributes = new(new AttributeModifiers(-1, 1, -2, 0, 35, 0, 0, 25, 1, 2));
    }
    public record Archer
    {
        public readonly GameClass ArcherAttributes = new(new AttributeModifiers(2, -2, 2, 0, 25, -1, 0, 25, -2, 2));
    }
}