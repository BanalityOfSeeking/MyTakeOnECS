using System;
using System.Collections.Generic;

namespace BonesOfTheFallen.Services.Components;

public struct HealthAndMana<T> : IEquatable<HealthAndMana<T>> where T : INumber<T>
{
    public T Health;
    public T Mana;

    public HealthAndMana(T health, T mana)
    {
        Health=health;
        Mana=mana;
    }

    public override bool Equals(object? obj)
    {
        return obj is HealthAndMana<T> mana && Equals(mana);
    }

    public bool Equals(HealthAndMana<T> other)
    {
        return EqualityComparer<T>.Default.Equals(Health, other.Health) &&
               EqualityComparer<T>.Default.Equals(Mana, other.Mana);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Health, Mana);
    }

    public static bool operator ==(HealthAndMana<T> left, HealthAndMana<T> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(HealthAndMana<T> left, HealthAndMana<T> right)
    {
        return !(left == right);
    }
}
