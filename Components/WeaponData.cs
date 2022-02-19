using BonesOfTheFallen.Services.Components;

namespace BonesOfTheFallen.Services
{
    public struct WeaponData
    {
        internal bool? Identifiable = default!;
        internal bool? IsMagic = false;
        public byte Damage = default!;
        public byte MagicDamage = default!;
        public bool HasEffect = false;
        internal byte EffectId = 0;

        public WeaponData(GameObject gameObject)
        {

            gameObject.Weapon = this;
        }

        internal GameSequence<float> Data { get; init; } = default!;
    }
    public struct ArmorData
    {
        public float Defense = default!;
        public float ResistDamage = default!;
        public float MagicDefense = default!;
        public float ResistMagic = default!;

        public ArmorData(GameObject gameObject)
        {
            var ArmorData = new ArmorSequences<float>();
            Defense = ArmorData.Defense.Memory.Span[3];
            ResistDamage = ArmorData.DamageResistChance.Memory.Span[1];
            MagicDefense = ArmorData.MagicDefense.Memory.Span[2];
            ResistMagic = ArmorData.MagicResistPercent.Memory.Span[1];
            gameObject.Armor = this;
        }
    }
}


