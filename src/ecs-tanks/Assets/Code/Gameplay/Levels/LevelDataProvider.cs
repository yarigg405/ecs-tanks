using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Code.Gameplay.Levels
{
    public class LevelDataProvider
    {
        public IEnumerable<SpawnPositionInfo> SpawnPositions { get; private set; }

        public void SetAvailableSpawnPositions(IEnumerable<SpawnPositionInfo> positions)
        {
            SpawnPositions = positions;
        }
    }

    [Serializable]
    public struct SpawnPositionInfo
    {
        public Transform SpawnPoint;
        public bool IsLocked;
    }
}
