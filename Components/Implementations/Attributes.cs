namespace BonesOfTheFallen.Services
{
    public record struct Attributes : IComponentBase
    {
        public bool IsPayer { get; init; }

        public Attributes(bool isPayer) : this()
        {
            IsPayer=isPayer;
        }

        public byte Charisma { get; init; }
        public byte Constitution { get; init; }
        public byte Dexterity { get; init; }
        public int Expierence { get; init; }
        public int Health { get; init; }
        public byte Inteligence { get; init; }
        public int Level { get; init; }
        public int Mana { get; init; }
        public byte Strength { get; init; }
        public byte Wisdom { get; init; }
    }
}
