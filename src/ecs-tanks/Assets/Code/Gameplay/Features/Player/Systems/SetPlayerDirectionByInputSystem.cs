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
                    player.isMoving = input.hasAxisInput;

                    if (input.hasAxisInput)
                    {
                        player.ReplaceDirection(input.AxisInput.normalized);
                    }
                }
        }
    }
}