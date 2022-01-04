using System;
using System.Threading.Channels;

namespace BonesOfTheFallen.Services
{
    public record VelocitySystem : SystemBase, ISystem, IVelocitySystem
    {
        internal bool IsPlayableSystem { get; } = false;

        private readonly ChannelReader<Velocity> Modifiers = default!;
        private readonly ChannelWriter<Position> Positions = default!;

        public VelocitySystem(bool isPlayableSystem, ChannelReader<Velocity> modifiers, ChannelWriter<Position> positionChannel)
        {
            IsPlayableSystem = isPlayableSystem;
            Modifiers = modifiers??throw new ArgumentNullException(nameof(modifiers));
            Positions = positionChannel??throw new ArgumentNullException(nameof(positionChannel));
        }

        public override void Process(in float time)
        {
            while (Modifiers.TryRead(out var item))
            {
                Positions.TryWrite(new Position() { X = item.X, Y = item.Y, Z = item.Z });
            }
        }
    }
}
