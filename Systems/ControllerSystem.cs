namespace BonesOfTheFallen.Services
{
    public record ControllerSystem : UpdateSystem<Velocity>
    {
        public override void ProcessEntity(float deltaTime, ref Velocity t1Rfef)
        {
            if (NativeKeyboard.IsKeyDown(KeyCode.Up))
            {
                t1Rfef.Value.Y -= 0.1f;
                return;
            }
            if (NativeKeyboard.IsKeyDown(KeyCode.Down))
            {
                t1Rfef.Value.Y += 0.1f;
                return;
            }
            if (NativeKeyboard.IsKeyDown(KeyCode.Left))
            {
                t1Rfef.Value.X -= 0.1f;
                return;
            }
            if (NativeKeyboard.IsKeyDown(KeyCode.Right))
            {
                t1Rfef.Value.X += 0.1f;
                return;
            }
        }
    }
}
