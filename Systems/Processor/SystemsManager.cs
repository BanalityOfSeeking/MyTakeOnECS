using System;

namespace BonesOfTheFallen.Services
{
    public record SystemsManager
    {
        public SystemBase[] GameSystems = Array.Empty<SystemBase>();
        public void Register(SystemBase g)
        {
            for(int i = 0; i < GameSystems.Length; i++)
            {
                if(GameSystems[i].Equals(g))
                {
                    return;
                }
            }
            Array.Resize(ref GameSystems, GameSystems.Length + 1);
            ref var system = ref GameSystems[^1];
            system = g;
        }
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
                    if (!init.IsInitialized)
                    {
                        init.Init(deltaTime);
                        init.IsInitialized = true;
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
