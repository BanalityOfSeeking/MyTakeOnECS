using Microsoft.Toolkit.HighPerformance.Helpers;
using System;
using System.Runtime.CompilerServices;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Gravity and Movement functions
    /// ** needs method to await user input, instead of trying to hopefully grab it. ** 
    /// </summary>
    /// <param name="position"></param>
    /// <returns>Postion or Postion affected by gravity</returns>
    public readonly struct GravityHelper : IRefAction<Position>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref Position position)
        {
            if (position.HasVerticalMovement)
            {
                if (position.Y > 1.0)
                {
                    position.Y -= 0.2;
                }
                if (position.Y < 0)
                {
                    position.Y = 0.0;
                }
            }
        }
    }



    /// <summary>
    /// Call each positions input routine to get a direction to move.
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public readonly struct MovementHelper : IRefAction<Position>
    {
        public void Invoke(ref Position position)
        {
            if (!position.IsMonster)
            {
                VelocityUpdate(ref position);
            }
            else
            {
                VelocityUpdateMonster(ref position);
            }
        }
        private static void VelocityUpdateMonster(ref Position postion)
        {
            var rand = Random.Shared.Next(0, 4);
            switch (rand)
            {
                case 0:
                    if (postion.HasVerticalMovement)
                    {
                        postion.Y -= 0.4f;
                    }
                    break;
                case 1:
                    if (postion.HasVerticalMovement)
                    {
                        postion.Y += 0.4f;
                    }
                    break;
                case 2:
                    if (postion.HasHorizontalMovement)
                    {
                        postion.X -= 0.4f;
                    }
                    break;
                case 3:
                    if (postion.HasHorizontalMovement)
                    {
                        postion.X += 0.4f;
                    }
                    break;
                default:
                    break;
            };
        }

        private static void VelocityUpdate(ref Position position)
        {

            if (NativeKeyboard.IsKeyDown(KeyCode.Down))
            {
                position.Y = -0.4f;
            }
            if (NativeKeyboard.IsKeyDown(KeyCode.Up))
            {
                position.Y = 0.4f;
            }
            if (NativeKeyboard.IsKeyDown(KeyCode.Left))
            {
                position.X = -0.4f;
            }
            if (NativeKeyboard.IsKeyDown(KeyCode.Right))
            {
                position.X =  0.4f;
            }
        }
    }
}
