using Microsoft.Toolkit.HighPerformance;
using System;
using System.Threading;
using System.Threading.Channels;

namespace BonesOfTheFallen.Services
{
    public record VelocitySystem : SystemBase<VelocityEnum, double>, ISystem<VelocityEnum, double>
    {
        internal bool IsPlayableSystem { get; } = false;

        public override IComponentBase<VelocityEnum> Component => InternalComponent;

        private Velocity InternalComponent = default!;
        private readonly ChannelReader<Velocity> Modifiers = default!;
        double Int0 = -1;

        public VelocitySystem(bool isPlayableSystem, ChannelReader<Velocity> modifiers)
        {
            IsPlayableSystem=isPlayableSystem;
            Modifiers=modifiers??throw new ArgumentNullException(nameof(modifiers));
        }

        public override Ref<double> GetPropertyRef(VelocityEnum attributeId) =>
            attributeId switch
            {
                VelocityEnum.None => new(ref Int0),
                VelocityEnum.X => new(ref InternalComponent.X),
                VelocityEnum.Y => new(ref InternalComponent.Y),
                VelocityEnum.Z => new(ref InternalComponent.Z),
                _ => new(ref Int0),
            };

        public void ProcessModifier(Velocity item)
        {
            _ = Interlocked.Exchange(ref InternalComponent, item);
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
