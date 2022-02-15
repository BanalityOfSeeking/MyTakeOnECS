﻿using BonesOfTheFallen.Services.Components;
using BonesOfTheFallen.Services.Components.Classes;
using DotNext;
using Microsoft.Toolkit.HighPerformance;
using System;
using System.Buffers;
using System.Collections.Generic;

namespace BonesOfTheFallen.Services
{

    public class GameSequenceSegment<T> : ReadOnlySequenceSegment<T>
    {
        public new Memory<T> Memory { get; }
        public GameSequenceSegment(Memory<T> memory) : base()
        {
            Memory = memory;
        }
        public GameSequenceSegment(T[] memory)
        {
            Memory = memory;
        }
        public GameSequenceSegment(Span<T> memory)
        {
            Memory = new Memory<T>(memory.ToArray());
        }
        public GameSequenceSegment(Range memory)
        {
            Memory = new T[memory.End.Value];
        }
        public new GameSequenceSegment<T> Next { get; set; } = default!;
    }
    public class GameSequence<T> where T : INumber<T>
    {
        private readonly List<GameSequenceSegment<T>> GameSegments = new(100);
        public GameSequence<T> AddSegment(GameSequenceSegment<T> gameSegments)
        {
            GameSegments.Add(gameSegments);
            return this;
        }
        public void SumSegments()
        {
            GameSequenceSegment<T> summed = new(new T[GameSegments[0].Memory.Length]);
            foreach (GameSequenceSegment<T> segment in GameSegments)
            {
                foreach (var item in segment.Memory.Span.Enumerate())
                {
                    summed.Memory.Span[item.Index] += item.Value;
                }
            }
            GameSegments.Clear();
            GameSegments.Add(summed);
        }
    }
    public record WeaponData
    {
        internal bool? Identifiable = default!;
        internal bool? IsMagic = false;
        internal GameSequence<int> Data { get; init; } = default!;
    }
    internal sealed record WeaponSystem
    {
        public WeaponSystem(GameObject gameObject, WeaponData data)
        {
            var storage = gameObject.GetUserData();
            var @class = storage.Get(gameObject.Class, GameClass.Farmer);
            switch (@class)
            {
                case GameClass.None:
                    throw new NotImplementedException();
                case GameClass.Farmer:
                    data.Identifiable = false;
                    data.IsMagic  = false;
                    // Range, Damage, MagicDamage, BlockChance
                    data.Data.AddSegment(new(new int[] { 3, 1, 0, 20 }));
                    break;
                case GameClass.Trainee:
                    break;
                case GameClass.Archer:
                    break;
                case GameClass.Cleric:
                    break;
                case GameClass.Fighter:
                    break;
                case GameClass.Mage:
                    break;
                default:
                    break;
            }

        }
    }
    internal record AttributeSequences
    {

        internal GameSequenceSegment<int> DamageResistChance = new(Range.EndAt(20));
        internal GameSequenceSegment<int> DefenseTotal = new(Range.EndAt(100));
        internal GameSequenceSegment<int> Charisma = new(Range.EndAt(25));
        internal GameSequenceSegment<int> Constitution = new(Range.EndAt(25));
        internal GameSequenceSegment<int> Dexterity = new(Range.EndAt(25));
        internal GameSequenceSegment<int> Intelligence = new(Range.EndAt(25));
        internal GameSequenceSegment<int> MagicDefenseTotal = new(Range.EndAt(50));
        internal GameSequenceSegment<int> MagicResistPercent = new(Range.EndAt(10));
        internal GameSequenceSegment<int> Strength = new(Range.EndAt(25));
        internal GameSequenceSegment<int> Wisdom = new(Range.EndAt(25));
    }
}


