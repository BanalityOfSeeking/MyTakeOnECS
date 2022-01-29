using BonesOfTheFallen.Classes;
using BonesOfTheFallen.GameItems;

namespace BonesOfTheFallen.Services
{
    public record struct PlayableObject
    {
        public int Id { get; }
        public Attributes Attr { get; }
        public GameClass Class { get; }
        public Inventory Inventor { get; }
        public Position Pos { get; }
        public Race Race { get; }
    }

}