using Assets.Code.Gameplay.Features.Player.Factory;
using Assets.Code.Gameplay.Levels;
using Fusion;
using System.Linq;
using VContainer;
using Yrr.Utils;


namespace Game
{
    public sealed class NetworkPlayerSpawner : SimulationBehaviour, IPlayerJoined, IPlayerLeft
    {
        [Inject] private readonly PlayerFactory _playerFactory;
        [Inject] private readonly LevelDataProvider _levelDataProvider;

        void IPlayerJoined.PlayerJoined(PlayerRef player)
        {
            //var spawnPosition = _levelDataProvider.SpawnPositions
            //    .Where(x => !x.IsLocked).GetRandomItem().SpawnPoint.position;
            //_playerFactory.CreatePlayer(spawnPosition, player, Runner.LocalPlayer);
        }

        void IPlayerLeft.PlayerLeft(PlayerRef player)
        {
            if (!Runner.IsServer) return;

            NetworkObject playerObject = Runner.GetPlayerObject(player);
            if (playerObject != null)
            {
                Runner.Despawn(playerObject);
            }
        }
    }
}