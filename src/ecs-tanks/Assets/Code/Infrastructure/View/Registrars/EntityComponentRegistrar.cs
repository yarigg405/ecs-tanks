﻿using Assets.Code.Gameplay.Common.Registrars;


namespace Assets.Code.Infrastructure.View.Registrars
{
    public abstract class EntityComponentRegistrar : EntityDependant, IEntityComponentRegistrar
    {
        public abstract void RegisterComponents();
        public abstract void UnRegisterComponents();
    }
}
