using System;

namespace BonesOfTheFallen.Services.Components;

public enum GameClass
{
    Farmer = 0x0100,
    TraineeArcher,
    TraineeCleric,
    TraineeFighter,
    TraineeMage,
    Archer,
    Cleric,
    Fighter,
    Mage,
}
public enum Masks
{
    ClassMask = 0x00FF,
    RaceMask = 0xFF00,
}