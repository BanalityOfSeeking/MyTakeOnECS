using BonesOfTheFallen.Services.Components;

namespace BonesOfTheFallen.Services
{
    public static class PositionExtensions
    {
        public static void SetXYZ(this Position<float> pos, int x, int y = default, int z = default)
        {
            pos.X = x;
            pos.Y = y;
            pos.Z = z;
        }
    }
}
