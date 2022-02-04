using BonesOfTheFallen.Services.Components.Interfaces;

namespace BonesOfTheFallen.Services
{
    public struct SystemProcessor
    {
        public SystemProcessor(ComponentRefAction<IComponentBase>[] func)
        {

            Funcs = func??throw new System.ArgumentNullException(nameof(func));
        }

        private readonly ComponentRefAction<IComponentBase>[] Funcs;

    }
}
