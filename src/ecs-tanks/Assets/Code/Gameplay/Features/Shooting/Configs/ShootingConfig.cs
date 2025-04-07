using UnityEngine;


namespace Assets.Code.Gameplay.Features.Shooting.Configs
{
    [CreateAssetMenu(fileName = "ShootingConfig", menuName = "ScriptableObjects/ShootingConfig", order = 51)]
    public sealed class ShootingConfig : ScriptableObject
    {
        public ShootingLevel[] Levels;
    }
}
