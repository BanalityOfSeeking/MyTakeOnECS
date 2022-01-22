using System.Threading.Tasks;

namespace BonesOfTheFallen.Services
{
    public interface ISystemSafe
    {
        ref EntitySafe AddEntity();
        void QueueWorkThread();
        public void Work();
    }
}