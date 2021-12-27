using System;
using System.Numerics;

namespace BonesOfTheFallen.Services
{
    public record MoverSystem : GenericBaseSystems<Position, Velocity>
    {
        public override void ProcessEntity(float deltaTime, ref Position t1Rfef, ref Velocity t2Ref)
        {
            if (t2Ref.Value != Vector2.Zero)
            {
                t1Rfef.Value += t2Ref.Value * Time.DeltaTime;
                t2Ref.Value = Vector2.Zero;
            }
            Console.SetCursorPosition(0, 1);
            Console.WriteLine(t1Rfef.Value);
        }
    }
}
