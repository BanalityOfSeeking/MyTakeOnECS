using BonesOfTheFallen.Services.Components.Classes;
using DotNext;


namespace BonesOfTheFallen.Services.Components;

public record GameObject
{
    public UserDataSlot<GameSequence<int>> Attributes;
    public UserDataSlot<WeaponData> Weapon;
    public UserDataSlot<HealthAndMana> HealthAndMana;
    public UserDataSlot<LevelAndXP> LevelAndXP;
    public UserDataSlot<Position> Position;
    public UserDataSlot<GameClass> Class;
    public UserDataSlot<Race> Race;
}
