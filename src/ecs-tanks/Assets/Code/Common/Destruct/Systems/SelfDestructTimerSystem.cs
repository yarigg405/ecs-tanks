using Assets.Code.Gameplay.Common.Time;
using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Common.Destruct.Systems
{
    internal sealed class SelfDestructTimerSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(16);
        private readonly ITimeService _timeService;

        internal SelfDestructTimerSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            _entities = game.GetGroup(GameMatcher.SelfDestructTimer);
        }

        void IExecuteSystem.Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                if (entity.SelfDestructTimer > 0)
                {
                    entity.ReplaceSelfDestructTimer(entity.SelfDestructTimer - _timeService.DeltaTime);
                }

                else
                {
                    entity.RemoveSelfDestructTimer();
                    entity.isDestructed = true;
                }
            }
        }
    }
}