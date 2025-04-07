using Assets.Code.Gameplay.Input.Network;
using Assets.Code.Gameplay.Input.Service;
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
                var input = _inputService.GetInput(player.PlayerRef);
                if (input.Buttons.IsSet<PlayerControlButtons>(PlayerControlButtons.Fire))
                {
                    player.isShotRequested = true;
                }
                else
                {
                    player.isShotRequested = false;
                }
            }
        }
    }
}