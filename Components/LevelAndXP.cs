using System;
using System.Diagnostics.CodeAnalysis;

namespace BonesOfTheFallen.Services.Components;

public struct LevelAndXP
{
    public int Level;
    public int XP;

    public LevelAndXP(int level, int xP)
    {
        Level=level;
        XP=xP;
    }


    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static bool operator ==(LevelAndXP left, LevelAndXP right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(LevelAndXP left, LevelAndXP right)
    {
        return !(left==right);
    }
}
