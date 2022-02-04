using System;

namespace BonesOfTheFallen.Services.Components;

public struct Attributes : IEquatable<Attributes>
{
    public int Charisma;
    public int Constitution;
    public int Dexterity;
    public int Expierence;
    public int Health;
    public int Inteligence;
    public int Level;
    public int Mana;
    public int Strength;
    public int Wisdom;

    public Attributes(int charisma, int constitution, int dexterity, int expierence, int health, int inteligence, int level, int mana, int strength, int wisdom)
    {
        Charisma=charisma;
        Constitution=constitution;
        Dexterity=dexterity;
        Expierence=expierence;
        Health=health;
        Inteligence=inteligence;
        Level=level;
        Mana=mana;
        Strength=strength;
        Wisdom=wisdom;
    }

    public bool Equals(Attributes other)
    {
        return Charisma==other.Charisma&&
               Constitution==other.Constitution&&
               Dexterity==other.Dexterity&&
               Expierence==other.Expierence&&
               Health==other.Health&&
               Inteligence==other.Inteligence&&
               Level==other.Level&&
               Mana==other.Mana&&
               Strength==other.Strength&&
               Wisdom==other.Wisdom;
    }

    public override int GetHashCode()
    {
        HashCode hash = new HashCode();
        hash.Add(Charisma);
        hash.Add(Constitution);
        hash.Add(Dexterity);
        hash.Add(Expierence);
        hash.Add(Health);
        hash.Add(Inteligence);
        hash.Add(Level);
        hash.Add(Mana);
        hash.Add(Strength);
        hash.Add(Wisdom);
        return hash.ToHashCode();
    }

    public static Attributes operator +(Attributes left, AttributeModifiers right)
    {
        left.Charisma += right.CharismaMod;
        left.Constitution += right.ConstitutionMod;
        left.Dexterity += right.DexterityMod;

        left.Health += right.HealthMod;
        left.Inteligence += right.InteligenceMod;

        left.Mana += right.ManaMod;
        left.Strength += right.StrengthMod;
        left.Wisdom += right.WisdomMod;
        return left;
    }

    public override bool Equals(object obj)
    {
        return obj is Attributes && Equals((Attributes)obj);
    }

    public static bool operator ==(Attributes left, Attributes right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Attributes left, Attributes right)
    {
        return !(left==right);
    }
}
