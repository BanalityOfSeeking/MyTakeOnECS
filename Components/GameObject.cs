using Microsoft.Maui.Graphics;
using System;

namespace BonesOfTheFallen.Services.Components;

public record GameObject
{
    public short GameFlags { get; internal set; }
    public Func<IDrawable>? Drawing = default!;
    public GameSequence<int>? Attributes = default!;
    public WeaponData? Weapon = default!;
    public ArmorData? Armor = default!;
    public HealthAndMana<int>? HealthAndMana = default!;
    public LevelAndXP<byte>? LevelAndXP = default!;
    public Position<float>? Position = default!;
    public void SetFlag(GameClass @class, Race race)
    {
        GameFlags ^= (short)@class;
        GameFlags ^= (short)race;
    }
}
