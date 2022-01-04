// See https://aka.ms/new-console-template for more information

using System;

namespace BonesOfTheFallen.Services
{
    public abstract record SystemsView
    {
        private ISystem<AttributeEnum, int> AttributeSystem { get; set; } = default!;
        private ISystem<PositionEnum, double> PositionSystem { get; set; } = default!;
        private ISystem<VelocityEnum, double> VelocitySystem { get; set;} = default!;

        public void SystemBaseViewAdd<T, U>(SystemBase<T, U> @base) where T : struct, Enum
        {
            switch (@base)
            {
                case SystemBase<AttributeEnum, int>:
                    AttributeSystem = (ISystem<AttributeEnum, int>)@base;
                    break;
                case SystemBase<PositionEnum, double>:
                    PositionSystem = (ISystem<PositionEnum, double>)@base;
                    break;
                case SystemBase<VelocityEnum, double>:
                    VelocitySystem = (ISystem<VelocityEnum, double>)@base;
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