using Assets.Code.Gameplay.Input.Network;
using Entitas;


namespace Assets.Code.Gameplay.Features.Player.Systems
{
    internal sealed class SetPlayerShootingByInputSystem : IExecuteSystem
    {
        private readonly NetworkInputService _inputService;
        private readonly IGroup<GameEntity> _players;

        internal SetPlayerShootingByInputSystem(GameContext game, NetworkInputService inputService)
        {
            _players = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Player,
                GameMatcher.PlayerRef
            ));
            _inputService = inputService;
        }

        void IExecuteSystem.Execute()
        {
            foreach (var player in _players)
            {

            }
        }
    }
}