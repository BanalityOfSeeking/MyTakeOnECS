// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Manages the creation of entities and the addition of components
    /// </summary>
    public record WorldManager
    {
        private readonly SystemsManager Systems;
        public WorldManager(SystemsManager systems)
        {
            Systems = systems;
        }

        int _nextID = 1;

        /// <summary>
        /// Creates entity
        /// </summary>
        /// <returns>int</returns>
        public int CreateEntity()
        {
            var ret = _nextID;
            _nextID += 1;
            return ret;
        }
        /// <summary>
        /// Adds Components where the component meets the unmanaged requirement 
        /// and implements IComponentBase
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="component"></param>
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
            // build entity mask, component by component
            var mask = BuildEntityMask<T>(entity);
            // Checks if entity mask matches systems
            Systems.TrackNewEntity(entity, mask);
        }
        /// <summary>
        /// Builds Entity masks, 
        /// by adding new mask to old 
        /// or creates a new mask for the entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Stores Masks and/or retrieves stored index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>int</returns>
        public static int AddMask<T>() where T : unmanaged, IComponentBase
        {
            if (!TypeMasks.Contains(typeof(T)))
            {
                TypeMasks.Add(typeof(T));
            }
            return GetMask<T>();
        }
        /// <summary>
        /// retrieves index of Type added to list. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>int</returns>
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
