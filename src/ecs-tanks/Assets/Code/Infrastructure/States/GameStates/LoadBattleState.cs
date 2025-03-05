using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.States.StatesInfrastructure;


namespace Assets.Code.Infrastructure.States.GameStates
{
    public sealed class LoadBattleState : SimplePayloadState<string>
    {        
        private readonly ISceneLoader _sceneLoader; 
        private readonly IStateMachine _stateMachine;

        public LoadBattleState(ISceneLoader sceneLoader, IStateMachine stateMachine)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
        }


        public override void Enter(string sceneName)
        {
            _sceneLoader.LoadScene(sceneName, EnterGameState);
        }

        private void EnterGameState()
        {
            _stateMachine.Enter<BattleEnterState>();
        }
    }
}
