using Entitas;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Movement.Systems
{
    internal sealed class TurnAlongDirectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        internal TurnAlongDirectionSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Transform,
                GameMatcher.Direction,
                GameMatcher.Moving
            ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var entity in _movers)
            {
                if (entity.isMoving)
                {
                    var direction = entity.Direction;
                    var angle = Vector2.SignedAngle(Vector2.up, direction);

                    entity.Transform.rotation = Quaternion.Euler(0, -angle - 90f, 0f);
                }
            }
        }
    }
}