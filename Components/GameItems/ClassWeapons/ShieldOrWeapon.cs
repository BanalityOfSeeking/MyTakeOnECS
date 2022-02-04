namespace BonesOfTheFallen.Services.Components.GameItems;

public ref struct ShieldOrWeapon
{
    public readonly Weapon Weapon;
    public readonly Armor Shield;

    public ShieldOrWeapon(Weapon weapon, Armor shield)
    {
        Weapon=weapon;
        Shield=shield;
    }
}
