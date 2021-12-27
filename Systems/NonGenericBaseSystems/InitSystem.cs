using System;

namespace BonesOfTheFallen.Services
{
    public abstract record InitSystem : SystemBase
    {
        protected InitSystem()
        {
        }

        protected InitSystem(SystemBase original) : base(original)
        {
        }

        public int UninitializedEntity;
        public abstract void Init(float deltaTime);
        public override void TrackNewEntity(int entity)
        {
            if (Array.IndexOf(Entities, entity) == -1)
            {
                base.TrackNewEntity(entity);
                UninitializedEntity = entity;
            }
        }
    }
}