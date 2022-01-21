using System;
using System.Threading;

namespace BonesOfTheFallen.Services
{
    public class SystemSafe : ISystemSafe
    {
        public SystemSafe(IComponentColumn? constantColumns, MemorySparseSet entitySet, ColumnAction funcs)
        {
            if (constantColumns == null)
            {
                throw new System.ArgumentNullException(nameof(constantColumns));
            }
            ConstantColumn = constantColumns;
            EntitySet=entitySet??throw new System.ArgumentNullException(nameof(entitySet));
            Funcs = funcs??throw new System.ArgumentNullException(nameof(funcs));
        }
        public readonly IMemorySparseSet EntitySet;
        private IComponentColumn ConstantColumn;
        private readonly ColumnAction Funcs;

        public ref EntitySafe AddEntity()
        {
            Span<int> entityRequest = new int[1];
            var result = EntitySet.ProvideEntities(ref entityRequest);
            ConstantColumn = ConstantColumn.AddComponent(ref result![0], out bool success);
            if (success)
            {
                return ref result[0];
            }
            return ref result[0];
        }


        public void QueueSystemWork()
        {
            AutoResetEvent ev = new(false);
            RegisteredWaitHandle registeredWait = default!;
            registeredWait = ThreadPool.UnsafeRegisterWaitForSingleObject(ev, new WaitOrTimerCallback(WaitProc), registeredWait, 10000, true);
            ThreadPool.UnsafeQueueUserWorkItem(new WorkItem(ConstantColumn, Funcs, ev), true);
            static void WaitProc(object? state, bool timedOut)
            {
                RegisteredWaitHandle resetEvent = (RegisteredWaitHandle)state!;
                if (!timedOut)
                {
                    if (resetEvent != null)
                    {
                        resetEvent.Unregister(null);
                    }
                }
            }
        }
    }
    public struct WorkItem : IThreadPoolWorkItem
    {
        private readonly ColumnAction Funcs = default!;
        private IComponentColumn Column = default!;
        private readonly AutoResetEvent ResetEvent = default!;

        public WorkItem(in IComponentColumn items,in ColumnAction funcs, in AutoResetEvent resetEvent)
        {
            Column = items;
            Funcs = funcs;
            ResetEvent = resetEvent;
        }
        public void Execute()
        {
            for (int i = 0; i < Column.NumberOfActiveComponents; i++)
            {
                Funcs?.Invoke(ref Column);
            }
            ResetEvent.Set();
        }
    }
}
