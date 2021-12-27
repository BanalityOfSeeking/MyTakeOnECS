// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace BonesOfTheFallen.Services
{
    public static class StoragePool
    {
        public static void Store<TValue>(int entity, TValue value) where TValue : unmanaged
        {
            // get components array
            ref var comps = ref TypedValue<TValue>.Components;
            ref var indexes = ref TypedValue<TValue>.EntityComponentIndex;
            // resize it to add 1
            Array.Resize(ref comps, comps.Length + 1);
            // store component storage index and entity;
            indexes[entity] = comps.Length - 1;
            // reference the new index
            comps[^1] = value;
        }

        public static ref TValue Get<TValue>(int entity) where TValue : unmanaged
        {
            var comps = TypedValue<TValue>.Components;
            var indexes = TypedValue<TValue>.EntityComponentIndex;
            return ref comps[indexes[entity]];
        }
        public static void StoreModifier(AttributeModifier modifier)
        {
            Modifiers.Writer.TryWrite(modifier);
        }
        public static void StoreModifier(int entity, AttributeEnum attribute, byte modifier)
        {
            Modifiers.Writer.TryWrite(new(entity, attribute, modifier));
        }

        public static ChannelReader<AttributeModifier> GetModifierReader()
        {
            return Modifiers.Reader;
        }

        internal static Channel<AttributeModifier> Modifiers = Channel.CreateUnbounded<AttributeModifier>();
        private static class TypedValue<TValue> where TValue : unmanaged
        {
            internal static TValue[] Components 
                = Array.Empty<TValue>();

            internal static Dictionary<int, int> EntityComponentIndex
                = new();
        }
    }
}