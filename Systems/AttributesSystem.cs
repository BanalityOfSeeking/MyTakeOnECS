using Microsoft.Toolkit.HighPerformance;
using System;
using System.Threading;
using System.Threading.Channels;

namespace BonesOfTheFallen.Services
{
    public record AttributesSystem : SystemBase, ISystem, IAttributesSystem
    {
        internal bool IsPlayableSystem { get; } = false;
        public IComponentBase<AttributeEnum> Component => InternalComponent;
        private Attributes InternalComponent = default!;
        private readonly ChannelReader<AttributesModifier> Modifiers = default!;
        int Int0 = -1;
        public Ref<int> GetPropertyRef(AttributeEnum attributeId) =>
            attributeId switch
            {
                AttributeEnum.None => new(ref Int0),
                AttributeEnum.Charisma => new(ref InternalComponent.Charisma),
                AttributeEnum.Constitution => new(ref InternalComponent.Constitution),
                AttributeEnum.Dexterity => new(ref InternalComponent.Dexterity),
                AttributeEnum.Expierence => new(ref InternalComponent.Expierence),
                AttributeEnum.Health => new(ref InternalComponent.Health),
                AttributeEnum.Inteligence => new(ref InternalComponent.Inteligence),
                AttributeEnum.Level => new(ref InternalComponent.Level),
                AttributeEnum.Mana => new(ref InternalComponent.Mana),
                AttributeEnum.Strength => new(ref InternalComponent.Strength),
                AttributeEnum.Wisdom => new(ref InternalComponent.Wisdom),
                _ => new(ref Int0),
            };

        public AttributesSystem(bool isPlayableSystem, ChannelReader<AttributesModifier> modifiers)
        {
            Modifiers = modifiers;
            Random Rand = Random.Shared;
            InternalComponent = new(isPlayableSystem)
            {
                Charisma = (byte)Rand.Next(3, 18),
                Constitution = (byte)Rand.Next(3, 18),
                Dexterity = (byte)Rand.Next(3, 18),
                Expierence = 0,
                Health = 100,
                Inteligence = (byte)Rand.Next(3, 18),
                Level = 1,
                Mana = 100,
                Strength = (byte)Rand.Next(3, 18),
                Wisdom = (byte)Rand.Next(3, 18),
            };
        }
        public override void Process(in float time)
        {
            while (Modifiers.TryRead(out var modifier))
            {
                _ = Interlocked.Add(ref GetPropertyRef(modifier.AttributeId).Value, modifier.Modifier);
            }
        }
    }
}