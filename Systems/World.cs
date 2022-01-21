using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
namespace BonesOfTheFallen.Services
{
    [Flags]
    public enum WorldCommandId
    {
        AddSystemEntity,
        AddSystem,
    }
    [Flags]
    public enum WorldOutputId
    {
        Entity,
        Handlers,
        View
    }


    public record struct WorldInputArgs
    {
        public int[] EntiesRequest = default!;
        public WorldCommandId Command = default!;
        public Type? NewSystemType = default!;
        public ColumnAction Func = default!;
    }
    public struct WorldOutputArgs
    {
        public EntitySafe[]? Entities;
        public ISystemSafe SystemRegistered;
    }
    public static class World
    {

        public static ConcurrentQueue<WorldInputArgs> WorldIn { get; set; } = default!;
        public static ConcurrentQueue<WorldOutputArgs> WorldOut { get; set; } = default!;

        private static bool ThreadIsRunning = false;
        public static bool ThreadRunning()
        {
            if (ThreadIsRunning == false)
            {
                ThreadIsRunning = !ThreadIsRunning;
                return ThreadPool.QueueUserWorkItem((x) => ProcessWorldCommand(x));
            }
            return true;
        }
        private static readonly Type MotherColumn = typeof(ComponentColumn<>);
        private static MemorySparseSet MssFactory() => new(1024);
        public static void ProcessWorldCommand(object? input)
        {
            int systems = 0;
            List<Type[]> listArgs = new();
            List<Type?> listTypes = new();
            ISystemSafe[] BaseSystems = new ISystemSafe[100];
            int i = 0;
            while (i == 0)
            {
                if (WorldIn.TryDequeue(out WorldInputArgs commandArgs))
                {
                    var woah = new WorldOutputArgs();
                    switch (commandArgs.Command)
                    {
                        case WorldCommandId.AddSystem:
                            if (commandArgs.NewSystemType != null && !listTypes.Contains(commandArgs.NewSystemType))
                            {
                                listArgs.Add(new Type[] { commandArgs.NewSystemType });
                                var genColumn = MotherColumn.MakeGenericType(listArgs[^1]);
                                var genSystem = new SystemSafe((IComponentColumn?)Activator.CreateInstance(genColumn, new object[] { 1024 }), MssFactory(), commandArgs.Func);
                                if (BaseSystems[systems] is null)
                                {
                                    BaseSystems[systems] = genSystem;
                                    listTypes.Add(BaseSystems[systems]?.GetType());
                                    woah.SystemRegistered = BaseSystems[systems];
                                    break;
                                }
                            }
                            woah.SystemRegistered = default!;
                            break;
                        default:
                            i = 1;
                            break;
                    }
                    if (WorldOut != default!)
                    {
                        WorldOut.Enqueue(woah);
                    }
                }
                Thread.Sleep(200);
            }
        }
    }
}
