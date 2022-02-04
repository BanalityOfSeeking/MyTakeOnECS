using BonesOfTheFallen.Services.Components;
using Microsoft.Toolkit.HighPerformance.Helpers;

/// <summary>
/// Gravity and Movement functions
/// ** needs method to await user input, instead of trying to hopefully grab it. ** 
/// </summary>
/// <param name="position"></param>
/// <returns>Postion or Postion affected by gravity</returns>
namespace BonesOfTheFallen.Services.Systems
{
    public readonly struct MovementHelper : IRefAction<Position>
    {
        public void Invoke(ref Position position)
        {
            VelocityUpdate(ref position);
        }
        private static bool previousUD = false;
        private static bool previousLR = false;
        private static void BoundingRule(ref Position postion, double updown, double leftright)
        {
            if (postion.Y + updown > 0.0 && previousUD == false)
            {
                postion.Y += updown;
                previousUD = true;
            }
            else if (postion.Y + updown < 0.00)
            {
                postion.Y = 0.0;
                previousUD = false;
            }
            else if (postion.X + leftright >= 100.0)
            {
                postion.X -= 0.5;
                previousLR = true;
            }
            else if (postion.X + leftright <= -100.0)
            {
                postion.X += 0.5;
                previousLR = true;
            }
            else
            {
                postion.X += leftright;
                postion.Y += updown;
            }
        }

        private static double updown = 0.0;
        private static double leftright = 0.0;
        private static void VelocityUpdate(ref Position position)
        {
            if (updown < 0.0)
            {

                if (NativeKeyboard.IsKeyDown(KeyCode.Down))
                {
                    updown = 0;
                }
                else if (NativeKeyboard.IsKeyDown(KeyCode.Up))
                {
                    updown = -1;
                }
            }
            else
            {
                if (NativeKeyboard.IsKeyDown(KeyCode.Left))
                {
                    leftright = -0.1f;
                }
                else if (NativeKeyboard.IsKeyDown(KeyCode.Right))
                {
                    leftright =  0.1f;
                }
            }
            if (updown > 0.0 || leftright > 0.0)
            {
                BoundingRule(ref position, updown, leftright);
            }
        }
    }
}
