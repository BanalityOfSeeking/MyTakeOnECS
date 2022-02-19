using System;
using System.Collections.Generic;

namespace BonesOfTheFallen.Services.Components;

public struct LevelAndXP<T> : IEquatable<LevelAndXP<T>> where T : INumber<T>
{
    public T Level;
    public T XP;

    public LevelAndXP(T level, T xP)
    {
        Level = level;
        XP = xP;
    }

    public override bool Equals(object? obj)
    {
        return obj is LevelAndXP<T> xP && Equals(xP);
    }

    public bool Equals(LevelAndXP<T> other)
    {
        return EqualityComparer<T>.Default.Equals(Level, other.Level) &&
               EqualityComparer<T>.Default.Equals(XP, other.XP);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Level, XP);
    }

    public static bool operator ==(LevelAndXP<T> left, LevelAndXP<T> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(LevelAndXP<T> left, LevelAndXP<T> right)
    {
        return !(left == right);
    }
}
