// See https://aka.ms/new-console-template for more information

using System;

namespace BonesOfTheFallen.Services
{
    public abstract record SystemBase
    {
        protected int TypeMask;
        protected int[] Entities = Array.Empty<int>();
        
        // return on duplicate entry
       
        public virtual void TrackNewEntity(int entity)
        {
            for (var ent = 0; ent < Entities.Length;ent++)
            {
                if (Entities[ent] == entity)
                {
                    return;
                }
                else if (Entities[ent] == 0)
                {
                    Entities[ent] = entity;

                    return;
                }
            }
            Array.Resize(ref Entities, Entities.Length + 1);
            Entities[^1] = entity;
        }

        public virtual void Process(float deltaTime)
        {
            foreach (var entity in Entities)
            {
                ProcessEntity(deltaTime, entity);
            }
        }

        public int GetTypeMask()
        {
            return TypeMask;
        }

        public abstract void ProcessEntity(float deltaTime, int entity);
    }

}