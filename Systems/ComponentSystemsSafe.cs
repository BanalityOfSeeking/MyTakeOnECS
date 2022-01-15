using Microsoft.Toolkit.HighPerformance.Helpers;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Access to the system as access to cache is already global from Safe side
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class ComponentSystemsSafe<T> where T : struct, IRefAction<T>
    {

        private static readonly SystemForSafe<T> SystemSafe = new();
        public static SystemForSafe<T> GetSystem() => SystemSafe;
    }
}
