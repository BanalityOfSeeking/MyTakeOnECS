using System;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Systems Manager stores registered systems and executes them
    /// </summary>
    public record SystemsManager
    {
        /// <summary>
        /// Store least derived type.
        /// </summary>
        public SystemBase[] GameSystems = Array.Empty<SystemBase>();

        /// <summary>
        /// Method registers systems with the manager.
        /// prevents duplicate system registration.
        /// </summary>
        /// <param name="system"></param>
        public void Register(SystemBase system)
        {
            for(int i = 0; i < GameSystems.Length; i++)
            {
                if(GameSystems[i].Equals(system))
                {
                    return;
                }
            }
            Array.Resize(ref GameSystems, GameSystems.Length + 1);
            GameSystems[^1] = system;
        }

        /// <summary>
        /// Initiates call chain for systems to process added entities
        /// </summary>
        /// <param name="deltaTime"></param>
        public void Process(float deltaTime)
        {
            if (GameSystems.Length == 0)
            {
                return;
            }
            for (int i = 0; i < GameSystems.Length; i++)
            {
                if (GameSystems[i] is InitSystem init)
                {
                    if (init.UninitializedEntity != -1)
                    {
                        init.Init(deltaTime);
                        init.UninitializedEntity = -1;
                    }
                    else
                    {
                        init.Process(deltaTime);
                    }
                }
                else
                { 
                    GameSystems[i].Process(deltaTime);
                } 
            }
        }
        /// <summary>
        /// Matches Entity Mask to Systems and adds entity to that system.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="mask"></param>
        public void TrackNewEntity(int entity, int mask)
        {
            foreach (var g in GameSystems)
            {
                if ((g.GetTypeMask() & mask) == g.GetTypeMask())
                {
                    g.TrackNewEntity(entity);
                }
            }
        }
    }
}
