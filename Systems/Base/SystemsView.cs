// See https://aka.ms/new-console-template for more information


namespace BonesOfTheFallen.Services
{
    public record SystemsView
    {
        private IAttributesSystem AttributeSystem { get; set; } = default!;
        private IPositionSystem PosSystem { get; set; } = default!;

        public void SystemBaseViewAdd(SystemBase @base)
        {
            switch (@base)
            {
                case AttributesSystem:
                    AttributeSystem = (IAttributesSystem)@base;
                    break;
                case PositionSystem:
                    PosSystem = (IPositionSystem)@base;
                    break;
                default:
                    break;
            }
        }
        public Position PositionComponent => (Position)(PosSystem.Component ?? default!);
        public Attributes AttributeComponent => (Attributes)(AttributeSystem.Component ?? default!);
    }
}