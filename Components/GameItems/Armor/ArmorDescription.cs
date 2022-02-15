namespace BonesOfTheFallen.Services.Components.GameItems;

public enum FighterCanEquipArmorCategories
{
    None,
    Light,
    Medium,
    Heavy,
}
public enum ClericCanEquipArmorCategories
{
    None,
    Light,
    Medium,
}
public enum MageCanEquipArmorCategories
{
   None,
   Light
}
public enum ArcherCanEquipArmorCategories
{
    None,
    Light
}
public class GameClassEquipmentCategories
{
    public FighterCanEquipArmorCategories FighterArmorTypes;
    public ClericCanEquipArmorCategories ClericArmorTypes;
    public MageCanEquipArmorCategories MageArmorTypess;
    public ArcherCanEquipArmorCategories ArcherArmorTypes;

}

public enum Light_Armor
{
    None,
    Cloth,
    Padded,
    Leather,

}