using Assets.Code.Gameplay.Input.Network;
using Entitas;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Player.Systems
{
    internal sealed class SetPlayerDirectionByInputSystem : IExecuteSystem
    {
        private readonly NetworkInputService _inputService;
        private readonly IGroup<GameEntity> _players;

        internal SetPlayerDirectionByInputSystem(GameContext game, NetworkInputService inputService)
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
                var hasInput = input.HorizontalInput != 0 || input.VerticalInput != 0;
                player.isMoving = hasInput;

                if (hasInput)
                {
                    var direction = new Vector2(input.HorizontalInput, input.VerticalInput).normalized;

                    if (direction.x != 0) direction.y = 0;
                    else if (direction.y != 0) direction.x = 0;

                    player.ReplaceDirection(direction);
                }
            }
        }
    }
}