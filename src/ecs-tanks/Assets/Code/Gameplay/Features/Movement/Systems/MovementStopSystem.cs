using Entitas;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Movement.Systems
{
    internal sealed class MovementStopSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        internal MovementStopSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Direction,
                GameMatcher.Rigidbody)
                .NoneOf(GameMatcher.Moving));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var entity in _entities)
            {
                entity.Rigidbody.linearVelocity = Vector3.zero;
            }
        }
    }
}