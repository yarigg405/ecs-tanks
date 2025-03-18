using Assets.Code.Common.Entity;
using Assets.Code.Common.Extensions;
using Assets.Code.Gameplay.Features.CharacterStats;
using Assets.Code.Gameplay.StaticData;
using Assets.Code.Infrastructure.Identifiers;
using Fusion;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Player.Factory
{
    public sealed class PlayerFactory
    {
        private readonly IdentifierService _identifier;
        private readonly PrefabsContainer _prefabsContainer;

        public PlayerFactory(IdentifierService identifier, PrefabsContainer prefabsContainer)
        {
            _identifier = identifier;
            _prefabsContainer = prefabsContainer;
        }

        public GameEntity CreatePlayer(Vector3 spawnPos, PlayerRef player)
        {
            var baseStats = InitStats.EmptyStatDictionary()
                .With(x => x[Stats.Speed] = 5f)
                .With(x => x[Stats.MaxHp] = 1f);

            return CreateEntity.Empty()
                .AddId(_identifier.Next())
                .AddDirection(Vector2.zero)
                .AddWorldPosition(spawnPos)
                .AddBaseStats(baseStats)
                .AddViewPrefab(_prefabsContainer.PlayerPrefab)
                .AddSpeed(baseStats[Stats.Speed])
                .AddCurrentHP(baseStats[Stats.MaxHp])
                .AddMaxHP(baseStats[Stats.MaxHp])
                .AddPlayerRef(player)
                .With(x => x.isPlayer = true)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isMovementAvailable = true)
                ;
        }
    }
}
