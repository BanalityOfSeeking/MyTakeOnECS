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

        // Entity manager
        public readonly IMemorySparseSet EntitySet;
        // componenent manager
        private IComponentColumn ConstantColumn;
        // func to run on this []
        private readonly ColumnAction Funcs;

        // adds entity to set and components to column.
        public ref EntitySafe AddEntity()
        {
            Span<int> entityRequest = new int[1];
            var result = EntitySet.ProvideEntities(ref entityRequest);
            ConstantColumn = ConstantColumn.AddComponentToEntity(ref result![0], out bool success);
            if (success)
            {
                return ref result[0];
            }
            return ref result[0];
        }

        public void Work()
        {
            Funcs.Invoke(ref ConstantColumn);
        }

        // queue the function you provide in WorldInputArgs, try to wait for it to complete.
        public void QueueWorkThread()
        {
            // wait Event
            AutoResetEvent ev = new(false);
            // wait handle
            RegisteredWaitHandle registeredWait = default!;
            // build wait
            registeredWait = ThreadPool.RegisterWaitForSingleObject(ev, new WaitOrTimerCallback(WaitProc), registeredWait, 1100, true);
           // enqueue thread
            ThreadPool.UnsafeQueueUserWorkItem(new WorkItem(ref ConstantColumn, Funcs, ev), true);
            // wait for event to be signaled.
            if(ev.WaitOne(1000))
            {
                return;
            }
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

        public WorkItem(ref IComponentColumn items,in ColumnAction funcs, in AutoResetEvent resetEvent)
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
            // functions ran signal event.
            ResetEvent.Set();
        }
    }
}
