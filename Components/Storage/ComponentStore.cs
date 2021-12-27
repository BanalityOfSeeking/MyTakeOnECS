// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Stores components via Typed lookup to store components and entity component indexes.
    /// And stores the fuctions for creating Channel for reading and writing AttributeModification Messages.
    /// </summary>
    public static class StoragePool
    {
        /// <summary>
        /// stores Components by entity
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        public static void Store<TValue>(int entity, TValue value) where TValue : unmanaged
        {
            // get components array
            ref var comps = ref TypedValue<TValue>.Components;
            // Get entity component indexes
            // ensure entity component not already added.
            if (!TypedValue<TValue>.EntityComponentIndex.ContainsKey(entity))
            {
                // resize array of components
                Array.Resize(ref comps, comps.Length + 1);
                // store component storage index and entity;
                TypedValue<TValue>.EntityComponentIndex[entity] = comps.Length - 1;
                // store component at index
                comps[^1] = value;
            }
        }
        /// <summary>
        /// Get Component by Entity
        /// </summary>
        /// <typeparam name="TValue?"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ref TValue Get<TValue>(int entity) where TValue : unmanaged
        {
            var comps = TypedValue<TValue>.Components;
            return ref comps[TypedValue<TValue>.EntityComponentIndex[entity]];
        }
        /// <summary>
        /// Write new AttributeModifier to Channel
        /// </summary>
        /// <param name="modifier"></param>
        public static void StoreModifier(AttributeModifier modifier)
        {
            Modifiers.Writer.TryWrite(modifier);
        }
        /// <summary>
        /// Write new AttributeModifier to Channel
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="attribute"></param>
        /// <param name="modifier"></param>
        public static void StoreModifier(int entity, AttributeEnum attribute, byte modifier)
        {
            StoreModifier(new(entity, attribute, modifier));
        }
        /// <summary>
        /// Gets the Channel Reader for processing Attribute Modifiers
        /// </summary>
        /// <returns></returns>
        public static ChannelReader<AttributeModifier> GetModifierReader()
        {
            return Modifiers.Reader;
        }
        /// <summary>
        /// Modifiers Channel
        /// </summary>
        internal static Channel<AttributeModifier> Modifiers = Channel.CreateUnbounded<AttributeModifier>();
        /// <summary>
        /// Static class to store Typed Components 
        /// along with the lookup for entity and component indexes.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        private static class TypedValue<TValue> where TValue : unmanaged
        {
            internal static TValue[] Components 
                = Array.Empty<TValue>();

            internal static Dictionary<int, int> EntityComponentIndex
                = new();
        }
    }
}