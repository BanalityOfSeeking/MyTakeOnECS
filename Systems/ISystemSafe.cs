using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BonesOfTheFallen.Services
{
    public interface ISystemSafe
    {
        ref EntitySafe AddEntity();
        Task QueueSystemWork(YieldAwaitable yieldAwaitable);
    }
}