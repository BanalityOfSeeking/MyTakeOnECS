namespace BonesOfTheFallen.Services
{
    public static class VelocityExtensions
    {
        public static void SetXYZ(this Velocity vel, int x, int y = default, int z = default)
        {
            vel.X = x;
            vel.Y = y;
            vel.Z = z;
        }
    }
}