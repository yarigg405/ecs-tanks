using Assets.Code.Gameplay.Features.Player.Factory;
using Assets.Code.Gameplay.Levels;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.States.StatesInfrastructure;
using System.Linq;
using Yrr.Utils;


namespace Assets.Code.Infrastructure.States.GameStates
{
    public sealed class BattleEnterState : SimpleState
    {
        private readonly IStateMachine _stateMachine;
        private readonly LevelDataProvider _levelDataProvider;
        private readonly PlayerFactory _playerFactory;

        public BattleEnterState(
            IStateMachine stateMachine,
            LevelDataProvider levelDataProvider,
            PlayerFactory playerFactory)
        {
            _stateMachine = stateMachine;
            _levelDataProvider = levelDataProvider;
            _playerFactory = playerFactory;
        }

        public override void Enter()
        {
            PlacePlayer();
            _stateMachine.Enter<BattleLoopState>();
        }

        private void PlacePlayer()
        {
            var spawnPosition = _levelDataProvider.SpawnPositions
                .Where(x => !x.IsLocked).GetRandomItem().SpawnPoint.position;
            _playerFactory.CreatePlayer(spawnPosition);
        }
    }
}
