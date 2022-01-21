using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

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


        public async Task QueueSystemWork(YieldAwaitable yieldAwaitable)
        {
            ThreadPool.UnsafeQueueUserWorkItem(new WorkItem(ConstantColumn, Funcs), true);
            await yieldAwaitable;
        }
    }
    public struct WorkItem : IThreadPoolWorkItem
    {
        private readonly ColumnAction Funcs = default!;
        private IComponentColumn Column = default!;

        public WorkItem(in IComponentColumn items,in ColumnAction funcs)
        {
            Column = items;
            Funcs = funcs;
        }
        public void Execute()
        {
            for (int i = 0; i < Column.NumberOfActiveComponents; i++)
            {
                Funcs?.Invoke(ref Column);
            }
        }
    }
}
