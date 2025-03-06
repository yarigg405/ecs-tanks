using UnityEngine;
using VContainer;


namespace Assets.Code.Gameplay.Levels
{
    public sealed class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private SpawnPositionInfo[] _spawnPositions;
        private LevelDataProvider _levelData;

        [Inject]
        private void Construct(LevelDataProvider levelData)
        {
            _levelData = levelData;
            _levelData.SetAvailableSpawnPositions(_spawnPositions);
        }
    }
}
