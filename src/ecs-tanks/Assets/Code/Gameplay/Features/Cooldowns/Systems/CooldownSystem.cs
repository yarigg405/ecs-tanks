using Assets.Code.Gameplay.Common.Time;
using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Gameplay.Features.Cooldowns.Systems
{
    internal sealed class CooldownSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _cooldownables;
        private readonly ITimeService _time;
        private List<GameEntity> _buffer = new(32);

        internal CooldownSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _cooldownables = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Cooldown,
                GameMatcher.CooldownLeft
                ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var cooldownable in _cooldownables.GetEntities(_buffer))
            {
                cooldownable.ReplaceCooldownLeft(cooldownable.CooldownLeft - _time.DeltaTime);

                if (cooldownable.CooldownLeft <= 0)
                {
                    cooldownable.isCooldownUp = true;
                    cooldownable.RemoveCooldownLeft();
                }
            }
        }
    }
}