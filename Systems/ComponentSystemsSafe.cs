using Microsoft.Toolkit.HighPerformance.Helpers;

namespace BonesOfTheFallen.Services
{
    public static class ComponentSystemsSafe<T> where T : struct, IRefAction<T>
    {

        private static readonly SystemForSafe<T> SystemSafe = new();
        public static SystemForSafe<T> GetSystem() => SystemSafe;
    }
}
