using Assets.Code.Infrastructure.View;
using System;


namespace Assets.Code.Gameplay.Features.Shooting.Configs
{
    [Serializable]
    public class ShootingLevel
    {
        public float Cooldown;
        public EntityBehaviour ViewPrefab;

        public ProjectileSetup ProjectileSetup;
    }
}
