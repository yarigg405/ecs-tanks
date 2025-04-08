using Assets.Code.Gameplay.Common.Time;
using Entitas;


namespace Assets.Code.Gameplay.Features.TargetCollection.Systems
{
    internal sealed class CollectTargetIntervalSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly ITimeService _time;

        internal CollectTargetIntervalSystem(GameContext game, ITimeService time)
        {
            _entities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.TargetsBuffer,
                GameMatcher.CollectTargetsInterval,
                GameMatcher.CollectTargetsTimer
            ));
            _time = time;
        }

        void IExecuteSystem.Execute()
        {
            foreach (var entity in _entities)
            {
                entity.ReplaceCollectTargetsTimer(entity.CollectTargetsTimer - _time.DeltaTime);
                if (entity.CollectTargetsTimer <= 0)
                {
                    entity.isReadyToCollectTargets = true;
                    entity.ReplaceCollectTargetsTimer(entity.CollectTargetsInterval);
                }
            }
        }
    }
}