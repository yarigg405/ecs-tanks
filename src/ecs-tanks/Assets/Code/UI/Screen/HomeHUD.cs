using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.States.GameStates;
using Assets.Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using Yrr.UI;


namespace Assets.Code.UI.Screen
{
    class HomeHUD : UIScreen
    {
        [SerializeField] private Button _startGameButton;

        [Inject] private readonly IStateMachine _stateMachine;

        private void Awake()
        {
            _startGameButton.onClick.AddListener(ClickStartGame);
        }

        private void OnDestroy()
        {
            _startGameButton.onClick.RemoveListener(ClickStartGame);
        }

        public void ClickStartGame()
        {
            _stateMachine.Enter<LoadBattleState, string>(SceneNames.GameScene);
        }
    }
}
