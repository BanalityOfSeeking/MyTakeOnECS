namespace BonesOfTheFallen.Services
{
    public delegate ref T ComponentRefAction<T>(ref T component) where T : IComponentBase;
}