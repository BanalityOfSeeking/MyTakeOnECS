namespace BonesOfTheFallen.Classes
{
    public ref struct Fighter
    {
        public AttributeModifiers Modifiers = new()
        {
            CharismaMod = -2,
            ConstitutionMod = 4,
            DexterityMod = -2,
            HealthMod = 50,
            InteligenceMod = -2,
            ManaMod = 25,
            StrengthMod = 2,
            WisdomMod = -2,
        };
        public void Dispose()
        {
        }
    }
    public ref struct Mage
    {
        public AttributeModifiers Modifiers = new()
        {
            CharismaMod = -1,
            ConstitutionMod = -2,
            DexterityMod = 2,
            HealthMod = 25,
            InteligenceMod = 2,
            ManaMod = 50,
            StrengthMod = -2,
            WisdomMod = 3,
        };
        public void Dispose()
        {
        }
    }
    public ref struct Cleric
    {
        public AttributeModifiers Modifiers = new()
        {
            CharismaMod = -1,
            ConstitutionMod = 1,
            DexterityMod = -2,
            HealthMod = 35,
            InteligenceMod = -2,
            ManaMod = 50,
            StrengthMod = 2,
            WisdomMod = 1,
        };
        public void Dispose()
        {
        }
    }
    public ref struct Archer
    {
        public AttributeModifiers Modifiers = new()
        {
            CharismaMod = 2,
            ConstitutionMod = -2,
            DexterityMod = 2,
            HealthMod = 25,
            InteligenceMod = -1,
            ManaMod = 25,
            StrengthMod = -2,
            WisdomMod = 2,
        };
        public void Dispose()
        {
        }
    }
}
