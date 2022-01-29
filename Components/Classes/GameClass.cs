namespace BonesOfTheFallen.Classes
{
    public record struct GameClass
    {
        public AttributeModifiers Modifiers { get; init; }
        public GameClass(AttributeModifiers modifiers)
        {
            Modifiers = modifiers;
        }
    } 
}