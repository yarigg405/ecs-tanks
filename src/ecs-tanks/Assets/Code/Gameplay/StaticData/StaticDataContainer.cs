using Assets.Code.Gameplay.Features.Shooting.Configs;
using UnityEngine;


namespace Assets.Code.Gameplay.StaticData
{
    [CreateAssetMenu(fileName = "StaticDataContainer", menuName = "ScriptableObjects/StaticDataContainer", order = 51)]
    public sealed class StaticDataContainer : ScriptableObject
    {
        [field: SerializeField] public ShootingConfig ShootingConfig { get; private set; }

        public ShootingLevel GetShootingLevel(int level)
        {
            if (level > ShootingConfig.Levels.Length)
                level = ShootingConfig.Levels.Length;

            return ShootingConfig.Levels[level - 1];
        }
    }
}
