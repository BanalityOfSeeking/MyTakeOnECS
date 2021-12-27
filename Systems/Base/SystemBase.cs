// See https://aka.ms/new-console-template for more information

using System;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Base of all Systems.
    /// int TypeMask
    /// int[] Entities that stores entites that match this system
    /// </summary>
    public abstract record SystemBase
    {
        protected int TypeMask;
        protected int[] Entities = Array.Empty<int>();

        // return on duplicate entry
        /// <summary>
        /// Method to perform entity tracking.
        /// Virtual Method.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void TrackNewEntity(int entity)
        {
            if (Array.IndexOf(Entities, entity) == -1)
            {
                Array.Resize(ref Entities, Entities.Length + 1);
                Entities[^1] = entity;
            }
        }

        /// <summary>
        /// Process Entities by calling the abstract function:
        /// ProcessEntity(float, int) 
        /// </summary>
        /// <param name="deltaTime"></param>
        public virtual void Process(float deltaTime)
        {
            foreach (var entity in Entities)
            {
                ProcessEntity(deltaTime, entity);
            }
        }
        /// <summary>
        /// Retrieves Type Mask
        /// </summary>
        /// <returns>System Type Mask</returns>
        public int GetTypeMask()
        {
            return TypeMask;
        }
        /// <summary>
        /// Abstract method that must be implemented publicly in derived records
        /// </summary>
        /// <param name="deltaTime"></param>
        /// <param name="entity"></param>
        public abstract void ProcessEntity(float deltaTime, int entity);
    }

}