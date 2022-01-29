namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// I want no allocation exution
    /// </summary>
    public struct SystemProcessor
    {
        public SystemProcessor(ComponentRefAction<IComponentBase>[] func)
        {

            Funcs = func??throw new System.ArgumentNullException(nameof(func));
        }

        private readonly ComponentRefAction<IComponentBase>[] Funcs;

    }
}
