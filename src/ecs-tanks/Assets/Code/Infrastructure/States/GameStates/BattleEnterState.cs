using Assets.Code.Gameplay.Features.Player.Factory;
using Assets.Code.Gameplay.Levels;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.States.StatesInfrastructure;
using Fusion;
using System.Linq;
using Yrr.Utils;


namespace Assets.Code.Infrastructure.States.GameStates
{
    public sealed class BattleEnterState : SimpleState
    {
        private readonly IStateMachine _stateMachine;
        private readonly LevelDataProvider _levelDataProvider;
        private readonly PlayerFactory _playerFactory;
        private readonly NetworkRunner _networkRunner;

        public BattleEnterState(
            IStateMachine stateMachine,
            LevelDataProvider levelDataProvider,
            PlayerFactory playerFactory,
            NetworkRunner networkRunner)
        {
            _stateMachine = stateMachine;
            _levelDataProvider = levelDataProvider;
            _playerFactory = playerFactory;
            _networkRunner = networkRunner;
        }

        public override void Enter()
        {
           // SpawnPlayer();
            _stateMachine.Enter<BattleLoopState>();
        }

        private void SpawnPlayer()
        {
            if (!_networkRunner.IsServer) return;

            var spawnPosition = _levelDataProvider.SpawnPositions
                .Where(x => !x.IsLocked).GetRandomItem().SpawnPoint.position;
            _playerFactory.CreatePlayer(spawnPosition,_networkRunner.LocalPlayer);
        }
    }
}
