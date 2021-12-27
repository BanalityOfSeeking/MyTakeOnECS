// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace BonesOfTheFallen.Services
{
    public record WorldManager
    {
        private readonly SystemsManager Systems;
        public WorldManager(SystemsManager systems)
        {
            Systems = systems;
        }

        int _nextID = 1;
        public int CreateEntity()
        {
            var ret = _nextID;
            _nextID += 1;
            return ret;
        }

        public void AddComponent<T>(int entity, T? component = default) where T : unmanaged, IComponentBase
        {
            if (component != null)
            {
                StoragePool.Store(entity, component.Value);
            }
            else
            {
                StoragePool.Store(entity, new T());
            }
            var mask = BuildEntityMask<T>(entity);
            Systems.TrackNewEntity(entity, mask);
        }
        public static int BuildEntityMask<T>(int entity) where T : unmanaged, IComponentBase
        {
            if(EntityComponentMasks.ContainsKey(entity))
            {
                EntityComponentMasks[entity] |= GetMask<T>();
            }
            else
            {
                EntityComponentMasks[entity] = GetMask<T>();
            }
            return EntityComponentMasks[entity];
        }
        public static int AddMask<T>() where T : unmanaged, IComponentBase
        {
            if (!TypeMasks.Contains(typeof(T)))
            {
                TypeMasks.Add(typeof(T));
            }
            return GetMask<T>();
        }

        public static int GetMask<T>() where T : unmanaged, IComponentBase
        {
            if (TypeMasks.Contains(typeof(T)))
            {
                return TypeMasks.IndexOf(typeof(T));
            }
            return 0;
        }

        private static readonly List<Type> TypeMasks = new() { typeof(int) };
        private static readonly Dictionary<int, int> EntityComponentMasks = new();
    }
}
