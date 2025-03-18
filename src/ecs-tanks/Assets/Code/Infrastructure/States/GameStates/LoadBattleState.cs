using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.States.StatesInfrastructure;
using Fusion;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Assets.Code.Infrastructure.States.GameStates
{
    public sealed class LoadBattleState : SimplePayloadState<string>
    {
        private readonly IStateMachine _stateMachine;
        private readonly NetworkSceneManagerDefault _sceneManager;
        private readonly NetworkRunner _runner;

        private string _sessionName = "SampleSession";

        public LoadBattleState(
            IStateMachine stateMachine,
            NetworkSceneManagerDefault sceneManager,
            NetworkRunner runner)
        {
            _stateMachine = stateMachine;
            _sceneManager = sceneManager;
            _runner = runner;
        }


        public override void Enter(string sceneName)
        {
            StartupSimulation(sceneName);
        }

        private async void StartupSimulation(string sceneName)
        {
            _runner.ProvideInput = true;
            var args = new StartGameArgs
            {
                GameMode = GameMode.AutoHostOrClient,
                SceneManager = _sceneManager,
                SessionName = _sessionName,
            };
            await _runner.StartGame(args);

            SceneManager.sceneLoaded += OnSceneLoaded;
            if (_runner.IsServer)
            {
                await _runner.LoadScene(GetScene(sceneName), LoadSceneMode.Single);
            }
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            _stateMachine.Enter<BattleEnterState>();
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private SceneRef GetScene(string sceneName)
        {
            var index = SceneUtility.GetBuildIndexByScenePath(sceneName);
            return SceneRef.FromIndex(index);
        }
    }
}
