using System;


namespace Assets.Code.Gameplay.Features.Shooting.Configs
{
    [Serializable]
    public sealed class ProjectileSetup
    {
        public float Speed;
        public int Pierce = 1;
        public float ContactRadius = 1;
        public float Damage = 1f;
    }
}
