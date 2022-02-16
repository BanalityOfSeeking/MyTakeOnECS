using BonesOfTheFallen.Services.Components.Classes;
using DotNext;


namespace BonesOfTheFallen.Services.Components;

public record GameObject
{
    public UserDataSlot<GameSequence<int>> Attributes = new();
    public UserDataSlot<WeaponData> Weapon = new();
    public UserDataSlot<HealthAndMana> HealthAndMana = new();
    public UserDataSlot<LevelAndXP> LevelAndXP = new();
    public UserDataSlot<Position> Position = new();
    public UserDataSlot<GameClass> Class = new();
    public UserDataSlot<Race> Race = new();
}
