using Assets.Code.Gameplay.Features.Player.Factory;
using Assets.Code.Gameplay.Levels;
using Fusion;
using System.Linq;
using Yrr.Utils;


namespace Assets.Code.Networking
{
    public class NetworkPlayerSpawner
    {
        private readonly PlayerFactory _playerFactory;
        private readonly LevelDataProvider _levelDataProvider;
        private readonly NetworkRunner _runner;

        public NetworkPlayerSpawner(
            LevelDataProvider levelDataProvider,
            PlayerFactory playerFactory,
            NetworkRunner networkRunner)
        {
            _levelDataProvider = levelDataProvider;
            _playerFactory = playerFactory;
            _runner = networkRunner;
        }

        internal void SpawnPlayer(PlayerRef player)
        {
            if (!_runner.IsServer) return;

            var spawnPosition = _levelDataProvider.SpawnPositions
                .Where(x => !x.IsLocked).GetRandomItem().SpawnPoint.position;
            _playerFactory.CreatePlayer(spawnPosition, player);
        }

        internal void DespawnPlayer(PlayerRef player)
        {

            if (!_runner.IsServer) return;

            NetworkObject playerObject = _runner.GetPlayerObject(player);
            if (playerObject != null)
            {
                _runner.Despawn(playerObject);
            }
        }
    }
}