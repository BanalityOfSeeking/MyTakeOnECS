using BonesOfTheFallen.Classes;
using BonesOfTheFallen.GameItems;

namespace BonesOfTheFallen.Services
{
    public record struct PlayableObject
    {
        public PlayableObject(int id, Attributes attr, Inventory inventor, Position pos, Race race)
        {
            Id=id;
            Attr=attr;
            Inventor=inventor;
            Pos=pos;
            Race=race;
        }

        public int Id { get; }
        public Attributes Attr { get; }
        public Inventory Inventor { get; }
        public Position Pos { get; }
        public Race Race { get; }
    }

}