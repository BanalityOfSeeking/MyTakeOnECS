// See https://aka.ms/new-console-template for more information

using System;

namespace BonesOfTheFallen.Services
{
    public abstract record SystemsView
    {
        private ISystem<AttributeEnum> AttributeSystem { get; set; } = default!;
        private ISystem<PositionEnum> PositionSystem { get; set; } = default!;
        private ISystem<VelocityEnum> VelocitySystem { get; set;} = default!;

        public void SystemBaseViewAdd<T>(SystemBase<T> @base) where T : struct, Enum
        {
            switch (@base)
            {
                case SystemBase<AttributeEnum>:
                    AttributeSystem = (ISystem<AttributeEnum>)@base;
                    break;
                case SystemBase<PositionEnum>:
                    PositionSystem = (ISystem<PositionEnum>)@base;
                    break;
                case SystemBase<VelocityEnum>:
                    VelocitySystem = (ISystem<VelocityEnum>)@base;
                    break;
                default:
                    break;
            }
        }
        public IComponentBase<VelocityEnum> VelocityComponent { get => VelocitySystem.Component ?? default!; }
        public IComponentBase<PositionEnum> PositionComponent { get => PositionSystem.Component ?? default!; }
        public IComponentBase<AttributeEnum> AttributeComponent { get => AttributeSystem.Component ?? default!; }
    }
}