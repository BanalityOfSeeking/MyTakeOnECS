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

        public bool IsInitialized { get; internal set; }
        public abstract void Init(float deltaTime);
        public override void TrackNewEntity(int entity)
        {
            base.TrackNewEntity(entity);
            if(Entities.Length > 0)
            {
                IsInitialized = false;
            }
        }
    }
}