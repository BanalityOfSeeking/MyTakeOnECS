namespace BonesOfTheFallen.Services.Components.GameItems;


public enum FighterMainHand
{
    None,
    Club,
    Sword,
    LongSword,
    TwoHandedSword,
    WarHammer,
    WarAxe,
    Spear,
}
public enum FighterOffHand
{
    None,
    Dagger,
    Shield,
    ShortSword,
}
public class Fighter
{
    public FighterMainHand MainHand { get; }
    public FighterOffHand OffHand { get; }

}
public enum ArcherMainHand
{
    None,
    CrossBow,
    HeavyCrossBow,
    LightBow,
    MediumBow,
    HeavyBow,
    DualStringBow,
}
public enum ArcherOffHand
{
    None,
    Dagger,
    Shield,
    ThrowingKnives,
}
public enum ClericMainHand
{
    None,
    Club,
    Mace,
    Hammer,
    Cudgel,
}
public enum ClericOffHand
{
    None, 
    Dagger,
    Shield,
    HolyArtifact,
    HolySymbol,
}
public enum MageOffHand
{
    None,
    Dagger,
    Book,
    Tomb,
    Wand,
    Scrolls,
    Artifact,
}