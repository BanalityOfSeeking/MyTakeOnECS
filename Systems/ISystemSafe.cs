using System.Linq;
using System.Threading.Tasks;

namespace BonesOfTheFallen.Services
{
    public interface ISystemSafe<T>
    {
        IOrderedAsyncEnumerable<T> DoWork(float time);
    }
}