using Assets.Code.Gameplay;
using Assets.Code.Infrastructure.States.StatesInfrastructure;


namespace Assets.Code.Infrastructure.States.GameStates
{
    public sealed class BattleLoopState : SimpleState, IUpdatableState
    {
        private readonly GameContext _game;
        private readonly GameFeature _gameFeature;
        private bool _isExit;

        public BattleLoopState(GameContext game, GameFeature gameFeature)
        {
           
            _game = game;
            _gameFeature = gameFeature;
        }



        public override void Enter()
        {
            _gameFeature.Initialize();
        }

        void IUpdatableState.Update()
        {
            if (_isExit) return;

            _gameFeature.Execute();
            _gameFeature.Cleanup();
        }

        public override void BeginExit()
        {
            _isExit = true;
        }

        public override void EndExit()
        {
            _gameFeature.DeactivateReactiveSystems();
            _gameFeature.ClearReactiveSystems();

            DestructEntities();

            _gameFeature.Cleanup();
            _gameFeature.TearDown();
        }

        private void DestructEntities()
        {
            //foreach (var entity in _game.GetEntities())
            //    entity.isDestructed = true;
        }
    }
}
