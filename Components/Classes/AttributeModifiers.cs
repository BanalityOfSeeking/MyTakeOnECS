namespace BonesOfTheFallen.Classes
{
    public record struct AttributeModifiers
    {
        public AttributeModifiers(
                int charismaMod = 0,
                int constitutionMod = 0,
                int dexterityMod = 0,
                int expierenceMod = 0,
                int healthMod = 0,
                int inteligenceMod = 0,
                int levelMod = 0,
                int manaMod = 0,
                int strengthMod = 0,
                int wisdomMod = 0)
        {
            CharismaMod=charismaMod;
            ConstitutionMod=constitutionMod;
            DexterityMod=dexterityMod;
            ExpierenceMod=expierenceMod;
            HealthMod=healthMod;
            InteligenceMod=inteligenceMod;
            LevelMod=levelMod;
            ManaMod=manaMod;
            StrengthMod=strengthMod;
            WisdomMod=wisdomMod;
        }

        public int CharismaMod { get; init; }
        public int ConstitutionMod { get; init; }
        public int DexterityMod { get; init; }
        public int ExpierenceMod { get; init; }
        public int HealthMod { get; init; }
        public int InteligenceMod { get; init; }
        public int LevelMod { get; init; }
        public int ManaMod { get; init; }
        public int StrengthMod { get; init; }
        public int WisdomMod { get; init; }
    }
}