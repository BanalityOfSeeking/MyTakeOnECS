using Microsoft.Toolkit.HighPerformance;
using System;
using System.Threading;
using System.Threading.Channels;

namespace BonesOfTheFallen.Services
{
    public record VelocitySystem : SystemBase<VelocityEnum>, ISystem<VelocityEnum>
    {
        internal bool IsPlayableSystem { get; } = false;

        public override IComponentBase<VelocityEnum> Component => InternalComponent;

        private readonly Velocity InternalComponent = default!;
        private readonly ChannelReader<Velocity> Modifiers = default!;
        private readonly ChannelWriter<Position> Positions = default!;

        public VelocitySystem(bool isPlayableSystem, ChannelReader<Velocity> modifiers, ChannelWriter<Position> positionChannel)
        {
            IsPlayableSystem = isPlayableSystem;
            Modifiers = modifiers??throw new ArgumentNullException(nameof(modifiers));
            Positions = positionChannel??throw new ArgumentNullException(nameof(positionChannel));

        }

        public void ProcessModifier(Velocity item)
        {
            Positions.TryWrite(new Position() { X = item.X, Y = item.Y, Z = item.Z });
        }

        public override void Process(in float time)
        {
            while (Modifiers.TryRead(out var modifier))
            {
                ProcessModifier(modifier);
            }
        }
    }
}
