using BonesOfTheFallen.Services.Components.GameItems;

namespace BonesOfTheFallen.Services.Components;

public ref struct PlayableObject
{
    public PlayableObject(Attributes attr, Inventory inventor, Position pos, Race race)
    {

        Attr=attr;
        Inventor=inventor;
        Pos=pos;
        Race=race;
    }
    public Attributes Attr { get; }
    public Inventory Inventor { get; }
    public Position Pos { get; }
    public Race Race { get; }
}
