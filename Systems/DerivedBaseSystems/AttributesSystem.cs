using System;
using System.Threading.Channels;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Attribute systems run init for all entities added to it 
    /// and processe attribute modifiers for entities
    /// </summary>
    public record AttributesSystem : InitSystem
    {
        // Get Attribute modifier component Channel
        private readonly ChannelReader<AttributeModifier> Reader = StoragePool.GetModifierReader();
        
        // Get Shared Random.
        private readonly Random Random = Random.Shared;
        
        /// <summary>
        /// Initialize Attributes for entities
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void Init(float deltaTime)
        {
            foreach (int entity in Entities)
            {

                Attributes Attributes = new()
                {
                    Charisma = (byte)Random.Next(3, 18),
                    Constitution = (byte)Random.Next(3, 18),
                    Dexterity = (byte)Random.Next(3, 18),
                    Expierence = 0,
                    Health = 100,
                    Inteligence = (byte)Random.Next(3, 18),
                    Level = 1,
                    Mana = 100,
                    Strength = (byte)Random.Next(3, 18),
                    Wisdom = (byte)Random.Next(3, 18),
                };
                // Store Component
                StoragePool.Store(entity, Attributes);
            }
        }
        /// <summary>
        /// Uses Enities[] in SystemBase to process messages 
        /// added via StoragePool.StoreModifier which write to a Channel.
        /// </summary>
        /// <param name="deltaTime"></param>
        /// <param name="entity"></param>
        public override void ProcessEntity(float deltaTime, int entity)
        {
            // Get Component by entity
            ref var attributes = ref StoragePool.Get<Attributes>(entity);
            // Read Attribute modifiers searching for entity match
            while (Reader.TryRead(out AttributeModifier mod))
            {
                // on match handle mapping
                if (mod.Entity == entity)
                {
                    attributes = mod.Attribute switch
                    {
                        AttributeEnum.Charisma => attributes = attributes with { Charisma = (byte)(attributes.Charisma + mod.Modifier) },
                        AttributeEnum.Constitution => attributes = attributes with { Constitution = (byte)(attributes.Constitution + mod.Modifier) },
                        AttributeEnum.Dexterity => attributes = attributes with { Dexterity = (byte)(attributes.Dexterity + mod.Modifier) },
                        AttributeEnum.Expierence => attributes = attributes with { Expierence = attributes.Expierence + mod.Modifier },
                        AttributeEnum.Health => attributes = attributes with { Health = attributes.Health + mod.Modifier },
                        AttributeEnum.Inteligence => attributes = attributes with { Inteligence = (byte)(attributes.Inteligence + mod.Modifier) },
                        AttributeEnum.Level => attributes = attributes with { Level = attributes.Level + mod.Modifier },
                        AttributeEnum.Mana => attributes = attributes with { Mana = attributes.Mana + mod.Modifier },
                        AttributeEnum.Strength => attributes = attributes with { Strength = (byte)(attributes.Strength + mod.Modifier) },
                        AttributeEnum.Wisdom => attributes = attributes with { Strength = (byte)(attributes.Strength + mod.Modifier) },
                        AttributeEnum.None => attributes,
                        _ => attributes
                    };
                }
                else
                {
                    // store the unused modifier
                    StoragePool.StoreModifier(mod);
                }
            }
        }

        public AttributesSystem(InitSystem original) : base(original)
        {
        }

        public AttributesSystem()
        {
            TypeMask = WorldManager.AddMask<Attributes>();
        }

        public AttributesSystem(SystemBase original) : base(original)
        {
        }
    }
}
