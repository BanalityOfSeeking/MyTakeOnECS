using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Services
{
    public struct Position
    {
        public double X;
        public double Y;
        public double Z;

    }
    public struct Location
    {
        public bool HasQuest;
        public string Name;
        public Position LocationPostion;
        public Rectangle Area;
        public bool IsTrader;


    }
}
