using System;

namespace BonesOfTheFallen.Classes
{
    public record struct AttributeModifiers : IDisposable
    {
        public int CharismaMod;
        public int ConstitutionMod;
        public int DexterityMod;
        public int HealthMod;
        public int InteligenceMod;
        public int ManaMod;
        public int StrengthMod;
        public int WisdomMod;
        public AttributeModifiers()
        {
            CharismaMod=0;
            ConstitutionMod=CharismaMod;
            DexterityMod=CharismaMod;
            HealthMod=CharismaMod;
            InteligenceMod=CharismaMod;
            ManaMod=CharismaMod;
            StrengthMod=CharismaMod;
            WisdomMod=CharismaMod;
        }
        public AttributeModifiers(int charismaMod, int constitutionMod, int dexterityMod, int healthMod, int inteligenceMod, int manaMod, int strengthMod, int wisdomMod)
        {
            CharismaMod=charismaMod;
            ConstitutionMod=constitutionMod;
            DexterityMod=dexterityMod;
            HealthMod=healthMod;
            InteligenceMod=inteligenceMod;
            ManaMod=manaMod;
            StrengthMod=strengthMod;
            WisdomMod=wisdomMod;
        }

        public void Dispose()
        {
        }
    }
}