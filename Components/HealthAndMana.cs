using System;

namespace BonesOfTheFallen.Services.Components;

public struct HealthAndMana
{
    public int Health;
    public int Mana;

    public HealthAndMana(int health, int mana)
    {
        Health=health;
        Mana=mana;
    }

    public override bool Equals(object? obj)
    {
        return obj is HealthAndMana mana&&
               Health==mana.Health&&
               Mana==mana.Mana;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Health, Mana);
    }

    public static bool operator ==(HealthAndMana left, HealthAndMana right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(HealthAndMana left, HealthAndMana right)
    {
        return !(left==right);
    }
}
