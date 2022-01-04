using Microsoft.Toolkit.HighPerformance;
using System.Threading;
using System.Threading.Channels;

namespace BonesOfTheFallen.Services
{
    public record PositionSystem : SystemBase<PositionEnum, double>, ISystem<PositionEnum, double>
    {
        internal bool IsPlayableSystem { get; } = false;

        public override IComponentBase<PositionEnum> Component => InternalComponent;

        private Position InternalComponent = default!;
        private readonly ChannelReader<Position> Modifiers = default!;
        double Int0 = -1;

        public PositionSystem(bool isPlayableSystem, ChannelReader<Position> modifiers)
        {
            IsPlayableSystem=isPlayableSystem;
            Modifiers=modifiers;
            InternalComponent = new();
        }

        public override Ref<double> GetPropertyRef(PositionEnum attributeId) =>
            attributeId switch
            {
                PositionEnum.None => new(ref Int0),
                PositionEnum.X => new(ref InternalComponent.X),
                PositionEnum.Y => new(ref InternalComponent.Y),
                PositionEnum.Z => new(ref InternalComponent.Z),
                _ => new(ref Int0),
            };

        public void ProcessModifier(Position item)
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
