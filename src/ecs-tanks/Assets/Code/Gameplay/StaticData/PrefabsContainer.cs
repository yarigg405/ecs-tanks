using Assets.Code.Infrastructure.View;
using UnityEngine;


namespace Assets.Code.Gameplay.StaticData
{
    [CreateAssetMenu(fileName = "PrefabsContainer", menuName = "ScriptableObjects/PrefabsContainer", order = 51)]
    public sealed class PrefabsContainer : ScriptableObject
    {
        [field: SerializeField] public EntityBehaviour PlayerPrefab { get; private set; }
    }
}
