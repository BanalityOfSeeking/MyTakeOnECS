using System;

namespace BonesOfTheFallen.Services
{
    public record LocationSystem : CheckSystem<Position>
    { 
        protected override bool CheckRoutine(ref Position t1Ref)
        {
            return (t1Ref.Value.X, t1Ref.Value.Y) switch
            {
                (0.0f, 0f) => true,                
                (1.0f, 1.0f) => true,
                _ => false
            };
        }

        public override void ProcessEntity(float deltaTime, ref Position t1Ref)
        {
            Console.WriteLine(t1Ref.ToString());
        }
    }
}
