// See https://aka.ms/new-console-template for more information

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Base of all Systems.
    /// </summary>
    public abstract record SystemBase : ISystem
    {
        protected SystemBase() : base()
        {
        }

        public abstract void Process(in float time);

    }
}