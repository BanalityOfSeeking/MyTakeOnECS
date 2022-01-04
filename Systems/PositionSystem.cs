using System.Threading;
using System.Threading.Channels;

namespace BonesOfTheFallen.Services
{
    public record PositionSystem : SystemBase, ISystem, IPositionSystem
    {
        internal bool IsPlayableSystem { get; } = false;

        public IComponentBase<PositionEnum> Component => InternalComponent;

        private Position InternalComponent = default!;
        private readonly ChannelReader<Position> Modifiers = default!;

        public PositionSystem(bool isPlayableSystem, ChannelReader<Position> modifiers)
        {
            IsPlayableSystem = isPlayableSystem;
            Modifiers = modifiers;
            InternalComponent = new();
        }

        public void ProcessModifier(Position item)
        {
            _ = Interlocked.Exchange(ref InternalComponent, item);
        }

        public override void Process(in float time)
        {
            while (Modifiers.TryRead(out var modifier))
            {
                ProcessModifier(modifier + InternalComponent);
            }
        }
    }
}
