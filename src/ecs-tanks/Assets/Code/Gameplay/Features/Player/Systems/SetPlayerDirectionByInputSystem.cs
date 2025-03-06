using Entitas;


namespace Assets.Code.Gameplay.Features.Player.Systems
{
    internal sealed class SetPlayerDirectionByInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _players;
        private readonly IGroup<GameEntity> _inputs;

        internal SetPlayerDirectionByInputSystem(GameContext game)
        {
            _players = game.GetGroup(GameMatcher.Player);
            _inputs = game.GetGroup(GameMatcher.Input);
        }

        void IExecuteSystem.Execute()
        {
            foreach (var input in _inputs)
                foreach (var player in _players)
                {
                    player.isMoving = input.isInputEmitted;

                    if (input.hasAxisInput)
                    {
                        var direction = input.AxisInput.normalized;

                        if (direction.x != 0) direction.y = 0;
                        else if (direction.y != 0) direction.x = 0;

                        player.ReplaceDirection(direction);
                    }
                }
        }
    }
}