using UnityEngine;
using VContainer;


namespace Assets.Code.Gameplay.Levels
{
    public sealed class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private SpawnPositionInfo[] _spawnPositions;
        [Inject] private readonly LevelDataProvider _levelData;

        private  void Start()
        {
            _levelData.SetAvailableSpawnPositions(_spawnPositions);
        }
    }
}
