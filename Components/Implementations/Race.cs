using System;
using System.Runtime.Caching;

namespace BonesOfTheFallen.Classes
{
    public enum Race
    {
        Human,     
        Dwarf,
        Elf,
    }
    public ref struct RaceContainer
    {
        public RaceContainer(Race race)
        {
            // load serialzed settings
            Modifiers = (AttributeModifiers)MemoryCache.Default[Enum.GetName(typeof(Race), race)];
        }
        public AttributeModifiers Modifiers;
    }
}