using Entitas;


namespace Assets.Code.Gameplay.Features.DamageApplication.Systems
{
    internal sealed class ApplyDamageOnTargetsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _damageDealers;
        private readonly GameContext _game;

        internal ApplyDamageOnTargetsSystem(GameContext game)
        {
            _game = game;
            _damageDealers = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Damage,
                GameMatcher.TargetsBuffer,
                GameMatcher.TargetLimit
            ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var damageDealer in _damageDealers)
                foreach (var targetId in damageDealer.TargetsBuffer)
                {
                    var target = _game.GetEntityWithId(targetId);
                    if (target.hasCurrentHP)
                    {
                        target.ReplaceCurrentHP(target.CurrentHP - damageDealer.Damage);
                        damageDealer.ReplaceTargetLimit(damageDealer.TargetLimit - 1);
                        if (damageDealer.TargetLimit <= 0)
                        {
                            damageDealer.isProcessed = true;
                        }                            
                    }
                }
        }
    }
}