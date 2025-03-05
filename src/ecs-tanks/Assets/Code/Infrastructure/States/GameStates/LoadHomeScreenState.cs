using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.States.StatesInfrastructure;
using System;


namespace Assets.Code.Infrastructure.States.GameStates
{
    public class LoadHomeScreenState : SimpleState
    {
        private readonly IStateMachine _stateMachine; 
        private readonly ISceneLoader _sceneLoader;

        public LoadHomeScreenState(IStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public override void Enter()
        {
            _sceneLoader.LoadScene(SceneNames.HomeScreenScene, EnterHomeScreenScene);
        }

        private void EnterHomeScreenScene()
        {
            _stateMachine.Enter<HomeScreenState>();
        }
    }
}
