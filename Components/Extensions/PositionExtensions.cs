using System;
using System.Threading.Tasks;

namespace BonesOfTheFallen.Services
{
    public static class PositionExtensions
    {
        public static void SetXYZ(this Position pos, int x, int y = default, int z = default)
        {
            pos.X = x;
            pos.Y = y;
            pos.Z = z;
        }
    }
}
